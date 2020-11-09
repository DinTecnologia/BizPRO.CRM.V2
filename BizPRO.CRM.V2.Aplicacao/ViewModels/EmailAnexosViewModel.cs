using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class EmailAnexosViewModel
    {
        public long Id { get; set; }
        public string IdProvisorio { get; set; }
        public string Nome { get; set; }
        public string Path { get; set; }
        public string Tamanho { get; set; }
        public string Extensao { get; set; }
        public string IdentificadorAnexoItem { get; set; }

        public ValidationResult ValidationResult { get; set; }
        public string PathImagem
        {
            get
            {
                var imagemAnexo = "anexos/anexo-file.png";

                if (!string.IsNullOrEmpty(Extensao))
                {
                    switch (Extensao)
                    {
                        case "txt":
                            imagemAnexo = "anexos/anexo-txt.png";
                            break;
                        case "pdf":
                            imagemAnexo = "anexos/anexo-pdf.png"; break;
                        case "doc":
                            imagemAnexo = "anexos/anexo-doc.png"; break;
                        case "docx":
                            imagemAnexo = "anexos/anexo-doc.png"; break;
                        case "csv":
                            imagemAnexo = "anexos/anexo-csv.png"; break;
                        case "jpg":
                            imagemAnexo = "anexos/anexo-jpg.png"; break;
                        case "jpeg":
                            imagemAnexo = "anexos/anexo-jpg.png"; break;
                        case "png":
                            imagemAnexo = "anexos/anexo-png.png"; break;
                        case "psd":
                            imagemAnexo = "anexos/anexo-psd.png"; break;
                        case "svg":
                            imagemAnexo = "anexos/anexo-svg.png"; break;
                        case "xls":
                            imagemAnexo = "anexos/anexo-xls.png"; break;
                        case "xlsx":
                            imagemAnexo = "anexos/anexo-xls.png"; break;
                        case "zip":
                            imagemAnexo = "anexos/anexo-zip.png"; break;
                        case "ppt":
                            imagemAnexo = "anexos/anexo-ppt.png"; break;
                        case "pptx":
                            imagemAnexo = "anexos/anexo-ppt.png"; break;
                        case "eml":
                            imagemAnexo = "anexos/anexo-eml.png"; break;
                    }
                }
                return imagemAnexo;
            }
        }
        public string ContentType()
        {
            var contentType = "";

            switch (Extensao)
            {
                case "323": contentType = "text/h323"; break;
                case "3g2": contentType = "video/3gpp2"; break;
                case "3gp": contentType = "video/3gpp"; break;
                case "3gp2": contentType = "video/3gpp2"; break;
                case "3gpp": contentType = "video/3gpp"; break;
                case "7z": contentType = "application/x-7z-compressed"; break;
                case "aa": contentType = "audio/audible"; break;
                case "AAC": contentType = "audio/aac"; break;
                case "aaf": contentType = "application/octet-stream"; break;
                case "aax": contentType = "audio/vnd.audible.aax"; break;
                case "ac3": contentType = "audio/ac3"; break;
                case "aca": contentType = "application/octet-stream"; break;
                case "accda": contentType = "application/msaccess.addin"; break;
                case "accdb": contentType = "application/msaccess"; break;
                case "accdc": contentType = "application/msaccess.cab"; break;
                case "accde": contentType = "application/msaccess"; break;
                case "accdr": contentType = "application/msaccess.runtime"; break;
                case "accdt": contentType = "application/msaccess"; break;
                case "accdw": contentType = "application/msaccess.webapplication"; break;
                case "accft": contentType = "application/msaccess.ftemplate"; break;
                case "acx": contentType = "application/internet-property-stream"; break;
                case "AddIn": contentType = "text/xml"; break;
                case "ade": contentType = "application/msaccess"; break;
                case "adobebridge": contentType = "application/x-bridge-url"; break;
                case "adp": contentType = "application/msaccess"; break;
                case "ADT": contentType = "audio/vnd.dlna.adts"; break;
                case "ADTS": contentType = "audio/aac"; break;
                case "afm": contentType = "application/octet-stream"; break;
                case "ai": contentType = "application/postscript"; break;
                case "aif": contentType = "audio/x-aiff"; break;
                case "aifc": contentType = "audio/aiff"; break;
                case "aiff": contentType = "audio/aiff"; break;
                case "air": contentType = "application/vnd.adobe.air-application-installer-package+zip"; break;
                case "amc": contentType = "application/x-mpeg"; break;
                case "application": contentType = "application/x-ms-application"; break;
                case "art": contentType = "image/x-jg"; break;
                case "asa": contentType = "application/xml"; break;
                case "asax": contentType = "application/xml"; break;
                case "ascx": contentType = "application/xml"; break;
                case "asd": contentType = "application/octet-stream"; break;
                case "asf": contentType = "video/x-ms-asf"; break;
                case "ashx": contentType = "application/xml"; break;
                case "asi": contentType = "application/octet-stream"; break;
                case "asm": contentType = "text/plain"; break;
                case "asmx": contentType = "application/xml"; break;
                case "aspx": contentType = "application/xml"; break;
                case "asr": contentType = "video/x-ms-asf"; break;
                case "asx": contentType = "video/x-ms-asf"; break;
                case "atom": contentType = "application/atom+xml"; break;
                case "au": contentType = "audio/basic"; break;
                case "avi": contentType = "video/x-msvideo"; break;
                case "axs": contentType = "application/olescript"; break;
                case "bas": contentType = "text/plain"; break;
                case "bcpio": contentType = "application/x-bcpio"; break;
                case "bin": contentType = "application/octet-stream"; break;
                case "bmp": contentType = "image/bmp"; break;
                case "c": contentType = "text/plain"; break;
                case "cab": contentType = "application/octet-stream"; break;
                case "caf": contentType = "audio/x-caf"; break;
                case "calx": contentType = "application/vnd.ms-office.calx"; break;
                case "cat": contentType = "application/vnd.ms-pki.seccat"; break;
                case "cc": contentType = "text/plain"; break;
                case "cd": contentType = "text/plain"; break;
                case "cdda": contentType = "audio/aiff"; break;
                case "cdf": contentType = "application/x-cdf"; break;
                case "cer": contentType = "application/x-x509-ca-cert"; break;
                case "chm": contentType = "application/octet-stream"; break;
                case "class": contentType = "application/x-java-applet"; break;
                case "clp": contentType = "application/x-msclip"; break;
                case "cmx": contentType = "image/x-cmx"; break;
                case "cnf": contentType = "text/plain"; break;
                case "cod": contentType = "image/cis-cod"; break;
                case "config": contentType = "application/xml"; break;
                case "contact": contentType = "text/x-ms-contact"; break;
                case "coverage": contentType = "application/xml"; break;
                case "cpio": contentType = "application/x-cpio"; break;
                case "cpp": contentType = "text/plain"; break;
                case "crd": contentType = "application/x-mscardfile"; break;
                case "crl": contentType = "application/pkix-crl"; break;
                case "crt": contentType = "application/x-x509-ca-cert"; break;
                case "cs": contentType = "text/plain"; break;
                case "csdproj": contentType = "text/plain"; break;
                case "csh": contentType = "application/x-csh"; break;
                case "csproj": contentType = "text/plain"; break;
                case "css": contentType = "text/css"; break;
                case "csv": contentType = "text/csv"; break;
                case "cur": contentType = "application/octet-stream"; break;
                case "cxx": contentType = "text/plain"; break;
                case "dat": contentType = "application/octet-stream"; break;
                case "datasource": contentType = "application/xml"; break;
                case "dbproj": contentType = "text/plain"; break;
                case "dcr": contentType = "application/x-director"; break;
                case "def": contentType = "text/plain"; break;
                case "deploy": contentType = "application/octet-stream"; break;
                case "der": contentType = "application/x-x509-ca-cert"; break;
                case "dgml": contentType = "application/xml"; break;
                case "dib": contentType = "image/bmp"; break;
                case "dif": contentType = "video/x-dv"; break;
                case "dir": contentType = "application/x-director"; break;
                case "disco": contentType = "text/xml"; break;
                case "dll": contentType = "application/x-msdownload"; break;
                case "dll.config": contentType = "text/xml"; break;
                case "dlm": contentType = "text/dlm"; break;
                case "doc": contentType = "application/msword"; break;
                case "docm": contentType = "application/vnd.ms-word.document.macroEnabled.12"; break;
                case "docx": contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"; break;
                case "dot": contentType = "application/msword"; break;
                case "dotm": contentType = "application/vnd.ms-word.template.macroEnabled.12"; break;
                case "dotx": contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.template"; break;
                case "dsp": contentType = "application/octet-stream"; break;
                case "dsw": contentType = "text/plain"; break;
                case "dtd": contentType = "text/xml"; break;
                case "dtsConfig": contentType = "text/xml"; break;
                case "dv": contentType = "video/x-dv"; break;
                case "dvi": contentType = "application/x-dvi"; break;
                case "dwf": contentType = "drawing/x-dwf"; break;
                case "dwp": contentType = "application/octet-stream"; break;
                case "dxr": contentType = "application/x-director"; break;
                case "eml": contentType = "message/rfc822"; break;
                case "emz": contentType = "application/octet-stream"; break;
                case "eot": contentType = "application/octet-stream"; break;
                case "eps": contentType = "application/postscript"; break;
                case "etl": contentType = "application/etl"; break;
                case "etx": contentType = "text/x-setext"; break;
                case "evy": contentType = "application/envoy"; break;
                case "exe": contentType = "application/octet-stream"; break;
                case "exe.config": contentType = "text/xml"; break;
                case "fdf": contentType = "application/vnd.fdf"; break;
                case "fif": contentType = "application/fractals"; break;
                case "filters": contentType = "Application/xml"; break;
                case "fla": contentType = "application/octet-stream"; break;
                case "flr": contentType = "x-world/x-vrml"; break;
                case "flv": contentType = "video/x-flv"; break;
                case "fsscript": contentType = "application/fsharp-script"; break;
                case "fsx": contentType = "application/fsharp-script"; break;
                case "generictest": contentType = "application/xml"; break;
                case "gif": contentType = "image/gif"; break;
                case "group": contentType = "text/x-ms-group"; break;
                case "gsm": contentType = "audio/x-gsm"; break;
                case "gtar": contentType = "application/x-gtar"; break;
                case "gz": contentType = "application/x-gzip"; break;
                case "h": contentType = "text/plain"; break;
                case "hdf": contentType = "application/x-hdf"; break;
                case "hdml": contentType = "text/x-hdml"; break;
                case "hhc": contentType = "application/x-oleobject"; break;
                case "hhk": contentType = "application/octet-stream"; break;
                case "hhp": contentType = "application/octet-stream"; break;
                case "hlp": contentType = "application/winhlp"; break;
                case "hpp": contentType = "text/plain"; break;
                case "hqx": contentType = "application/mac-binhex40"; break;
                case "hta": contentType = "application/hta"; break;
                case "htc": contentType = "text/x-component"; break;
                case "htm": contentType = "text/html"; break;
                case "html": contentType = "text/html"; break;
                case "htt": contentType = "text/webviewhtml"; break;
                case "hxa": contentType = "application/xml"; break;
                case "hxc": contentType = "application/xml"; break;
                case "hxd": contentType = "application/octet-stream"; break;
                case "hxe": contentType = "application/xml"; break;
                case "hxf": contentType = "application/xml"; break;
                case "hxh": contentType = "application/octet-stream"; break;
                case "hxi": contentType = "application/octet-stream"; break;
                case "hxk": contentType = "application/xml"; break;
                case "hxq": contentType = "application/octet-stream"; break;
                case "hxr": contentType = "application/octet-stream"; break;
                case "hxs": contentType = "application/octet-stream"; break;
                case "hxt": contentType = "text/html"; break;
                case "hxv": contentType = "application/xml"; break;
                case "hxw": contentType = "application/octet-stream"; break;
                case "hxx": contentType = "text/plain"; break;
                case "i": contentType = "text/plain"; break;
                case "ico": contentType = "image/x-icon"; break;
                case "ics": contentType = "application/octet-stream"; break;
                case "idl": contentType = "text/plain"; break;
                case "ief": contentType = "image/ief"; break;
                case "iii": contentType = "application/x-iphone"; break;
                case "inc": contentType = "text/plain"; break;
                case "inf": contentType = "application/octet-stream"; break;
                case "inl": contentType = "text/plain"; break;
                case "ins": contentType = "application/x-internet-signup"; break;
                case "ipa": contentType = "application/x-itunes-ipa"; break;
                case "ipg": contentType = "application/x-itunes-ipg"; break;
                case "ipproj": contentType = "text/plain"; break;
                case "ipsw": contentType = "application/x-itunes-ipsw"; break;
                case "iqy": contentType = "text/x-ms-iqy"; break;
                case "isp": contentType = "application/x-internet-signup"; break;
                case "ite": contentType = "application/x-itunes-ite"; break;
                case "itlp": contentType = "application/x-itunes-itlp"; break;
                case "itms": contentType = "application/x-itunes-itms"; break;
                case "itpc": contentType = "application/x-itunes-itpc"; break;
                case "IVF": contentType = "video/x-ivf"; break;
                case "jar": contentType = "application/java-archive"; break;
                case "java": contentType = "application/octet-stream"; break;
                case "jck": contentType = "application/liquidmotion"; break;
                case "jcz": contentType = "application/liquidmotion"; break;
                case "jfif": contentType = "image/pjpeg"; break;
                case "jnlp": contentType = "application/x-java-jnlp-file"; break;
                case "jpb": contentType = "application/octet-stream"; break;
                case "jpe": contentType = "image/jpeg"; break;
                case "jpeg": contentType = "image/jpeg"; break;
                case "jpg": contentType = "image/jpeg"; break;
                case "js": contentType = "application/x-javascript"; break;
                case "jsx": contentType = "text/jscript"; break;
                case "jsxbin": contentType = "text/plain"; break;
                case "latex": contentType = "application/x-latex"; break;
                case "library-ms": contentType = "application/windows-library+xml"; break;
                case "lit": contentType = "application/x-ms-reader"; break;
                case "loadtest": contentType = "application/xml"; break;
                case "lpk": contentType = "application/octet-stream"; break;
                case "lsf": contentType = "video/x-la-asf"; break;
                case "lst": contentType = "text/plain"; break;
                case "lsx": contentType = "video/x-la-asf"; break;
                case "lzh": contentType = "application/octet-stream"; break;
                case "m13": contentType = "application/x-msmediaview"; break;
                case "m14": contentType = "application/x-msmediaview"; break;
                case "m1v": contentType = "video/mpeg"; break;
                case "m2t": contentType = "video/vnd.dlna.mpeg-tts"; break;
                case "m2ts": contentType = "video/vnd.dlna.mpeg-tts"; break;
                case "m2v": contentType = "video/mpeg"; break;
                case "m3u": contentType = "audio/x-mpegurl"; break;
                case "m3u8": contentType = "audio/x-mpegurl"; break;
                case "m4a": contentType = "audio/m4a"; break;
                case "m4b": contentType = "audio/m4b"; break;
                case "m4p": contentType = "audio/m4p"; break;
                case "m4r": contentType = "audio/x-m4r"; break;
                case "m4v": contentType = "video/x-m4v"; break;
                case "mac": contentType = "image/x-macpaint"; break;
                case "mak": contentType = "text/plain"; break;
                case "man": contentType = "application/x-troff-man"; break;
                case "manifest": contentType = "application/x-ms-manifest"; break;
                case "map": contentType = "text/plain"; break;
                case "master": contentType = "application/xml"; break;
                case "mda": contentType = "application/msaccess"; break;
                case "mdb": contentType = "application/x-msaccess"; break;
                case "mde": contentType = "application/msaccess"; break;
                case "mdp": contentType = "application/octet-stream"; break;
                case "me": contentType = "application/x-troff-me"; break;
                case "mfp": contentType = "application/x-shockwave-flash"; break;
                case "mht": contentType = "message/rfc822"; break;
                case "mhtml": contentType = "message/rfc822"; break;
                case "mid": contentType = "audio/mid"; break;
                case "midi": contentType = "audio/mid"; break;
                case "mix": contentType = "application/octet-stream"; break;
                case "mk": contentType = "text/plain"; break;
                case "mmf": contentType = "application/x-smaf"; break;
                case "mno": contentType = "text/xml"; break;
                case "mny": contentType = "application/x-msmoney"; break;
                case "mod": contentType = "video/mpeg"; break;
                case "mov": contentType = "video/quicktime"; break;
                case "movie": contentType = "video/x-sgi-movie"; break;
                case "mp2": contentType = "video/mpeg"; break;
                case "mp2v": contentType = "video/mpeg"; break;
                case "mp3": contentType = "audio/mpeg"; break;
                case "mp4": contentType = "video/mp4"; break;
                case "mp4v": contentType = "video/mp4"; break;
                case "mpa": contentType = "video/mpeg"; break;
                case "mpe": contentType = "video/mpeg"; break;
                case "mpeg": contentType = "video/mpeg"; break;
                case "mpf": contentType = "application/vnd.ms-mediapackage"; break;
                case "mpg": contentType = "video/mpeg"; break;
                case "mpp": contentType = "application/vnd.ms-project"; break;
                case "mpv2": contentType = "video/mpeg"; break;
                case "mqv": contentType = "video/quicktime"; break;
                case "ms": contentType = "application/x-troff-ms"; break;
                case "msi": contentType = "application/octet-stream"; break;
                case "mso": contentType = "application/octet-stream"; break;
                case "mts": contentType = "video/vnd.dlna.mpeg-tts"; break;
                case "mtx": contentType = "application/xml"; break;
                case "mvb": contentType = "application/x-msmediaview"; break;
                case "mvc": contentType = "application/x-miva-compiled"; break;
                case "mxp": contentType = "application/x-mmxp"; break;
                case "nc": contentType = "application/x-netcdf"; break;
                case "nsc": contentType = "video/x-ms-asf"; break;
                case "nws": contentType = "message/rfc822"; break;
                case "ocx": contentType = "application/octet-stream"; break;
                case "oda": contentType = "application/oda"; break;
                case "odc": contentType = "text/x-ms-odc"; break;
                case "odh": contentType = "text/plain"; break;
                case "odl": contentType = "text/plain"; break;
                case "odp": contentType = "application/vnd.oasis.opendocument.presentation"; break;
                case "ods": contentType = "application/oleobject"; break;
                case "odt": contentType = "application/vnd.oasis.opendocument.text"; break;
                case "one": contentType = "application/onenote"; break;
                case "onea": contentType = "application/onenote"; break;
                case "onepkg": contentType = "application/onenote"; break;
                case "onetmp": contentType = "application/onenote"; break;
                case "onetoc": contentType = "application/onenote"; break;
                case "onetoc2": contentType = "application/onenote"; break;
                case "orderedtest": contentType = "application/xml"; break;
                case "osdx": contentType = "application/opensearchdescription+xml"; break;
                case "p10": contentType = "application/pkcs10"; break;
                case "p12": contentType = "application/x-pkcs12"; break;
                case "p7b": contentType = "application/x-pkcs7-certificates"; break;
                case "p7c": contentType = "application/pkcs7-mime"; break;
                case "p7m": contentType = "application/pkcs7-mime"; break;
                case "p7r": contentType = "application/x-pkcs7-certreqresp"; break;
                case "p7s": contentType = "application/pkcs7-signature"; break;
                case "pbm": contentType = "image/x-portable-bitmap"; break;
                case "pcast": contentType = "application/x-podcast"; break;
                case "pct": contentType = "image/pict"; break;
                case "pcx": contentType = "application/octet-stream"; break;
                case "pcz": contentType = "application/octet-stream"; break;
                case "pdf": contentType = "application/pdf"; break;
                case "pfb": contentType = "application/octet-stream"; break;
                case "pfm": contentType = "application/octet-stream"; break;
                case "pfx": contentType = "application/x-pkcs12"; break;
                case "pgm": contentType = "image/x-portable-graymap"; break;
                case "pic": contentType = "image/pict"; break;
                case "pict": contentType = "image/pict"; break;
                case "pkgdef": contentType = "text/plain"; break;
                case "pkgundef": contentType = "text/plain"; break;
                case "pko": contentType = "application/vnd.ms-pki.pko"; break;
                case "pls": contentType = "audio/scpls"; break;
                case "pma": contentType = "application/x-perfmon"; break;
                case "pmc": contentType = "application/x-perfmon"; break;
                case "pml": contentType = "application/x-perfmon"; break;
                case "pmr": contentType = "application/x-perfmon"; break;
                case "pmw": contentType = "application/x-perfmon"; break;
                case "png": contentType = "image/png"; break;
                case "pnm": contentType = "image/x-portable-anymap"; break;
                case "pnt": contentType = "image/x-macpaint"; break;
                case "pntg": contentType = "image/x-macpaint"; break;
                case "pnz": contentType = "image/png"; break;
                case "pot": contentType = "application/vnd.ms-powerpoint"; break;
                case "potm": contentType = "application/vnd.ms-powerpoint.template.macroEnabled.12"; break;
                case "potx": contentType = "application/vnd.openxmlformats-officedocument.presentationml.template"; break;
                case "ppa": contentType = "application/vnd.ms-powerpoint"; break;
                case "ppam": contentType = "application/vnd.ms-powerpoint.addin.macroEnabled.12"; break;
                case "ppm": contentType = "image/x-portable-pixmap"; break;
                case "pps": contentType = "application/vnd.ms-powerpoint"; break;
                case "ppsm": contentType = "application/vnd.ms-powerpoint.slideshow.macroEnabled.12"; break;
                case "ppsx": contentType = "application/vnd.openxmlformats-officedocument.presentationml.slideshow"; break;
                case "ppt": contentType = "application/vnd.ms-powerpoint"; break;
                case "pptm": contentType = "application/vnd.ms-powerpoint.presentation.macroEnabled.12"; break;
                case "pptx": contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation"; break;
                case "prf": contentType = "application/pics-rules"; break;
                case "prm": contentType = "application/octet-stream"; break;
                case "prx": contentType = "application/octet-stream"; break;
                case "ps": contentType = "application/postscript"; break;
                case "psc1": contentType = "application/PowerShell"; break;
                case "psd": contentType = "application/octet-stream"; break;
                case "psess": contentType = "application/xml"; break;
                case "psm": contentType = "application/octet-stream"; break;
                case "psp": contentType = "application/octet-stream"; break;
                case "pub": contentType = "application/x-mspublisher"; break;
                case "pwz": contentType = "application/vnd.ms-powerpoint"; break;
                case "qht": contentType = "text/x-html-insertion"; break;
                case "qhtm": contentType = "text/x-html-insertion"; break;
                case "qt": contentType = "video/quicktime"; break;
                case "qti": contentType = "image/x-quicktime"; break;
                case "qtif": contentType = "image/x-quicktime"; break;
                case "qtl": contentType = "application/x-quicktimeplayer"; break;
                case "qxd": contentType = "application/octet-stream"; break;
                case "ra": contentType = "audio/x-pn-realaudio"; break;
                case "ram": contentType = "audio/x-pn-realaudio"; break;
                case "rar": contentType = "application/octet-stream"; break;
                case "ras": contentType = "image/x-cmu-raster"; break;
                case "rat": contentType = "application/rat-file"; break;
                case "rc": contentType = "text/plain"; break;
                case "rc2": contentType = "text/plain"; break;
                case "rct": contentType = "text/plain"; break;
                case "rdlc": contentType = "application/xml"; break;
                case "resx": contentType = "application/xml"; break;
                case "rf": contentType = "image/vnd.rn-realflash"; break;
                case "rgb": contentType = "image/x-rgb"; break;
                case "rgs": contentType = "text/plain"; break;
                case "rm": contentType = "application/vnd.rn-realmedia"; break;
                case "rmi": contentType = "audio/mid"; break;
                case "rmp": contentType = "application/vnd.rn-rn_music_package"; break;
                case "roff": contentType = "application/x-troff"; break;
                case "rpm": contentType = "audio/x-pn-realaudio-plugin"; break;
                case "rqy": contentType = "text/x-ms-rqy"; break;
                case "rtf": contentType = "application/rtf"; break;
                case "rtx": contentType = "text/richtext"; break;
                case "ruleset": contentType = "application/xml"; break;
                case "s": contentType = "text/plain"; break;
                case "safariextz": contentType = "application/x-safari-safariextz"; break;
                case "scd": contentType = "application/x-msschedule"; break;
                case "sct": contentType = "text/scriptlet"; break;
                case "sd2": contentType = "audio/x-sd2"; break;
                case "sdp": contentType = "application/sdp"; break;
                case "sea": contentType = "application/octet-stream"; break;
                case "searchConnector-ms": contentType = "application/windows-search-connector+xml"; break;
                case "setpay": contentType = "application/set-payment-initiation"; break;
                case "setreg": contentType = "application/set-registration-initiation"; break;
                case "settings": contentType = "application/xml"; break;
                case "sgimb": contentType = "application/x-sgimb"; break;
                case "sgml": contentType = "text/sgml"; break;
                case "sh": contentType = "application/x-sh"; break;
                case "shar": contentType = "application/x-shar"; break;
                case "shtml": contentType = "text/html"; break;
                case "sit": contentType = "application/x-stuffit"; break;
                case "sitemap": contentType = "application/xml"; break;
                case "skin": contentType = "application/xml"; break;
                case "sldm": contentType = "application/vnd.ms-powerpoint.slide.macroEnabled.12"; break;
                case "sldx": contentType = "application/vnd.openxmlformats-officedocument.presentationml.slide"; break;
                case "slk": contentType = "application/vnd.ms-excel"; break;
                case "sln": contentType = "text/plain"; break;
                case "slupkg-ms": contentType = "application/x-ms-license"; break;
                case "smd": contentType = "audio/x-smd"; break;
                case "smi": contentType = "application/octet-stream"; break;
                case "smx": contentType = "audio/x-smd"; break;
                case "smz": contentType = "audio/x-smd"; break;
                case "snd": contentType = "audio/basic"; break;
                case "snippet": contentType = "application/xml"; break;
                case "snp": contentType = "application/octet-stream"; break;
                case "sol": contentType = "text/plain"; break;
                case "sor": contentType = "text/plain"; break;
                case "spc": contentType = "application/x-pkcs7-certificates"; break;
                case "spl": contentType = "application/futuresplash"; break;
                case "src": contentType = "application/x-wais-source"; break;
                case "srf": contentType = "text/plain"; break;
                case "SSISDeploymentManifest": contentType = "text/xml"; break;
                case "ssm": contentType = "application/streamingmedia"; break;
                case "sst": contentType = "application/vnd.ms-pki.certstore"; break;
                case "stl": contentType = "application/vnd.ms-pki.stl"; break;
                case "sv4cpio": contentType = "application/x-sv4cpio"; break;
                case "sv4crc": contentType = "application/x-sv4crc"; break;
                case "svc": contentType = "application/xml"; break;
                case "swf": contentType = "application/x-shockwave-flash"; break;
                case "t": contentType = "application/x-troff"; break;
                case "tar": contentType = "application/x-tar"; break;
                case "tcl": contentType = "application/x-tcl"; break;
                case "testrunconfig": contentType = "application/xml"; break;
                case "testsettings": contentType = "application/xml"; break;
                case "tex": contentType = "application/x-tex"; break;
                case "texi": contentType = "application/x-texinfo"; break;
                case "texinfo": contentType = "application/x-texinfo"; break;
                case "tgz": contentType = "application/x-compressed"; break;
                case "thmx": contentType = "application/vnd.ms-officetheme"; break;
                case "thn": contentType = "application/octet-stream"; break;
                case "tif": contentType = "image/tiff"; break;
                case "tiff": contentType = "image/tiff"; break;
                case "tlh": contentType = "text/plain"; break;
                case "tli": contentType = "text/plain"; break;
                case "toc": contentType = "application/octet-stream"; break;
                case "tr": contentType = "application/x-troff"; break;
                case "trm": contentType = "application/x-msterminal"; break;
                case "trx": contentType = "application/xml"; break;
                case "ts": contentType = "video/vnd.dlna.mpeg-tts"; break;
                case "tsv": contentType = "text/tab-separated-values"; break;
                case "ttf": contentType = "application/octet-stream"; break;
                case "tts": contentType = "video/vnd.dlna.mpeg-tts"; break;
                case "txt": contentType = "text/plain"; break;
                case "u32": contentType = "application/octet-stream"; break;
                case "uls": contentType = "text/iuls"; break;
                case "user": contentType = "text/plain"; break;
                case "ustar": contentType = "application/x-ustar"; break;
                case "vb": contentType = "text/plain"; break;
                case "vbdproj": contentType = "text/plain"; break;
                case "vbk": contentType = "video/mpeg"; break;
                case "vbproj": contentType = "text/plain"; break;
                case "vbs": contentType = "text/vbscript"; break;
                case "vcf": contentType = "text/x-vcard"; break;
                case "vcproj": contentType = "Application/xml"; break;
                case "vcs": contentType = "text/plain"; break;
                case "vcxproj": contentType = "Application/xml"; break;
                case "vddproj": contentType = "text/plain"; break;
                case "vdp": contentType = "text/plain"; break;
                case "vdproj": contentType = "text/plain"; break;
                case "vdx": contentType = "application/vnd.ms-visio.viewer"; break;
                case "vml": contentType = "text/xml"; break;
                case "vscontent": contentType = "application/xml"; break;
                case "vsct": contentType = "text/xml"; break;
                case "vsd": contentType = "application/vnd.visio"; break;
                case "vsi": contentType = "application/ms-vsi"; break;
                case "vsix": contentType = "application/vsix"; break;
                case "vsixlangpack": contentType = "text/xml"; break;
                case "vsixmanifest": contentType = "text/xml"; break;
                case "vsmdi": contentType = "application/xml"; break;
                case "vspscc": contentType = "text/plain"; break;
                case "vss": contentType = "application/vnd.visio"; break;
                case "vsscc": contentType = "text/plain"; break;
                case "vssettings": contentType = "text/xml"; break;
                case "vssscc": contentType = "text/plain"; break;
                case "vst": contentType = "application/vnd.visio"; break;
                case "vstemplate": contentType = "text/xml"; break;
                case "vsto": contentType = "application/x-ms-vsto"; break;
                case "vsw": contentType = "application/vnd.visio"; break;
                case "vsx": contentType = "application/vnd.visio"; break;
                case "vtx": contentType = "application/vnd.visio"; break;
                case "wav": contentType = "audio/wav"; break;
                case "wave": contentType = "audio/wav"; break;
                case "wax": contentType = "audio/x-ms-wax"; break;
                case "wbk": contentType = "application/msword"; break;
                case "wbmp": contentType = "image/vnd.wap.wbmp"; break;
                case "wcm": contentType = "application/vnd.ms-works"; break;
                case "wdb": contentType = "application/vnd.ms-works"; break;
                case "wdp": contentType = "image/vnd.ms-photo"; break;
                case "webarchive": contentType = "application/x-safari-webarchive"; break;
                case "webtest": contentType = "application/xml"; break;
                case "wiq": contentType = "application/xml"; break;
                case "wiz": contentType = "application/msword"; break;
                case "wks": contentType = "application/vnd.ms-works"; break;
                case "WLMP": contentType = "application/wlmoviemaker"; break;
                case "wlpginstall": contentType = "application/x-wlpg-detect"; break;
                case "wlpginstall3": contentType = "application/x-wlpg3-detect"; break;
                case "wm": contentType = "video/x-ms-wm"; break;
                case "wma": contentType = "audio/x-ms-wma"; break;
                case "wmd": contentType = "application/x-ms-wmd"; break;
                case "wmf": contentType = "application/x-msmetafile"; break;
                case "wml": contentType = "text/vnd.wap.wml"; break;
                case "wmlc": contentType = "application/vnd.wap.wmlc"; break;
                case "wmls": contentType = "text/vnd.wap.wmlscript"; break;
                case "wmlsc": contentType = "application/vnd.wap.wmlscriptc"; break;
                case "wmp": contentType = "video/x-ms-wmp"; break;
                case "wmv": contentType = "video/x-ms-wmv"; break;
                case "wmx": contentType = "video/x-ms-wmx"; break;
                case "wmz": contentType = "application/x-ms-wmz"; break;
                case "wpl": contentType = "application/vnd.ms-wpl"; break;
                case "wps": contentType = "application/vnd.ms-works"; break;
                case "wri": contentType = "application/x-mswrite"; break;
                case "wrl": contentType = "x-world/x-vrml"; break;
                case "wrz": contentType = "x-world/x-vrml"; break;
                case "wsc": contentType = "text/scriptlet"; break;
                case "wsdl": contentType = "text/xml"; break;
                case "wvx": contentType = "video/x-ms-wvx"; break;
                case "x": contentType = "application/directx"; break;
                case "xaf": contentType = "x-world/x-vrml"; break;
                case "xaml": contentType = "application/xaml+xml"; break;
                case "xap": contentType = "application/x-silverlight-app"; break;
                case "xbap": contentType = "application/x-ms-xbap"; break;
                case "xbm": contentType = "image/x-xbitmap"; break;
                case "xdr": contentType = "text/plain"; break;
                case "xht": contentType = "application/xhtml+xml"; break;
                case "xhtml": contentType = "application/xhtml+xml"; break;
                case "xla": contentType = "application/vnd.ms-excel"; break;
                case "xlam": contentType = "application/vnd.ms-excel.addin.macroEnabled.12"; break;
                case "xlc": contentType = "application/vnd.ms-excel"; break;
                case "xld": contentType = "application/vnd.ms-excel"; break;
                case "xlk": contentType = "application/vnd.ms-excel"; break;
                case "xll": contentType = "application/vnd.ms-excel"; break;
                case "xlm": contentType = "application/vnd.ms-excel"; break;
                case "xls": contentType = "application/vnd.ms-excel"; break;
                case "xlsb": contentType = "application/vnd.ms-excel.sheet.binary.macroEnabled.12"; break;
                case "xlsm": contentType = "application/vnd.ms-excel.sheet.macroEnabled.12"; break;
                case "xlsx": contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; break;
                case "xlt": contentType = "application/vnd.ms-excel"; break;
                case "xltm": contentType = "application/vnd.ms-excel.template.macroEnabled.12"; break;
                case "xltx": contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.template"; break;
                case "xlw": contentType = "application/vnd.ms-excel"; break;
                case "xml": contentType = "text/xml"; break;
                case "xmta": contentType = "application/xml"; break;
                case "xof": contentType = "x-world/x-vrml"; break;
                case "XOML": contentType = "text/plain"; break;
                case "xpm": contentType = "image/x-xpixmap"; break;
                case "xps": contentType = "application/vnd.ms-xpsdocument"; break;
                case "xrm-ms": contentType = "text/xml"; break;
                case "xsc": contentType = "application/xml"; break;
                case "xsd": contentType = "text/xml"; break;
                case "xsf": contentType = "text/xml"; break;
                case "xsl": contentType = "text/xml"; break;
                case "xslt": contentType = "text/xml"; break;
                case "xsn": contentType = "application/octet-stream"; break;
                case "xss": contentType = "application/xml"; break;
                case "xtp": contentType = "application/octet-stream"; break;
                case "xwd": contentType = "image/x-xwindowdump"; break;
                case "z": contentType = "application/x-compress"; break;
                case "zip": contentType = "application/x-zip-compressed"; break;
                default: contentType = "application/octet-stream"; break;
            }

            return contentType;
        }
        public EmailAnexosViewModel()
        {
            ValidationResult = new ValidationResult();
        }
        public EmailAnexosViewModel(long id, string nome, string path, long tamanho, string extensao)
        {
            ValidationResult = new ValidationResult();
            Id = id;
            Nome = nome;
            Path = path;
            Tamanho = TamanhoAmigavel(tamanho);
            Extensao = extensao;
        }
        public EmailAnexosViewModel(long id, string nome, string path, long tamanho, string extensao, string identificadorAnexoItem)
        {
            ValidationResult = new ValidationResult();
            Id = id;
            Nome = nome;
            Path = path;
            Tamanho = TamanhoAmigavel(tamanho);
            Extensao = extensao;
            IdentificadorAnexoItem = identificadorAnexoItem;
        }
        protected static string TamanhoAmigavel(long? tamanho)
        {
            long bytes = 0;

            if (tamanho == null)
                return "";
            else
                bytes = (long)tamanho;

            if (bytes < 0) throw new ArgumentException("bytes");

            double humano;
            string sufixo;

            if (bytes >= 1152921504606846976L) // Exabyte (1024^6)
            {
                humano = bytes >> 50;
                sufixo = "EB";
            }
            else if (bytes >= 1125899906842624L) // Petabyte (1024^5)
            {
                humano = bytes >> 40;
                sufixo = "PB";
            }
            else if (bytes >= 1099511627776L) // Terabyte (1024^4)
            {
                humano = bytes >> 30;
                sufixo = "TB";
            }
            else if (bytes >= 1073741824) // Gigabyte (1024^3)
            {
                humano = bytes >> 20;
                sufixo = "GB";
            }
            else if (bytes >= 1048576) // Megabyte (1024^2)
            {
                humano = bytes >> 10;
                sufixo = "MB";
            }
            else if (bytes >= 1024) // Kilobyte (1024^1)
            {
                humano = bytes;
                sufixo = "KB";
            }
            else return "1 KB"; //bytes.ToString("0 B"); // Byte

            humano /= 1024;
            return humano.ToString("0.## ") + sufixo;
        }        
    }
}
