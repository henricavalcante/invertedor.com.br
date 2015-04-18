using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Microsoft.VisualBasic;
using System.Net;
using System.IO;

namespace invertedor.com.br.Controllers
{
    public class InverterController : Controller
    {
        //
        // GET: /Inverter/
        public string Inverter(string Texto)
        {
            //Cria a partir do texto original um array de char
            char[] ArrayChar = Texto.ToCharArray();
            //Com o array criado invertemos a ordem do mesmo
            Array.Reverse(ArrayChar);
            //Agora basta criarmos uma nova String, ja com o array invertido.
            return new string(ArrayChar);
        }

        public string strtohexa(string data)
        {
            try
            {
                byte[] raw = new byte[data.Length / 2];
                for (int i = 0; i < raw.Length; i++)
                {
                    raw[i] = Convert.ToByte(data.Substring(i * 2, 2), 16);
                }
                string s = Encoding.ASCII.GetString(raw); // GatewayServer

                return s;
            }
            catch (Exception)
            {
                return String.Empty;
            }
            
        }

        public string base64Decode(string data)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();

                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }

        public string ParImparInvertido(string Texto)
        {
            try
            {
                var result1 = string.Empty;
                var result2 = string.Empty;

                if (Texto.Length <= 7)
                {
                    return string.Empty;
                }

                var str1 = Strings.Left(Texto, 7);

                var str2 = Texto.Substring(7);

                // /:thtp/
                // wwmgula.o/dRKXBYDRK=?mcdopae.w

            
                var str13 = String.Empty;
                if (str1.Length > (str1.Length / 2) * 2)
                {
                    str13 = str1.Substring(str1.Length / 2, 1);
                }

                for (int i = 0; i < (str1.Length / 2); i++)
                {
                    result1 += str1.Substring(i, 1);
                    str1 = Inverter(str1);
                    result1 += str1.Substring(i, 1);
                    str1 = Inverter(str1);

                }

                result1 += str13;


                var str23 = String.Empty;
                if (str2.Length > (str2.Length / 2) * 2)
                {
                    str23 = str2.Substring(str2.Length / 2, 1);
                }

                for (int i = 0; i < (str2.Length /2); i++)
                {
                    result2 += str2.Substring(i, 1);
                    str2 = Inverter(str2);

                    result2 += str2.Substring(i, 1);
                    str2 = Inverter(str2);

                }
                result2 += str23;

            
                return Inverter(result1) + result2;
            }
            catch (Exception)
            {
                
                return String.Empty;
            }
            
        }

        public string MeioInvertido(string Texto)
        {
            try
            {
                var result1 = Strings.Left(Texto, 15);
                var result2 = Texto.Substring(15);
                return Inverter(result2 + result1);
            }
            catch (Exception)
            {
                return string.Empty;
            }
            
        }

        public string Encurtar(string Texto)
        {

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] buffer = encoding.GetBytes("");

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://8hm.me/api.txt?url=" + Texto);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = buffer.Length;
            Stream newStream = myRequest.GetRequestStream();
            newStream.Write(buffer, 0, buffer.Length);
            newStream.Close();
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myRequest.GetResponse();
            Stream streamResponse = myHttpWebResponse.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            Char[] readBuffer = new Char[256];

            int count = streamRead.Read(readBuffer, 0, 256);

            string link = String.Empty;
            while (count > 0)
            {
                String resultData = new String(readBuffer, 0, count);
                link += resultData;
                count = streamRead.Read(readBuffer, 0, 256);
            }
            streamRead.Close();
            streamResponse.Close();
            myHttpWebResponse.Close();
            
            return link;
   
        
        }

        public List<String> Descriptografar(string Texto)
        { 
        
                var lst = new List<string>();

                


                var escapes = new List<char>();
                escapes.Add('=');
                escapes.Add('.');
                escapes.Add('/');

                foreach (var esc in escapes)
                {
                    var aux = Texto;
                    var aux2 = string.Empty;

                    while (aux.IndexOf(esc) >= 0)
                    {
                        if (aux.Length >= (aux.IndexOf(esc) +1))
                        {
                            aux2 = aux.Substring(aux.IndexOf(esc) +1);

                            lst.Add(Inverter(aux2));
                            lst.Add(base64Decode(aux2));
                            lst.Add(strtohexa(aux2));
                            lst.Add(ParImparInvertido(aux2));
                            lst.Add(MeioInvertido(aux2));
                            aux = aux2;

                        }
                        else
                        {
                            break;
                        }

                    }

                    aux = Texto;

                    while (aux.IndexOf(esc) >= 0)
                    {
                            aux = aux.Substring(aux.IndexOf(esc));
                            lst.Add(aux);
                            lst.Add(Inverter(aux));
                            lst.Add(base64Decode(aux));
                            lst.Add(strtohexa(aux));
                            lst.Add(ParImparInvertido(aux));
                            lst.Add(MeioInvertido(aux));
                            aux = aux.Substring(1);

                    }

                    var strArr = Texto.Split(esc);
                    foreach (var item in strArr)
                    {
                        lst.Add(item);
                        lst.Add(Inverter(item));
                        lst.Add(base64Decode(item));
                        lst.Add(strtohexa(item));
                        lst.Add(ParImparInvertido(aux2));
                    }

                }
                

                lst.Add(Inverter(Texto));

                lst.Add(base64Decode(Texto));
                    
                var result = new List<string>();
                foreach (var item in lst)
                {
                    if (Strings.Left(item, 7) == "http://")
                    {
                        result.Add(item);
                    }
                }

                return result.Distinct().ToList();

        }

        public ActionResult Index(string id)
        {
            if (id != null)
            {
                id = id.Trim();

                if (!id.Equals(String.Empty))
                {
                    ViewData["linkoriginal"] = id;


                    var result = Descriptografar(id);

                    if (result.Count > 0)
                    {
                        ViewData["url"] = result;
                        ViewData["encurtado"] = Encurtar(result[0]);
                    }
                    else
                    {
                        ViewData["url"] = new List<string>();
                        ViewData["mensagem"] = "Não conseguimos desproteger este link, envie email para contato@henrimichel.com.br para resolvermos este problema.";
                        
                    
                    }
                    return View();
                }
            
            }
            return RedirectToAction("Index", "Home");
            
        }

    }
}
