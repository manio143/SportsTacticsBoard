// Sports Tactics Board
//
// http://github.com/manio143/SportsTacticsBoard
// 
// Sports Tactics Board is a utility that allows coaches, trainers and 
// officials to describe sports tactics, strategies and positioning using 
// a magnetic or chalk-board style approach.
// 
// Copyright (C) 2016 Marian Dziubiak
// Copyright (C) 2006-2010 Robert Turner
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
using System;
using System.Globalization;
using System.Threading;
using Eto.Forms;
using SportsTacticsBoard.Resources;

namespace SportsTacticsBoard
{
    static class Program
    {
        private const string CultureOption = "-culture";

        [STAThread]
        static void Main(string[] args)
        {
            var application = new Application();

            ResourceManager manager;
            if (args.Length == 2 && args[0] == CultureOption)
            {
                try
                {
                    var culture = new CultureInfo(args[1]);
                    manager = new ResourceManager(args[1]);
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
                catch (Exception exception)
                {
                    if (exception is ArgumentException || exception is NotSupportedException)
                    {
                        manager = new ResourceManager(CultureInfo.CurrentCulture.Name);
                        var msg = string.Format(CultureInfo.CurrentCulture,
                            manager.LocalizationResource.InvalidCultureOptionFormat, CultureOption, args[1]);
                        MessageBox.Show(msg, manager.LocalizationResource.InvalidParametersTitle,
                            MessageBoxButtons.OK, MessageBoxType.Information);
                    }
                    else
                        throw;
                }
            }
            else
                manager = new ResourceManager(CultureInfo.CurrentCulture.Name);

            System.Diagnostics.Trace.TraceInformation("System.Threading.Thread.CurrentThread.CurrentCulture.Name={0}", Thread.CurrentThread.CurrentCulture.Name);
            System.Diagnostics.Trace.TraceInformation("System.Threading.Thread.CurrentThread.CurrentUICulture.Name={0}", Thread.CurrentThread.CurrentUICulture.Name);
            
            application.Run(new MainForm(manager));
        }
    }
}