using System;
using Gtk;
using NetStandartLibrary;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnPressed(object sender, EventArgs e)
    {
        var dialog = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, ClassWriter.WriteHello(this.UserName.Text));

        dialog.Run();
        dialog.Destroy();
    }
}
