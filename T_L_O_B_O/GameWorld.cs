using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;


namespace T_L_O_B_O
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
     
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // the Primary list form where all objects are store
        static private List<GameObject> gameObjectList;

        // allows us to remove objects form the gameobject
        List<GameObject> removeList;
        internal List<GameObject> RemoveList
        {
            get { return removeList; }
            set { removeList = value; }
        }
        // allows us to add objects to the gameobjectlist
        private List<GameObject> addList;
        internal List<GameObject> AddList { get { return addList; } set { addList = value; } }


        private List<Collider> colliders;
        internal List<Collider> Colliders
        {
            get { return colliders; }
        }
        public float deltaTime;

        private EnemyPool enemypool;
        Map map;

        public static float ScreenWidth;
        public static float ScreenHeight;
        private Camera camera;
        private GameObject player, chest;
        private BackGround backGround = new BackGround();
        static private GameWorld instance;
        static public GameWorld Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                }
                return instance;
            }
        }
        //construcktor
        private GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.IsFullScreen = true;
            Window.AllowUserResizing = true;

            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;
            gameObjectList = new List<GameObject>();
            removeList = new List<GameObject>();
            addList = new List<GameObject>();
            colliders = new List<Collider>();
            enemypool = new EnemyPool();
            Director director = new Director(new PlayerBuilder());
            player = director.Construct(new Vector2(200,200));
            gameObjectList.Add(player);
            Director Chest = new Director(new ChestBuilder());
            Chest.Construct(new Vector2(-50, 200));
            
            map = new Map();
            
            base.Initialize();
        }

        Texture2D Chest;

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            foreach (GameObject item in gameObjectList)
            {
                item.LoadContent(Content);
            }
            map.LoadContent(Content);
            // instanciate the camera
            camera = new Camera();
            backGround.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.N))
            {
               AddList.Add(enemypool.Create());
            }
            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
                foreach (GameObject item in gameObjectList)
                {
                    if ((item.GetComponent("Enemy") != null))
                    {
                       enemypool.ReleaseObject(item);
                       break;
                    }
                }
            }

            foreach (GameObject item in gameObjectList)
            {
                item.Update(gameTime);
            }
            foreach (GameObject item in addList)
            {
                item.LoadContent(Content);
                gameObjectList.Add(item);
            }
            addList.Clear();
            foreach (GameObject item in removeList)
            {
                gameObjectList.Remove(item);
            }
       
            removeList.Clear();
            // TODO: Add your update logic here
            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;
            camera.Follow(player, (Collider)player.GetComponent("Collider"));
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin(transformMatrix: camera.Transform);
            backGround.Draw(spriteBatch);
            map.Draw(spriteBatch);
            foreach (GameObject item in gameObjectList)
            {
                item.Draw(spriteBatch);
            }
            spriteBatch.End();
            // UI Sprites not affektede
            spriteBatch.Begin();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
