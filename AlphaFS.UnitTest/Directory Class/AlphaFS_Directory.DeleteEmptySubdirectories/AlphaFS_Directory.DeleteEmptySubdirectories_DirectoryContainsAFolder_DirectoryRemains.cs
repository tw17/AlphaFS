/*  Copyright (C) 2008-2018 Peter Palotas, Jeffrey Jangli, Alexandr Normuradov
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy 
 *  of this software and associated documentation files (the "Software"), to deal 
 *  in the Software without restriction, including without limitation the rights 
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
 *  copies of the Software, and to permit persons to whom the Software is 
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in 
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 *  THE SOFTWARE. 
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace AlphaFS.UnitTest
{
   public partial class AlphaFS_Directory_DeleteEmptySubdirectoriesTest
   {
      // Pattern: <class>_<function>_<scenario>_<expected result>


      [TestMethod]
      public void AlphaFS_Directory_DeleteEmptySubdirectories_DirectoryContainsAFolder_DirectoryRemains_LocalAndNetwork_Success()
      {
         Directory_DeleteEmptySubdirectories_DirectoryContainsAFolder_DirectoryRemains(false);
         Directory_DeleteEmptySubdirectories_DirectoryContainsAFolder_DirectoryRemains(true);
      }

      
      private void Directory_DeleteEmptySubdirectories_DirectoryContainsAFolder_DirectoryRemains(bool isNetwork)
      {
         UnitTestConstants.PrintUnitTestHeader(isNetwork);

         var tempPath = System.IO.Path.GetTempPath();
         if (isNetwork)
            tempPath = Alphaleonis.Win32.Filesystem.Path.LocalToUnc(tempPath);


         using (var rootDir = new TemporaryDirectory(tempPath, MethodBase.GetCurrentMethod().Name))
         {
            var folder = System.IO.Directory.CreateDirectory(System.IO.Path.Combine(rootDir.Directory.FullName, "Source Folder"));
            Console.WriteLine("\nInput Directory Path: [{0}]", folder.FullName);


            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(folder.FullName, "A Folder"));

            Alphaleonis.Win32.Filesystem.Directory.DeleteEmptySubdirectories(folder.FullName, true);


            folder.Refresh();

            var exists = folder.Exists;
            Console.WriteLine("\n\tFolder exists: [{0}]", exists);

            Assert.IsTrue(folder.Exists);
         }

         Console.WriteLine();
      }
   }
}
