using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTogetherApp.Shared.Model
{
    public static class EmailText
    {
        public static string registerMail = @"
                                                <!DOCTYPE html>
                                                <html>
                                                <head>
                                                </head>
                                                <body style='background-color: #8A2BE2; color: white; font-family: Arial, sans-serif;'>

                                                <div style='padding: 20px; background-color: #FFFFFF; border-radius: 5px; margin: 20px; text-align: center;'>
                                                  <h1 style='color: black;'>Hallo und herzlich willkommen bei DriveTogether!</h1>
                                                  <h3 style='color: black;'>Wir sind begeistert, dass du dich entschieden hast, Teil unserer Gemeinschaft zu sein. DriveTogether verbindet Menschen, die gemeinsam reisen wollen, und du bist nun ein wichtiger Teil davon.!</h3>
                                                  <p style='color: #555;'>Freue dich auf spannende neue Bekanntschaften und angenehme Fahrten. Wir sind hier, um jede Reise zu einer guten Erfahrung zu machen.</p>
                                                  <p style='color: #555;'>Liebe Grüsse und viel Spass auf deiner ersten Fahrt!</p>

                                                  <p style='color: #555;'>Markus (CEO)</p>
                                                </div>

                                                </body>
                                                </html>
                                                ";
    }
}
