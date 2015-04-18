using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using invertedor.com.br.Controllers;
using Microsoft.VisualBasic;

namespace TestesUnitarios
{
    /*
     * http://www.baixarfilmeseseries.org/download/?url=MDJRVOII=d?/moc.daolpuagem.www//:ptth
     * http://protetordelink.tv/download/digomunhoz/878/687474703a2f2f7777772e6d65676175706c6f61642e636f6d2f3f643d41523049424e3544
     * http://www.baixarjogoscompletos.info/protetor/en/?url=aHR0cDovL3d3dy5maWxlc2VydmUuY29tL2ZpbGUvN3NhOThzRS9TQ1JfWk9NLnBhcnQxLnJhcg==
     * http://www.agaleradodownload.com/download/?id=687474703a2f2f7777772e6d65676175706c6f61642e636f6d2f3f643d5144495141325045
     */

    [TestClass]
    public class TestarMetodosDeDescriptografia
    {
        [TestMethod]
        public void TestarBase64()
        {

            var ctl = new InverterController();
            var url = "aHR0cDovL3d3dy5maWxlc2VydmUuY29tL2ZpbGUvN3NhOThzRS9TQ1JfWk9NLnBhcnQxLnJhcg==";
            
            var result = ctl.base64Decode(url);

            Assert.AreEqual("http://", Strings.Left(result, 7));

        }

        [TestMethod]
        public void TestarHexa()
        {

            var ctl = new InverterController();
            var url = "687474703a2f2f7777772e6d65676175706c6f61642e636f6d2f3f643d5144495141325045";

            var result = ctl.strtohexa(url);

            Assert.AreEqual("http://", Strings.Left(result, 7));

        }


        [TestMethod]
        public void TestarInverter()
        {

            var ctl = new InverterController();
            var url = "MDJRVOII=d?/moc.daolpuagem.www//:ptth";

            var result = ctl.Inverter(url);

            Assert.AreEqual("http://", Strings.Left(result, 7));

        }

        [TestMethod]
        public void TestarParImparInvertido()
        {

            var ctl = new InverterController();
            var url = "/:thtp/wwmgula.o/dRKXBYDRK=?mcdopae.w";

            var result = ctl.ParImparInvertido(url);

            Assert.AreEqual("http://", Strings.Left(result, 7));

        }

        [TestMethod]
        public void TestarMeioInvertido()
        {

            var ctl = new InverterController();
            var url = "dnam.www//:ptth54018190020182sc2h/daolnwod/rb.moc.siama";

            var result = ctl.MeioInvertido(url);

            Assert.AreEqual("http://", Strings.Left(result, 7));

        }


        [TestMethod]
        public void TestarDescriptografarLinksInteiros()
        {

            var ctl = new InverterController();
            var urls = new List<string>();

            urls.Add("http://www.baixarfilmeseseries.org/download/?url=MDJRVOII=d?/moc.daolpuagem.www//:ptth");
            urls.Add("MDJRVOII=d?/moc.daolpuagem.www//:ptth");
            urls.Add("http://www.baixarfilmeseseries.org/download/?url=http://www.baixarfilmeseseries.org/");

            urls.Add("http://protetordelink.tv/download/digomunhoz/878/687474703a2f2f7777772e6d65676175706c6f61642e636f6d2f3f643d41523049424e3544");
            urls.Add("http://www.baixarjogoscompletos.info/protetor/en/?url=aHR0cDovL3d3dy5maWxlc2VydmUuY29tL2ZpbGUvN3NhOThzRS9TQ1JfWk9NLnBhcnQxLnJhcg==");
            urls.Add("http://www.agaleradodownload.com/download/?id=687474703a2f2f7777772e6d65676175706c6f61642e636f6d2f3f643d5144495141325045");

            urls.Add("http://www.inverterlink.com.br/?id=rb.moc.knilretrevni.www//:ptth");
            urls.Add("http://www.inverterlink.com.br/?id=aHR0cDovL3d3dy5pbnZlcnRlcmxpbmsuY29tLmJy");
            urls.Add("http://www.inverterlink.com.br/?id=687474703a2f2f7777772e6d65676175706c6f61642e636f6d2f3f643d524c573753445647");
            urls.Add("http://www.inverterlink.com.br/?id=687474703a2f2f7777772e696e7665727465726c696e6b2e636f6d2e6272");

            //não sei ainda
            urls.Add("http://www.link-protegido.com/gigafilmes /protetor.php?link=agem.www//:ptthRQICZOUB=d?/moc.daolpu");
            urls.Add("http://www.link-protegido.com/semprefilmes/protetor.php?link=agem.www//:ptthNEYIP91A=d?/moc.daolpu");
            urls.Add("http://www.link-protegido.com/semprefilmes/protetor.php?link=agem.www//:ptthMAU9LUVF=d?/moc.daolpu");
            urls.Add("http://www.link-protegido.com/brasildowns/protetor.php?link=dnam.www//:ptth54018190020182sc2h/daolnwod/rb.moc.siama");
            urls.Add("http://www.link-protegido.com/brasildowns/protetor.php?link=dnam.www//:ptth8533819002018272e1/daolnwod/rb.moc.siama");
            urls.Add("http://www.link-protegido.com/brasildowns/protetor.php?link=dnam.www//:ptth14519190020182p0ib/daolnwod/rb.moc.siama");
            
            

            //Par e Impar Invertidos em ordem crescente e decrescente
            urls.Add("http://www.xico.com.br/?link=id///vcsmt/ufpyeovpths/2kbeio5ultle.fpit:sp2oe/:thtp/wwmgula.o/dRKXBYDRK=?mcdopae.w");
            urls.Add("http://www.link-protegido.com/semprefilmesv2/?link=a16d==p=dmm8o/=&p2=/:thtp/wwmgula.o/d9GY80861=?mcdopae.w");
            urls.Add("http://www.link-protegido.com/brasildowns/?link=lhR:gao98.w?p/ma8ump/dcottw=wSed6V.7/&p2=/:thtp/wwmgula.o/d7V98S8R6=?mcdopae.w");
            urls.Add("http://www.link-protegido.com/brasildowns/?link=.m/.w/R98lwet2aBuc?ogtpd68hmaop:d/w=U&p2=/:thtp/wwmgula.o/d9R8UB628=?mcdopae.w");
            urls.Add("http://www.link-protegido.com/brasildowns/?link=clIa1LeAdh:.uXQmmtpSowa?wdKt/o=.//wpg&p2=/:thtp/wwmgula.o/dI1KAQSXL=?mcdopae.w");
            urls.Add("http://www.link-protegido.com/brasildowns/?link=oe/ptm/uD9tgw1al?cad.:w=C/wphdP0m.LLo&p2=/:thtp/wwmgula.o/dLP0DL9C1=?mcdopae.w");
            urls.Add("http://www.link-protegido.com/brasildowns/?link=QuE=a/wpd/mh?9d8.owcto/pTeQtQg:mal.6w&p2=/:thtp/wwmgula.o/dQQQ8TE96=?mcdopae.w");
            urls.Add("http://www.link-protegido.com/brasildowns/?link=Bapt?3geFto/a=.wuwdHmph.cdTD:/mwol7/S&p2=/:thtp/wwmgula.o/dDHTS37BF=?mcdopae.w");
            urls.Add("http://www.link-protegido.com/brasildowns/?link=tgV.m/a:o4w=w1?495dZ.p/macupetl/dhwQo&p2=/:thtp/wwmgula.o/dQZ91454V=?mcdopae.w");

            foreach (var i in urls)
            {
                var result = ctl.Descriptografar(i);

                Assert.AreEqual(true, (result.Count > 0), i);

                foreach (var j in result)
                {
                    Assert.AreEqual("http://", Strings.Left(j, 7),i);    
                }
                

            }

        }


    }
}
