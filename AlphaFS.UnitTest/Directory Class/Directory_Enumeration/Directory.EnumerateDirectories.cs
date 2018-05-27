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
using System.Linq;
using System.Reflection;

namespace AlphaFS.UnitTest
{
   public partial class EnumerationTest
   {
      // Pattern: <class>_<function>_<scenario>_<expected result>


      [TestMethod]
      public void Directory_EnumerateDirectories_LocalAndNetwork_Success()
      {
         Directory_EnumerateDirectories(false);
         Directory_EnumerateDirectories(true);
      }


      private void Directory_EnumerateDirectories(bool isNetwork)
      {
         UnitTestConstants.PrintUnitTestHeader(isNetwork);

         using (var tempRoot = new TemporaryDirectory(isNetwork ? Alphaleonis.Win32.Filesystem.Path.LocalToUnc(UnitTestConstants.TempFolder) : UnitTestConstants.TempFolder, MethodBase.GetCurrentMethod().Name))
         {
            var folder = tempRoot.RandomDirectoryFullPath;
            Console.WriteLine("\nInput Directory Path: [{0}]\n", folder);

            UnitTestConstants.CreateDirectoriesAndFiles(folder, 10, false, true, true);


            var sysIOCollection = System.IO.Directory.EnumerateDirectories(folder, "*", System.IO.SearchOption.AllDirectories).ToArray();

            var alphaFSCollection = Alphaleonis.Win32.Filesystem.Directory.EnumerateDirectories(folder, "*", System.IO.SearchOption.AllDirectories).ToArray();


            Console.WriteLine("\tSystem.IO directories enumerated: {0:N0}", sysIOCollection.Length);
            Console.WriteLine("\tAlphaFS   directories enumerated: {0:N0}", alphaFSCollection.Length);


            CollectionAssert.AreEqual(sysIOCollection, alphaFSCollection);
         }

         Console.WriteLine();
      }
   }
}
