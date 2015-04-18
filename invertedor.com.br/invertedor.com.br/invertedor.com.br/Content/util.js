var ua = navigator.userAgent.toLowerCase();

if (ua.indexOf(" chrome/") >= 0 || ua.indexOf(" firefox/") >= 0 || ua.indexOf(' gecko/') >= 0)
{
	var StringMaker = function ()
	{
		this.str = "";
		this.length = 0;
		this.append = function (s)
		{
			this.str += s;
			this.length += s.length;
		}
		this.prepend = function (s)
		{
			this.str = s + this.str;
			this.length += s.length;
		}
		this.toString = function ()
		{
			return this.str;
		}
	}
}
else
{
	var StringMaker = function ()
	{
		this.parts = [];
		this.length = 0;
		this.append = function (s)
		{
			this.parts.push(s);
			this.length += s.length;
		}
		this.prepend = function (s)
		{
			this.parts.unshift(s);
			this.length += s.length;
		}
		this.toString = function ()
		{
			return this.parts.join('');
		}
	}
}


var keyStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

function decode64(input)
{
	var output = new StringMaker();
	var chr1, chr2, chr3;
	var enc1, enc2, enc3, enc4;
	var i = 0;

	input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

	while (i < input.length)
	{
		enc1 = keyStr.indexOf(input.charAt(i++));
		enc2 = keyStr.indexOf(input.charAt(i++));
		enc3 = keyStr.indexOf(input.charAt(i++));
		enc4 = keyStr.indexOf(input.charAt(i++));

		chr1 = (enc1 << 2) | (enc2 >> 4);
		chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
		chr3 = ((enc3 & 3) << 6) | enc4;

		output.append(String.fromCharCode(chr1));

		if (enc3 != 64)
		{
			output.append(String.fromCharCode(chr2));
		}
		if (enc4 != 64)
		{
			output.append(String.fromCharCode(chr3));
		}
	}

	return output.toString();
}

function invert(form)
{
	String.prototype.reverse = function()
	{
		splitext = this.split("");
		revertext = splitext.reverse();
		reversed = revertext.join("");
		return reversed;
	}
	var url = document.form.input.value;
	document.form.output.value = url.reverse();
	form.output.focus();
	form.output.select();
}
			
$(document).ready(function()
{			
	$("#trres1").hide();
	$("#trres2").hide();
	
	$("#submit_url").click(function()
	{
		$("#trres1").show();
		$("#trres1").eq(2).fadeIn('slow');
		$("#trres2").show();
		$("#trres2").eq(2).fadeIn('slow');
	});
	
	$("#clear").click(function()
	{
		$("#trres1").hide();
		$("#trres1").eq(2).fadeOut('slow');
		$("#trres2").hide();
		$("#trres2").eq(2).fadeOut('slow');
	});
	
	$("#header").corner("rounded 10px");
	$("#menu").corner("rounded 10px");
	$("#url_area").corner("rounded 10px");
	$("#url_area2").corner("rounded 10px");
	$("#url_area3").corner("rounded 10px");
	$("#url_area4").corner("rounded 10px");
	$("#url_area5").corner("rounded 10px");
	$("#footer").corner("rounded 10px");
	$("#foot").corner("rounded 10px");
});
			
function addFav()
{
	var url      = "http://www.inverterlink.com.br";
	var title    = "Inverter Link";
	if (window.sidebar) window.sidebar.addPanel(title, url,"");
	else if(window.opera && window.print){
		var mbm = document.createElement('a');
		mbm.setAttribute('rel','sidebar');
		mbm.setAttribute('href',url);
		mbm.setAttribute('title',title);
		mbm.click();
	}
	else if(document.all){window.external.AddFavorite(url, title);}
}

function url_unescape(formunescape)
{
	var url = document.formunescape.unesc.value;
	temp = new Array();
	for(i = 0; i < url.length; i++)
	{
		if(i % 2 == 0)
		{
			temp.push('%');
		}
		temp.push(url[i]);
	}
	
	var a = temp.join("");
	document.formunescape.unesc.value = unescape(a);
}

function desprotegerString(StringProtegida, inverter)
{
	var middle = (StringProtegida.length % 2 != 0) ? ((StringProtegida.length + 1) / 2) : (StringProtegida.length / 2);
	var strImpar = StringProtegida.substring(0, middle);
	var strParInverted = StringProtegida.substring(middle);
	var strPar = '';
	for (i=strParInverted.length-1; i>-1; i--)
	strPar += strParInverted.charAt(i);
	var max = strPar.length > strImpar.length ? strPar.length : strImpar.length;
	var String = '';
	for (i=0; i<max; i++)
	{
		if (i <= strImpar.length)
		String += strImpar.charAt(i);
		if (i < strPar.length)
		String += strPar.charAt(i);          
	}
	Result = '';
	if (inverter)
	{
		for (i=String.length-1; i>-1; i--)
		Result += String.charAt(i);
	}
	else
	Result = String;
	return Result;
}

function desproteger()
{
	var protocoloUrlProtegida = document.getElementById('urlProtegida').value;
	var fimProtocolo = protocoloUrlProtegida.indexOf('/', 2);
	var protocoloProtegido = protocoloUrlProtegida.substr(0, fimProtocolo + 1);
	var urlProtegida = protocoloUrlProtegida.substr(fimProtocolo + 1);
	var url = desprotegerString(protocoloProtegido, true) + desprotegerString(urlProtegida, false);
	document.parimpar.urlProtegida.value = url;
}

function hexDecode(str)
{
	var b16_digits = '0123456789abcdef';
	var b16_map = new Array();
	for (var i=0; i<256; i++)
	{
		b16_map[b16_digits.charAt(i >> 4) + b16_digits.charAt(i & 15)] = String.fromCharCode(i);
	}
	if (!str.match(/^[a-f0-9]*$/i))
	{
		document.formhextostring.hextostr.value = 'valor informado não é hexadecimal';
	}
	else
	{	
		if (str.length % 2)
		{
			str = '0'+str;
		}			
		var result = new Array();
		var j = 0;
		for (var i = 0; i<str.length; i += 2)
		{
			result[j++] = b16_map[str.substr(i, 2)];
		}
		document.formhextostring.hextostr.value = result.join('');
	}
}