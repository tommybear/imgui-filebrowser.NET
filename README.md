# imgui-filebrowser.NET

[imgui-filebrowser.NET](https://github.com/tommybear/imgui-filebrowser.NET) is a single .cs file browser implementation for [MonoGame.ImGuiNet](https://github.com/Mezo-hx/MonoGame.ImGuiNet).

![image](https://github.com/tommybear/imgui-filebrowser.NET/assets/1712535/ffd7ed68-bd9c-4744-beba-999db306501b)


## Getting Started

Instead of creating a file dialog with an immediate function call, you need to create a `FileBrowser` instance, open it with member function `Open()`, and call `Display()` in each frame. Here is a simple example:

```cs
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using ImGuiNET;
using FileBrowser;
using MonoGame.ImGuiNet;
using System.Diagnostics;

namespace ImguiFileBrowserNet
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private imFileBrowser fileBrowser;
        ImGuiRenderer GuiRenderer;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            GuiRenderer = new ImGuiRenderer(this);
            GuiRenderer.RebuildFontAtlas();

            fileBrowser = new imFileBrowser(0);
            fileBrowser.SetTitle("File Browser");
            fileBrowser.SetPwd(".");
            fileBrowser.SetTypeFilters(new string[] { "*.png", "*.bmp", "*.*" }.ToList<string>());
            // Not yet implemented
            //fileBrowser.SetOkButtonLabel("Select");
            //fileBrowser.SetCancelButtonLabel("Cancel");
            fileBrowser.SetWindowPos(0, 300);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        private void DrawImGuiMenuBar()
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem("Open", "Ctrl+O")) { fileBrowser.Open(); }
                    ImGui.EndMenu();
                }
                ImGui.EndMainMenuBar();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            GuiRenderer.BeginLayout(gameTime);

            DrawImGuiMenuBar();

            fileBrowser.Display();

            if(fileBrowser.HasSelected())
            {
                foreach (var file in fileBrowser.GetSelected())
                {
                    Debug.WriteLine(file);
                }
            }

            if(fileBrowser.HasCancelled())
            {
                Debug.WriteLine("Cancelled");
            }

            GuiRenderer.EndLayout();
            base.Draw(gameTime);
        }
    }
}
```

## Options

Various options can be combined with '|' and passed to the constructor:

```cs
public enum ImGuiFileBrowserFlags
{
    None = 0,
    SelectDirectory = 1 << 0, // select directory instead of regular file
    EnterNewFilename = 1 << 1, // allow user to enter new filename when selecting regular file
    NoModal = 1 << 2, // file browsing window is modal by default. specify this to use a popup window
    NoTitleBar = 1 << 3, // hide window title bar
    NoStatusBar = 1 << 4, // hide status bar at the bottom of browsing window
    CloseOnEsc = 1 << 5, // close file browser when pressing 'ESC'
    CreateNewDir = 1 << 6, // allow user to create new directory
    MultipleSelection = 1 << 7, // allow user to select multiple files. this will hide ImGuiFileBrowserFlags_EnterNewFilename
    HideRegularFiles = 1 << 8, // hide regular files when ImGuiFileBrowserFlags_SelectDirectory is enabled
    ConfirmOnEnter = 1 << 9, // confirm selection when pressnig 'ENTER'
}
```

Here are some common examples:

```cs
// select single regular file for opening
0
// select multiple regular files for opening
ImGuiFileBrowserFlags_MultipleSelection
// select single directory for opening
ImGuiFileBrowserFlags_SelectDirectory
// select multiple directories for opening
ImGuiFileBrowserFlags_SelectDirectory | ImGuiFileBrowserFlags_MultipleSelection
// select single regular file for saving
ImGuiFileBrowserFlags_EnterNewFilename | ImGuiFileBrowserFlags_CreateNewDir
// select single directory for saving
ImGuiFileBrowserFlags_SelectDirectory | ImGuiFileBrowserFlags_CreateNewDir
// select single directory and hide regular files in browser
ImGuiFileBrowserFlags_SelectDirectory | ImGuiFileBrowserFlags_HideRegularFiles
```

## Usage

* double click to enter a directory
* single click to (de)select a regular file (or directory, when `ImGuiFileBrowserFlags_SelectDirectory` is enabled).
*  When `ImGuiFileBrowserFlags_SelectDirectory` is enabled and no directory is selected, click `ok` to choose the current directory as selected result.
*  When `ImGuiFileBrowserFlags_MultipleSelection` is enabled, hold  `Ctrl` for multi selection and `Shift` for range selection.  
*  When `ImGuiFileBrowserFlags_MultipleSelection` is enabled, use `Ctrl + A` to select all (filtered) items.
*  When `ImGuiFileBrowserFlags_CreateNewDir` is enabled, click the top-right little button "+" to create a new directory.
*  When `ImGuiFileBrowserFlags_SelectDirectory` is not specified,  double click to choose a regular file as selected result.

## Type Filters

* (optionally) use `browser.SetTypeFilters({"*.h", "*.cpp"})` to set file extension filters.
* "*.*" matches with any extension

This browser is cross platform.
