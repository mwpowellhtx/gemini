﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Gemini.Demo.Modules.Home.ViewModels;
using Gemini.Framework;
using Gemini.Framework.Results;
using Gemini.Modules.MainMenu.Models;
using Gemini.Modules.PropertyGrid;

namespace Gemini.Demo.Modules.Home
{
	[Export(typeof(IModule))]
	public class Module : ModuleBase
	{
		[Import]
		private IPropertyGrid _propertyGrid;

		public override void Initialize()
		{
			MainMenu.All
				.First(x => x.Name == "View")
				.Add(new MenuItem("Home", OpenHome));

            MainMenu.All
                .First(x => x.Name == "View")
                .Add(new MenuItem("Cube", OpenCube));
		}

        public override void PostInitialize()
        {
            var homeViewModel = IoC.Get<HomeViewModel>();
            Shell.OpenDocument(homeViewModel);
            Shell.OpenDocument(IoC.Get<HelixViewModel>());
            _propertyGrid.SelectedObject = homeViewModel;
        }

		private IEnumerable<IResult> OpenHome()
		{
			yield return Show.Document<HomeViewModel>();
		}

        private IEnumerable<IResult> OpenCube()
        {
            yield return Show.Document<HelixViewModel>();
        }
	}
}