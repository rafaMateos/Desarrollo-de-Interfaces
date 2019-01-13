using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;

namespace ProbandoMonoGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //Para cargar esta imagen como una textura de sprite, abre Game1.cs y agrega las siguientes variables de clase.
        const float SKYRATIO = 2f / 3f;
        float screenWidth;
        float screenHeight;
        Texture2D grass;
        Texture2D gameOverTexture;
       

        SpriteClass dino;
        SpriteClass broccoli;

        bool spaceDown;
        bool gameStarted;
        bool gameOver;



        float broccoliSpeedMultiplier;
        float gravitySpeed;
        float dinoSpeedX;
        float dinoJumpY;
        float score;

        Random random;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
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

            //Las variables screenWidth y screenHeight deberán inicializarse, así que debes agregar este código al método Initialize:
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;

            screenHeight = ScaleToHighDPI((float)ApplicationView.GetForCurrentView().VisibleBounds.Height);
            screenWidth = ScaleToHighDPI((float)ApplicationView.GetForCurrentView().VisibleBounds.Width);

            broccoliSpeedMultiplier = 0.5f;
            spaceDown = false;
            gameOver = false;
            gameStarted = false;
            score = 0;
            random = new Random();
            dinoSpeedX = ScaleToHighDPI(1000f);
            dinoJumpY = ScaleToHighDPI(-1200f);
            gravitySpeed = ScaleToHighDPI(30f);

            this.IsMouseVisible = false;
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

            //Para cargar la textura en la variable de césped, agrega lo siguiente al método LoadContent:
            grass = Content.Load<Texture2D>("suelo");
           
            dino = new SpriteClass(GraphicsDevice,"person.png",ScaleToHighDPI(0.5f));
            broccoli = new SpriteClass(GraphicsDevice, "broccoli.png", ScaleToHighDPI(0.2f));

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
            // TODO: Add your update logic here
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            KeyboardHandler(); // Handle keyboard input
                               // Update animated SpriteClass objects based on their current rates of change
           dino.Update(elapsedTime);
            broccoli.Update(elapsedTime);

            // Accelerate the dino downward each frame to simulate gravity.
            dino.dY += gravitySpeed;

            // Set game floor so the player does not fall through it
            if (dino.y > screenHeight * SKYRATIO)
            {
                dino.dY = 0;
                dino.y = screenHeight * SKYRATIO;
            }

            // Set game edges to prevent the player from moving offscreen
            if (dino.x > screenWidth - dino.texture.Width / 2)
            {
                dino.x = screenWidth - dino.texture.Width / 2;
                dino.dX = 0;
            }
            if (dino.x < 0 + dino.texture.Width / 2)
            {
                dino.x = 0 + dino.texture.Width / 2;
                dino.dX = 0;
            }

            // If the broccoli goes offscreen, spawn a new one and iterate the score
            if (broccoli.y > screenHeight + 100 || broccoli.y < -100 || broccoli.x > screenWidth + 100 || broccoli.x < -100)
            {
                SpawnBroccoli();
                score++;
            }
            if (dino.RectangleCollision(broccoli)) {
                gameOver = true;
 
            } 
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
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(grass, new Rectangle(0, (int)(screenHeight * SKYRATIO),(int)screenWidth, (int)screenHeight), Color.White);
            broccoli.Draw(spriteBatch);
            dino.Draw(spriteBatch);
            base.Draw(gameTime);
            spriteBatch.End();

            
        }

        public float ScaleToHighDPI(float f)
        {
            DisplayInformation d = DisplayInformation.GetForCurrentView();
            f *= (float)d.RawPixelsPerViewPixel;
            return f;
        }

        //Queremos que el brécol se genere fuera de pantalla y se dirija hacia el avatar del jugador para que tenga que esquivarlo.Para ello, agrega este método a la clase de Game1.cs :
        public void SpawnBroccoli()
        {
            int direction = random.Next(1, 5);
            switch (direction)
            {
                case 1:
                    broccoli.x = -100;
                    broccoli.y = random.Next(0, (int)screenHeight);
                    break;
                case 2:
                    broccoli.y = -100;
                    broccoli.x = random.Next(0, (int)screenWidth);
                    break;
                case 3:
                    broccoli.x = screenWidth + 100;
                    broccoli.y = random.Next(0, (int)screenHeight);
                    break;
                case 4:
                    broccoli.y = screenHeight + 100;
                    broccoli.x = random.Next(0, (int)screenWidth);
                    break;
            }

            if (score % 5 == 0) broccoliSpeedMultiplier += 0.2f;

            broccoli.dX = (dino.x - broccoli.x) * broccoliSpeedMultiplier;
            broccoli.dY = (dino.y - broccoli.y) * broccoliSpeedMultiplier;
            broccoli.dA = 7f;
        }

        /*Antes de pasar al control de la entrada de teclado, 
         * es necesario un método que configure el estado inicial del juego de los dos objetos que creamos. 
         * En lugar de que el juego comience en cuanto se ejecute la aplicación, queremos que el usuario 
         * lo inicie manualmente al presionar la barra espaciadora. Agrega el código siguiente, que configura
         * el estado inicial de los objetos animados y restablece la puntuación:*/
        public void StartGame()
        {
            dino.x = screenWidth / 2;
            dino.y = screenHeight * SKYRATIO;
            broccoliSpeedMultiplier = 0.5f;
            SpawnBroccoli();
            score = 0;
        }

        /*
         A continuación, necesitamos un nuevo método para controlar la entrada de usuario mediante el teclado. Agrega este método a Game1.cs:*/
        void KeyboardHandler()
        {
            KeyboardState state = Keyboard.GetState();

            // Quit the game if Escape is pressed.
            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // Start the game if Space is pressed.
            if (!gameStarted)
            {
                if (state.IsKeyDown(Keys.Space))
                {
                    StartGame();
                    gameStarted = true;
                    spaceDown = true;
                    gameOver = false;
                }
                return;
                }
                // Jump if Space is pressed


                if (state.IsKeyDown(Keys.Space) || state.IsKeyDown(Keys.Up))
             {
                // Jump if the Space is pressed but not held and the dino is on the floor
                if (!spaceDown && dino.y >= screenHeight * SKYRATIO - 1) dino.dY = dinoJumpY;

                spaceDown = true;
            }
            else spaceDown = false;

            // Handle left and right
            if (state.IsKeyDown(Keys.Left)) dino.dX = dinoSpeedX * -1;

            else if (state.IsKeyDown(Keys.Right)) dino.dX = dinoSpeedX;
            else dino.dX = 0;
        }
    }
}
