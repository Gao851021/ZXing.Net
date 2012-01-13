/*
* Copyright 2007 ZXing authors
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Text;

namespace com.google.zxing.client.result
{
   /// <summary> <p>Abstract class representing the result of decoding a barcode, as more than
   /// a String -- as some type of structured data. This might be a subclass which represents
   /// a URL, or an e-mail address. {@link ResultParser#parseResult(Result)} will turn a raw
   /// decoded string into the most appropriate type of structured representation.</p>
   /// 
   /// <p>Thanks to Jeff Griffin for proposing rewrite of these classes that relies less
   /// on exception-based mechanisms during parsing.</p>
   /// 
   /// </summary>
   /// <author>  Sean Owen
   /// </author>
   /// <author>www.Redivivus.in (suraj.supekar@redivivus.in) - Ported from ZXING Java Source 
   /// </author>
   public abstract class ParsedResult
   {
      public virtual ParsedResultType Type { get; private set; }
      public abstract String DisplayResult { get; }

      protected ParsedResult(ParsedResultType type)
      {
         Type = type;
      }

      public override String ToString()
      {
         return DisplayResult;
      }

      public static void maybeAppend(String value, StringBuilder result)
      {
         if (value == null || value.Length <= 0)
            return;

         // Don't add a newline before the first value
         if (result.Length > 0)
         {
            result.Append('\n');
         }
         result.Append(value);
      }

      public static void maybeAppend(String[] value, StringBuilder result)
      {
         if (value == null)
            return;

         foreach (string t in value)
         {
            if (!string.IsNullOrEmpty(t))
            {
               if (result.Length > 0)
               {
                  result.Append('\n');
               }
               result.Append(t);
            }
         }
      }
   }
}