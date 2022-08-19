﻿using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MetalCore.BLL.Models
{
    public class EmailBLL
    {
        /*
        public void SendEmail(string EmailDestino, string token)
        {
            string urlDomain = "https://metalcorecr.azurewebsites.net/";

            string EmailOrigen = "metalcore506@gmail.com";
            string pass = "iinhllwfrotlxlfc";
            string url = urlDomain + "/Login/RestablecerPassword/?token=" + token;


            //Montar Correo con plantilla
            
            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Restablecimiento de pass", MontarPantilla("a"));
            oMailMessage.IsBodyHtml = true;
            
            /*
            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Restablecimiento de contraseña",
                "<p>Se ha generado el siguiente enlace para que restablezca su contraseña</p>" +
                "<br>" +
                "<a href= '" + url + "'>Click para recuperar</a>");
            
            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, pass);

            oSmtpClient.Send(oMailMessage);
            /*
            //Montar correo sin plantilla
            using (var message = new MailMessage(EmailOrigen, EmailDestino)
            {
                Subject = "Recuperación de contraseña",
                Body = "Se ha generado el siguiente enlace para que restablezca su contraseña" + url + " "
            })
            {
                oSmtpClient.Send(message);
            }
            --

            oSmtpClient.Dispose();

        }
    */

        

        public void PruebaPlantilla(string EmailDestino, string token)
        {
            string urlDomain = "https://metalcorecr.azurewebsites.net";

            string EmailOrigen = "metalcore506@gmail.com";
            string pass = "iinhllwfrotlxlfc";
            string url = urlDomain + "/Login/RestablecerPassword/?token=" + token;


            //Plantailla

            string html2 = "<style>" +
                "@media only screen and (min-width: 620px){.u-row{width:600px!important}.u-row .u-col{vertical-align:top}.u-row .u-col-50{width:300px!important}.u-row .u-col-100{width:600px!important}}@media (max-width: 620px){.u-row-container{max-width:100%!important;padding-left:0!important;padding-right:0!important}.u-row .u-col{min-width:320px!important;max-width:100%!important;display:block!important}.u-row{width:calc(100% - 40px)!important}.u-col{width:100%!important}.u-col > div{margin:0 auto}}body{margin:0;padding:0}table,tr,td{vertical-align:top;border-collapse:collapse}p{margin:0}.ie-container table,.mso-container table{table-layout:fixed}*{line-height:inherit}a[x-apple-data-detectors='true']{color:inherit!important;text-decoration:none!important}table,td{color:#000}a{color:#161a39;text-decoration:underline}" +
                "</style>" +
                "</head><body class='clean-body u_body' style='margin: 0;padding: 0;-webkit-text-size-adjust: 100%;background-color: #f9f9f9;color: #000000'> <table style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #f9f9f9;width:100%' cellpadding='0' cellspacing='0'> <tbody> <tr style='vertical-align: top'> <td style='word-break: break-word;border-collapse: collapse !important;vertical-align: top'> <div class='u-row-container' style='padding: 0px;background-color: #f9f9f9'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #f9f9f9;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:15px;font-family:'Lato',sans-serif;' align='left'> <table height='0px' align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;border-top: 1px solid #f9f9f9;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'> <tbody> <tr style='vertical-align: top'> <td style='word-break: break-word;border-collapse: collapse !important;vertical-align: top;font-size: 0px;line-height: 0px;mso-line-height-rule: exactly;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'> <span>&#160;</span> </td></tr></tbody> </table> </td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:25px 10px;font-family:'Lato',sans-serif;' align='left'> <table width='100%' cellpadding='0' cellspacing='0' border='0'> <tr> <td style='padding-right: 0px;padding-left: 0px;' align='center'> " +
                "<img align='center' border='0' src='https://metalcorecr.azurewebsites.net/images/image-3.png' alt='Image' title='Image' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 29%;max-width: 168.2px;' width='168.2'/>" +
                " </td></tr></table> </td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #161a39;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:35px 10px 10px;font-family:'Lato',sans-serif;' align='left'> <table width='100%' cellpadding='0' cellspacing='0' border='0'> <tr> <td style='padding-right: 0px;padding-left: 0px;' align='center'> " +
                "<img align='center' border='0' src='https://metalcorecr.azurewebsites.net/images/image-4.png' alt='Image' title='Image' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 10%;max-width: 58px;' width='58'/> " +
                "</td></tr></table> </td></tr></tbody></table><table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:0px 10px 30px;font-family:'Lato',sans-serif;' align='left'> <div style='line-height: 140%; text-align: left; word-wrap: break-word;'> <p style='font-size: 14px; line-height: 140%; text-align: center;'><span style='font-size: 28px; line-height: 39.2px; color: #ffffff; font-family: Lato, sans-serif;'>Restablecimiento de contrase&ntilde;a</span></p></div></td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:40px 40px 30px;font-family:'Lato',sans-serif;' align='left'> <div style='line-height: 140%; text-align: left; word-wrap: break-word;'> <p style='font-size: 14px; line-height: 140%;'><span style='font-size: 18px; line-height: 25.2px; color: #666666;'>Hola,</span></p><p style='font-size: 14px; line-height: 140%;'>&nbsp;</p><p style='font-size: 14px; line-height: 140%;'><span style='font-size: 18px; line-height: 25.2px; color: #7f8d8d;'>Le hemos enviado este correo electr&oacute;nico en respuesta a su solicitud de restablecer su contrase&ntilde;a en nombre de la empresa.</span></p><p style='font-size: 14px; line-height: 140%;'>&nbsp;</p><p style='font-size: 14px; line-height: 140%;'><br/><span style='font-size: 18px; line-height: 25.2px; color: #7f8c8c;'><span style='color: #7f8d8d; font-size: 18px; line-height: 25.2px;'>Para restablecer su contrase&ntilde;a, siga el siguiente enlace</span>:</span></p></div></td></tr></tbody></table><table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:0px 40px;font-family:'Lato',sans-serif;' align='left'> <div align='left'> <a href='" + url + "' target='_blank' style='box-sizing: border-box;display: inline-block;font-family:'Lato',sans-serif;text-decoration: none;-webkit-text-size-adjust: none;text-align: center;color: #FFFFFF; background-color: #18163a; border-radius: 1px;-webkit-border-radius: 1px; -moz-border-radius: 1px; width:auto; max-width:100%; overflow-wrap: break-word; word-break: break-word; word-wrap:break-word; mso-border-alt: none;'> <span style='display:block;padding:15px 40px;line-height:120%;'><span style='font-size: 18px; line-height: 21.6px;'>Reset Password</span></span> </a> </div></td></tr></tbody></table><table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:40px 40px 30px;font-family:'Lato',sans-serif;' align='left'> <div style='line-height: 140%; text-align: left; word-wrap: break-word;'> <p style='font-size: 14px; line-height: 140%;'><span style='color: #888888; font-size: 14px; line-height: 19.6px;'><em><span style='font-size: 16px; line-height: 22.4px;'>Por favor, ignore este correo electr&oacute;nico si no ha solicitado un cambio de contrase&ntilde;a. </span></em></span></p></div></td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #18163a;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-50' style='max-width: 320px;min-width: 300px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 20px 20px 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Lato',sans-serif;' align='left'> <div style='line-height: 140%; text-align: left; word-wrap: break-word;'> <p style='font-size: 14px; line-height: 140%;'><span style='color: #fffefe; font-size: 14px; line-height: 19.6px;'>Grupo Artemetal</span></p><p style='font-size: 14px; line-height: 140%;'><span style='font-size: 14px; line-height: 19.6px; color: #ecf0f1;'>8432 2792 | Info@artemetal.com</span></p></div></td></tr></tbody></table> </div></div></div><div class='u-col u-col-50' style='max-width: 320px;min-width: 300px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px 0px 0px 20px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:25px 10px 10px;font-family:'Lato',sans-serif;' align='left'> <div align='left'> <div style='display: table; max-width:93px;'> <table align='left' border='0' cellspacing='0' cellpadding='0' width='32' height='32' style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 15px'> <tbody><tr style='vertical-align: top'><td align='left' valign='middle' style='word-break: break-word;border-collapse: collapse !important;vertical-align: top'> <a href=' https://www.facebook.com/GrupoArteMetalCR' title='Facebook' target='_blank'>" +
                "<img src='https://metalcorecr.azurewebsites.net/images/image-1.png' alt='Facebook' title='Facebook' width='32' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important'>" +
                " </a> </td></tr></tbody></table> <table align='left' border='0' cellspacing='0' cellpadding='0' width='32' height='32' style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 0px'> <tbody><tr style='vertical-align: top'><td align='left' valign='middle' style='word-break: break-word;border-collapse: collapse !important;vertical-align: top'> <a href=' https://www.instagram.com/grupoartemetalcr/' title='Instagram' target='_blank'>" +
                " <img src='https://metalcorecr.azurewebsites.net/images/image-2.png' alt='Instagram' title='Instagram' width='32' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important'>" +
                " </a> </td></tr></tbody></table> </div></div></td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: #f9f9f9'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #1c103b;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:15px;font-family:'Lato',sans-serif;' align='left'> <table height='0px' align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;border-top: 1px solid #1c103b;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'> <tbody> <tr style='vertical-align: top'> <td style='word-break: break-word;border-collapse: collapse !important;vertical-align: top;font-size: 0px;line-height: 0px;mso-line-height-rule: exactly;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'> <span>&#160;</span> </td></tr></tbody> </table> </td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #f9f9f9;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> </div></div></div></div></div></div></td></tr></tbody> </table> </body></html>";



            AlternateView htmlView =
                AlternateView.CreateAlternateViewFromString(html2,
                                        Encoding.UTF8,
                                        MediaTypeNames.Text.Html);

            // Creamos el recurso a incrustar. Observad
            // que el ID que le asignamos (arbitrario) está
            // referenciado desde el código HTML como origen
            // de la imagen (resaltado en amarillo)...
            /*
            LinkedResource img1 =
                new LinkedResource("https://metalcorecr.azurewebsites.net/image-1.png",
                                    MediaTypeNames.Image.Jpeg);
            img1.ContentId = "imagen1";

            LinkedResource img2 =
                new LinkedResource(@"/site/wwwroot/imagesimages/image-2.png",
                                    MediaTypeNames.Image.Jpeg);
            img2.ContentId = "imagen2";

            LinkedResource img3 =
                new LinkedResource(@"/site/wwwroot/images/images/image-3.png",
                                    MediaTypeNames.Image.Jpeg);
            img3.ContentId = "imagen3";

            LinkedResource img4 =
                new LinkedResource(@"/site/wwwroot/images/images/image-4.png",
                                    MediaTypeNames.Image.Jpeg);
            img4.ContentId = "imagen4";

            // Lo incrustamos en la vista HTML...

            htmlView.LinkedResources.Add(img1);
            htmlView.LinkedResources.Add(img2);
            htmlView.LinkedResources.Add(img3);
            htmlView.LinkedResources.Add(img4);
            */
            //fin p

            //Montar Correo con plantilla

            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Restablecimiento de pass", html2);
            oMailMessage.IsBodyHtml = true;
            oMailMessage.AlternateViews.Add(htmlView);

            /*
            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Restablecimiento de contraseña",
                "<p>Se ha generado el siguiente enlace para que restablezca su contraseña</p>" +
                "<br>" +
                "<a href= '" + url + "'>Click para recuperar</a>");
            */
            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, pass);


            oSmtpClient.Send(oMailMessage);


        }

        public void TrajaboAsignadoPlantilla(UsuarioObj usuario, TrabajoObj trabajo)
        {

            string EmailOrigen = "metalcore506@gmail.com";
            string pass = "iinhllwfrotlxlfc";
            string nombreEmpleado = usuario.Nombre;
            string EmailDestino = usuario.email;

            string cliente = trabajo.NombreCliente;
            string direccion = trabajo.Direccion;
            string fechaAgendad = trabajo.Fecha.ToString();
            string contacto = trabajo.TelefonoCliente;



            //Plantailla
            string html2 = "< !DOCTYPE HTML PUBLIC '-//W3C//DTD XHTML 1.0 Transitional //EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml' xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office'><head><!--[if gte mso 9]><xml> <o:OfficeDocumentSettings> <o:AllowPNG/> <o:PixelsPerInch>96</o:PixelsPerInch> </o:OfficeDocumentSettings></xml><![endif]--> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <meta name='x-apple-disable-message-reformatting'> <meta http-equiv='X-UA-Compatible' content='IE=edge'> <title></title> <style type='text/css'> @media only screen and (min-width: 620px){.u-row{width: 600px !important;}.u-row .u-col{vertical-align: top;}.u-row .u-col-50{width: 300px !important;}.u-row .u-col-100{width: 600px !important;}}@media (max-width: 620px){.u-row-container{max-width: 100% !important; padding-left: 0px !important; padding-right: 0px !important;}.u-row .u-col{min-width: 320px !important; max-width: 100% !important; display: block !important;}.u-row{width: calc(100% - 40px) !important;}.u-col{width: 100% !important;}.u-col > div{margin: 0 auto;}}body{margin: 0; padding: 0;}table,tr,td{vertical-align: top; border-collapse: collapse;}p{margin: 0;}.ie-container table,.mso-container table{table-layout: fixed;}*{line-height: inherit;}a[x-apple-data-detectors='true']{color: inherit !important; text-decoration: none !important;}table, td{color: #000000;}a{color: #161a39; text-decoration: underline;}</style> <html xmlns='http://www.w3.org/1999/xhtml' xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office'><head> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <meta name='x-apple-disable-message-reformatting'> <meta http-equiv='X-UA-Compatible' content='IE=edge'> <title></title><link href='https://fonts.googleapis.com/css?family=Lato:400,700&display=swap' rel='stylesheet' type='text/css'></head><body class='clean-body u_body' style='margin: 0;padding: 0;-webkit-text-size-adjust: 100%;background-color: #f9f9f9;color: #000000'> <table style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #f9f9f9;width:100%' cellpadding='0' cellspacing='0'> <tbody> <tr style='vertical-align: top'> <td style='word-break: break-word;border-collapse: collapse !important;vertical-align: top'> <div class='u-row-container' style='padding: 0px;background-color: #f9f9f9'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #f9f9f9;'> <div style='border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='height: 100%;width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody><tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:15px;font-family:'Lato',sans-serif;' align='left'> <table height='0px' align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;border-top: 1px solid #f9f9f9;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'><tbody> <tr style='vertical-align: top'><td style='word-break: break-word;border-collapse: collapse !important;vertical-align: top;font-size: 0px;line-height: 0px;mso-line-height-rule: exactly;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'> <span>&#160;</span></td></tr></tbody> </table> </td></tr></tbody></table></div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;'> <div style='border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='height: 100%;width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:25px 10px;font-family:'Lato',sans-serif;' align='left'> <table width='100%' cellpadding='0' cellspacing='0' border='0'> <tr> <td style='padding-right: 0px;padding-left: 0px;' align='center'> <img align='center' border='0' src='https://metalcorecr.azurewebsites.net/images/image-3.png' alt='Image' title='Image' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 29%;max-width: 168.2px;' width='168.2'/> </td></tr></table> </td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #161a39;'> <div style='border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='height: 100%;width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:35px 10px 10px;font-family:'Lato',sans-serif;' align='left'> <table width='100%' cellpadding='0' cellspacing='0' border='0'> <tr> <td style='padding-right: 0px;padding-left: 0px;' align='center'> <img align='center' border='0' src='https://metalcorecr.azurewebsites.net/images/image-5.png' alt='Image' title='Image' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 10%;max-width: 58px;' width='58'/> </td></tr></table> </td></tr></tbody></table><table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:0px 10px 30px;font-family:'Lato',sans-serif;' align='left'> <div style='line-height: 140%; text-align: left; word-wrap: break-word;'> <p style='font-size: 14px; line-height: 140%; text-align: center;'><span style='font-size: 28px; line-height: 39.2px; color: #ffffff; font-family: Lato, sans-serif;'>Asignación de trabajo</span></p></div></td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;'> <div style='border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='height: 100%;width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:40px 40px 30px;font-family:'Lato',sans-serif;' align='left'> <div style='line-height: 140%; text-align: left; word-wrap: break-word;'> <p style='font-size: 14px; line-height: 140%;'><span style='font-size: 18px; line-height: 25.2px; color: #666666;'>Hola, <span> " + nombreEmpleado + "</span> </span></p><p style='font-size: 14px; line-height: 140%;'> </p><p style='font-size: 14px; line-height: 140%;'><span style='font-size: 18px; line-height: 25.2px; color: #666666;'>Se le ha asignado un nuevo trabajo, los detalles se detallan a continuación</span></p><p style='font-size: 14px; line-height: 140%;'> </p><p style='font-size: 14px; line-height: 140%;'><span style='font-size: 18px; line-height: 25.2px; color: #666666;'>Nombre: <span> " + cliente + "</span> </span></p><p style='font-size: 14px; line-height: 140%;'><span style='font-size: 18px; line-height: 25.2px; color: #666666;'>Dirección: <span> " + direccion + "</span> </span></p><p style='font-size: 14px; line-height: 140%;'><span style='font-size: 18px; line-height: 25.2px; color: #666666;'>Fecha agendada:: <span> " + fechaAgendad + "</span> </span></p><p style='font-size: 14px; line-height: 140%;'><span style='font-size: 18px; line-height: 25.2px; color: #666666;'>Contacto del cliente: <span> " + contacto + "</span> </span></p></div></td></tr></tbody></table><table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:40px 40px 30px;font-family:'Lato',sans-serif;' align='left'> </td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #18163a;'> <div style='border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;'> <div class='u-col u-col-50' style='max-width: 320px;min-width: 300px;display: table-cell;vertical-align: top;'> <div style='height: 100%;width: 100% !important;'> <div style='padding: 20px 20px 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Lato',sans-serif;' align='left'> <div style='line-height: 140%; text-align: left; word-wrap: break-word;'> <p style='font-size: 14px; line-height: 140%;'><span style='font-size: 16px; line-height: 22.4px; color: #ecf0f1;'>Grupo Artemetal</span></p><p style='font-size: 14px; line-height: 140%;'><span style='font-size: 14px; line-height: 19.6px; color: #ecf0f1;'>8432 - 2792 | Info@artemetal.com</span></p></div></td></tr></tbody></table> </div></div></div><div class='u-col u-col-50' style='max-width: 320px;min-width: 300px;display: table-cell;vertical-align: top;'> <div style='height: 100%;width: 100% !important;'> <div style='padding: 0px 0px 0px 20px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:25px 10px 10px;font-family:'Lato',sans-serif;' align='left'> <div align='left'> <div style='display: table; max-width:93px;'> <table align='left' border='0' cellspacing='0' cellpadding='0' width='32' height='32' style='width: 32px !important;height: 32px !important;display: inline-block;border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 15px'> <tbody><tr style='vertical-align: top'><td align='left' valign='middle' style='word-break: break-word;border-collapse: collapse !important;vertical-align: top'> <a href=' https://www.facebook.com/GrupoArteMetalCR' title='Facebook' target='_blank'> <img src='https://metalcorecr.azurewebsites.net/images/image-1.png' alt='Facebook' title='Facebook' width='32' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important'> </a> </td></tr></tbody></table> <table align='left' border='0' cellspacing='0' cellpadding='0' width='32' height='32' style='width: 32px !important;height: 32px !important;display: inline-block;border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 0px'> <tbody><tr style='vertical-align: top'><td align='left' valign='middle' style='word-break: break-word;border-collapse: collapse !important;vertical-align: top'> <a href=' https://www.instagram.com/grupoartemetalcr/' title='Instagram' target='_blank'> <img src='https://metalcorecr.azurewebsites.net/images/image-2.png' alt='Instagram' title='Instagram' width='32' style='outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important'> </a> </td></tr></tbody></table> </div></div></td></tr></tbody></table> </div></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: #f9f9f9'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #1c103b;'> <div style='border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='height: 100%;width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> <table style='font-family:'Lato',sans-serif;' role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'> <tbody> <tr> <td style='overflow-wrap:break-word;word-break:break-word;padding:15px;font-family:'Lato',sans-serif;' align='left'> <table height='0px' align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;border-top: 1px solid #1c103b;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'> <tbody> <tr style='vertical-align: top'> <td style='word-break: break-word;border-collapse: collapse !important;vertical-align: top;font-size: 0px;line-height: 0px;mso-line-height-rule: exactly;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%'> <span>&#160;</span> </td></tr></tbody> </table> </td></tr></tbody></table></div></div></div></div></div><div class='u-row-container' style='padding: 0px;background-color: transparent'> <div class='u-row' style='Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #f9f9f9;'> <div style='border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;'> <div class='u-col u-col-100' style='max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;'> <div style='height: 100%;width: 100% !important;'> <div style='padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;'> </div></div></div></div></div></div></td></tr></tbody> </table></body></html>";
            

            AlternateView htmlView =
                AlternateView.CreateAlternateViewFromString(html2,
                                        Encoding.UTF8,
                                        MediaTypeNames.Text.Html);

      
            /*
            LinkedResource img1 =
                new LinkedResource(@"C:/Users/Lenovo/Desktop/MetalCore/SegundoSprint/main/MetalCore.BLL/images/image-1.png",
                                    MediaTypeNames.Image.Jpeg);
            img1.ContentId = "imagen1";

            LinkedResource img2 =
                new LinkedResource(@"C:/Users/Lenovo/Desktop/MetalCore/SegundoSprint/main/MetalCore.BLL/images/image-2.png",
                                    MediaTypeNames.Image.Jpeg);
            img2.ContentId = "imagen2";

            LinkedResource img3 =
                new LinkedResource(@"C:/Users/Lenovo/Desktop/MetalCore/SegundoSprint/main/MetalCore.BLL/images/image-3.png",
                                    MediaTypeNames.Image.Jpeg);
            img3.ContentId = "imagen3";

            LinkedResource img4 =
                new LinkedResource(@"C:/Users/Lenovo/Desktop/MetalCore/SegundoSprint/main/MetalCore.BLL/images/image-5.png",
                                    MediaTypeNames.Image.Jpeg);
            img4.ContentId = "imagen5";
            // Lo incrustamos en la vista HTML...

            htmlView.LinkedResources.Add(img1);
            htmlView.LinkedResources.Add(img2);
            htmlView.LinkedResources.Add(img3);
            htmlView.LinkedResources.Add(img4);
            */
            //fin p

            //Montar Correo con plantilla

            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Nuevo Trabajo Asignado", html2);
            oMailMessage.IsBodyHtml = true;
            oMailMessage.AlternateViews.Add(htmlView);

            
            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, pass);


            oSmtpClient.Send(oMailMessage);
        }
    }

   
}
