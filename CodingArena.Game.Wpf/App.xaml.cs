using CodingArena.Game.Entities;
using System;
using System.ComponentModel.Composition.Hosting;
using System.Windows;

namespace CodingArena.Game.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private CompositionContainer Container { get; }

        public App()
        {
            Container = ContainerFactory.Create();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            try
            {
                var game = Container.GetExportedValue<IGame>();
                var output = Container.GetExportedValue<IOutput>();
                output.Observe(game);
                var mainViewModel = Container.GetExportedValue<IMainViewModel>();
                mainViewModel.Game = game;
                mainViewModel.Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error during startup: {exception}");
            }
        }
    }
}
