using System;
using Terminal.Gui;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();

            var top = Application.Top;

            var win = new Window("Hello")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 1
            };

            int count = 0;
            var ml = new Label(new Rect(3, 17, 47, 1), "Mouse: ");
            var dupa = new Label(new Rect(3, 13, 47, 1), "DUPA!");
            Application.RootMouseEvent += (MouseEvent me) => ml.Text = $"Mouse: ({me.X},{me.Y}) - {me.Flags} {count++}";

            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_Quit", "", () => { if (Quit ()) Application.RequestStop(); })
                })
            });

            win.Add(ml);

            top.Add(win, menu);
            Application.Run();
            Application.Driver.End();
        }

        static bool Quit()
        {
            var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
            return n == 0;
        }
    }
}
