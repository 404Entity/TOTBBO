using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
namespace T_L_O_B_O
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int ScreenWidth;
        public static int ScreenHeight;
        private Camera camera;


        // the Primary source for objects in the game 
        static private List<GameObject> gameObjectList;
        // The Remove list allows of to remove gameobject from the gameobject list
        List<GameObject> removeList;
        internal List<GameObject> RemoveList
        {
            get { return removeList; }
            set { removeList = value; }
        }
        // the Addlist allows us to add objects to the gameobject list
        private List<GameObject> addList;
        internal List<GameObject> AddList { get { return addList; } set { addList = value; } }

        private List<Collider> colliders;
        internal List<Collider> Colliders
        {
            get { return colliders; }
        }
        public float deltaTime;
        private EnemyPool enemypool;

        // sets the gameworld in a singletom Pattern(only allow one instance of the gameworld class)
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
            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;
            gameObjectList = new List<GameObject>();
            removeList = new List<GameObject>();
            addList = new List<GameObject>();
            colliders = new List<Collider>();
            enemypool = new EnemyPool();
            Director director = new Director(new PlayerBuilder());
            gameObjectList.Add(director.Construct(Vector2.Zero));
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera();
            foreach (GameObject item in gameObjectList)
            {
                item.LoadContent(Content);
            }

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
                if (item is Player)
                {
                    SpriteRenderer thatthing = (SpriteRenderer)item.GetComponent("Spriterenderer");
                    camera.Follow(item,thatthing);
                }
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
            spriteBatch.Begin();
            foreach (GameObject item in gameObjectList)
            {
                item.Draw(spriteBatch);
            }
            spriteBatch.End();
            spriteBatch.Begin(transformMatrix: camera.Transform);

            spriteBatch.End();
           
            base.Draw(gameTime);
        }
    }
}
