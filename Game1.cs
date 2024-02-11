using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using ImGuiNET;
using FileBrowser;
using MonoGame.ImGuiNet;

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
            fileBrowser.Open();
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

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            GuiRenderer.BeginLayout(gameTime);
            fileBrowser.Display();
            ImGui.End();

            GuiRenderer.EndLayout();
            base.Draw(gameTime);
        }
    }
}
