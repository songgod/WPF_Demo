﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Resource
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LoadLanguage(); 
        }

        private void LoadLanguage()
        {
            CultureInfo currentCultureInfo = CultureInfo.CurrentCulture;
            ResourceDictionary langRd = null;
            try
            {
                langRd = Application.LoadComponent(new Uri(@"lang\" + currentCultureInfo.Name + ".xaml", UriKind.Relative))
                    as ResourceDictionary;
            }
            catch
            {
                
                throw;
            }
            if (langRd!=null)
            {
                if (this.Resources.MergedDictionaries.Count>0)
                {
                    this.Resources.MergedDictionaries.Clear();
                }
                this.Resources.MergedDictionaries.Add(langRd);
            }
        }
    }
}
