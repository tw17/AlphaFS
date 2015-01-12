﻿/* Copyright (C) 2008-2015 Peter Palotas, Jeffrey Jangli, Alexandr Normuradov
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

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security;
using System.Text;

namespace Alphaleonis.Win32.Filesystem
{
   public static partial class File
   {
      #region AppendText

      /// <summary>
      ///   Creates a <see cref="StreamWriter"/> that appends NativeMethods.DefaultFileEncoding encoded text to an existing file, or to a new
      ///   file if the specified file does not exist.
      /// </summary>
      /// <param name="path">The path to the file to append to.</param>
      /// <returns>
      ///   A stream writer that appends NativeMethods.DefaultFileEncoding encoded text to the specified file or to a new file.
      /// </returns>
      [SecurityCritical]
      public static StreamWriter AppendText(string path)
      {
         return AppendTextInternal(null, path, NativeMethods.DefaultFileEncoding, PathFormat.RelativePath);
      }

      /// <summary>
      ///   Creates a <see cref="StreamWriter"/> that appends NativeMethods.DefaultFileEncoding encoded text to an existing file, or
      ///   to a new file if the specified file does not exist.
      /// </summary>
      /// <param name="path">The path to the file to append to.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      /// <returns>
      ///   A stream writer that appends NativeMethods.DefaultFileEncoding encoded text to the specified file or to a new file.
      /// </returns>
      [SecurityCritical]
      public static StreamWriter AppendText(string path, PathFormat pathFormat)
      {
         return AppendTextInternal(null, path, NativeMethods.DefaultFileEncoding, pathFormat);
      }

      /// <summary>
      ///   Creates a <see cref="StreamWriter"/> that appends NativeMethods.DefaultFileEncoding encoded text to an existing file, or
      ///   to a new file if the specified file does not exist.
      /// </summary>
      /// <param name="path">The path to the file to append to.</param>
      /// <param name="encoding">The character <see cref="Encoding"/> to use.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      /// <returns>
      ///   A stream writer that appends NativeMethods.DefaultFileEncoding encoded text to the specified file or to a new file.
      /// </returns>
      [SecurityCritical]
      public static StreamWriter AppendText(string path, Encoding encoding, PathFormat pathFormat)
      {
         return AppendTextInternal(null, path, encoding, pathFormat);
      }

      /// <summary>
      ///   Creates a <see cref="StreamWriter"/> that appends NativeMethods.DefaultFileEncoding encoded text to an existing file, or
      ///   to a new file if the specified file does not exist.
      /// </summary>
      /// <param name="path">The path to the file to append to.</param>
      /// <param name="encoding">The character <see cref="Encoding"/> to use.</param>
      /// <returns>
      ///   A stream writer that appends NativeMethods.DefaultFileEncoding encoded text to the specified file or to a new file.
      /// </returns>
      [SecurityCritical]
      public static StreamWriter AppendText(string path, Encoding encoding)
      {
         return AppendTextInternal(null, path, encoding, PathFormat.RelativePath);
      }

      #region Transactional

      /// <summary>
      ///   Creates a <see cref="StreamWriter"/> that appends NativeMethods.DefaultFileEncoding encoded text to an existing file, or
      ///   to a new file if the specified file does not exist.
      /// </summary>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">The path to the file to append to.</param>
      /// <returns>
      ///   A stream writer that appends NativeMethods.DefaultFileEncoding encoded text to the specified file or to a new file.
      /// </returns>
      [SecurityCritical]
      public static StreamWriter AppendText(KernelTransaction transaction, string path)
      {
         return AppendTextInternal(transaction, path, NativeMethods.DefaultFileEncoding, PathFormat.RelativePath);
      }

      /// <summary>
      ///   Creates a <see cref="StreamWriter"/> that appends NativeMethods.DefaultFileEncoding encoded text to an existing file, or
      ///   to a new file if the specified file does not exist.
      /// </summary>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">The path to the file to append to.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      /// <returns>
      ///   A stream writer that appends NativeMethods.DefaultFileEncoding encoded text to the specified file or to a new file.
      /// </returns>
      [SecurityCritical]
      public static StreamWriter AppendText(KernelTransaction transaction, string path, PathFormat pathFormat)
      {
         return AppendTextInternal(transaction, path, NativeMethods.DefaultFileEncoding, pathFormat);
      }

      /// <summary>
      ///   Creates a <see cref="StreamWriter"/> that appends NativeMethods.DefaultFileEncoding encoded text to an existing file, or
      ///   to a new file if the specified file does not exist.
      /// </summary>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">The path to the file to append to.</param>
      /// <param name="encoding">The character <see cref="Encoding"/> to use.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      /// <returns>
      ///   A stream writer that appends NativeMethods.DefaultFileEncoding encoded text to the specified file or to a new file.
      /// </returns>
      [SecurityCritical]
      public static StreamWriter AppendText(KernelTransaction transaction, string path, Encoding encoding, PathFormat pathFormat)
      {
         return AppendTextInternal(transaction, path, encoding, pathFormat);
      }

      /// <summary>
      ///   Creates a <see cref="StreamWriter"/> that appends NativeMethods.DefaultFileEncoding encoded text to an existing file, or
      ///   to a new file if the specified file does not exist.
      /// </summary>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">The path to the file to append to.</param>
      /// <param name="encoding">The character <see cref="Encoding"/> to use.</param>
      /// <returns>
      ///   A stream writer that appends NativeMethods.DefaultFileEncoding encoded text to the specified file or to a new file.
      /// </returns>
      [SecurityCritical]
      public static StreamWriter AppendText(KernelTransaction transaction, string path, Encoding encoding)
      {
         return AppendTextInternal(transaction, path, encoding, PathFormat.RelativePath);
      }

      #endregion // Transacted

      #endregion // AppendText

      #region Internal Methods

      /// <summary>
      ///   Unified method AppendTextInternal() to create a <see cref="StreamWriter"/> that appends NativeMethods.DefaultFileEncoding
      ///   encoded text to an existing file, or to a new file if the specified file does not exist.
      /// </summary>
      /// <exception cref="IOException">Thrown when an IO failure occurred.</exception>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">The path to the file to append to.</param>
      /// <param name="encoding">The character <see cref="Encoding"/> to use.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      /// <returns>
      ///   A stream writer that appends NativeMethods.DefaultFileEncoding encoded text to the specified file or to a new file.
      /// </returns>
      [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
      [SecurityCritical]
      internal static StreamWriter AppendTextInternal(KernelTransaction transaction, string path, Encoding encoding, PathFormat pathFormat)
      {
         FileStream fs = OpenInternal(transaction, path, FileMode.OpenOrCreate, 0, FileAccess.Write, FileShare.None, ExtendedFileAttributes.Normal, pathFormat);

         try
         {
            fs.Seek(0, SeekOrigin.End);
            return new StreamWriter(fs, encoding);
         }
         catch (IOException)
         {
            fs.Close();
            throw;
         }
      }

      #endregion
   }
}
