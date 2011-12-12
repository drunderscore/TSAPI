using Hooks;




using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
namespace Terraria
{
	public class Main : Game
	{
		private const int MF_BYPOSITION = 1024;
		public const int sectionWidth = 200;
		public const int sectionHeight = 150;
		public const int maxTileSets = 145;
		public const int maxWallTypes = 29;
		public const int maxBackgrounds = 32;
		public const int maxDust = 2000;
		public const int maxCombatText = 100;
		public const int maxItemText = 20;
		public const int maxPlayers = 255;
		public const int maxChests = 1000;
		public const int maxItemTypes = 586;
		public const int maxItems = 200;
		public const int maxBuffs = 40;
		public const int maxProjectileTypes = 109;
		public const int maxProjectiles = 1000;
		public const int maxNPCTypes = 142;
		public const int maxNPCs = 200;
		public const int maxGoreTypes = 157;
		public const int maxGore = 200;
		public const int maxInventory = 48;
		public const int maxItemSounds = 37;
		public const int maxNPCHitSounds = 10;
		public const int maxNPCKilledSounds = 14;
		public const int maxLiquidTypes = 2;
		public const int maxMusic = 14;
		public const int numArmorHead = 44;
		public const int numArmorBody = 25;
		public const int numArmorLegs = 24;
		public const double dayLength = 54000.0;
		public const double nightLength = 32400.0;
		public const int maxStars = 130;
		public const int maxStarTypes = 5;
		public const int maxClouds = 100;
		public const int maxCloudTypes = 4;
		public const int maxHair = 36;
		public static int curRelease = 36;
		public static string versionNumber = "v1.1";
		public static string versionNumber2 = "v1.1";
		public static bool skipMenu = false;
		public static bool verboseNetplay = false;
		public static bool stopTimeOuts = false;
		public static bool showSpam = false;
		public static bool showItemOwner = false;
		public static int oldTempLightCount = 0;
		public static int musicBox = -1;
		public static int musicBox2 = -1;
		public static float upTimer;
		public static float upTimerMax;
		public static float upTimerMaxDelay;
		public static float[] drawTimer = new float[10];
		public static float[] drawTimerMax = new float[10];
		public static float[] drawTimerMaxDelay = new float[10];
		public static float[] renderTimer = new float[10];
		public static float[] lightTimer = new float[10];
		public static bool drawDiag = false;
		public static bool drawRelease = false;
		public static bool renderNow = false;
		public static bool drawToScreen = false;
		public static bool targetSet = false;
		public static int mouseX;
		public static int mouseY;
		public static bool mouseLeft;
		public static bool mouseRight;
		public static float essScale = 1f;
		public static int essDir = -1;
		public static string debugWords = "";
		public static bool gamePad = false;
		public static bool netDiag = false;
		public static int txData = 0;
		public static int rxData = 0;
		public static int txMsg = 0;
		public static int rxMsg = 0;
		public static int maxMsg = 61;
		public static int[] rxMsgType = new int[Main.maxMsg];
		public static int[] rxDataType = new int[Main.maxMsg];
		public static int[] txMsgType = new int[Main.maxMsg];
		public static int[] txDataType = new int[Main.maxMsg];
		public static float uCarry = 0f;
		public static bool drawSkip = false;
		public static int fpsCount = 0;
		public static Stopwatch fpsTimer = new Stopwatch();
		public static Stopwatch updateTimer = new Stopwatch();
		public bool gammaTest;
		public static bool showSplash = true;
		public static bool ignoreErrors = true;
		public static string defaultIP = "";
		public static int dayRate = 1;
		public static int maxScreenW = 1920;
		public static int minScreenW = 800;
		public static int maxScreenH = 1200;
		public static int minScreenH = 600;
		public static float iS = 1f;
		public static bool render = false;
		public static int qaStyle = 0;
		public static int zoneX = 99;
		public static int zoneY = 87;
		public static float harpNote = 0f;
		public static bool[] debuff = new bool[40];
		public static string[] buffName = new string[40];
		public static string[] buffTip = new string[40];
		public static int maxMP = 10;
		public static string[] recentWorld = new string[Main.maxMP];
		public static string[] recentIP = new string[Main.maxMP];
		public static int[] recentPort = new int[Main.maxMP];
		public static bool shortRender = true;
		public static int quickBG = 2;
		public static int bgDelay = 0;
		public static int bgStyle = 0;
		public static float[] bgAlpha = new float[10];
		public static float[] bgAlpha2 = new float[10];
		public bool showNPCs;
		public int mouseNPC = -1;
		public static int wof = -1;
		public static int wofT;
		public static int wofB;
		public static int wofF = 0;
		private static int offScreenRange = 200;
		private int firstTileX;
		private int lastTileX;
		private int firstTileY;
		private int lastTileY;
		private double bgParrallax;
		private int bgStart;
		private int bgLoops;
		private int bgStartY;
		private int bgLoopsY;
		private int bgTop;
		public static int renderCount = 99;
		private Process tServer = new Process();
		private static Stopwatch saveTime = new Stopwatch();
		public static Color mcColor = new Color(125, 125, 255);
		public static Color hcColor = new Color(200, 125, 255);
		public static Color bgColor;
		public static bool mouseHC = false;
		public static string chestText = "Chest";
		public static bool craftingHide = false;
		public static bool armorHide = false;
		public static float craftingAlpha = 1f;
		public static float armorAlpha = 1f;
		public static float[] buffAlpha = new float[40];
		public static Item trashItem = new Item();
		public static bool hardMode = false;
		public float chestLootScale = 1f;
		public bool chestLootHover;
		public float chestStackScale = 1f;
		public bool chestStackHover;
		public float chestDepositScale = 1f;
		public bool chestDepositHover;
		public static bool drawScene = false;
		public static Vector2 sceneWaterPos = default(Vector2);
		public static Vector2 sceneTilePos = default(Vector2);
		public static Vector2 sceneTile2Pos = default(Vector2);
		public static Vector2 sceneWallPos = default(Vector2);
		public static Vector2 sceneBackgroundPos = default(Vector2);
		public static bool maxQ = true;
		public static float gfxQuality = 1f;
		public static float gfxRate = 0.01f;
		public int DiscoStyle;
		public static int DiscoR = 255;
		public static int DiscoB = 0;
		public static int DiscoG = 0;
		public static int teamCooldown = 0;
		public static int teamCooldownLen = 300;
		public static bool gamePaused = false;
		public static int updateTime = 0;
		public static int drawTime = 0;
		public static int uCount = 0;
		public static int updateRate = 0;
		public static int frameRate = 0;
		public static bool RGBRelease = false;
		public static bool qRelease = false;
		public static bool netRelease = false;
		public static bool frameRelease = false;
		public static bool showFrameRate = false;
		public static int magmaBGFrame = 0;
		public static int magmaBGFrameCounter = 0;
		public static int saveTimer = 0;
		public static bool autoJoin = false;
		public static bool serverStarting = false;
		public static float leftWorld = 0f;
		public static float rightWorld = 134400f;
		public static float topWorld = 0f;
		public static float bottomWorld = 38400f;
		public static int maxTilesX = (int)Main.rightWorld / 16 + 1;
		public static int maxTilesY = (int)Main.bottomWorld / 16 + 1;
		public static int maxSectionsX = Main.maxTilesX / 200;
		public static int maxSectionsY = Main.maxTilesY / 150;
		public static int numDust = 2000;
		public static int maxNetPlayers = 255;
		public static string[] chrName = new string[142];
		public static int worldRate = 1;
		public static float caveParrallax = 1f;
		public static string[] tileName = new string[145];
		public static int dungeonX;
		public static int dungeonY;
		public static Liquid[] liquid = new Liquid[Liquid.resLiquid];
		public static LiquidBuffer[] liquidBuffer = new LiquidBuffer[10000];
		public static bool dedServ = false;
		public static int spamCount = 0;
		public static int curMusic = 0;
		public int newMusic;
		public static bool showItemText = true;
		public static bool autoSave = true;
		public static string buffString = "";
		public static string libPath = "";
		public static int lo = 0;
		public static int LogoA = 255;
		public static int LogoB = 0;
		public static bool LogoT = false;
		public static string statusText = "";
		public static string worldName = "";
		public static int worldID;
		public static int background = 0;
		public static Color tileColor;
		public static double worldSurface;
		public static double rockLayer;
		public static Color[] teamColor = new Color[5];
		public static bool dayTime = true;
		public static double time = 13500.0;
		public static int moonPhase = 0;
		public static short sunModY = 0;
		public static short moonModY = 0;
		public static bool grabSky = false;
		public static bool bloodMoon = false;
		public static int checkForSpawns = 0;
		public static int helpText = 0;
		public static bool autoGen = false;
		public static bool autoPause = false;
		public static int[] projFrames = new int[109];
		public static float demonTorch = 1f;
		public static int demonTorchDir = 1;
		public static int numStars;
		public static int cloudLimit = 100;
		public static int numClouds = Main.cloudLimit;
		public static float windSpeed = 0f;
		public static float windSpeedSpeed = 0f;
		public static Cloud[] cloud = new Cloud[100];
		public static bool resetClouds = true;
		public static int sandTiles;
		public static int evilTiles;
		public static int holyTiles;
		public static int meteorTiles;
		public static int jungleTiles;
		public static int dungeonTiles;
		public static int fadeCounter = 0;
		public static float invAlpha = 1f;
		public static float invDir = 1f;
		[ThreadStatic]
		public static Random rand;
		public static float[] musicFade = new float[14];
		public static float musicVolume = 0.75f;
		public static float soundVolume = 1f;
		public static bool[] tileLighted = new bool[145];
		public static bool[] tileMergeDirt = new bool[145];
		public static bool[] tileCut = new bool[145];
		public static bool[] tileAlch = new bool[145];
		public static int[] tileShine = new int[145];
		public static bool[] tileShine2 = new bool[145];
		public static bool[] wallHouse = new bool[29];
		public static int[] wallBlend = new int[29];
		public static bool[] tileStone = new bool[145];
		public static bool[] tilePick = new bool[145];
		public static bool[] tileAxe = new bool[145];
		public static bool[] tileHammer = new bool[145];
		public static bool[] tileWaterDeath = new bool[145];
		public static bool[] tileLavaDeath = new bool[145];
		public static bool[] tileTable = new bool[145];
		public static bool[] tileBlockLight = new bool[145];
		public static bool[] tileNoSunLight = new bool[145];
		public static bool[] tileDungeon = new bool[145];
		public static bool[] tileSolidTop = new bool[145];
		public static bool[] tileSolid = new bool[145];
		public static bool[] tileNoAttach = new bool[145];
		public static bool[] tileNoFail = new bool[145];
		public static bool[] tileFrameImportant = new bool[145];
		public static int[] backgroundWidth = new int[32];
		public static int[] backgroundHeight = new int[32];
		public static bool tilesLoaded = false;
		//public static Tile[,] tile = new Tile[Main.maxTilesX, Main.maxTilesY];
        public static TileCollection tile = new TileCollection();
		public static Dust[] dust = new Dust[2001];
		public static Star[] star = new Star[130];
		public static Item[] item = new Item[201];
		public static NPC[] npc = new NPC[201];
		public static Gore[] gore = new Gore[201];
		public static Projectile[] projectile = new Projectile[1001];
		public static CombatText[] combatText = new CombatText[100];
		public static ItemText[] itemText = new ItemText[20];
		public static Chest[] chest = new Chest[1000];
		public static Sign[] sign = new Sign[1000];
		public static Vector2 screenPosition;
		public static Vector2 screenLastPosition;
		public static int screenWidth = 800;
		public static int screenHeight = 600;
		public static int chatLength = 600;
		public static bool chatMode = false;
		public static bool chatRelease = false;
		public static int numChatLines = 7;
		public static string chatText = "";
		public static ChatLine[] chatLine = new ChatLine[Main.numChatLines];
		public static bool inputTextEnter = false;
		public static float[] hotbarScale = new float[]
		{
			1f, 
			0.75f, 
			0.75f, 
			0.75f, 
			0.75f, 
			0.75f, 
			0.75f, 
			0.75f, 
			0.75f, 
			0.75f
		};
		public static byte mouseTextColor = 0;
		public static int mouseTextColorChange = 1;
		public static bool mouseLeftRelease = false;
		public static bool mouseRightRelease = false;
		public static bool playerInventory = false;
		public static int stackSplit;
		public static int stackCounter = 0;
		public static int stackDelay = 7;
		public static Item mouseItem = new Item();
		public static Item guideItem = new Item();
		public static Item reforgeItem = new Item();
		private static float inventoryScale = 0.75f;
		public static bool hasFocus = true;
		public static Recipe[] recipe = new Recipe[Recipe.maxRecipes];
		public static int[] availableRecipe = new int[Recipe.maxRecipes];
		public static float[] availableRecipeY = new float[Recipe.maxRecipes];
		public static int numAvailableRecipes;
		public static int focusRecipe;
		public static int myPlayer = 0;
		public static Player[] player = new Player[256];
		public static int spawnTileX;
		public static int spawnTileY;
		public static bool npcChatRelease = false;
		public static bool editSign = false;
		public static string signText = "";
		public static string npcChatText = "";
		public static bool npcChatFocus1 = false;
		public static bool npcChatFocus2 = false;
		public static bool npcChatFocus3 = false;
		public static int npcShop = 0;
		public Chest[] shop = new Chest[9];
		public static bool craftGuide = false;
		public static bool reforge = false;
		private static Item toolTip = new Item();
		private static int backSpaceCount = 0;
		public static string motd = "";
		public bool toggleFullscreen;
		private int numDisplayModes;
		private int[] displayWidth = new int[99];
		private int[] displayHeight = new int[99];
		public static bool gameMenu = true;
		public static Player[] loadPlayer = new Player[5];
		public static string[] loadPlayerPath = new string[5];
		private static int numLoadPlayers = 0;
		public static string playerPathName;
		public static string[] loadWorld = new string[999];
		public static string[] loadWorldPath = new string[999];
		private static int numLoadWorlds = 0;
		public static string worldPathName;
		public static string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\My Games\\Terraria";
		public static string WorldPath = Main.SavePath + "\\Worlds";
		public static string PlayerPath = Main.SavePath + "\\Players";
		public static string[] itemName = new string[586];
		public static string[] npcName = new string[142];
		private static KeyboardState inputText;
		private static KeyboardState oldInputText;
		public static int invasionType = 0;
		public static double invasionX = 0.0;
		public static int invasionSize = 0;
		public static int invasionDelay = 0;
		public static int invasionWarn = 0;
		public static bool invasionDefeat = false;
		public static int[] npcFrameCount = new int[]
		{
			1, 
			2, 
			2, 
			3, 
			6, 
			2, 
			2, 
			1, 
			1, 
			1, 
			1, 
			1, 
			1, 
			1, 
			1, 
			1, 
			2, 
			16, 
			14, 
			16, 
			14, 
			15, 
			16, 
			2, 
			10, 
			1, 
			16, 
			16, 
			16, 
			3, 
			1, 
			15, 
			3, 
			1, 
			3, 
			1, 
			1, 
			16, 
			16, 
			1, 
			1, 
			1, 
			3, 
			3, 
			15, 
			3, 
			7, 
			7, 
			4, 
			5, 
			5, 
			5, 
			3, 
			3, 
			16, 
			6, 
			3, 
			6, 
			6, 
			2, 
			5, 
			3, 
			2, 
			7, 
			7, 
			4, 
			2, 
			8, 
			1, 
			5, 
			1, 
			2, 
			4, 
			16, 
			5, 
			4, 
			4, 
			15, 
			15, 
			15, 
			15, 
			2, 
			4, 
			6, 
			6, 
			18, 
			16, 
			1, 
			1, 
			1, 
			1, 
			1, 
			1, 
			4, 
			3, 
			1, 
			1, 
			1, 
			1, 
			1, 
			1, 
			5, 
			6, 
			7, 
			16, 
			1, 
			1, 
			16, 
			16, 
			12, 
			20, 
			21, 
			1, 
			2, 
			2, 
			3, 
			6, 
			1, 
			1, 
			1, 
			15, 
			4, 
			11, 
			1, 
			14, 
			6, 
			6, 
			3, 
			1, 
			2, 
			2, 
			1, 
			3, 
			4, 
			1, 
			2, 
			1, 
			4, 
			2, 
			1, 
			15, 
			3
		};
		private static bool mouseExit = false;
		private static float exitScale = 0.8f;
		private static bool mouseReforge = false;
		private static float reforgeScale = 0.8f;
		public static Player clientPlayer = new Player();
		public static string getIP = Main.defaultIP;
		public static string getPort = Convert.ToString(Netplay.serverPort);
		public static bool menuMultiplayer = false;
		public static bool menuServer = false;
		public static int netMode = 0;
		public static int timeOut = 120;
		public static int netPlayCounter;
		public static int lastNPCUpdate;
		public static int lastItemUpdate;
		public static int maxNPCUpdates = 5;
		public static int maxItemUpdates = 5;
		public static string cUp = "W";
		public static string cLeft = "A";
		public static string cDown = "S";
		public static string cRight = "D";
		public static string cJump = "Space";
		public static string cThrowItem = "T";
		public static string cInv = "Escape";
		public static string cHeal = "H";
		public static string cMana = "M";
		public static string cBuff = "B";
		public static string cHook = "E";
		public static string cTorch = "LeftShift";
		public static Color mouseColor = new Color(255, 50, 95);
		public static Color cursorColor = Color.White;
		public static int cursorColorDirection = 1;
		public static float cursorAlpha = 0f;
		public static float cursorScale = 0f;
		public static bool signBubble = false;
		public static int signX = 0;
		public static int signY = 0;
		public static bool hideUI = false;
		public static bool releaseUI = false;
		public static bool fixedTiming = false;
		private int splashCounter;
		public static string oldStatusText = "";
		public static bool autoShutdown = false;
		private float logoRotation;
		private float logoRotationDirection = 1f;
		private float logoRotationSpeed = 1f;
		private float logoScale = 1f;
		private float logoScaleDirection = 1f;
		private float logoScaleSpeed = 1f;
		private static int maxMenuItems = 14;
		private float[] menuItemScale = new float[Main.maxMenuItems];
		private int focusMenu = -1;
		private int selectedMenu = -1;
		private int selectedMenu2 = -1;
		private int selectedPlayer;
		private int selectedWorld;
		public static int menuMode = 0;
		private static Item cpItem = new Item();
		private int textBlinkerCount;
		private int textBlinkerState;
		public static string newWorldName = "";
		private static int accSlotCount = 0;
		private Color selColor = Color.White;
		private int focusColor;
		private int colorDelay;
		private int setKey = -1;
		private int bgScroll;
		public static bool autoPass = false;
		public static int menuFocus = 0;
		public static void LoadWorlds()
		{
			Directory.CreateDirectory(Main.WorldPath);
			string[] files = Directory.GetFiles(Main.WorldPath, "*.wld");
			int num = files.Length;
			if (!Main.dedServ && num > 5)
			{
				num = 5;
			}
			for (int i = 0; i < num; i++)
			{
				Main.loadWorldPath[i] = files[i];
				try
				{
					using (FileStream fileStream = new FileStream(Main.loadWorldPath[i], FileMode.Open))
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							binaryReader.ReadInt32();
							Main.loadWorld[i] = binaryReader.ReadString();
							binaryReader.Close();
						}
					}
				}
				catch
				{
					Main.loadWorld[i] = Main.loadWorldPath[i];
				}
			}
			Main.numLoadWorlds = num;
		}
		private static void LoadPlayers()
		{
			Directory.CreateDirectory(Main.PlayerPath);
			string[] files = Directory.GetFiles(Main.PlayerPath, "*.plr");
			int num = files.Length;
			if (num > 5)
			{
				num = 5;
			}
			for (int i = 0; i < 5; i++)
			{
				Main.loadPlayer[i] = new Player();
				if (i < num)
				{
					Main.loadPlayerPath[i] = files[i];
					Main.loadPlayer[i] = Player.LoadPlayer(Main.loadPlayerPath[i]);
				}
			}
			Main.numLoadPlayers = num;
		}
		protected void OpenRecent()
		{
			try
			{
				if (File.Exists(Main.SavePath + "\\servers.dat"))
				{
					using (FileStream fileStream = new FileStream(Main.SavePath + "\\servers.dat", FileMode.Open))
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							binaryReader.ReadInt32();
							for (int i = 0; i < 10; i++)
							{
								Main.recentWorld[i] = binaryReader.ReadString();
								Main.recentIP[i] = binaryReader.ReadString();
								Main.recentPort[i] = binaryReader.ReadInt32();
							}
						}
					}
				}
			}
			catch
			{
			}
		}
		public static void SaveRecent()
		{
			Directory.CreateDirectory(Main.SavePath);
			try
			{
				File.SetAttributes(Main.SavePath + "\\servers.dat", FileAttributes.Normal);
			}
			catch
			{
			}
			try
			{
				using (FileStream fileStream = new FileStream(Main.SavePath + "\\servers.dat", FileMode.Create))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
					{
						binaryWriter.Write(Main.curRelease);
						for (int i = 0; i < 10; i++)
						{
							binaryWriter.Write(Main.recentWorld[i]);
							binaryWriter.Write(Main.recentIP[i]);
							binaryWriter.Write(Main.recentPort[i]);
						}
					}
				}
			}
			catch
			{
			}
		}
		protected void SaveSettings()
		{
			Directory.CreateDirectory(Main.SavePath);
			try
			{
				File.SetAttributes(Main.SavePath + "\\config.dat", FileAttributes.Normal);
			}
			catch
			{
			}
			try
			{
				using (FileStream fileStream = new FileStream(Main.SavePath + "\\config.dat", FileMode.Create))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
					{
						binaryWriter.Write(Main.curRelease);
						binaryWriter.Write(this.graphics.IsFullScreen);
						binaryWriter.Write(Main.mouseColor.R);
						binaryWriter.Write(Main.mouseColor.G);
						binaryWriter.Write(Main.mouseColor.B);
						binaryWriter.Write(Main.soundVolume);
						binaryWriter.Write(Main.musicVolume);
						binaryWriter.Write(Main.cUp);
						binaryWriter.Write(Main.cDown);
						binaryWriter.Write(Main.cLeft);
						binaryWriter.Write(Main.cRight);
						binaryWriter.Write(Main.cJump);
						binaryWriter.Write(Main.cThrowItem);
						binaryWriter.Write(Main.cInv);
						binaryWriter.Write(Main.cHeal);
						binaryWriter.Write(Main.cMana);
						binaryWriter.Write(Main.cBuff);
						binaryWriter.Write(Main.cHook);
						binaryWriter.Write(Main.caveParrallax);
						binaryWriter.Write(Main.fixedTiming);
						binaryWriter.Write(this.graphics.PreferredBackBufferWidth);
						binaryWriter.Write(this.graphics.PreferredBackBufferHeight);
						binaryWriter.Write(Main.autoSave);
						binaryWriter.Write(Main.autoPause);
						binaryWriter.Write(Main.showItemText);
						binaryWriter.Write(Main.cTorch);
						binaryWriter.Write((byte)Lighting.lightMode);
						binaryWriter.Write((byte)Main.qaStyle);
						binaryWriter.Close();
					}
				}
			}
			catch
			{
			}
		}
		protected void OpenSettings()
		{
			try
			{
				if (File.Exists(Main.SavePath + "\\config.dat"))
				{
					using (FileStream fileStream = new FileStream(Main.SavePath + "\\config.dat", FileMode.Open))
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							int num = binaryReader.ReadInt32();
							bool flag = binaryReader.ReadBoolean();
							Main.mouseColor.R = binaryReader.ReadByte();
							Main.mouseColor.G = binaryReader.ReadByte();
							Main.mouseColor.B = binaryReader.ReadByte();
							Main.soundVolume = binaryReader.ReadSingle();
							Main.musicVolume = binaryReader.ReadSingle();
							Main.cUp = binaryReader.ReadString();
							Main.cDown = binaryReader.ReadString();
							Main.cLeft = binaryReader.ReadString();
							Main.cRight = binaryReader.ReadString();
							Main.cJump = binaryReader.ReadString();
							Main.cThrowItem = binaryReader.ReadString();
							if (num >= 1)
							{
								Main.cInv = binaryReader.ReadString();
							}
							if (num >= 12)
							{
								Main.cHeal = binaryReader.ReadString();
								Main.cMana = binaryReader.ReadString();
								Main.cBuff = binaryReader.ReadString();
							}
							if (num >= 13)
							{
								Main.cHook = binaryReader.ReadString();
							}
							Main.caveParrallax = binaryReader.ReadSingle();
							if (num >= 2)
							{
								Main.fixedTiming = binaryReader.ReadBoolean();
							}
							if (num >= 4)
							{
								this.graphics.PreferredBackBufferWidth = binaryReader.ReadInt32();
								this.graphics.PreferredBackBufferHeight = binaryReader.ReadInt32();
							}
							if (num >= 8)
							{
								Main.autoSave = binaryReader.ReadBoolean();
							}
							if (num >= 9)
							{
								Main.autoPause = binaryReader.ReadBoolean();
							}
							if (num >= 19)
							{
								Main.showItemText = binaryReader.ReadBoolean();
							}
							if (num >= 30)
							{
								Main.cTorch = binaryReader.ReadString();
								Lighting.lightMode = (int)binaryReader.ReadByte();
								Main.qaStyle = (int)binaryReader.ReadByte();
							}
							binaryReader.Close();
							if (flag && !this.graphics.IsFullScreen)
							{
								this.graphics.ToggleFullScreen();
							}
						}
					}
				}
			}
			catch
			{
			}
		}
		private static void ErasePlayer(int i)
		{
			try
			{
				File.Delete(Main.loadPlayerPath[i]);
				File.Delete(Main.loadPlayerPath[i] + ".bak");
				Main.LoadPlayers();
			}
			catch
			{
			}
		}
		private static void EraseWorld(int i)
		{
			try
			{
				File.Delete(Main.loadWorldPath[i]);
				File.Delete(Main.loadWorldPath[i] + ".bak");
				Main.LoadWorlds();
			}
			catch
			{
			}
		}
		private static string nextLoadPlayer()
		{
			int num = 1;
			while (File.Exists(string.Concat(new object[]
			{
				Main.PlayerPath, 
				"\\player", 
				num, 
				".plr"
			})))
			{
				num++;
			}
			return string.Concat(new object[]
			{
				Main.PlayerPath, 
				"\\player", 
				num, 
				".plr"
			});
		}
		private static string nextLoadWorld()
		{
			int num = 1;
			while (File.Exists(string.Concat(new object[]
			{
				Main.WorldPath, 
				"\\world", 
				num, 
				".wld"
			})))
			{
				num++;
			}
			return string.Concat(new object[]
			{
				Main.WorldPath, 
				"\\world", 
				num, 
				".wld"
			});
		}
		public void autoCreate(string newOpt)
		{
			if (newOpt == "0")
			{
				Main.autoGen = false;
				return;
			}
			if (newOpt == "1")
			{
				Main.maxTilesX = 4200;
				Main.maxTilesY = 1200;
				Main.autoGen = true;
				return;
			}
			if (newOpt == "2")
			{
				Main.maxTilesX = 6300;
				Main.maxTilesY = 1800;
				Main.autoGen = true;
				return;
			}
			if (newOpt == "3")
			{
				Main.maxTilesX = 8400;
				Main.maxTilesY = 2400;
				Main.autoGen = true;
			}
		}
		public void NewMOTD(string newMOTD)
		{
			Main.motd = newMOTD;
		}
		public void LoadDedConfig(string configPath)
		{
			if (File.Exists(configPath))
			{
				using (StreamReader streamReader = new StreamReader(configPath))
				{
					string text;
					while ((text = streamReader.ReadLine()) != null)
					{
						try
						{
							if (text.Length > 6 && text.Substring(0, 6).ToLower() == "world=")
							{
								string text2 = text.Substring(6);
								Main.worldPathName = text2;
							}
							if (text.Length > 5 && text.Substring(0, 5).ToLower() == "port=")
							{
								string value = text.Substring(5);
								try
								{
									int serverPort = Convert.ToInt32(value);
									Netplay.serverPort = serverPort;
								}
								catch
								{
								}
							}
							if (text.Length > 11 && text.Substring(0, 11).ToLower() == "maxplayers=")
							{
								string value2 = text.Substring(11);
								try
								{
									int num = Convert.ToInt32(value2);
									Main.maxNetPlayers = num;
								}
								catch
								{
								}
							}
							if (text.Length > 11 && text.Substring(0, 9).ToLower() == "priority=")
							{
								string value3 = text.Substring(9);
								try
								{
									int num2 = Convert.ToInt32(value3);
									if (num2 >= 0 && num2 <= 5)
									{
										Process currentProcess = Process.GetCurrentProcess();
										if (num2 == 0)
										{
											currentProcess.PriorityClass = ProcessPriorityClass.RealTime;
										}
										else
										{
											if (num2 == 1)
											{
												currentProcess.PriorityClass = ProcessPriorityClass.High;
											}
											else
											{
												if (num2 == 2)
												{
													currentProcess.PriorityClass = ProcessPriorityClass.AboveNormal;
												}
												else
												{
													if (num2 == 3)
													{
														currentProcess.PriorityClass = ProcessPriorityClass.Normal;
													}
													else
													{
														if (num2 == 4)
														{
															currentProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
														}
														else
														{
															if (num2 == 5)
															{
																currentProcess.PriorityClass = ProcessPriorityClass.Idle;
															}
														}
													}
												}
											}
										}
									}
								}
								catch
								{
								}
							}
							if (text.Length > 9 && text.Substring(0, 9).ToLower() == "password=")
							{
								string password = text.Substring(9);
								Netplay.password = password;
							}
							if (text.Length > 5 && text.Substring(0, 5).ToLower() == "motd=")
							{
								string text3 = text.Substring(5);
								Main.motd = text3;
							}
							if (text.Length >= 10 && text.Substring(0, 10).ToLower() == "worldpath=")
							{
								string worldPath = text.Substring(10);
								Main.WorldPath = worldPath;
							}
							if (text.Length >= 10 && text.Substring(0, 10).ToLower() == "worldname=")
							{
								string text4 = text.Substring(10);
								Main.worldName = text4;
							}
							if (text.Length > 8 && text.Substring(0, 8).ToLower() == "banlist=")
							{
								string banFile = text.Substring(8);
								Netplay.banFile = banFile;
							}
							if (text.Length > 11 && text.Substring(0, 11).ToLower() == "autocreate=")
							{
								string a = text.Substring(11);
								if (a == "0")
								{
									Main.autoGen = false;
								}
								else
								{
									if (a == "1")
									{
										Main.maxTilesX = 4200;
										Main.maxTilesY = 1200;
										Main.autoGen = true;
									}
									else
									{
										if (a == "2")
										{
											Main.maxTilesX = 6300;
											Main.maxTilesY = 1800;
											Main.autoGen = true;
										}
										else
										{
											if (a == "3")
											{
												Main.maxTilesX = 8400;
												Main.maxTilesY = 2400;
												Main.autoGen = true;
											}
										}
									}
								}
							}
							if (text.Length > 7 && text.Substring(0, 7).ToLower() == "secure=")
							{
								string a2 = text.Substring(7);
								if (a2 == "1")
								{
									Netplay.spamCheck = true;
								}
							}
						}
						catch
						{
						}
					}
				}
			}
		}
		public void SetNetPlayers(int mPlayers)
		{
			Main.maxNetPlayers = mPlayers;
		}
		public void SetWorld(string wrold)
		{
			Main.worldPathName = wrold;
		}
		public void SetWorldName(string wrold)
		{
			Main.worldName = wrold;
		}
		public void autoShut()
		{
			Main.autoShutdown = true;
		}
		public void AutoPass()
		{
			Main.autoPass = true;
		}
		public void AutoJoin(string IP)
		{
			Main.defaultIP = IP;
			Main.getIP = IP;
			Netplay.SetIP(Main.defaultIP);
			Main.autoJoin = true;
		}
		public void AutoHost()
		{
			Main.menuMultiplayer = true;
			Main.menuServer = true;
			Main.menuMode = 1;
		}
		public void loadLib(string path)
		{
			Main.libPath = path;
			Main.LoadLibrary(Main.libPath);
		}
		public void DedServ()
		{
            GameHooks.OnInitialize(true);
			Main.rand = new Random();
			if (Main.autoShutdown)
			{
				string text = "terraria" + Main.rand.Next(2147483647);
				Console.Title = text;
				IntPtr intPtr = Main.FindWindow(null, text);
				if (intPtr != IntPtr.Zero)
				{
					Main.ShowWindow(intPtr, 0);
				}
			}
			else
			{
				Console.Title = "Terraria Server " + Main.versionNumber2;
			}
			Main.dedServ = true;
			Main.showSplash = false;
			this.Initialize();
            /*var npcstring = "";
            for (int i = -17; i < Terraria.Main.maxNPCTypes; i++)
            {
                var Npc = new Terraria.NPC();
                Npc.netDefaults(i);
                npcstring += string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}\t{16}\t{17}\n",
                    Npc.type, Npc.netID, Npc.name, Npc.life, Npc.damage, Npc.defense, Npc.knockBackResist, Npc.noGravity, Npc.value,
                    Npc.friendly, Npc.noTileCollide, Npc.aiStyle, Npc.scale, Npc.boss, Npc.lavaImmune, Npc.townNPC,
                    Npc.height, Npc.width);
            }
            File.WriteAllText("npc.txt", npcstring);
            var itemstring = "";
            for (int i = -24; i < Terraria.Main.maxItemTypes; i++)
            {
                var item = new Terraria.Item();
                item.netDefaults(i);
                itemstring += item.type + "\t" + item.name + "\n";
            }
            File.WriteAllText("item.txt", itemstring);
            var prefixstring = "";
            for (int i = 1; i < 84; i++)
            {
                Item item = new Item();
                item.SetDefaults(0);
                item.prefix = (byte)i;
                prefixstring += i + "\t" + item.AffixName() + "\n";
            }
		    File.WriteAllText("prefix.txt", prefixstring);*/
			for (int i = 0; i < 142; i++)
			{
				NPC nPC = new NPC();
				nPC.SetDefaults(i, -1f);
				Main.npcName[i] = nPC.name;
			}
            while (Main.worldPathName == null || Main.worldPathName == "")
            {
                Main.LoadWorlds();
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Terraria Server " + Main.versionNumber2);
                    Console.WriteLine("");
                    for (int j = 0; j < Main.numLoadWorlds; j++)
                    {
                        Console.WriteLine(string.Concat(new object[]
                                                            {
                                                                j + 1,
                                                                '\t',
                                                                '\t',
                                                                Main.loadWorld[j]
                                                            }));
                    }
                    Console.WriteLine(string.Concat(new object[]
                                                        {
                                                            "n",
                                                            '\t',
                                                            '\t',
                                                            "New World"
                                                        }));
                    Console.WriteLine("d <number>" + '\t' + "Delete World");
                    Console.WriteLine("");
                    Console.Write("Choose World: ");
                    string text2 = Console.ReadLine();
                    try
                    {
                        Console.Clear();
                    }
                    catch
                    {
                    }
                    if (text2.Length >= 2 && text2.Substring(0, 2).ToLower() == "d ")
                    {
                        try
                        {
                            int num = Convert.ToInt32(text2.Substring(2)) - 1;
                            if (num < Main.numLoadWorlds)
                            {
                                Console.WriteLine("Terraria Server " + Main.versionNumber2);
                                Console.WriteLine("");
                                Console.WriteLine("Really delete " + Main.loadWorld[num] + "?");
                                Console.Write("(y/n): ");
                                string text3 = Console.ReadLine();
                                if (text3.ToLower() == "y")
                                {
                                    Main.EraseWorld(num);
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            Console.Clear();
                            continue;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    if (text2 == "n" || text2 == "N")
                    {
                        bool flag2 = true;
                        while (flag2)
                        {
                            Console.WriteLine("Terraria Server " + Main.versionNumber2);
                            Console.WriteLine("");
                            Console.WriteLine("1" + '\t' + "Small");
                            Console.WriteLine("2" + '\t' + "Medium");
                            Console.WriteLine("3" + '\t' + "Large");
                            Console.WriteLine("");
                            Console.Write("Choose size: ");
                            string value = Console.ReadLine();
                            try
                            {
                                int num2 = Convert.ToInt32(value);
                                if (num2 == 1)
                                {
                                    Main.maxTilesX = 4200;
                                    Main.maxTilesY = 1200;
                                    flag2 = false;
                                }
                                else
                                {
                                    if (num2 == 2)
                                    {
                                        Main.maxTilesX = 6300;
                                        Main.maxTilesY = 1800;
                                        flag2 = false;
                                    }
                                    else
                                    {
                                        if (num2 == 3)
                                        {
                                            Main.maxTilesX = 8400;
                                            Main.maxTilesY = 2400;
                                            flag2 = false;
                                        }
                                    }
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                Console.Clear();
                            }
                            catch
                            {
                            }
                        }
                        flag2 = true;
                        while (flag2)
                        {
                            Console.WriteLine("Terraria Server " + Main.versionNumber2);
                            Console.WriteLine("");
                            Console.Write("Enter world name: ");
                            Main.newWorldName = Console.ReadLine();
                            if (Main.newWorldName != "" && Main.newWorldName != " " && Main.newWorldName != null)
                            {
                                flag2 = false;
                            }
                            try
                            {
                                Console.Clear();
                            }
                            catch
                            {
                            }
                        }
                        Main.worldName = Main.newWorldName;
                        Main.worldPathName = Main.nextLoadWorld();
                        Main.menuMode = 10;
                        WorldGen.CreateNewWorld();
                        flag2 = false;
                        while (Main.menuMode == 10)
                        {
                            if (Main.oldStatusText != Main.statusText)
                            {
                                Main.oldStatusText = Main.statusText;
                                Console.WriteLine(Main.statusText);
                            }
                        }
                        try
                        {
                            Console.Clear();
                            continue;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    try
                    {
                        int num3 = Convert.ToInt32(text2);
                        num3--;
                        if (num3 >= 0 && num3 < Main.numLoadWorlds)
                        {
                            bool flag3 = true;
                            while (flag3)
                            {
                                Console.WriteLine("Terraria Server " + Main.versionNumber2);
                                Console.WriteLine("");
                                Console.Write("Max players (press enter for 8): ");
                                string text4 = Console.ReadLine();
                                try
                                {
                                    if (text4 == "")
                                    {
                                        text4 = "8";
                                    }
                                    int num4 = Convert.ToInt32(text4);
                                    if (num4 <= 255 && num4 >= 1)
                                    {
                                        Main.maxNetPlayers = num4;
                                        flag3 = false;
                                    }
                                    flag3 = false;
                                }
                                catch
                                {
                                }
                                try
                                {
                                    Console.Clear();
                                }
                                catch
                                {
                                }
                            }
                            flag3 = true;
                            while (flag3)
                            {
                                Console.WriteLine("Terraria Server " + Main.versionNumber2);
                                Console.WriteLine("");
                                Console.Write("Server port (press enter for 7777): ");
                                string text5 = Console.ReadLine();
                                try
                                {
                                    if (text5 == "")
                                    {
                                        text5 = "7777";
                                    }
                                    int num5 = Convert.ToInt32(text5);
                                    if (num5 <= 65535)
                                    {
                                        Netplay.serverPort = num5;
                                        flag3 = false;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    Console.Clear();
                                }
                                catch
                                {
                                }
                            }
                            Console.WriteLine("Terraria Server " + Main.versionNumber2);
                            Console.WriteLine("");
                            Console.Write("Server password (press enter for none): ");
                            Netplay.password = Console.ReadLine();
                            Main.worldPathName = Main.loadWorldPath[num3];
                            flag = false;
                            try
                            {
                                Console.Clear();
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
		    try
			{
				Console.Clear();
			}
			catch
			{
			}
			WorldGen.serverLoadWorld();
			Console.WriteLine("Terraria Server " + Main.versionNumber);
			Console.WriteLine("");
			while (!Netplay.ServerUp)
			{
				if (Main.oldStatusText != Main.statusText)
				{
					Main.oldStatusText = Main.statusText;
					Console.WriteLine(Main.statusText);
				}
			}
			try
			{
				Console.Clear();
			}
			catch
			{
			}
			Console.WriteLine("Terraria Server " + Main.versionNumber);
			Console.WriteLine("");
			Console.WriteLine("Listening on port " + Netplay.serverPort);
			Console.WriteLine("Type 'help' for a list of commands.");
			Console.WriteLine("");
			Console.Title = "Terraria Server: " + Main.worldName;
			Stopwatch stopwatch = new Stopwatch();
			if (!Main.autoShutdown)
			{
				Main.startDedInput();
			}
            GameHooks.OnInitialize(false);
			stopwatch.Start();
			double num6 = 16.666666666666668;
			double num7 = 0.0;
			int num8 = 0;
			Stopwatch stopwatch2 = new Stopwatch();
			stopwatch2.Start();
			while (!Netplay.disconnect)
			{
				double num9 = (double)stopwatch.ElapsedMilliseconds;
				if (num9 + num7 >= num6)
				{
					num8++;
					num7 += num9 - num6;
					stopwatch.Reset();
					stopwatch.Start();
					if (Main.oldStatusText != Main.statusText)
					{
						Main.oldStatusText = Main.statusText;
						Console.WriteLine(Main.statusText);
					}
					if (num7 > 1000.0)
					{
						num7 = 1000.0;
					}
					if (Netplay.anyClients)
					{
                        GameHooks.OnUpdate(true);
						this.Update(new GameTime());
                        GameHooks.OnUpdate(false);
					}
					double num10 = (double)stopwatch.ElapsedMilliseconds + num7;
					if (num10 < num6)
					{
						int num11 = (int)(num6 - num10) - 1;
						if (num11 > 1)
						{
							Thread.Sleep(num11);
							if (!Netplay.anyClients)
							{
								num7 = 0.0;
								Thread.Sleep(10);
							}
						}
					}
				}
				Thread.Sleep(0);
			}
		}
		public static void startDedInput()
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(Main.startDedInputCallBack), 1);
		}
		public static void startDedInputCallBack(object threadContext)
		{
			while (!Netplay.disconnect)
			{
				Console.Write(": ");
				string text = Console.ReadLine();
                if (!ServerHooks.OnCommand(text))
                {
                    string text2 = text;
                    text = text.ToLower();
                    try
                    {
                        if (text == "help")
                        {
                            Console.WriteLine("Available commands:");
                            Console.WriteLine("");
                            Console.WriteLine(string.Concat(new object[]
                                                                {
                                                                    "help ",
                                                                    '\t',
                                                                    '\t',
                                                                    " Displays a list of commands."
                                                                }));
                            Console.WriteLine("playing " + '\t' + " Shows the list of players");
                            Console.WriteLine(string.Concat(new object[]
                                                                {
                                                                    "clear ",
                                                                    '\t',
                                                                    '\t',
                                                                    " Clear the console window."
                                                                }));
                            Console.WriteLine(string.Concat(new object[]
                                                                {
                                                                    "exit ",
                                                                    '\t',
                                                                    '\t',
                                                                    " Shutdown the server and save."
                                                                }));
                            Console.WriteLine("exit-nosave " + '\t' + " Shutdown the server without saving.");
                            Console.WriteLine(string.Concat(new object[]
                                                                {
                                                                    "save ",
                                                                    '\t',
                                                                    '\t',
                                                                    " Save the game world."
                                                                }));
                            Console.WriteLine("kick <player> " + '\t' + " Kicks a player from the server.");
                            Console.WriteLine("ban <player> " + '\t' + " Bans a player from the server.");
                            Console.WriteLine("password" + '\t' + " Show password.");
                            Console.WriteLine("password <pass>" + '\t' + " Change password.");
                            Console.WriteLine(string.Concat(new object[]
                                                                {
                                                                    "version",
                                                                    '\t',
                                                                    '\t',
                                                                    " Print version number."
                                                                }));
                            Console.WriteLine(string.Concat(new object[]
                                                                {
                                                                    "time",
                                                                    '\t',
                                                                    '\t',
                                                                    " Display game time."
                                                                }));
                            Console.WriteLine(string.Concat(new object[]
                                                                {
                                                                    "port",
                                                                    '\t',
                                                                    '\t',
                                                                    " Print the listening port."
                                                                }));
                            Console.WriteLine("maxplayers" + '\t' + " Print the max number of players.");
                            Console.WriteLine("say <words>" + '\t' + " Send a message.");
                            Console.WriteLine(string.Concat(new object[]
                                                                {
                                                                    "motd",
                                                                    '\t',
                                                                    '\t',
                                                                    " Print MOTD."
                                                                }));
                            Console.WriteLine("motd <words>" + '\t' + " Change MOTD.");
                            Console.WriteLine(string.Concat(new object[]
                                                                {
                                                                    "dawn",
                                                                    '\t',
                                                                    '\t',
                                                                    " Change time to dawn."
                                                                }));
                            Console.WriteLine(string.Concat(new object[]
                                                                {
                                                                    "noon",
                                                                    '\t',
                                                                    '\t',
                                                                    " Change time to noon."
                                                                }));
                            Console.WriteLine(string.Concat(new object[]
                                                                {
                                                                    "dusk",
                                                                    '\t',
                                                                    '\t',
                                                                    " Change time to dusk."
                                                                }));
                            Console.WriteLine("midnight" + '\t' + " Change time to midnight.");
                            Console.WriteLine(string.Concat(new object[]
                                                                {
                                                                    "settle",
                                                                    '\t',
                                                                    '\t',
                                                                    " Settle all water."
                                                                }));
                        }
                        else
                        {
                            if (text == "settle")
                            {
                                if (!Liquid.panicMode)
                                {
                                    Liquid.StartPanic();
                                }
                                else
                                {
                                    Console.WriteLine("Water is already settling");
                                }
                            }
                            else
                            {
                                if (text == "dawn")
                                {
                                    Main.dayTime = true;
                                    Main.time = 0.0;
                                    NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                                }
                                else
                                {
                                    if (text == "dusk")
                                    {
                                        Main.dayTime = false;
                                        Main.time = 0.0;
                                        NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                                    }
                                    else
                                    {
                                        if (text == "noon")
                                        {
                                            Main.dayTime = true;
                                            Main.time = 27000.0;
                                            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                                        }
                                        else
                                        {
                                            if (text == "midnight")
                                            {
                                                Main.dayTime = false;
                                                Main.time = 16200.0;
                                                NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                                            }
                                            else
                                            {
                                                if (text == "exit-nosave")
                                                {
                                                    Netplay.disconnect = true;
                                                }
                                                else
                                                {
                                                    if (text == "exit")
                                                    {
                                                        WorldGen.saveWorld(false);
                                                        Netplay.disconnect = true;
                                                    }
                                                    else
                                                    {
                                                        if (text == "save")
                                                        {
                                                            WorldGen.saveWorld(false);
                                                        }
                                                        else
                                                        {
                                                            if (text == "time")
                                                            {
                                                                string text3 = "AM";
                                                                double num = Main.time;
                                                                if (!Main.dayTime)
                                                                {
                                                                    num += 54000.0;
                                                                }
                                                                num = num/86400.0*24.0;
                                                                double num2 = 7.5;
                                                                num = num - num2 - 12.0;
                                                                if (num < 0.0)
                                                                {
                                                                    num += 24.0;
                                                                }
                                                                if (num >= 12.0)
                                                                {
                                                                    text3 = "PM";
                                                                }
                                                                int num3 = (int) num;
                                                                double num4 = num - (double) num3;
                                                                num4 = (double) ((int) (num4*60.0));
                                                                string text4 = string.Concat(num4);
                                                                if (num4 < 10.0)
                                                                {
                                                                    text4 = "0" + text4;
                                                                }
                                                                if (num3 > 12)
                                                                {
                                                                    num3 -= 12;
                                                                }
                                                                if (num3 == 0)
                                                                {
                                                                    num3 = 12;
                                                                }
                                                                Console.WriteLine(string.Concat(new object[]
                                                                                                    {
                                                                                                        "Time: ",
                                                                                                        num3,
                                                                                                        ":",
                                                                                                        text4,
                                                                                                        " ",
                                                                                                        text3
                                                                                                    }));
                                                            }
                                                            else
                                                            {
                                                                if (text == "maxplayers")
                                                                {
                                                                    Console.WriteLine("Player limit: " + Main.maxNetPlayers);
                                                                }
                                                                else
                                                                {
                                                                    if (text == "port")
                                                                    {
                                                                        Console.WriteLine("Port: " + Netplay.serverPort);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (text == "version")
                                                                        {
                                                                            Console.WriteLine("Terraria Server " + Main.versionNumber);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (text == "clear")
                                                                            {
                                                                                try
                                                                                {
                                                                                    Console.Clear();
                                                                                    continue;
                                                                                }
                                                                                catch
                                                                                {
                                                                                    continue;
                                                                                }
                                                                            }
                                                                            if (text == "playing")
                                                                            {
                                                                                int num5 = 0;
                                                                                for (int i = 0; i < 255; i++)
                                                                                {
                                                                                    if (Main.player[i].active)
                                                                                    {
                                                                                        num5++;
                                                                                        Console.WriteLine(string.Concat(new object[]
                                                                                                                            {
                                                                                                                                Main.player[i].name,
                                                                                                                                " (",
                                                                                                                                Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint,
                                                                                                                                ")"
                                                                                                                            }));
                                                                                    }
                                                                                }
                                                                                if (num5 == 0)
                                                                                {
                                                                                    Console.WriteLine("No players connected.");
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (num5 == 1)
                                                                                    {
                                                                                        Console.WriteLine("1 player connected.");
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine(num5 + " players connected.");
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (!(text == ""))
                                                                                {
                                                                                    if (text == "motd")
                                                                                    {
                                                                                        if (Main.motd == "")
                                                                                        {
                                                                                            Console.WriteLine("Welcome to " + Main.worldName + "!");
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("MOTD: " + Main.motd);
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (text.Length >= 5 && text.Substring(0, 5) == "motd ")
                                                                                        {
                                                                                            string text5 = text2.Substring(5);
                                                                                            Main.motd = text5;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (text.Length == 8 && text.Substring(0, 8) == "password")
                                                                                            {
                                                                                                if (Netplay.password == "")
                                                                                                {
                                                                                                    Console.WriteLine("No password set.");
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    Console.WriteLine("Password: " + Netplay.password);
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (text.Length >= 9 && text.Substring(0, 9) == "password ")
                                                                                                {
                                                                                                    string text6 = text2.Substring(9);
                                                                                                    if (text6 == "")
                                                                                                    {
                                                                                                        Netplay.password = "";
                                                                                                        Console.WriteLine("Password disabled.");
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        Netplay.password = text6;
                                                                                                        Console.WriteLine("Password: " + Netplay.password);
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (text == "say")
                                                                                                    {
                                                                                                        Console.WriteLine("Usage: say <words>");
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (text.Length >= 4 && text.Substring(0, 4) == "say ")
                                                                                                        {
                                                                                                            string text7 = text2.Substring(4);
                                                                                                            if (text7 == "")
                                                                                                            {
                                                                                                                Console.WriteLine("Usage: say <words>");
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                Console.WriteLine("<Server> " + text7);
                                                                                                                NetMessage.SendData(25, -1, -1, "<Server> " + text7, 255, 255f, 240f, 20f, 0);
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (text.Length == 4 && text.Substring(0, 4) == "kick")
                                                                                                            {
                                                                                                                Console.WriteLine("Usage: kick <player>");
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (text.Length >= 5 && text.Substring(0, 5) == "kick ")
                                                                                                                {
                                                                                                                    string text8 = text.Substring(5);
                                                                                                                    text8 = text8.ToLower();
                                                                                                                    if (text8 == "")
                                                                                                                    {
                                                                                                                        Console.WriteLine("Usage: kick <player>");
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        for (int j = 0; j < 255; j++)
                                                                                                                        {
                                                                                                                            if (Main.player[j].active && Main.player[j].name.ToLower() == text8)
                                                                                                                            {
                                                                                                                                NetMessage.SendData(2, j, -1, "Kicked from server.", 0, 0f, 0f, 0f, 0);
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (text.Length == 3 && text.Substring(0, 3) == "ban")
                                                                                                                    {
                                                                                                                        Console.WriteLine("Usage: ban <player>");
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (text.Length >= 4 && text.Substring(0, 4) == "ban ")
                                                                                                                        {
                                                                                                                            string text9 = text.Substring(4);
                                                                                                                            text9 = text9.ToLower();
                                                                                                                            if (text9 == "")
                                                                                                                            {
                                                                                                                                Console.WriteLine("Usage: ban <player>");
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                for (int k = 0; k < 255; k++)
                                                                                                                                {
                                                                                                                                    if (Main.player[k].active && Main.player[k].name.ToLower() == text9)
                                                                                                                                    {
                                                                                                                                        Netplay.AddBan(k);
                                                                                                                                        NetMessage.SendData(2, k, -1, "Banned from server.", 0, 0f, 0f, 0f, 0);
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            Console.WriteLine("Invalid command.");
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid command.");
                    }
                }
			}
		}
		public Main()
		{
			this.graphics = new GraphicsDeviceManager(this);
			base.Content.RootDirectory = "Content";
		}
		protected override void Initialize()
		{
			NPC.clrNames();
			NPC.setNames();
			Main.bgAlpha[0] = 1f;
			Main.bgAlpha2[0] = 1f;
			for (int i = 0; i < 109; i++)
			{
				Main.projFrames[i] = 1;
			}
			Main.projFrames[72] = 4;
			Main.projFrames[86] = 4;
			Main.projFrames[87] = 4;
			Main.projFrames[102] = 2;
			Main.debuff[20] = true;
			Main.debuff[21] = true;
			Main.debuff[22] = true;
			Main.debuff[23] = true;
			Main.debuff[24] = true;
			Main.debuff[25] = true;
			Main.debuff[28] = true;
			Main.debuff[30] = true;
			Main.debuff[31] = true;
			Main.debuff[32] = true;
			Main.debuff[33] = true;
			Main.debuff[34] = true;
			Main.debuff[35] = true;
			Main.debuff[36] = true;
			Main.debuff[37] = true;
			Main.debuff[38] = true;
			Main.debuff[39] = true;
			Main.buffName[1] = "Obsidian Skin";
			Main.buffTip[1] = "Immune to lava";
			Main.buffName[2] = "Regeneration";
			Main.buffTip[2] = "Provides life regeneration";
			Main.buffName[3] = "Swiftness";
			Main.buffTip[3] = "25% increased movement speed";
			Main.buffName[4] = "Gills";
			Main.buffTip[4] = "Breathe water instead of air";
			Main.buffName[5] = "Ironskin";
			Main.buffTip[5] = "Increase defense by 8";
			Main.buffName[6] = "Mana Regeneration";
			Main.buffTip[6] = "Increased mana regeneration";
			Main.buffName[7] = "Magic Power";
			Main.buffTip[7] = "20% increased magic damage";
			Main.buffName[8] = "Featherfall";
			Main.buffTip[8] = "Press UP or DOWN to control speed of descent";
			Main.buffName[9] = "Spelunker";
			Main.buffTip[9] = "Shows the location of treasure and ore";
			Main.buffName[10] = "Invisibility";
			Main.buffTip[10] = "Grants invisibility";
			Main.buffName[11] = "Shine";
			Main.buffTip[11] = "Emitting light";
			Main.buffName[12] = "Night Owl";
			Main.buffTip[12] = "Increased night vision";
			Main.buffName[13] = "Battle";
			Main.buffTip[13] = "Increased enemy spawn rate";
			Main.buffName[14] = "Thorns";
			Main.buffTip[14] = "Attackers also take damage";
			Main.buffName[15] = "Water Walking";
			Main.buffTip[15] = "Press DOWN to enter water";
			Main.buffName[16] = "Archery";
			Main.buffTip[16] = "20% increased arrow damage and speed";
			Main.buffName[17] = "Hunter";
			Main.buffTip[17] = "Shows the location of enemies";
			Main.buffName[18] = "Gravitation";
			Main.buffTip[18] = "Press UP or DOWN to reverse gravity";
			Main.buffName[19] = "Orb of Light";
			Main.buffTip[19] = "A magical orb that provides light";
			Main.buffName[20] = "Poisoned";
			Main.buffTip[20] = "Slowly losing life";
			Main.buffName[21] = "Potion Sickness";
			Main.buffTip[21] = "Cannot consume anymore healing items";
			Main.buffName[22] = "Darkness";
			Main.buffTip[22] = "Decreased light vision";
			Main.buffName[23] = "Cursed";
			Main.buffTip[23] = "Cannot use any items";
			Main.buffName[24] = "On Fire!";
			Main.buffTip[24] = "Slowly losing life";
			Main.buffName[25] = "Tipsy";
			Main.buffTip[25] = "Increased melee abilities, lowered defense";
			Main.buffName[26] = "Well Fed";
			Main.buffTip[26] = "Minor improvements to all stats";
			Main.buffName[27] = "Fairy";
			Main.buffTip[27] = "A fairy is following you";
			Main.buffName[28] = "Werewolf";
			Main.buffTip[28] = "Physical abilities are increased";
			Main.buffName[29] = "Clairvoyance";
			Main.buffTip[29] = "Magic powers are increased";
			Main.buffName[30] = "Bleeding";
			Main.buffTip[30] = "Cannot regenerate life";
			Main.buffName[31] = "Confused";
			Main.buffTip[31] = "Movement is reversed";
			Main.buffName[32] = "Slow";
			Main.buffTip[32] = "Movement speed is reduced";
			Main.buffName[33] = "Weak";
			Main.buffTip[33] = "Physical abilities are decreased";
			Main.buffName[34] = "Merfolk";
			Main.buffTip[34] = "Can breathe and move easily underwater";
			Main.buffName[35] = "Silenced";
			Main.buffTip[35] = "Cannot use items that require mana";
			Main.buffName[36] = "Broken Armor";
			Main.buffTip[36] = "Defense is cut in half";
			Main.buffName[37] = "Horrified";
			Main.buffTip[37] = "You have seen something nasty, there is no escape.";
			Main.buffName[38] = "The Tongue";
			Main.buffTip[38] = "You are being sucked into the mouth";
			Main.buffName[39] = "Cursed Inferno";
			Main.buffTip[39] = "Losing life";
			for (int j = 0; j < 10; j++)
			{
				Main.recentWorld[j] = "";
				Main.recentIP[j] = "";
				Main.recentPort[j] = 0;
			}
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			if (WorldGen.genRand == null)
			{
				WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
			}
			int num = Main.rand.Next(15);
			if (num == 0)
			{
				base.Window.Title = "Terraria: Dig Peon, Dig!";
			}
			else
			{
				if (num == 1)
				{
					base.Window.Title = "Terraria: Epic Dirt";
				}
				else
				{
					if (num == 2)
					{
						base.Window.Title = "Terraria: Hey Guys!";
					}
					else
					{
						if (num == 3)
						{
							base.Window.Title = "Terraria: Sand is Overpowered";
						}
						else
						{
							if (num == 4)
							{
								base.Window.Title = "Terraria Part 3: The Return of the Guide";
							}
							else
							{
								if (num == 5)
								{
									base.Window.Title = "Terraria: A Bunnies Tale";
								}
								else
								{
									if (num == 6)
									{
										base.Window.Title = "Terraria: Dr. Bones and The Temple of Blood Moon";
									}
									else
									{
										if (num == 7)
										{
											base.Window.Title = "Terraria: Slimeassic Park";
										}
										else
										{
											if (num == 8)
											{
												base.Window.Title = "Terraria: The Grass is Greener on This Side";
											}
											else
											{
												if (num == 9)
												{
													base.Window.Title = "Terraria: Small Blocks, Not for Children Under the Age of 5";
												}
												else
												{
													if (num == 10)
													{
														base.Window.Title = "Terraria: Digger T' Blocks";
													}
													else
													{
														if (num == 11)
														{
															base.Window.Title = "Terraria: There is No Cow Layer";
														}
														else
														{
															if (num == 12)
															{
																base.Window.Title = "Terraria: Suspicous Looking Eyeballs";
															}
															else
															{
																if (num == 13)
																{
																	base.Window.Title = "Terraria: Purple Grass!";
																}
																else
																{
																	if (num == 14)
																	{
																		base.Window.Title = "Terraria: Noone Dug Behind!";
																	}
																	else
																	{
																		base.Window.Title = "Terraria: Shut Up and Dig Gaiden!";
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			Main.lo = Main.rand.Next(6);
			Main.tileShine2[6] = true;
			Main.tileShine2[7] = true;
			Main.tileShine2[8] = true;
			Main.tileShine2[9] = true;
			Main.tileShine2[12] = true;
			Main.tileShine2[21] = true;
			Main.tileShine2[22] = true;
			Main.tileShine2[25] = true;
			Main.tileShine2[45] = true;
			Main.tileShine2[46] = true;
			Main.tileShine2[47] = true;
			Main.tileShine2[63] = true;
			Main.tileShine2[64] = true;
			Main.tileShine2[65] = true;
			Main.tileShine2[66] = true;
			Main.tileShine2[67] = true;
			Main.tileShine2[68] = true;
			Main.tileShine2[107] = true;
			Main.tileShine2[108] = true;
			Main.tileShine2[111] = true;
			Main.tileShine2[121] = true;
			Main.tileShine2[122] = true;
			Main.tileShine2[117] = true;
			Main.tileShine[129] = 300;
			Main.tileHammer[141] = true;
			Main.tileHammer[4] = true;
			Main.tileHammer[10] = true;
			Main.tileHammer[11] = true;
			Main.tileHammer[12] = true;
			Main.tileHammer[13] = true;
			Main.tileHammer[14] = true;
			Main.tileHammer[15] = true;
			Main.tileHammer[16] = true;
			Main.tileHammer[17] = true;
			Main.tileHammer[18] = true;
			Main.tileHammer[19] = true;
			Main.tileHammer[21] = true;
			Main.tileHammer[26] = true;
			Main.tileHammer[28] = true;
			Main.tileHammer[29] = true;
			Main.tileHammer[31] = true;
			Main.tileHammer[33] = true;
			Main.tileHammer[34] = true;
			Main.tileHammer[35] = true;
			Main.tileHammer[36] = true;
			Main.tileHammer[42] = true;
			Main.tileHammer[48] = true;
			Main.tileHammer[49] = true;
			Main.tileHammer[50] = true;
			Main.tileHammer[54] = true;
			Main.tileHammer[55] = true;
			Main.tileHammer[77] = true;
			Main.tileHammer[78] = true;
			Main.tileHammer[79] = true;
			Main.tileHammer[81] = true;
			Main.tileHammer[85] = true;
			Main.tileHammer[86] = true;
			Main.tileHammer[87] = true;
			Main.tileHammer[88] = true;
			Main.tileHammer[89] = true;
			Main.tileHammer[90] = true;
			Main.tileHammer[91] = true;
			Main.tileHammer[92] = true;
			Main.tileHammer[93] = true;
			Main.tileHammer[94] = true;
			Main.tileHammer[95] = true;
			Main.tileHammer[96] = true;
			Main.tileHammer[97] = true;
			Main.tileHammer[98] = true;
			Main.tileHammer[99] = true;
			Main.tileHammer[100] = true;
			Main.tileHammer[101] = true;
			Main.tileHammer[102] = true;
			Main.tileHammer[103] = true;
			Main.tileHammer[104] = true;
			Main.tileHammer[105] = true;
			Main.tileHammer[106] = true;
			Main.tileHammer[114] = true;
			Main.tileHammer[125] = true;
			Main.tileHammer[126] = true;
			Main.tileHammer[128] = true;
			Main.tileHammer[129] = true;
			Main.tileHammer[132] = true;
			Main.tileHammer[133] = true;
			Main.tileHammer[134] = true;
			Main.tileHammer[135] = true;
			Main.tileHammer[136] = true;
			Main.tileFrameImportant[139] = true;
			Main.tileHammer[139] = true;
			Main.tileFrameImportant[142] = true;
			Main.tileHammer[142] = true;
			Main.tileFrameImportant[143] = true;
			Main.tileHammer[143] = true;
			Main.tileFrameImportant[144] = true;
			Main.tileHammer[144] = true;
			Main.tileStone[131] = true;
			Main.tileFrameImportant[136] = true;
			Main.tileFrameImportant[137] = true;
			Main.tileFrameImportant[138] = true;
			Main.tileBlockLight[137] = true;
			Main.tileSolid[137] = true;
			Main.tileBlockLight[138] = true;
			Main.tileSolid[138] = true;
			Main.tileBlockLight[140] = true;
			Main.tileSolid[140] = true;
			Main.tileAxe[5] = true;
			Main.tileAxe[30] = true;
			Main.tileAxe[72] = true;
			Main.tileAxe[80] = true;
			Main.tileAxe[124] = true;
			Main.tileShine[22] = 1150;
			Main.tileShine[6] = 1150;
			Main.tileShine[7] = 1100;
			Main.tileShine[8] = 1000;
			Main.tileShine[9] = 1050;
			Main.tileShine[12] = 1000;
			Main.tileShine[21] = 1200;
			Main.tileShine[63] = 900;
			Main.tileShine[64] = 900;
			Main.tileShine[65] = 900;
			Main.tileShine[66] = 900;
			Main.tileShine[67] = 900;
			Main.tileShine[68] = 900;
			Main.tileShine[45] = 1900;
			Main.tileShine[46] = 2000;
			Main.tileShine[47] = 2100;
			Main.tileShine[122] = 1800;
			Main.tileShine[121] = 1850;
			Main.tileShine[125] = 600;
			Main.tileShine[109] = 9000;
			Main.tileShine[110] = 9000;
			Main.tileShine[116] = 9000;
			Main.tileShine[117] = 9000;
			Main.tileShine[118] = 8000;
			Main.tileShine[107] = 950;
			Main.tileShine[108] = 900;
			Main.tileShine[111] = 850;
			Main.tileLighted[4] = true;
			Main.tileLighted[17] = true;
			Main.tileLighted[133] = true;
			Main.tileLighted[31] = true;
			Main.tileLighted[33] = true;
			Main.tileLighted[34] = true;
			Main.tileLighted[35] = true;
			Main.tileLighted[36] = true;
			Main.tileLighted[37] = true;
			Main.tileLighted[42] = true;
			Main.tileLighted[49] = true;
			Main.tileLighted[58] = true;
			Main.tileLighted[61] = true;
			Main.tileLighted[70] = true;
			Main.tileLighted[71] = true;
			Main.tileLighted[72] = true;
			Main.tileLighted[76] = true;
			Main.tileLighted[77] = true;
			Main.tileLighted[19] = true;
			Main.tileLighted[22] = true;
			Main.tileLighted[26] = true;
			Main.tileLighted[83] = true;
			Main.tileLighted[84] = true;
			Main.tileLighted[92] = true;
			Main.tileLighted[93] = true;
			Main.tileLighted[95] = true;
			Main.tileLighted[98] = true;
			Main.tileLighted[100] = true;
			Main.tileLighted[109] = true;
			Main.tileLighted[125] = true;
			Main.tileLighted[126] = true;
			Main.tileLighted[129] = true;
			Main.tileLighted[140] = true;
			Main.tileMergeDirt[1] = true;
			Main.tileMergeDirt[6] = true;
			Main.tileMergeDirt[7] = true;
			Main.tileMergeDirt[8] = true;
			Main.tileMergeDirt[9] = true;
			Main.tileMergeDirt[22] = true;
			Main.tileMergeDirt[25] = true;
			Main.tileMergeDirt[30] = true;
			Main.tileMergeDirt[37] = true;
			Main.tileMergeDirt[38] = true;
			Main.tileMergeDirt[40] = true;
			Main.tileMergeDirt[53] = true;
			Main.tileMergeDirt[56] = true;
			Main.tileMergeDirt[107] = true;
			Main.tileMergeDirt[108] = true;
			Main.tileMergeDirt[111] = true;
			Main.tileMergeDirt[112] = true;
			Main.tileMergeDirt[116] = true;
			Main.tileMergeDirt[117] = true;
			Main.tileMergeDirt[123] = true;
			Main.tileMergeDirt[140] = true;
			Main.tileMergeDirt[39] = true;
			Main.tileMergeDirt[122] = true;
			Main.tileMergeDirt[121] = true;
			Main.tileMergeDirt[120] = true;
			Main.tileMergeDirt[119] = true;
			Main.tileMergeDirt[118] = true;
			Main.tileMergeDirt[47] = true;
			Main.tileMergeDirt[46] = true;
			Main.tileMergeDirt[45] = true;
			Main.tileMergeDirt[44] = true;
			Main.tileMergeDirt[43] = true;
			Main.tileMergeDirt[41] = true;
			Main.tileFrameImportant[3] = true;
			Main.tileFrameImportant[4] = true;
			Main.tileFrameImportant[5] = true;
			Main.tileFrameImportant[10] = true;
			Main.tileFrameImportant[11] = true;
			Main.tileFrameImportant[12] = true;
			Main.tileFrameImportant[13] = true;
			Main.tileFrameImportant[14] = true;
			Main.tileFrameImportant[15] = true;
			Main.tileFrameImportant[16] = true;
			Main.tileFrameImportant[17] = true;
			Main.tileFrameImportant[18] = true;
			Main.tileFrameImportant[20] = true;
			Main.tileFrameImportant[21] = true;
			Main.tileFrameImportant[24] = true;
			Main.tileFrameImportant[26] = true;
			Main.tileFrameImportant[27] = true;
			Main.tileFrameImportant[28] = true;
			Main.tileFrameImportant[29] = true;
			Main.tileFrameImportant[31] = true;
			Main.tileFrameImportant[33] = true;
			Main.tileFrameImportant[34] = true;
			Main.tileFrameImportant[35] = true;
			Main.tileFrameImportant[36] = true;
			Main.tileFrameImportant[42] = true;
			Main.tileFrameImportant[50] = true;
			Main.tileFrameImportant[55] = true;
			Main.tileFrameImportant[61] = true;
			Main.tileFrameImportant[71] = true;
			Main.tileFrameImportant[72] = true;
			Main.tileFrameImportant[73] = true;
			Main.tileFrameImportant[74] = true;
			Main.tileFrameImportant[77] = true;
			Main.tileFrameImportant[78] = true;
			Main.tileFrameImportant[79] = true;
			Main.tileFrameImportant[81] = true;
			Main.tileFrameImportant[82] = true;
			Main.tileFrameImportant[83] = true;
			Main.tileFrameImportant[84] = true;
			Main.tileFrameImportant[85] = true;
			Main.tileFrameImportant[86] = true;
			Main.tileFrameImportant[87] = true;
			Main.tileFrameImportant[88] = true;
			Main.tileFrameImportant[89] = true;
			Main.tileFrameImportant[90] = true;
			Main.tileFrameImportant[91] = true;
			Main.tileFrameImportant[92] = true;
			Main.tileFrameImportant[93] = true;
			Main.tileFrameImportant[94] = true;
			Main.tileFrameImportant[95] = true;
			Main.tileFrameImportant[96] = true;
			Main.tileFrameImportant[97] = true;
			Main.tileFrameImportant[98] = true;
			Main.tileFrameImportant[99] = true;
			Main.tileFrameImportant[101] = true;
			Main.tileFrameImportant[102] = true;
			Main.tileFrameImportant[103] = true;
			Main.tileFrameImportant[104] = true;
			Main.tileFrameImportant[105] = true;
			Main.tileFrameImportant[100] = true;
			Main.tileFrameImportant[106] = true;
			Main.tileFrameImportant[110] = true;
			Main.tileFrameImportant[113] = true;
			Main.tileFrameImportant[114] = true;
			Main.tileFrameImportant[125] = true;
			Main.tileFrameImportant[126] = true;
			Main.tileFrameImportant[128] = true;
			Main.tileFrameImportant[129] = true;
			Main.tileFrameImportant[132] = true;
			Main.tileFrameImportant[133] = true;
			Main.tileFrameImportant[134] = true;
			Main.tileFrameImportant[135] = true;
			Main.tileFrameImportant[141] = true;
			Main.tileCut[3] = true;
			Main.tileCut[24] = true;
			Main.tileCut[28] = true;
			Main.tileCut[32] = true;
			Main.tileCut[51] = true;
			Main.tileCut[52] = true;
			Main.tileCut[61] = true;
			Main.tileCut[62] = true;
			Main.tileCut[69] = true;
			Main.tileCut[71] = true;
			Main.tileCut[73] = true;
			Main.tileCut[74] = true;
			Main.tileCut[82] = true;
			Main.tileCut[83] = true;
			Main.tileCut[84] = true;
			Main.tileCut[110] = true;
			Main.tileCut[113] = true;
			Main.tileCut[115] = true;
			Main.tileAlch[82] = true;
			Main.tileAlch[83] = true;
			Main.tileAlch[84] = true;
			Main.tileLavaDeath[104] = true;
			Main.tileLavaDeath[110] = true;
			Main.tileLavaDeath[113] = true;
			Main.tileLavaDeath[115] = true;
			Main.tileSolid[127] = true;
			Main.tileSolid[130] = true;
			Main.tileBlockLight[130] = true;
			Main.tileBlockLight[131] = true;
			Main.tileSolid[107] = true;
			Main.tileBlockLight[107] = true;
			Main.tileSolid[108] = true;
			Main.tileBlockLight[108] = true;
			Main.tileSolid[111] = true;
			Main.tileBlockLight[111] = true;
			Main.tileSolid[109] = true;
			Main.tileBlockLight[109] = true;
			Main.tileSolid[110] = false;
			Main.tileNoAttach[110] = true;
			Main.tileNoFail[110] = true;
			Main.tileSolid[112] = true;
			Main.tileBlockLight[112] = true;
			Main.tileSolid[116] = true;
			Main.tileBlockLight[116] = true;
			Main.tileSolid[117] = true;
			Main.tileBlockLight[117] = true;
			Main.tileSolid[123] = true;
			Main.tileBlockLight[123] = true;
			Main.tileSolid[118] = true;
			Main.tileBlockLight[118] = true;
			Main.tileSolid[119] = true;
			Main.tileBlockLight[119] = true;
			Main.tileSolid[120] = true;
			Main.tileBlockLight[120] = true;
			Main.tileSolid[121] = true;
			Main.tileBlockLight[121] = true;
			Main.tileSolid[122] = true;
			Main.tileBlockLight[122] = true;
			Main.tileBlockLight[115] = true;
			Main.tileSolid[0] = true;
			Main.tileBlockLight[0] = true;
			Main.tileSolid[1] = true;
			Main.tileBlockLight[1] = true;
			Main.tileSolid[2] = true;
			Main.tileBlockLight[2] = true;
			Main.tileSolid[3] = false;
			Main.tileNoAttach[3] = true;
			Main.tileNoFail[3] = true;
			Main.tileSolid[4] = false;
			Main.tileNoAttach[4] = true;
			Main.tileNoFail[4] = true;
			Main.tileNoFail[24] = true;
			Main.tileSolid[5] = false;
			Main.tileSolid[6] = true;
			Main.tileBlockLight[6] = true;
			Main.tileSolid[7] = true;
			Main.tileBlockLight[7] = true;
			Main.tileSolid[8] = true;
			Main.tileBlockLight[8] = true;
			Main.tileSolid[9] = true;
			Main.tileBlockLight[9] = true;
			Main.tileBlockLight[10] = true;
			Main.tileSolid[10] = true;
			Main.tileNoAttach[10] = true;
			Main.tileBlockLight[10] = true;
			Main.tileSolid[11] = false;
			Main.tileSolidTop[19] = true;
			Main.tileSolid[19] = true;
			Main.tileSolid[22] = true;
			Main.tileSolid[23] = true;
			Main.tileSolid[25] = true;
			Main.tileSolid[30] = true;
			Main.tileNoFail[32] = true;
			Main.tileBlockLight[32] = true;
			Main.tileSolid[37] = true;
			Main.tileBlockLight[37] = true;
			Main.tileSolid[38] = true;
			Main.tileBlockLight[38] = true;
			Main.tileSolid[39] = true;
			Main.tileBlockLight[39] = true;
			Main.tileSolid[40] = true;
			Main.tileBlockLight[40] = true;
			Main.tileSolid[41] = true;
			Main.tileBlockLight[41] = true;
			Main.tileSolid[43] = true;
			Main.tileBlockLight[43] = true;
			Main.tileSolid[44] = true;
			Main.tileBlockLight[44] = true;
			Main.tileSolid[45] = true;
			Main.tileBlockLight[45] = true;
			Main.tileSolid[46] = true;
			Main.tileBlockLight[46] = true;
			Main.tileSolid[47] = true;
			Main.tileBlockLight[47] = true;
			Main.tileSolid[48] = true;
			Main.tileBlockLight[48] = true;
			Main.tileSolid[53] = true;
			Main.tileBlockLight[53] = true;
			Main.tileSolid[54] = true;
			Main.tileBlockLight[52] = true;
			Main.tileSolid[56] = true;
			Main.tileBlockLight[56] = true;
			Main.tileSolid[57] = true;
			Main.tileBlockLight[57] = true;
			Main.tileSolid[58] = true;
			Main.tileBlockLight[58] = true;
			Main.tileSolid[59] = true;
			Main.tileBlockLight[59] = true;
			Main.tileSolid[60] = true;
			Main.tileBlockLight[60] = true;
			Main.tileSolid[63] = true;
			Main.tileBlockLight[63] = true;
			Main.tileStone[63] = true;
			Main.tileStone[130] = true;
			Main.tileSolid[64] = true;
			Main.tileBlockLight[64] = true;
			Main.tileStone[64] = true;
			Main.tileSolid[65] = true;
			Main.tileBlockLight[65] = true;
			Main.tileStone[65] = true;
			Main.tileSolid[66] = true;
			Main.tileBlockLight[66] = true;
			Main.tileStone[66] = true;
			Main.tileSolid[67] = true;
			Main.tileBlockLight[67] = true;
			Main.tileStone[67] = true;
			Main.tileSolid[68] = true;
			Main.tileBlockLight[68] = true;
			Main.tileStone[68] = true;
			Main.tileSolid[75] = true;
			Main.tileBlockLight[75] = true;
			Main.tileSolid[76] = true;
			Main.tileBlockLight[76] = true;
			Main.tileSolid[70] = true;
			Main.tileBlockLight[70] = true;
			Main.tileNoFail[50] = true;
			Main.tileNoAttach[50] = true;
			Main.tileDungeon[41] = true;
			Main.tileDungeon[43] = true;
			Main.tileDungeon[44] = true;
			Main.tileBlockLight[30] = true;
			Main.tileBlockLight[25] = true;
			Main.tileBlockLight[23] = true;
			Main.tileBlockLight[22] = true;
			Main.tileBlockLight[62] = true;
			Main.tileSolidTop[18] = true;
			Main.tileSolidTop[14] = true;
			Main.tileSolidTop[16] = true;
			Main.tileSolidTop[114] = true;
			Main.tileNoAttach[20] = true;
			Main.tileNoAttach[19] = true;
			Main.tileNoAttach[13] = true;
			Main.tileNoAttach[14] = true;
			Main.tileNoAttach[15] = true;
			Main.tileNoAttach[16] = true;
			Main.tileNoAttach[17] = true;
			Main.tileNoAttach[18] = true;
			Main.tileNoAttach[19] = true;
			Main.tileNoAttach[21] = true;
			Main.tileNoAttach[27] = true;
			Main.tileNoAttach[114] = true;
			Main.tileTable[14] = true;
			Main.tileTable[18] = true;
			Main.tileTable[19] = true;
			Main.tileTable[114] = true;
			Main.tileNoAttach[86] = true;
			Main.tileNoAttach[87] = true;
			Main.tileNoAttach[88] = true;
			Main.tileNoAttach[89] = true;
			Main.tileNoAttach[90] = true;
			Main.tileLavaDeath[86] = true;
			Main.tileLavaDeath[87] = true;
			Main.tileLavaDeath[88] = true;
			Main.tileLavaDeath[89] = true;
			Main.tileLavaDeath[125] = true;
			Main.tileLavaDeath[126] = true;
			Main.tileLavaDeath[101] = true;
			Main.tileTable[101] = true;
			Main.tileNoAttach[101] = true;
			Main.tileLavaDeath[102] = true;
			Main.tileNoAttach[102] = true;
			Main.tileNoAttach[94] = true;
			Main.tileNoAttach[95] = true;
			Main.tileNoAttach[96] = true;
			Main.tileNoAttach[97] = true;
			Main.tileNoAttach[98] = true;
			Main.tileNoAttach[99] = true;
			Main.tileLavaDeath[94] = true;
			Main.tileLavaDeath[95] = true;
			Main.tileLavaDeath[96] = true;
			Main.tileLavaDeath[97] = true;
			Main.tileLavaDeath[98] = true;
			Main.tileLavaDeath[99] = true;
			Main.tileLavaDeath[100] = true;
			Main.tileLavaDeath[103] = true;
			Main.tileTable[87] = true;
			Main.tileTable[88] = true;
			Main.tileSolidTop[87] = true;
			Main.tileSolidTop[88] = true;
			Main.tileSolidTop[101] = true;
			Main.tileNoAttach[91] = true;
			Main.tileLavaDeath[91] = true;
			Main.tileNoAttach[92] = true;
			Main.tileLavaDeath[92] = true;
			Main.tileNoAttach[93] = true;
			Main.tileLavaDeath[93] = true;
			Main.tileWaterDeath[4] = true;
			Main.tileWaterDeath[51] = true;
			Main.tileWaterDeath[93] = true;
			Main.tileWaterDeath[98] = true;
			Main.tileLavaDeath[3] = true;
			Main.tileLavaDeath[5] = true;
			Main.tileLavaDeath[10] = true;
			Main.tileLavaDeath[11] = true;
			Main.tileLavaDeath[12] = true;
			Main.tileLavaDeath[13] = true;
			Main.tileLavaDeath[14] = true;
			Main.tileLavaDeath[15] = true;
			Main.tileLavaDeath[16] = true;
			Main.tileLavaDeath[17] = true;
			Main.tileLavaDeath[18] = true;
			Main.tileLavaDeath[19] = true;
			Main.tileLavaDeath[20] = true;
			Main.tileLavaDeath[27] = true;
			Main.tileLavaDeath[28] = true;
			Main.tileLavaDeath[29] = true;
			Main.tileLavaDeath[32] = true;
			Main.tileLavaDeath[33] = true;
			Main.tileLavaDeath[34] = true;
			Main.tileLavaDeath[35] = true;
			Main.tileLavaDeath[36] = true;
			Main.tileLavaDeath[42] = true;
			Main.tileLavaDeath[49] = true;
			Main.tileLavaDeath[50] = true;
			Main.tileLavaDeath[52] = true;
			Main.tileLavaDeath[55] = true;
			Main.tileLavaDeath[61] = true;
			Main.tileLavaDeath[62] = true;
			Main.tileLavaDeath[69] = true;
			Main.tileLavaDeath[71] = true;
			Main.tileLavaDeath[72] = true;
			Main.tileLavaDeath[73] = true;
			Main.tileLavaDeath[74] = true;
			Main.tileLavaDeath[79] = true;
			Main.tileLavaDeath[80] = true;
			Main.tileLavaDeath[81] = true;
			Main.tileLavaDeath[106] = true;
			Main.wallHouse[1] = true;
			Main.wallHouse[4] = true;
			Main.wallHouse[5] = true;
			Main.wallHouse[6] = true;
			Main.wallHouse[10] = true;
			Main.wallHouse[11] = true;
			Main.wallHouse[12] = true;
			Main.wallHouse[16] = true;
			Main.wallHouse[17] = true;
			Main.wallHouse[18] = true;
			Main.wallHouse[19] = true;
			Main.wallHouse[20] = true;
			Main.wallHouse[21] = true;
			Main.wallHouse[22] = true;
			Main.wallHouse[23] = true;
			Main.wallHouse[24] = true;
			Main.wallHouse[25] = true;
			Main.wallHouse[26] = true;
			Main.wallHouse[27] = true;
			for (int k = 0; k < 29; k++)
			{
				if (k == 20)
				{
					Main.wallBlend[k] = 14;
				}
				else
				{
					if (k == 19)
					{
						Main.wallBlend[k] = 9;
					}
					else
					{
						if (k == 18)
						{
							Main.wallBlend[k] = 8;
						}
						else
						{
							if (k == 17)
							{
								Main.wallBlend[k] = 7;
							}
							else
							{
								if (k == 16)
								{
									Main.wallBlend[k] = 2;
								}
								else
								{
									Main.wallBlend[k] = k;
								}
							}
						}
					}
				}
			}
			Main.tileNoFail[32] = true;
			Main.tileNoFail[61] = true;
			Main.tileNoFail[69] = true;
			Main.tileNoFail[73] = true;
			Main.tileNoFail[74] = true;
			Main.tileNoFail[82] = true;
			Main.tileNoFail[83] = true;
			Main.tileNoFail[84] = true;
			Main.tileNoFail[110] = true;
			Main.tileNoFail[113] = true;
			for (int l = 0; l < 145; l++)
			{
				Main.tileName[l] = "";
				if (Main.tileSolid[l])
				{
					Main.tileNoSunLight[l] = true;
				}
			}
			Main.tileNoSunLight[19] = false;
			Main.tileNoSunLight[11] = true;
			Main.tileName[13] = "Bottle";
			Main.tileName[14] = "Table";
			Main.tileName[15] = "Chair";
			Main.tileName[16] = "Anvil";
			Main.tileName[17] = "Furnace";
			Main.tileName[18] = "Workbench";
			Main.tileName[26] = "Demon Altar";
			Main.tileName[77] = "Hellforge";
			Main.tileName[86] = "Loom";
			Main.tileName[94] = "Keg";
			Main.tileName[96] = "Cooking Pot";
			Main.tileName[101] = "Bookcase";
			Main.tileName[106] = "Sawmill";
			Main.tileName[114] = "Tinkerer's Workshop";
			Main.tileName[133] = "Adamantite Forge";
			Main.tileName[134] = "Mythril Anvil";
			for (int m = 0; m < Main.maxMenuItems; m++)
			{
				this.menuItemScale[m] = 0.8f;
			}
			for (int n = 0; n < 2001; n++)
			{
				Main.dust[n] = new Dust();
			}
			for (int num2 = 0; num2 < 201; num2++)
			{
				Main.item[num2] = new Item();
			}
			for (int num3 = 0; num3 < 201; num3++)
			{
				Main.npc[num3] = new NPC();
				Main.npc[num3].whoAmI = num3;
			}
			for (int num4 = 0; num4 < 256; num4++)
			{
				Main.player[num4] = new Player();
			}
			for (int num5 = 0; num5 < 1001; num5++)
			{
				Main.projectile[num5] = new Projectile();
			}
			for (int num6 = 0; num6 < 201; num6++)
			{
				Main.gore[num6] = new Gore();
			}
			for (int num7 = 0; num7 < 100; num7++)
			{
				Main.cloud[num7] = new Cloud();
			}
			for (int num8 = 0; num8 < 100; num8++)
			{
				Main.combatText[num8] = new CombatText();
			}
			for (int num9 = 0; num9 < 20; num9++)
			{
				Main.itemText[num9] = new ItemText();
			}
			for (int num10 = 0; num10 < 586; num10++)
			{
				Item item = new Item();
				item.SetDefaults(num10, false);
				Main.itemName[num10] = item.name;
				if (item.headSlot > 0)
				{
					Item.headType[item.headSlot] = item.type;
				}
				if (item.bodySlot > 0)
				{
					Item.bodyType[item.bodySlot] = item.type;
				}
				if (item.legSlot > 0)
				{
					Item.legType[item.legSlot] = item.type;
				}
			}
			for (int num11 = 0; num11 < Recipe.maxRecipes; num11++)
			{
				Main.recipe[num11] = new Recipe();
				Main.availableRecipeY[num11] = (float)(65 * num11);
			}
			Recipe.SetupRecipes();
			for (int num12 = 0; num12 < Main.numChatLines; num12++)
			{
				Main.chatLine[num12] = new ChatLine();
			}
			for (int num13 = 0; num13 < Liquid.resLiquid; num13++)
			{
				Main.liquid[num13] = new Liquid();
			}
			for (int num14 = 0; num14 < 10000; num14++)
			{
				Main.liquidBuffer[num14] = new LiquidBuffer();
			}
			this.shop[0] = new Chest();
			this.shop[1] = new Chest();
			this.shop[1].SetupShop(1);
			this.shop[2] = new Chest();
			this.shop[2].SetupShop(2);
			this.shop[3] = new Chest();
			this.shop[3].SetupShop(3);
			this.shop[4] = new Chest();
			this.shop[4].SetupShop(4);
			this.shop[5] = new Chest();
			this.shop[5].SetupShop(5);
			this.shop[6] = new Chest();
			this.shop[6].SetupShop(6);
			this.shop[7] = new Chest();
			this.shop[7].SetupShop(7);
			this.shop[8] = new Chest();
			this.shop[8].SetupShop(8);
			Main.teamColor[0] = Color.White;
			Main.teamColor[1] = new Color(230, 40, 20);
			Main.teamColor[2] = new Color(20, 200, 30);
			Main.teamColor[3] = new Color(75, 90, 255);
			Main.teamColor[4] = new Color(200, 180, 0);
			if (Main.menuMode == 1)
			{
				Main.LoadPlayers();
			}
			Netplay.Init();
			if (Main.skipMenu)
			{
				WorldGen.clearWorld();
				Main.gameMenu = false;
				Main.LoadPlayers();
				Main.player[Main.myPlayer] = (Player)Main.loadPlayer[0].Clone();
				Main.PlayerPath = Main.loadPlayerPath[0];
				Main.LoadWorlds();
				WorldGen.generateWorld(-1);
				WorldGen.EveryTileFrame();
				Main.player[Main.myPlayer].Spawn();
			}
			else
			{
				IntPtr systemMenu = Main.GetSystemMenu(base.Window.Handle, false);
				int menuItemCount = Main.GetMenuItemCount(systemMenu);
				Main.RemoveMenu(systemMenu, menuItemCount - 1, 1024);
			}
			if (Main.dedServ)
			{
				return;
			}
			this.graphics.PreferredBackBufferWidth = Main.screenWidth;
			this.graphics.PreferredBackBufferHeight = Main.screenHeight;
			this.graphics.ApplyChanges();
			base.Initialize();
			base.Window.AllowUserResizing = true;
			this.OpenSettings();
			this.OpenRecent();
			Star.SpawnStars();
			foreach (DisplayMode current in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
			{
				if (current.Width >= Main.minScreenW && current.Height >= Main.minScreenH && current.Width <= Main.maxScreenW && current.Height <= Main.maxScreenH)
				{
					bool flag = true;
					for (int num15 = 0; num15 < this.numDisplayModes; num15++)
					{
						if (current.Width == this.displayWidth[num15] && current.Height == this.displayHeight[num15])
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						this.displayHeight[this.numDisplayModes] = current.Height;
						this.displayWidth[this.numDisplayModes] = current.Width;
						this.numDisplayModes++;
					}
				}
			}
			if (Main.autoJoin)
			{
				Main.LoadPlayers();
				Main.menuMode = 1;
				Main.menuMultiplayer = true;
			}
			Main.fpsTimer.Start();
			Main.updateTimer.Start();
		}
		protected override void LoadContent()
		{
			try
			{
				Main.engine = new AudioEngine("Content\\TerrariaMusic.xgs");
				Main.soundBank = new SoundBank(Main.engine, "Content\\Sound Bank.xsb");
				Main.waveBank = new WaveBank(Main.engine, "Content\\Wave Bank.xwb");
				for (int i = 1; i < 14; i++)
				{
					Main.music[i] = Main.soundBank.GetCue("Music_" + i);
				}
				Main.soundMech[0] = base.Content.Load<SoundEffect>("Sounds\\Mech_0");
				Main.soundInstanceMech[0] = Main.soundMech[0].CreateInstance();
				Main.soundGrab = base.Content.Load<SoundEffect>("Sounds\\Grab");
				Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
				Main.soundPixie = base.Content.Load<SoundEffect>("Sounds\\Pixie");
				Main.soundInstancePixie = Main.soundGrab.CreateInstance();
				Main.soundDig[0] = base.Content.Load<SoundEffect>("Sounds\\Dig_0");
				Main.soundInstanceDig[0] = Main.soundDig[0].CreateInstance();
				Main.soundDig[1] = base.Content.Load<SoundEffect>("Sounds\\Dig_1");
				Main.soundInstanceDig[1] = Main.soundDig[1].CreateInstance();
				Main.soundDig[2] = base.Content.Load<SoundEffect>("Sounds\\Dig_2");
				Main.soundInstanceDig[2] = Main.soundDig[2].CreateInstance();
				Main.soundTink[0] = base.Content.Load<SoundEffect>("Sounds\\Tink_0");
				Main.soundInstanceTink[0] = Main.soundTink[0].CreateInstance();
				Main.soundTink[1] = base.Content.Load<SoundEffect>("Sounds\\Tink_1");
				Main.soundInstanceTink[1] = Main.soundTink[1].CreateInstance();
				Main.soundTink[2] = base.Content.Load<SoundEffect>("Sounds\\Tink_2");
				Main.soundInstanceTink[2] = Main.soundTink[2].CreateInstance();
				Main.soundPlayerHit[0] = base.Content.Load<SoundEffect>("Sounds\\Player_Hit_0");
				Main.soundInstancePlayerHit[0] = Main.soundPlayerHit[0].CreateInstance();
				Main.soundPlayerHit[1] = base.Content.Load<SoundEffect>("Sounds\\Player_Hit_1");
				Main.soundInstancePlayerHit[1] = Main.soundPlayerHit[1].CreateInstance();
				Main.soundPlayerHit[2] = base.Content.Load<SoundEffect>("Sounds\\Player_Hit_2");
				Main.soundInstancePlayerHit[2] = Main.soundPlayerHit[2].CreateInstance();
				Main.soundFemaleHit[0] = base.Content.Load<SoundEffect>("Sounds\\Female_Hit_0");
				Main.soundInstanceFemaleHit[0] = Main.soundFemaleHit[0].CreateInstance();
				Main.soundFemaleHit[1] = base.Content.Load<SoundEffect>("Sounds\\Female_Hit_1");
				Main.soundInstanceFemaleHit[1] = Main.soundFemaleHit[1].CreateInstance();
				Main.soundFemaleHit[2] = base.Content.Load<SoundEffect>("Sounds\\Female_Hit_2");
				Main.soundInstanceFemaleHit[2] = Main.soundFemaleHit[2].CreateInstance();
				Main.soundPlayerKilled = base.Content.Load<SoundEffect>("Sounds\\Player_Killed");
				Main.soundInstancePlayerKilled = Main.soundPlayerKilled.CreateInstance();
				Main.soundChat = base.Content.Load<SoundEffect>("Sounds\\Chat");
				Main.soundInstanceChat = Main.soundChat.CreateInstance();
				Main.soundGrass = base.Content.Load<SoundEffect>("Sounds\\Grass");
				Main.soundInstanceGrass = Main.soundGrass.CreateInstance();
				Main.soundDoorOpen = base.Content.Load<SoundEffect>("Sounds\\Door_Opened");
				Main.soundInstanceDoorOpen = Main.soundDoorOpen.CreateInstance();
				Main.soundDoorClosed = base.Content.Load<SoundEffect>("Sounds\\Door_Closed");
				Main.soundInstanceDoorClosed = Main.soundDoorClosed.CreateInstance();
				Main.soundMenuTick = base.Content.Load<SoundEffect>("Sounds\\Menu_Tick");
				Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
				Main.soundMenuOpen = base.Content.Load<SoundEffect>("Sounds\\Menu_Open");
				Main.soundInstanceMenuOpen = Main.soundMenuOpen.CreateInstance();
				Main.soundMenuClose = base.Content.Load<SoundEffect>("Sounds\\Menu_Close");
				Main.soundInstanceMenuClose = Main.soundMenuClose.CreateInstance();
				Main.soundShatter = base.Content.Load<SoundEffect>("Sounds\\Shatter");
				Main.soundInstanceShatter = Main.soundShatter.CreateInstance();
				Main.soundZombie[0] = base.Content.Load<SoundEffect>("Sounds\\Zombie_0");
				Main.soundInstanceZombie[0] = Main.soundZombie[0].CreateInstance();
				Main.soundZombie[1] = base.Content.Load<SoundEffect>("Sounds\\Zombie_1");
				Main.soundInstanceZombie[1] = Main.soundZombie[1].CreateInstance();
				Main.soundZombie[2] = base.Content.Load<SoundEffect>("Sounds\\Zombie_2");
				Main.soundInstanceZombie[2] = Main.soundZombie[2].CreateInstance();
				Main.soundZombie[3] = base.Content.Load<SoundEffect>("Sounds\\Zombie_3");
				Main.soundInstanceZombie[3] = Main.soundZombie[3].CreateInstance();
				Main.soundZombie[4] = base.Content.Load<SoundEffect>("Sounds\\Zombie_4");
				Main.soundInstanceZombie[4] = Main.soundZombie[4].CreateInstance();
				Main.soundRoar[0] = base.Content.Load<SoundEffect>("Sounds\\Roar_0");
				Main.soundInstanceRoar[0] = Main.soundRoar[0].CreateInstance();
				Main.soundRoar[1] = base.Content.Load<SoundEffect>("Sounds\\Roar_1");
				Main.soundInstanceRoar[1] = Main.soundRoar[1].CreateInstance();
				Main.soundSplash[0] = base.Content.Load<SoundEffect>("Sounds\\Splash_0");
				Main.soundInstanceSplash[0] = Main.soundRoar[0].CreateInstance();
				Main.soundSplash[1] = base.Content.Load<SoundEffect>("Sounds\\Splash_1");
				Main.soundInstanceSplash[1] = Main.soundSplash[1].CreateInstance();
				Main.soundDoubleJump = base.Content.Load<SoundEffect>("Sounds\\Double_Jump");
				Main.soundInstanceDoubleJump = Main.soundRoar[0].CreateInstance();
				Main.soundRun = base.Content.Load<SoundEffect>("Sounds\\Run");
				Main.soundInstanceRun = Main.soundRun.CreateInstance();
				Main.soundCoins = base.Content.Load<SoundEffect>("Sounds\\Coins");
				Main.soundInstanceCoins = Main.soundCoins.CreateInstance();
				Main.soundUnlock = base.Content.Load<SoundEffect>("Sounds\\Unlock");
				Main.soundInstanceUnlock = Main.soundUnlock.CreateInstance();
				Main.soundMaxMana = base.Content.Load<SoundEffect>("Sounds\\MaxMana");
				Main.soundInstanceMaxMana = Main.soundMaxMana.CreateInstance();
				Main.soundDrown = base.Content.Load<SoundEffect>("Sounds\\Drown");
				Main.soundInstanceDrown = Main.soundDrown.CreateInstance();
				for (int j = 1; j < 38; j++)
				{
					Main.soundItem[j] = base.Content.Load<SoundEffect>("Sounds\\Item_" + j);
					Main.soundInstanceItem[j] = Main.soundItem[j].CreateInstance();
				}
				for (int k = 1; k < 11; k++)
				{
					Main.soundNPCHit[k] = base.Content.Load<SoundEffect>("Sounds\\NPC_Hit_" + k);
					Main.soundInstanceNPCHit[k] = Main.soundNPCHit[k].CreateInstance();
				}
				for (int l = 1; l < 15; l++)
				{
					Main.soundNPCKilled[l] = base.Content.Load<SoundEffect>("Sounds\\NPC_Killed_" + l);
					Main.soundInstanceNPCKilled[l] = Main.soundNPCKilled[l].CreateInstance();
				}
			}
			catch
			{
				Main.musicVolume = 0f;
				Main.soundVolume = 0f;
			}
			Main.reforgeTexture = base.Content.Load<Texture2D>("Images\\Reforge");
			Main.timerTexture = base.Content.Load<Texture2D>("Images\\Timer");
			Main.wofTexture = base.Content.Load<Texture2D>("Images\\WallOfFlesh");
			Main.wallOutlineTexture = base.Content.Load<Texture2D>("Images\\Wall_Outline");
			Main.raTexture = base.Content.Load<Texture2D>("Images\\ra-logo");
			Main.reTexture = base.Content.Load<Texture2D>("Images\\re-logo");
			Main.splashTexture = base.Content.Load<Texture2D>("Images\\splash");
			Main.fadeTexture = base.Content.Load<Texture2D>("Images\\fade-out");
			Main.ghostTexture = base.Content.Load<Texture2D>("Images\\Ghost");
			Main.evilCactusTexture = base.Content.Load<Texture2D>("Images\\Evil_Cactus");
			Main.goodCactusTexture = base.Content.Load<Texture2D>("Images\\Good_Cactus");
			Main.wraithEyeTexture = base.Content.Load<Texture2D>("Images\\Wraith_Eyes");
			Main.MusicBoxTexture = base.Content.Load<Texture2D>("Images\\Music_Box");
			Main.wingsTexture[1] = base.Content.Load<Texture2D>("Images\\Wings_1");
			Main.wingsTexture[2] = base.Content.Load<Texture2D>("Images\\Wings_2");
			Main.destTexture[0] = base.Content.Load<Texture2D>("Images\\Dest1");
			Main.destTexture[1] = base.Content.Load<Texture2D>("Images\\Dest2");
			Main.destTexture[2] = base.Content.Load<Texture2D>("Images\\Dest3");
			Main.wireTexture = base.Content.Load<Texture2D>("Images\\Wires");
			for (int m = 0; m < 6; m++)
			{
				Main.loTexture[m] = base.Content.Load<Texture2D>("Images\\logo_" + (m + 1));
			}
			this.spriteBatch = new SpriteBatch(base.GraphicsDevice);
			for (int n = 1; n < 2; n++)
			{
				Main.bannerTexture[n] = base.Content.Load<Texture2D>("Images\\House_Banner_" + n);
			}
			for (int num = 0; num < 11; num++)
			{
				Main.npcHeadTexture[num] = base.Content.Load<Texture2D>("Images\\NPC_Head_" + num);
			}
			for (int num2 = 0; num2 < 145; num2++)
			{
				Main.tileTexture[num2] = base.Content.Load<Texture2D>("Images\\Tiles_" + num2);
			}
			for (int num3 = 1; num3 < 29; num3++)
			{
				Main.wallTexture[num3] = base.Content.Load<Texture2D>("Images\\Wall_" + num3);
			}
			for (int num4 = 1; num4 < 40; num4++)
			{
				Main.buffTexture[num4] = base.Content.Load<Texture2D>("Images\\Buff_" + num4);
			}
			for (int num5 = 0; num5 < 32; num5++)
			{
				Main.backgroundTexture[num5] = base.Content.Load<Texture2D>("Images\\Background_" + num5);
				Main.backgroundWidth[num5] = Main.backgroundTexture[num5].Width;
				Main.backgroundHeight[num5] = Main.backgroundTexture[num5].Height;
			}
			for (int num6 = 0; num6 < 586; num6++)
			{
				Main.itemTexture[num6] = base.Content.Load<Texture2D>("Images\\Item_" + num6);
			}
			for (int num7 = 0; num7 < 142; num7++)
			{
				Main.npcTexture[num7] = base.Content.Load<Texture2D>("Images\\NPC_" + num7);
			}
			for (int num8 = 0; num8 < 142; num8++)
			{
				NPC nPC = new NPC();
				nPC.SetDefaults(num8, -1f);
				Main.npcName[num8] = nPC.name;
			}
			for (int num9 = 0; num9 < 109; num9++)
			{
				Main.projectileTexture[num9] = base.Content.Load<Texture2D>("Images\\Projectile_" + num9);
			}
			for (int num10 = 1; num10 < 157; num10++)
			{
				Main.goreTexture[num10] = base.Content.Load<Texture2D>("Images\\Gore_" + num10);
			}
			for (int num11 = 0; num11 < 4; num11++)
			{
				Main.cloudTexture[num11] = base.Content.Load<Texture2D>("Images\\Cloud_" + num11);
			}
			for (int num12 = 0; num12 < 5; num12++)
			{
				Main.starTexture[num12] = base.Content.Load<Texture2D>("Images\\Star_" + num12);
			}
			for (int num13 = 0; num13 < 2; num13++)
			{
				Main.liquidTexture[num13] = base.Content.Load<Texture2D>("Images\\Liquid_" + num13);
			}
			Main.npcToggleTexture[0] = base.Content.Load<Texture2D>("Images\\House_1");
			Main.npcToggleTexture[1] = base.Content.Load<Texture2D>("Images\\House_2");
			Main.HBLockTexture[0] = base.Content.Load<Texture2D>("Images\\Lock_0");
			Main.HBLockTexture[1] = base.Content.Load<Texture2D>("Images\\Lock_1");
			Main.gridTexture = base.Content.Load<Texture2D>("Images\\Grid");
			Main.trashTexture = base.Content.Load<Texture2D>("Images\\Trash");
			Main.cdTexture = base.Content.Load<Texture2D>("Images\\CoolDown");
			Main.logoTexture = base.Content.Load<Texture2D>("Images\\Logo");
			Main.logo2Texture = base.Content.Load<Texture2D>("Images\\Logo2");
			Main.logo3Texture = base.Content.Load<Texture2D>("Images\\Logo3");
			Main.dustTexture = base.Content.Load<Texture2D>("Images\\Dust");
			Main.sunTexture = base.Content.Load<Texture2D>("Images\\Sun");
			Main.sun2Texture = base.Content.Load<Texture2D>("Images\\Sun2");
			Main.moonTexture = base.Content.Load<Texture2D>("Images\\Moon");
			Main.blackTileTexture = base.Content.Load<Texture2D>("Images\\Black_Tile");
			Main.heartTexture = base.Content.Load<Texture2D>("Images\\Heart");
			Main.bubbleTexture = base.Content.Load<Texture2D>("Images\\Bubble");
			Main.manaTexture = base.Content.Load<Texture2D>("Images\\Mana");
			Main.cursorTexture = base.Content.Load<Texture2D>("Images\\Cursor");
			Main.ninjaTexture = base.Content.Load<Texture2D>("Images\\Ninja");
			Main.antLionTexture = base.Content.Load<Texture2D>("Images\\AntlionBody");
			Main.spikeBaseTexture = base.Content.Load<Texture2D>("Images\\Spike_Base");
			Main.treeTopTexture[0] = base.Content.Load<Texture2D>("Images\\Tree_Tops_0");
			Main.treeBranchTexture[0] = base.Content.Load<Texture2D>("Images\\Tree_Branches_0");
			Main.treeTopTexture[1] = base.Content.Load<Texture2D>("Images\\Tree_Tops_1");
			Main.treeBranchTexture[1] = base.Content.Load<Texture2D>("Images\\Tree_Branches_1");
			Main.treeTopTexture[2] = base.Content.Load<Texture2D>("Images\\Tree_Tops_2");
			Main.treeBranchTexture[2] = base.Content.Load<Texture2D>("Images\\Tree_Branches_2");
			Main.treeTopTexture[3] = base.Content.Load<Texture2D>("Images\\Tree_Tops_3");
			Main.treeBranchTexture[3] = base.Content.Load<Texture2D>("Images\\Tree_Branches_3");
			Main.shroomCapTexture = base.Content.Load<Texture2D>("Images\\Shroom_Tops");
			Main.inventoryBackTexture = base.Content.Load<Texture2D>("Images\\Inventory_Back");
			Main.inventoryBack2Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back2");
			Main.inventoryBack3Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back3");
			Main.inventoryBack4Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back4");
			Main.inventoryBack5Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back5");
			Main.inventoryBack6Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back6");
			Main.inventoryBack7Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back7");
			Main.inventoryBack8Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back8");
			Main.inventoryBack9Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back9");
			Main.inventoryBack10Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back10");
			Main.inventoryBack11Texture = base.Content.Load<Texture2D>("Images\\Inventory_Back11");
			Main.textBackTexture = base.Content.Load<Texture2D>("Images\\Text_Back");
			Main.chatTexture = base.Content.Load<Texture2D>("Images\\Chat");
			Main.chat2Texture = base.Content.Load<Texture2D>("Images\\Chat2");
			Main.chatBackTexture = base.Content.Load<Texture2D>("Images\\Chat_Back");
			Main.teamTexture = base.Content.Load<Texture2D>("Images\\Team");
			for (int num14 = 1; num14 < 25; num14++)
			{
				Main.femaleBodyTexture[num14] = base.Content.Load<Texture2D>("Images\\Female_Body_" + num14);
				Main.armorBodyTexture[num14] = base.Content.Load<Texture2D>("Images\\Armor_Body_" + num14);
				Main.armorArmTexture[num14] = base.Content.Load<Texture2D>("Images\\Armor_Arm_" + num14);
			}
			for (int num15 = 1; num15 < 44; num15++)
			{
				Main.armorHeadTexture[num15] = base.Content.Load<Texture2D>("Images\\Armor_Head_" + num15);
			}
			for (int num16 = 1; num16 < 24; num16++)
			{
				Main.armorLegTexture[num16] = base.Content.Load<Texture2D>("Images\\Armor_Legs_" + num16);
			}
			for (int num17 = 0; num17 < 36; num17++)
			{
				Main.playerHairTexture[num17] = base.Content.Load<Texture2D>("Images\\Player_Hair_" + (num17 + 1));
			}
			Main.skinBodyTexture = base.Content.Load<Texture2D>("Images\\Skin_Body");
			Main.skinLegsTexture = base.Content.Load<Texture2D>("Images\\Skin_Legs");
			Main.playerEyeWhitesTexture = base.Content.Load<Texture2D>("Images\\Player_Eye_Whites");
			Main.playerEyesTexture = base.Content.Load<Texture2D>("Images\\Player_Eyes");
			Main.playerHandsTexture = base.Content.Load<Texture2D>("Images\\Player_Hands");
			Main.playerHands2Texture = base.Content.Load<Texture2D>("Images\\Player_Hands2");
			Main.playerHeadTexture = base.Content.Load<Texture2D>("Images\\Player_Head");
			Main.playerPantsTexture = base.Content.Load<Texture2D>("Images\\Player_Pants");
			Main.playerShirtTexture = base.Content.Load<Texture2D>("Images\\Player_Shirt");
			Main.playerShoesTexture = base.Content.Load<Texture2D>("Images\\Player_Shoes");
			Main.playerUnderShirtTexture = base.Content.Load<Texture2D>("Images\\Player_Undershirt");
			Main.playerUnderShirt2Texture = base.Content.Load<Texture2D>("Images\\Player_Undershirt2");
			Main.femalePantsTexture = base.Content.Load<Texture2D>("Images\\Female_Pants");
			Main.femaleShirtTexture = base.Content.Load<Texture2D>("Images\\Female_Shirt");
			Main.femaleShoesTexture = base.Content.Load<Texture2D>("Images\\Female_Shoes");
			Main.femaleUnderShirtTexture = base.Content.Load<Texture2D>("Images\\Female_Undershirt");
			Main.femaleUnderShirt2Texture = base.Content.Load<Texture2D>("Images\\Female_Undershirt2");
			Main.femaleShirt2Texture = base.Content.Load<Texture2D>("Images\\Female_Shirt2");
			Main.chaosTexture = base.Content.Load<Texture2D>("Images\\Chaos");
			Main.EyeLaserTexture = base.Content.Load<Texture2D>("Images\\Eye_Laser");
			Main.BoneEyesTexture = base.Content.Load<Texture2D>("Images\\Bone_eyes");
			Main.BoneLaserTexture = base.Content.Load<Texture2D>("Images\\Bone_Laser");
			Main.lightDiscTexture = base.Content.Load<Texture2D>("Images\\Light_Disc");
			Main.confuseTexture = base.Content.Load<Texture2D>("Images\\Confuse");
			Main.probeTexture = base.Content.Load<Texture2D>("Images\\Probe");
			Main.chainTexture = base.Content.Load<Texture2D>("Images\\Chain");
			Main.chain2Texture = base.Content.Load<Texture2D>("Images\\Chain2");
			Main.chain3Texture = base.Content.Load<Texture2D>("Images\\Chain3");
			Main.chain4Texture = base.Content.Load<Texture2D>("Images\\Chain4");
			Main.chain5Texture = base.Content.Load<Texture2D>("Images\\Chain5");
			Main.chain6Texture = base.Content.Load<Texture2D>("Images\\Chain6");
			Main.chain7Texture = base.Content.Load<Texture2D>("Images\\Chain7");
			Main.chain8Texture = base.Content.Load<Texture2D>("Images\\Chain8");
			Main.chain9Texture = base.Content.Load<Texture2D>("Images\\Chain9");
			Main.chain10Texture = base.Content.Load<Texture2D>("Images\\Chain10");
			Main.chain11Texture = base.Content.Load<Texture2D>("Images\\Chain11");
			Main.chain12Texture = base.Content.Load<Texture2D>("Images\\Chain12");
			Main.boneArmTexture = base.Content.Load<Texture2D>("Images\\Arm_Bone");
			Main.boneArm2Texture = base.Content.Load<Texture2D>("Images\\Arm_Bone_2");
			Main.fontItemStack = base.Content.Load<SpriteFont>("Fonts\\Item_Stack");
			Main.fontMouseText = base.Content.Load<SpriteFont>("Fonts\\Mouse_Text");
			Main.fontDeathText = base.Content.Load<SpriteFont>("Fonts\\Death_Text");
			Main.fontCombatText[0] = base.Content.Load<SpriteFont>("Fonts\\Combat_Text");
			Main.fontCombatText[1] = base.Content.Load<SpriteFont>("Fonts\\Combat_Crit");
		}
		protected override void UnloadContent()
		{
		}
		protected void UpdateMusic()
		{
			try
			{
				if (!Main.dedServ)
				{
					if (Main.curMusic > 0)
					{
						if (!base.IsActive)
						{
							if (!Main.music[Main.curMusic].IsPaused && Main.music[Main.curMusic].IsPlaying)
							{
								try
								{
									Main.music[Main.curMusic].Pause();
								}
								catch
								{
								}
							}
							return;
						}
						if (Main.music[Main.curMusic].IsPaused)
						{
							Main.music[Main.curMusic].Resume();
						}
					}
					bool flag = false;
					bool flag2 = false;
					bool flag3 = false;
					Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
					int num = 5000;
					for (int i = 0; i < 200; i++)
					{
						if (Main.npc[i].active)
						{
							if (Main.npc[i].type == 134)
							{
								Rectangle value = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
								if (rectangle.Intersects(value))
								{
									flag3 = true;
									break;
								}
							}
							else
							{
								if (Main.npc[i].type == 113 || Main.npc[i].type == 114 || Main.npc[i].type == 125 || Main.npc[i].type == 126)
								{
									Rectangle value2 = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
									if (rectangle.Intersects(value2))
									{
										flag2 = true;
										break;
									}
								}
								else
								{
									if (Main.npc[i].boss || Main.npc[i].type == 13 || Main.npc[i].type == 14 || Main.npc[i].type == 15 || Main.npc[i].type == 134 || Main.npc[i].type == 26 || Main.npc[i].type == 27 || Main.npc[i].type == 28 || Main.npc[i].type == 29 || Main.npc[i].type == 111)
									{
										Rectangle value3 = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
										if (rectangle.Intersects(value3))
										{
											flag = true;
											break;
										}
									}
								}
							}
						}
					}
					if (Main.musicVolume == 0f)
					{
						this.newMusic = 0;
					}
					else
					{
						if (Main.gameMenu)
						{
							if (Main.netMode != 2)
							{
								this.newMusic = 6;
							}
							else
							{
								this.newMusic = 0;
							}
						}
						else
						{
							if (flag2)
							{
								this.newMusic = 12;
							}
							else
							{
								if (flag)
								{
									this.newMusic = 5;
								}
								else
								{
									if (flag3)
									{
										this.newMusic = 13;
									}
									else
									{
										if (Main.player[Main.myPlayer].position.Y > (float)((Main.maxTilesY - 200) * 16))
										{
											this.newMusic = 2;
										}
										else
										{
											if (Main.player[Main.myPlayer].zoneEvil)
											{
												if ((double)Main.player[Main.myPlayer].position.Y > Main.worldSurface * 16.0 + (double)Main.screenHeight)
												{
													this.newMusic = 10;
												}
												else
												{
													this.newMusic = 8;
												}
											}
											else
											{
												if (Main.player[Main.myPlayer].zoneMeteor || Main.player[Main.myPlayer].zoneDungeon)
												{
													this.newMusic = 2;
												}
												else
												{
													if (Main.player[Main.myPlayer].zoneJungle)
													{
														this.newMusic = 7;
													}
													else
													{
														if ((double)Main.player[Main.myPlayer].position.Y > Main.worldSurface * 16.0 + (double)Main.screenHeight)
														{
															if (Main.player[Main.myPlayer].zoneHoly)
															{
																this.newMusic = 11;
															}
															else
															{
																this.newMusic = 4;
															}
														}
														else
														{
															if (Main.dayTime)
															{
																if (Main.player[Main.myPlayer].zoneHoly)
																{
																	this.newMusic = 9;
																}
																else
																{
																	this.newMusic = 1;
																}
															}
															else
															{
																if (!Main.dayTime)
																{
																	if (Main.bloodMoon)
																	{
																		this.newMusic = 2;
																	}
																	else
																	{
																		this.newMusic = 3;
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					if (Main.gameMenu)
					{
						Main.musicBox2 = -1;
						Main.musicBox = -1;
					}
					if (Main.musicBox2 >= 0)
					{
						Main.musicBox = Main.musicBox2;
					}
					if (Main.musicBox >= 0)
					{
						if (Main.musicBox == 0)
						{
							this.newMusic = 1;
						}
						if (Main.musicBox == 1)
						{
							this.newMusic = 2;
						}
						if (Main.musicBox == 2)
						{
							this.newMusic = 3;
						}
						if (Main.musicBox == 4)
						{
							this.newMusic = 4;
						}
						if (Main.musicBox == 5)
						{
							this.newMusic = 5;
						}
						if (Main.musicBox == 3)
						{
							this.newMusic = 6;
						}
						if (Main.musicBox == 6)
						{
							this.newMusic = 7;
						}
						if (Main.musicBox == 7)
						{
							this.newMusic = 8;
						}
						if (Main.musicBox == 9)
						{
							this.newMusic = 9;
						}
						if (Main.musicBox == 8)
						{
							this.newMusic = 10;
						}
						if (Main.musicBox == 11)
						{
							this.newMusic = 11;
						}
						if (Main.musicBox == 10)
						{
							this.newMusic = 12;
						}
						if (Main.musicBox == 12)
						{
							this.newMusic = 13;
						}
					}
					Main.curMusic = this.newMusic;
					for (int j = 1; j < 14; j++)
					{
						if (j == Main.curMusic)
						{
							if (!Main.music[j].IsPlaying)
							{
								Main.music[j] = Main.soundBank.GetCue("Music_" + j);
								Main.music[j].Play();
								Main.music[j].SetVariable("Volume", Main.musicFade[j] * Main.musicVolume);
							}
							else
							{
								Main.musicFade[j] += 0.005f;
								if (Main.musicFade[j] > 1f)
								{
									Main.musicFade[j] = 1f;
								}
								Main.music[j].SetVariable("Volume", Main.musicFade[j] * Main.musicVolume);
							}
						}
						else
						{
							if (Main.music[j].IsPlaying)
							{
								if (Main.musicFade[Main.curMusic] > 0.25f)
								{
									Main.musicFade[j] -= 0.005f;
								}
								else
								{
									if (Main.curMusic == 0)
									{
										Main.musicFade[j] = 0f;
									}
								}
								if (Main.musicFade[j] <= 0f)
								{
									Main.musicFade[j] -= 0f;
									Main.music[j].Stop(AudioStopOptions.Immediate);
								}
								else
								{
									Main.music[j].SetVariable("Volume", Main.musicFade[j] * Main.musicVolume);
								}
							}
							else
							{
								Main.musicFade[j] = 0f;
							}
						}
					}
				}
			}
			catch
			{
				Main.musicVolume = 0f;
			}
		}
		protected override void Update(GameTime gameTime)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			WorldGen.destroyObject = false;
			if (!Main.dedServ)
			{
				if (Main.fixedTiming)
				{
					if (base.IsActive)
					{
						base.IsFixedTimeStep = false;
					}
					else
					{
						base.IsFixedTimeStep = true;
					}
				}
				else
				{
					base.IsFixedTimeStep = true;
				}
				this.graphics.SynchronizeWithVerticalRetrace = true;
				this.UpdateMusic();
				if (Main.showSplash)
				{
					return;
				}
				if (!Main.gameMenu && Main.netMode == 1)
				{
					if (!Main.saveTime.IsRunning)
					{
						Main.saveTime.Start();
					}
					if (Main.saveTime.ElapsedMilliseconds > 300000L)
					{
						Main.saveTime.Reset();
						WorldGen.saveToonWhilePlaying();
					}
				}
				else
				{
					if (!Main.gameMenu && Main.autoSave)
					{
						if (!Main.saveTime.IsRunning)
						{
							Main.saveTime.Start();
						}
						if (Main.saveTime.ElapsedMilliseconds > 600000L)
						{
							Main.saveTime.Reset();
							WorldGen.saveToonWhilePlaying();
							WorldGen.saveAndPlay();
						}
					}
					else
					{
						if (Main.saveTime.IsRunning)
						{
							Main.saveTime.Stop();
						}
					}
				}
				if (Main.teamCooldown > 0)
				{
					Main.teamCooldown--;
				}
				Main.updateTime++;
				if (Main.fpsTimer.ElapsedMilliseconds >= 1000L)
				{
					if (Main.fpsCount >= 60)
					{
						Main.gfxQuality += Main.gfxRate;
						Main.gfxRate += 0.005f;
					}
					else
					{
						if (Main.fpsCount < 59)
						{
							Main.gfxRate = 0.01f;
							if (Main.fpsCount <= 50)
							{
								Main.gfxQuality -= 0.15f;
							}
							else
							{
								if (Main.fpsCount <= 55)
								{
									Main.gfxQuality -= 0.1f;
								}
								else
								{
									if (Main.fpsCount <= 58)
									{
										Main.gfxQuality -= 0.05f;
									}
									else
									{
										Main.gfxQuality -= 0.01f;
									}
								}
							}
						}
					}
					if (Main.gfxQuality < 0f)
					{
						Main.gfxQuality = 0f;
					}
					if (Main.gfxQuality > 1f)
					{
						Main.gfxQuality = 1f;
					}
					if (Main.maxQ && base.IsActive)
					{
						Main.gfxQuality = 1f;
						Main.maxQ = false;
					}
					Main.updateRate = Main.uCount;
					Main.frameRate = Main.fpsCount;
					Main.fpsCount = 0;
					Main.fpsTimer.Restart();
					Main.updateTime = 0;
					Main.drawTime = 0;
					Main.uCount = 0;
					if (Main.netMode == 2)
					{
						Main.cloudLimit = 0;
					}
				}
				if (Main.fixedTiming)
				{
					float num = 16f;
					float num2 = (float)Main.updateTimer.ElapsedMilliseconds;
					if (num2 + Main.uCarry < num)
					{
						Main.drawSkip = true;
						return;
					}
					Main.uCarry += num2 - num;
					if (Main.uCarry > 1000f)
					{
						Main.uCarry = 1000f;
					}
					Main.updateTimer.Restart();
				}
				Main.uCount++;
				Main.drawSkip = false;
				if (Main.qaStyle == 1)
				{
					Main.gfxQuality = 1f;
				}
				else
				{
					if (Main.qaStyle == 2)
					{
						Main.gfxQuality = 0.5f;
					}
					else
					{
						if (Main.qaStyle == 3)
						{
							Main.gfxQuality = 0f;
						}
					}
				}
				Main.numDust = (int)(2000f * (Main.gfxQuality * 0.75f + 0.25f));
				Gore.goreTime = (int)(600f * Main.gfxQuality);
				Main.cloudLimit = (int)(100f * Main.gfxQuality);
				Liquid.maxLiquid = (int)(2500f + 2500f * Main.gfxQuality);
				Liquid.cycles = (int)(17f - 10f * Main.gfxQuality);
				if ((double)Main.gfxQuality < 0.5)
				{
					this.graphics.SynchronizeWithVerticalRetrace = false;
				}
				else
				{
					this.graphics.SynchronizeWithVerticalRetrace = true;
				}
				if ((double)Main.gfxQuality < 0.05)
				{
					Lighting.maxRenderCount = 9;
				}
				else
				{
					if ((double)Main.gfxQuality < 0.25)
					{
						Lighting.maxRenderCount = 8;
					}
					else
					{
						if ((double)Main.gfxQuality < 0.5)
						{
							Lighting.maxRenderCount = 7;
						}
						else
						{
							if ((double)Main.gfxQuality < 0.75)
							{
								Lighting.maxRenderCount = 6;
							}
							else
							{
								if ((double)Main.gfxQuality < 0.95)
								{
									Lighting.maxRenderCount = 5;
								}
								else
								{
									Lighting.maxRenderCount = 4;
								}
							}
						}
					}
				}
				if (Liquid.quickSettle)
				{
					Liquid.maxLiquid = Liquid.resLiquid;
					Liquid.cycles = 1;
				}
				if (!base.IsActive)
				{
					Main.hasFocus = false;
				}
				else
				{
					Main.hasFocus = true;
				}
				if (!base.IsActive && Main.netMode == 0)
				{
					base.IsMouseVisible = true;
					if (Main.netMode != 2 && Main.myPlayer >= 0)
					{
						Main.player[Main.myPlayer].delayUseItem = true;
					}
					Main.mouseLeftRelease = false;
					Main.mouseRightRelease = false;
					if (Main.gameMenu)
					{
						Main.UpdateMenu();
					}
					Main.gamePaused = true;
					return;
				}
				base.IsMouseVisible = false;
				Main.demonTorch += (float)Main.demonTorchDir * 0.01f;
				if (Main.demonTorch > 1f)
				{
					Main.demonTorch = 1f;
					Main.demonTorchDir = -1;
				}
				if (Main.demonTorch < 0f)
				{
					Main.demonTorch = 0f;
					Main.demonTorchDir = 1;
				}
				int num3 = 7;
				if (this.DiscoStyle == 0)
				{
					Main.DiscoG += num3;
					if (Main.DiscoG >= 255)
					{
						Main.DiscoG = 255;
						this.DiscoStyle++;
					}
					Main.DiscoR -= num3;
					if (Main.DiscoR <= 0)
					{
						Main.DiscoR = 0;
					}
				}
				else
				{
					if (this.DiscoStyle == 1)
					{
						Main.DiscoB += num3;
						if (Main.DiscoB >= 255)
						{
							Main.DiscoB = 255;
							this.DiscoStyle++;
						}
						Main.DiscoG -= num3;
						if (Main.DiscoG <= 0)
						{
							Main.DiscoG = 0;
						}
					}
					else
					{
						Main.DiscoR += num3;
						if (Main.DiscoR >= 255)
						{
							Main.DiscoR = 255;
							this.DiscoStyle = 0;
						}
						Main.DiscoB -= num3;
						if (Main.DiscoB <= 0)
						{
							Main.DiscoB = 0;
						}
					}
				}
				if (Main.keyState.IsKeyDown(Keys.F10) && !Main.chatMode && !Main.editSign)
				{
					if (Main.frameRelease)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.showFrameRate)
						{
							Main.showFrameRate = false;
						}
						else
						{
							Main.showFrameRate = true;
						}
					}
					Main.frameRelease = false;
				}
				else
				{
					Main.frameRelease = true;
				}
				if (Main.keyState.IsKeyDown(Keys.F9) && !Main.chatMode && !Main.editSign)
				{
					if (Main.RGBRelease)
					{
						Lighting.lightCounter += 100;
						Main.PlaySound(12, -1, -1, 1);
						Lighting.lightMode++;
						if (Lighting.lightMode >= 4)
						{
							Lighting.lightMode = 0;
						}
						if (Lighting.lightMode == 2 || Lighting.lightMode == 0)
						{
							Main.renderCount = 0;
							Main.renderNow = true;
							int num4 = Main.screenWidth / 16 + Lighting.offScreenTiles * 2;
							int num5 = Main.screenHeight / 16 + Lighting.offScreenTiles * 2;
							for (int i = 0; i < num4; i++)
							{
								for (int j = 0; j < num5; j++)
								{
									Lighting.color[i, j] = 0f;
									Lighting.colorG[i, j] = 0f;
									Lighting.colorB[i, j] = 0f;
								}
							}
						}
					}
					Main.RGBRelease = false;
				}
				else
				{
					Main.RGBRelease = true;
				}
				if (Main.keyState.IsKeyDown(Keys.F8) && !Main.chatMode && !Main.editSign)
				{
					if (Main.netRelease)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.netDiag)
						{
							Main.netDiag = false;
						}
						else
						{
							Main.netDiag = true;
						}
					}
					Main.netRelease = false;
				}
				else
				{
					Main.netRelease = true;
				}
				if (Main.keyState.IsKeyDown(Keys.F7) && !Main.chatMode && !Main.editSign)
				{
					if (Main.drawRelease)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (Main.drawDiag)
						{
							Main.drawDiag = false;
						}
						else
						{
							Main.drawDiag = true;
						}
					}
					Main.drawRelease = false;
				}
				else
				{
					Main.drawRelease = true;
				}
				if (Main.keyState.IsKeyDown(Keys.F11))
				{
					if (Main.releaseUI)
					{
						if (Main.hideUI)
						{
							Main.hideUI = false;
						}
						else
						{
							Main.hideUI = true;
						}
					}
					Main.releaseUI = false;
				}
				else
				{
					Main.releaseUI = true;
				}
				if ((Main.keyState.IsKeyDown(Keys.LeftAlt) || Main.keyState.IsKeyDown(Keys.RightAlt)) && Main.keyState.IsKeyDown(Keys.Enter))
				{
					if (this.toggleFullscreen)
					{
						this.graphics.ToggleFullScreen();
						Main.chatRelease = false;
					}
					this.toggleFullscreen = false;
				}
				else
				{
					this.toggleFullscreen = true;
				}
				if (!Main.gamePad || Main.gameMenu)
				{
					Main.oldMouseState = Main.mouseState;
					Main.mouseState = Mouse.GetState();
					Main.mouseX = Main.mouseState.X;
					Main.mouseY = Main.mouseState.Y;
					Main.mouseLeft = false;
					Main.mouseRight = false;
					if (Main.mouseState.LeftButton == ButtonState.Pressed)
					{
						Main.mouseLeft = true;
					}
					if (Main.mouseState.RightButton == ButtonState.Pressed)
					{
						Main.mouseRight = true;
					}
				}
				Main.keyState = Keyboard.GetState();
				if (Main.editSign)
				{
					Main.chatMode = false;
				}
				if (Main.chatMode)
				{
					if (Main.keyState.IsKeyDown(Keys.Escape))
					{
						Main.chatMode = false;
					}
					string a = Main.chatText;
					Main.chatText = Main.GetInputText(Main.chatText);
					while (Main.fontMouseText.MeasureString(Main.chatText).X > 470f)
					{
						Main.chatText = Main.chatText.Substring(0, Main.chatText.Length - 1);
					}
					if (a != Main.chatText)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					if (Main.inputTextEnter && Main.chatRelease)
					{
						if (Main.chatText != "")
						{
							NetMessage.SendData(25, -1, -1, Main.chatText, Main.myPlayer, 0f, 0f, 0f, 0);
						}
						Main.chatText = "";
						Main.chatMode = false;
						Main.chatRelease = false;
						Main.player[Main.myPlayer].releaseHook = false;
						Main.player[Main.myPlayer].releaseThrow = false;
						Main.PlaySound(11, -1, -1, 1);
					}
				}
				if (Main.keyState.IsKeyDown(Keys.Enter) && Main.netMode == 1 && !Main.keyState.IsKeyDown(Keys.LeftAlt) && !Main.keyState.IsKeyDown(Keys.RightAlt))
				{
					if (Main.chatRelease && !Main.chatMode && !Main.editSign && !Main.keyState.IsKeyDown(Keys.Escape))
					{
						Main.PlaySound(10, -1, -1, 1);
						Main.chatMode = true;
						Main.chatText = "";
					}
					Main.chatRelease = false;
				}
				else
				{
					Main.chatRelease = true;
				}
				if (Main.gameMenu)
				{
					Main.UpdateMenu();
					if (Main.netMode != 2)
					{
						return;
					}
					Main.gamePaused = false;
				}
			}
			if (Main.netMode == 1)
			{
				for (int k = 0; k < 49; k++)
				{
					if (Main.player[Main.myPlayer].inventory[k].IsNotTheSameAs(Main.clientPlayer.inventory[k]))
					{
						NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].inventory[k].name, Main.myPlayer, (float)k, (float)Main.player[Main.myPlayer].inventory[k].prefix, 0f, 0);
					}
				}
				if (Main.player[Main.myPlayer].armor[0].IsNotTheSameAs(Main.clientPlayer.armor[0]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[0].name, Main.myPlayer, 49f, (float)Main.player[Main.myPlayer].armor[0].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[1].IsNotTheSameAs(Main.clientPlayer.armor[1]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[1].name, Main.myPlayer, 50f, (float)Main.player[Main.myPlayer].armor[1].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[2].IsNotTheSameAs(Main.clientPlayer.armor[2]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[2].name, Main.myPlayer, 51f, (float)Main.player[Main.myPlayer].armor[2].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[3].IsNotTheSameAs(Main.clientPlayer.armor[3]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[3].name, Main.myPlayer, 52f, (float)Main.player[Main.myPlayer].armor[3].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[4].IsNotTheSameAs(Main.clientPlayer.armor[4]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[4].name, Main.myPlayer, 53f, (float)Main.player[Main.myPlayer].armor[4].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[5].IsNotTheSameAs(Main.clientPlayer.armor[5]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[5].name, Main.myPlayer, 54f, (float)Main.player[Main.myPlayer].armor[5].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[6].IsNotTheSameAs(Main.clientPlayer.armor[6]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[6].name, Main.myPlayer, 55f, (float)Main.player[Main.myPlayer].armor[6].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[7].IsNotTheSameAs(Main.clientPlayer.armor[7]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[7].name, Main.myPlayer, 56f, (float)Main.player[Main.myPlayer].armor[7].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[8].IsNotTheSameAs(Main.clientPlayer.armor[8]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[8].name, Main.myPlayer, 57f, (float)Main.player[Main.myPlayer].armor[8].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[9].IsNotTheSameAs(Main.clientPlayer.armor[9]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[9].name, Main.myPlayer, 58f, (float)Main.player[Main.myPlayer].armor[9].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].armor[10].IsNotTheSameAs(Main.clientPlayer.armor[10]))
				{
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[10].name, Main.myPlayer, 59f, (float)Main.player[Main.myPlayer].armor[10].prefix, 0f, 0);
				}
				if (Main.player[Main.myPlayer].chest != Main.clientPlayer.chest)
				{
					NetMessage.SendData(33, -1, -1, "", Main.player[Main.myPlayer].chest, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].talkNPC != Main.clientPlayer.talkNPC)
				{
					NetMessage.SendData(40, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneEvil != Main.clientPlayer.zoneEvil)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneMeteor != Main.clientPlayer.zoneMeteor)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneDungeon != Main.clientPlayer.zoneDungeon)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneJungle != Main.clientPlayer.zoneJungle)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				if (Main.player[Main.myPlayer].zoneHoly != Main.clientPlayer.zoneHoly)
				{
					NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
				bool flag = false;
				for (int l = 0; l < 10; l++)
				{
					if (Main.player[Main.myPlayer].buffType[l] != Main.clientPlayer.buffType[l])
					{
						flag = true;
					}
				}
				if (flag)
				{
					NetMessage.SendData(50, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
					NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				}
			}
			if (Main.netMode == 1)
			{
				Main.clientPlayer = (Player)Main.player[Main.myPlayer].clientClone();
			}
			if (Main.netMode == 0 && (Main.playerInventory || Main.npcChatText != "" || Main.player[Main.myPlayer].sign >= 0) && Main.autoPause)
			{
				Keys[] pressedKeys = Main.keyState.GetPressedKeys();
				Main.player[Main.myPlayer].controlInv = false;
				for (int m = 0; m < pressedKeys.Length; m++)
				{
					string a2 = string.Concat(pressedKeys[m]);
					if (a2 == Main.cInv)
					{
						Main.player[Main.myPlayer].controlInv = true;
					}
				}
				if (Main.player[Main.myPlayer].controlInv)
				{
					if (Main.player[Main.myPlayer].releaseInventory)
					{
						Main.player[Main.myPlayer].toggleInv();
					}
					Main.player[Main.myPlayer].releaseInventory = false;
				}
				else
				{
					Main.player[Main.myPlayer].releaseInventory = true;
				}
				if (Main.playerInventory)
				{
					int num6 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
					Main.focusRecipe += num6;
					if (Main.focusRecipe > Main.numAvailableRecipes - 1)
					{
						Main.focusRecipe = Main.numAvailableRecipes - 1;
					}
					if (Main.focusRecipe < 0)
					{
						Main.focusRecipe = 0;
					}
					Main.player[Main.myPlayer].dropItemCheck();
				}
				Main.player[Main.myPlayer].head = Main.player[Main.myPlayer].armor[0].headSlot;
				Main.player[Main.myPlayer].body = Main.player[Main.myPlayer].armor[1].bodySlot;
				Main.player[Main.myPlayer].legs = Main.player[Main.myPlayer].armor[2].legSlot;
				if (!Main.player[Main.myPlayer].hostile)
				{
					if (Main.player[Main.myPlayer].armor[8].headSlot >= 0)
					{
						Main.player[Main.myPlayer].head = Main.player[Main.myPlayer].armor[8].headSlot;
					}
					if (Main.player[Main.myPlayer].armor[9].bodySlot >= 0)
					{
						Main.player[Main.myPlayer].body = Main.player[Main.myPlayer].armor[9].bodySlot;
					}
					if (Main.player[Main.myPlayer].armor[10].legSlot >= 0)
					{
						Main.player[Main.myPlayer].legs = Main.player[Main.myPlayer].armor[10].legSlot;
					}
				}
				if (Main.editSign)
				{
					if (Main.player[Main.myPlayer].sign == -1)
					{
						Main.editSign = false;
					}
					else
					{
						Main.npcChatText = Main.GetInputText(Main.npcChatText);
						if (Main.inputTextEnter)
						{
							byte[] bytes = new byte[]
							{
								10
							};
							Main.npcChatText += Encoding.ASCII.GetString(bytes);
						}
					}
				}
				Main.gamePaused = true;
				return;
			}
			Main.gamePaused = false;
			if (!Main.dedServ && (double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0 && Main.netMode != 2)
			{
				Star.UpdateStars();
				Cloud.UpdateClouds();
			}
			int n = 0;
			while (n < 255)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.player[n].UpdatePlayer(n);
						goto IL_15E4;
					}
					catch
					{
						goto IL_15E4;
					}
					goto IL_15D5;
				}
				goto IL_15D5;
				IL_15E4:
				n++;
				continue;
				IL_15D5:
				Main.player[n].UpdatePlayer(n);
				goto IL_15E4;
			}
			if (Main.netMode != 1)
			{
				NPC.SpawnNPC();
			}
			for (int num7 = 0; num7 < 255; num7++)
			{
				Main.player[num7].activeNPCs = 0f;
				Main.player[num7].townNPCs = 0f;
			}
			if (Main.wof >= 0 && !Main.npc[Main.wof].active)
			{
				Main.wof = -1;
			}
			int num8 = 0;
			while (num8 < 200)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.npc[num8].UpdateNPC(num8);
						goto IL_1694;
					}
					catch (Exception)
					{
						Main.npc[num8] = new NPC();
						goto IL_1694;
					}
					goto IL_1685;
				}
				goto IL_1685;
				IL_1694:
				num8++;
				continue;
				IL_1685:
				Main.npc[num8].UpdateNPC(num8);
				goto IL_1694;
			}
			int num9 = 0;
			while (num9 < 200)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.gore[num9].Update();
						goto IL_16DB;
					}
					catch
					{
						Main.gore[num9] = new Gore();
						goto IL_16DB;
					}
					goto IL_16CE;
				}
				goto IL_16CE;
				IL_16DB:
				num9++;
				continue;
				IL_16CE:
				Main.gore[num9].Update();
				goto IL_16DB;
			}
			int num10 = 0;
			while (num10 < 1000)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.projectile[num10].Update(num10);
						goto IL_1726;
					}
					catch
					{
						Main.projectile[num10] = new Projectile();
						goto IL_1726;
					}
					goto IL_1717;
				}
				goto IL_1717;
				IL_1726:
				num10++;
				continue;
				IL_1717:
				Main.projectile[num10].Update(num10);
				goto IL_1726;
			}
			int num11 = 0;
			while (num11 < 200)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						Main.item[num11].UpdateItem(num11);
						goto IL_1771;
					}
					catch
					{
						Main.item[num11] = new Item();
						goto IL_1771;
					}
					goto IL_1762;
				}
				goto IL_1762;
				IL_1771:
				num11++;
				continue;
				IL_1762:
				Main.item[num11].UpdateItem(num11);
				goto IL_1771;
			}
			if (Main.ignoreErrors)
			{
				try
				{
					Dust.UpdateDust();
					goto IL_17B7;
				}
				catch
				{
					for (int num12 = 0; num12 < 2000; num12++)
					{
						Main.dust[num12] = new Dust();
					}
					goto IL_17B7;
				}
			}
			Dust.UpdateDust();
			IL_17B7:
			if (Main.netMode != 2)
			{
				CombatText.UpdateCombatText();
				ItemText.UpdateItemText();
			}
			if (Main.ignoreErrors)
			{
				try
				{
					Main.UpdateTime();
					goto IL_17E5;
				}
				catch
				{
					Main.checkForSpawns = 0;
					goto IL_17E5;
				}
			}
			Main.UpdateTime();
			IL_17E5:
			if (Main.netMode != 1)
			{
				if (Main.ignoreErrors)
				{
					try
					{
						WorldGen.UpdateWorld();
						Main.UpdateInvasion();
						goto IL_180D;
					}
					catch
					{
						goto IL_180D;
					}
				}
				WorldGen.UpdateWorld();
				Main.UpdateInvasion();
			}
			IL_180D:
			if (Main.ignoreErrors)
			{
				try
				{
					if (Main.netMode == 2)
					{
						Main.UpdateServer();
					}
					if (Main.netMode == 1)
					{
						Main.UpdateClient();
					}
					goto IL_1855;
				}
				catch
				{
					int arg_1838_0 = Main.netMode;
					goto IL_1855;
				}
			}
			if (Main.netMode == 2)
			{
				Main.UpdateServer();
				goto IL_1848;
			}
			goto IL_1848;
			IL_1855:
			if (Main.ignoreErrors)
			{
				try
				{
					for (int num13 = 0; num13 < Main.numChatLines; num13++)
					{
						if (Main.chatLine[num13].showTime > 0)
						{
							Main.chatLine[num13].showTime--;
						}
					}
					goto IL_18F4;
				}
				catch
				{
					for (int num14 = 0; num14 < Main.numChatLines; num14++)
					{
						Main.chatLine[num14] = new ChatLine();
					}
					goto IL_18F4;
				}
				goto IL_18BB;
			}
			goto IL_18BB;
			IL_18F4:
			Main.upTimer = (float)stopwatch.ElapsedMilliseconds;
			if (Main.upTimerMaxDelay > 0f)
			{
				Main.upTimerMaxDelay -= 1f;
				goto IL_1928;
			}
			Main.upTimerMax = 0f;
			goto IL_1928;
			IL_18BB:
			for (int num15 = 0; num15 < Main.numChatLines; num15++)
			{
				if (Main.chatLine[num15].showTime > 0)
				{
					Main.chatLine[num15].showTime--;
				}
			}
			goto IL_18F4;
			IL_1848:
			if (Main.netMode == 1)
			{
				Main.UpdateClient();
				goto IL_1855;
			}
			goto IL_1855;
			IL_1928:
			if (Main.upTimer > Main.upTimerMax)
			{
				Main.upTimerMax = Main.upTimer;
				Main.upTimerMaxDelay = 400f;
			}
			base.Update(gameTime);
		}
		private static void UpdateMenu()
		{
			Main.playerInventory = false;
			Main.exitScale = 0.8f;
			if (Main.netMode == 0)
			{
				if (!Main.grabSky)
				{
					Main.time += 86.4;
					if (!Main.dayTime)
					{
						if (Main.time > 32400.0)
						{
							Main.bloodMoon = false;
							Main.time = 0.0;
							Main.dayTime = true;
							Main.moonPhase++;
							if (Main.moonPhase >= 8)
							{
								Main.moonPhase = 0;
								return;
							}
						}
					}
					else
					{
						if (Main.time > 54000.0)
						{
							Main.time = 0.0;
							Main.dayTime = false;
							return;
						}
					}
				}
			}
			else
			{
				if (Main.netMode == 1)
				{
					Main.UpdateTime();
				}
			}
		}
		public static string GetInputText(string oldString)
		{
			if (!Main.hasFocus)
			{
				return oldString;
			}
			Main.inputTextEnter = false;
			string text = oldString;
			if (text == null)
			{
				text = "";
			}
			Main.oldInputText = Main.inputText;
			Main.inputText = Keyboard.GetState();
			bool flag = ((ushort)Main.GetKeyState(20) & 65535) != 0;
			bool flag2 = false;
			if (Main.inputText.IsKeyDown(Keys.LeftShift) || Main.inputText.IsKeyDown(Keys.RightShift))
			{
				flag2 = true;
			}
			Keys[] pressedKeys = Main.inputText.GetPressedKeys();
			Keys[] pressedKeys2 = Main.oldInputText.GetPressedKeys();
			bool flag3 = false;
			if (Main.inputText.IsKeyDown(Keys.Back) && Main.oldInputText.IsKeyDown(Keys.Back))
			{
				if (Main.backSpaceCount == 0)
				{
					Main.backSpaceCount = 7;
					flag3 = true;
				}
				Main.backSpaceCount--;
			}
			else
			{
				Main.backSpaceCount = 15;
			}
			for (int i = 0; i < pressedKeys.Length; i++)
			{
				bool flag4 = true;
				for (int j = 0; j < pressedKeys2.Length; j++)
				{
					if (pressedKeys[i] == pressedKeys2[j])
					{
						flag4 = false;
					}
				}
				string text2 = string.Concat(pressedKeys[i]);
				if (text2 == "Back" && (flag4 || flag3))
				{
					if (text.Length > 0)
					{
						text = text.Substring(0, text.Length - 1);
					}
				}
				else
				{
					if (flag4)
					{
						if (text2 == "Space")
						{
							text2 = " ";
						}
						else
						{
							if (text2.Length == 1)
							{
								char c = Convert.ToChar(text2);
								int num = Convert.ToInt32(c);
								if (num >= 65 && num <= 90 && ((!flag2 && !flag) || (flag2 && flag)))
								{
									num += 32;
									c = Convert.ToChar(num);
									text2 = string.Concat(c);
								}
							}
							else
							{
								if (text2.Length == 2 && text2.Substring(0, 1) == "D")
								{
									text2 = text2.Substring(1, 1);
									if (flag2)
									{
										if (text2 == "1")
										{
											text2 = "!";
										}
										if (text2 == "2")
										{
											text2 = "@";
										}
										if (text2 == "3")
										{
											text2 = "#";
										}
										if (text2 == "4")
										{
											text2 = "$";
										}
										if (text2 == "5")
										{
											text2 = "%";
										}
										if (text2 == "6")
										{
											text2 = "^";
										}
										if (text2 == "7")
										{
											text2 = "&";
										}
										if (text2 == "8")
										{
											text2 = "*";
										}
										if (text2 == "9")
										{
											text2 = "(";
										}
										if (text2 == "0")
										{
											text2 = ")";
										}
									}
								}
								else
								{
									if (text2.Length == 7 && text2.Substring(0, 6) == "NumPad")
									{
										text2 = text2.Substring(6, 1);
									}
									else
									{
										if (text2 == "Divide")
										{
											text2 = "/";
										}
										else
										{
											if (text2 == "Multiply")
											{
												text2 = "*";
											}
											else
											{
												if (text2 == "Subtract")
												{
													text2 = "-";
												}
												else
												{
													if (text2 == "Add")
													{
														text2 = "+";
													}
													else
													{
														if (text2 == "Decimal")
														{
															text2 = ".";
														}
														else
														{
															if (text2 == "OemSemicolon")
															{
																text2 = ";";
															}
															else
															{
																if (text2 == "OemPlus")
																{
																	text2 = "=";
																}
																else
																{
																	if (text2 == "OemComma")
																	{
																		text2 = ",";
																	}
																	else
																	{
																		if (text2 == "OemMinus")
																		{
																			text2 = "-";
																		}
																		else
																		{
																			if (text2 == "OemPeriod")
																			{
																				text2 = ".";
																			}
																			else
																			{
																				if (text2 == "OemQuestion")
																				{
																					text2 = "/";
																				}
																				else
																				{
																					if (text2 == "OemTilde")
																					{
																						text2 = "`";
																					}
																					else
																					{
																						if (text2 == "OemOpenBrackets")
																						{
																							text2 = "[";
																						}
																						else
																						{
																							if (text2 == "OemPipe")
																							{
																								text2 = "\\";
																							}
																							else
																							{
																								if (text2 == "OemCloseBrackets")
																								{
																									text2 = "]";
																								}
																								else
																								{
																									if (text2 == "OemQuotes")
																									{
																										text2 = "'";
																									}
																									else
																									{
																										if (text2 == "OemBackslash")
																										{
																											text2 = "\\";
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
															if (flag2)
															{
																if (text2 == ";")
																{
																	text2 = ":";
																}
																else
																{
																	if (text2 == "=")
																	{
																		text2 = "+";
																	}
																	else
																	{
																		if (text2 == ",")
																		{
																			text2 = "<";
																		}
																		else
																		{
																			if (text2 == "-")
																			{
																				text2 = "_";
																			}
																			else
																			{
																				if (text2 == ".")
																				{
																					text2 = ">";
																				}
																				else
																				{
																					if (text2 == "/")
																					{
																						text2 = "?";
																					}
																					else
																					{
																						if (text2 == "`")
																						{
																							text2 = "~";
																						}
																						else
																						{
																							if (text2 == "[")
																							{
																								text2 = "{";
																							}
																							else
																							{
																								if (text2 == "\\")
																								{
																									text2 = "|";
																								}
																								else
																								{
																									if (text2 == "]")
																									{
																										text2 = "}";
																									}
																									else
																									{
																										if (text2 == "'")
																										{
																											text2 = "\"";
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
						if (text2 == "Enter")
						{
							Main.inputTextEnter = true;
						}
						if (text2.Length == 1)
						{
							text += text2;
						}
					}
				}
			}
			return text;
		}
		protected void MouseText(string cursorText, int rare = 0, byte diff = 0)
		{
			if (this.mouseNPC > -1)
			{
				return;
			}
			if (cursorText == null)
			{
				return;
			}
			int num = Main.mouseX + 10;
			int num2 = Main.mouseY + 10;
			Color color = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
			float num20;
			Vector2 origin;
			if (Main.toolTip.type > 0)
			{
				if (Main.player[Main.myPlayer].kbGlove)
				{
					Main.toolTip.knockBack *= 1.7f;
				}
				rare = Main.toolTip.rare;
				int num3 = 20;
				int num4 = 1;
				string[] array = new string[num3];
				bool[] array2 = new bool[num3];
				bool[] array3 = new bool[num3];
				for (int i = 0; i < num3; i++)
				{
					array2[i] = false;
					array3[i] = false;
				}
				array[0] = Main.toolTip.AffixName();
				if (Main.toolTip.stack > 1)
				{
					string[] array4;
					string[] expr_DB = array4 = array;
					int arg_11F_1 = 0;
					object obj = array4[0];
					expr_DB[arg_11F_1] = string.Concat(new object[]
					{
						obj, 
						" (", 
						Main.toolTip.stack, 
						")"
					});
				}
				if (Main.toolTip.social)
				{
					array[num4] = "Equipped in social slot";
					num4++;
					array[num4] = "No stats will be gained";
					num4++;
				}
				else
				{
					if (Main.toolTip.damage > 0)
					{
						int damage = Main.toolTip.damage;
						if (Main.toolTip.melee)
						{
							array[num4] = string.Concat((int)(Main.player[Main.myPlayer].meleeDamage * (float)damage));
							string[] array5;
							IntPtr intPtr;
							(array5 = array)[(int)(intPtr = (IntPtr)num4)] = array5[(int)intPtr] + " melee";
						}
						else
						{
							if (Main.toolTip.ranged)
							{
								array[num4] = string.Concat((int)(Main.player[Main.myPlayer].rangedDamage * (float)damage));
								string[] array6;
								IntPtr intPtr2;
								(array6 = array)[(int)(intPtr2 = (IntPtr)num4)] = array6[(int)intPtr2] + " ranged";
							}
							else
							{
								if (Main.toolTip.magic)
								{
									array[num4] = string.Concat((int)(Main.player[Main.myPlayer].magicDamage * (float)damage));
									string[] array7;
									IntPtr intPtr3;
									(array7 = array)[(int)(intPtr3 = (IntPtr)num4)] = array7[(int)intPtr3] + " magic";
								}
								else
								{
									array[num4] = string.Concat(damage);
								}
							}
						}
						string[] array8;
						IntPtr intPtr4;
						(array8 = array)[(int)(intPtr4 = (IntPtr)num4)] = array8[(int)intPtr4] + " damage";
						num4++;
						if (Main.toolTip.melee)
						{
							int num5 = Main.player[Main.myPlayer].meleeCrit - Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].crit + Main.toolTip.crit;
							array[num4] = num5 + "% critical strike chance";
							num4++;
						}
						else
						{
							if (Main.toolTip.ranged)
							{
								int num6 = Main.player[Main.myPlayer].rangedCrit - Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].crit + Main.toolTip.crit;
								array[num4] = num6 + "% critical strike chance";
								num4++;
							}
							else
							{
								if (Main.toolTip.magic)
								{
									int num7 = Main.player[Main.myPlayer].magicCrit - Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].crit + Main.toolTip.crit;
									array[num4] = num7 + "% critical strike chance";
									num4++;
								}
							}
						}
						if (Main.toolTip.useStyle > 0)
						{
							if (Main.toolTip.useAnimation <= 8)
							{
								array[num4] = "Insanely fast";
							}
							else
							{
								if (Main.toolTip.useAnimation <= 20)
								{
									array[num4] = "Very fast";
								}
								else
								{
									if (Main.toolTip.useAnimation <= 25)
									{
										array[num4] = "Fast";
									}
									else
									{
										if (Main.toolTip.useAnimation <= 30)
										{
											array[num4] = "Average";
										}
										else
										{
											if (Main.toolTip.useAnimation <= 35)
											{
												array[num4] = "Slow";
											}
											else
											{
												if (Main.toolTip.useAnimation <= 45)
												{
													array[num4] = "Very slow";
												}
												else
												{
													if (Main.toolTip.useAnimation <= 55)
													{
														array[num4] = "Extremely slow";
													}
													else
													{
														array[num4] = "Snail";
													}
												}
											}
										}
									}
								}
							}
							string[] array9;
							IntPtr intPtr5;
							(array9 = array)[(int)(intPtr5 = (IntPtr)num4)] = array9[(int)intPtr5] + " speed";
							num4++;
						}
						if (Main.toolTip.knockBack == 0f)
						{
							array[num4] = "No";
						}
						else
						{
							if ((double)Main.toolTip.knockBack <= 1.5)
							{
								array[num4] = "Extremely weak";
							}
							else
							{
								if (Main.toolTip.knockBack <= 3f)
								{
									array[num4] = "Very weak";
								}
								else
								{
									if (Main.toolTip.knockBack <= 4f)
									{
										array[num4] = "Weak";
									}
									else
									{
										if (Main.toolTip.knockBack <= 6f)
										{
											array[num4] = "Average";
										}
										else
										{
											if (Main.toolTip.knockBack <= 7f)
											{
												array[num4] = "Strong";
											}
											else
											{
												if (Main.toolTip.knockBack <= 9f)
												{
													array[num4] = "Very strong";
												}
												else
												{
													if (Main.toolTip.knockBack <= 11f)
													{
														array[num4] = "Extremely strong";
													}
													else
													{
														array[num4] = "Insane";
													}
												}
											}
										}
									}
								}
							}
						}
						string[] array10;
						IntPtr intPtr6;
						(array10 = array)[(int)(intPtr6 = (IntPtr)num4)] = array10[(int)intPtr6] + " knockback";
						num4++;
					}
					if (Main.toolTip.headSlot > 0 || Main.toolTip.bodySlot > 0 || Main.toolTip.legSlot > 0 || Main.toolTip.accessory)
					{
						array[num4] = "Equipable";
						num4++;
					}
					if (Main.toolTip.vanity)
					{
						array[num4] = "Vanity Item";
						num4++;
					}
					if (Main.toolTip.defense > 0)
					{
						array[num4] = Main.toolTip.defense + " defense";
						num4++;
					}
					if (Main.toolTip.pick > 0)
					{
						array[num4] = Main.toolTip.pick + "% pickaxe power";
						num4++;
					}
					if (Main.toolTip.axe > 0)
					{
						array[num4] = Main.toolTip.axe * 5 + "% axe power";
						num4++;
					}
					if (Main.toolTip.hammer > 0)
					{
						array[num4] = Main.toolTip.hammer + "% hammer power";
						num4++;
					}
					if (Main.toolTip.healLife > 0)
					{
						array[num4] = "Restores " + Main.toolTip.healLife + " life";
						num4++;
					}
					if (Main.toolTip.healMana > 0)
					{
						array[num4] = "Restores " + Main.toolTip.healMana + " mana";
						num4++;
					}
					if (Main.toolTip.mana > 0 && (Main.toolTip.type != 127 || !Main.player[Main.myPlayer].spaceGun))
					{
						array[num4] = "Uses " + (int)((float)Main.toolTip.mana * Main.player[Main.myPlayer].manaCost) + " mana";
						num4++;
					}
					if (Main.toolTip.createWall > 0 || Main.toolTip.createTile > -1)
					{
						if (Main.toolTip.type != 213)
						{
							array[num4] = "Can be placed";
							num4++;
						}
					}
					else
					{
						if (Main.toolTip.ammo > 0)
						{
							array[num4] = "Ammo";
							num4++;
						}
						else
						{
							if (Main.toolTip.consumable)
							{
								array[num4] = "Consumable";
								num4++;
							}
						}
					}
					if (Main.toolTip.material)
					{
						array[num4] = "Material";
						num4++;
					}
					if (Main.toolTip.toolTip != null)
					{
						array[num4] = Main.toolTip.toolTip;
						num4++;
					}
					if (Main.toolTip.toolTip2 != null)
					{
						array[num4] = Main.toolTip.toolTip2;
						num4++;
					}
					if (Main.toolTip.buffTime > 0)
					{
						string text = "0 s";
						if (Main.toolTip.buffTime / 60 >= 60)
						{
							text = Math.Round((double)(Main.toolTip.buffTime / 60) / 60.0) + " minute duration";
						}
						else
						{
							text = Math.Round((double)Main.toolTip.buffTime / 60.0) + " second duration";
						}
						array[num4] = text;
						num4++;
					}
					if (Main.toolTip.prefix > 0)
					{
						if (Main.cpItem == null || Main.cpItem.name != Main.toolTip.name)
						{
							Main.cpItem = new Item();
							Main.cpItem.SetDefaults(Main.toolTip.name);
						}
						if (Main.cpItem.damage != Main.toolTip.damage)
						{
							double num8 = (double)((float)Main.toolTip.damage - (float)Main.cpItem.damage);
							num8 = num8 / (double)((float)Main.cpItem.damage) * 100.0;
							num8 = Math.Round(num8);
							if (num8 > 0.0)
							{
								array[num4] = "+" + num8 + "% damage";
							}
							else
							{
								array[num4] = num8 + "% damage";
							}
							if (num8 < 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.cpItem.useAnimation != Main.toolTip.useAnimation)
						{
							double num9 = (double)((float)Main.toolTip.useAnimation - (float)Main.cpItem.useAnimation);
							num9 = num9 / (double)((float)Main.cpItem.useAnimation) * 100.0;
							num9 = Math.Round(num9);
							num9 *= -1.0;
							if (num9 > 0.0)
							{
								array[num4] = "+" + num9 + "% speed";
							}
							else
							{
								array[num4] = num9 + "% speed";
							}
							if (num9 < 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.cpItem.crit != Main.toolTip.crit)
						{
							double num10 = (double)((float)Main.toolTip.crit - (float)Main.cpItem.crit);
							if (num10 > 0.0)
							{
								array[num4] = "+" + num10 + "% critical strike chance";
							}
							else
							{
								array[num4] = num10 + "% critical strike chance";
							}
							if (num10 < 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.cpItem.mana != Main.toolTip.mana)
						{
							double num11 = (double)((float)Main.toolTip.mana - (float)Main.cpItem.mana);
							num11 = num11 / (double)((float)Main.cpItem.mana) * 100.0;
							num11 = Math.Round(num11);
							if (num11 > 0.0)
							{
								array[num4] = "+" + num11 + "% mana cost";
							}
							else
							{
								array[num4] = num11 + "% mana cost";
							}
							if (num11 > 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.cpItem.scale != Main.toolTip.scale)
						{
							double num12 = (double)(Main.toolTip.scale - Main.cpItem.scale);
							num12 = num12 / (double)Main.cpItem.scale * 100.0;
							num12 = Math.Round(num12);
							if (num12 > 0.0)
							{
								array[num4] = "+" + num12 + "% size";
							}
							else
							{
								array[num4] = num12 + "% size";
							}
							if (num12 < 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.cpItem.shootSpeed != Main.toolTip.shootSpeed)
						{
							double num13 = (double)(Main.toolTip.shootSpeed - Main.cpItem.shootSpeed);
							num13 = num13 / (double)Main.cpItem.shootSpeed * 100.0;
							num13 = Math.Round(num13);
							if (num13 > 0.0)
							{
								array[num4] = "+" + num13 + "% velocity";
							}
							else
							{
								array[num4] = num13 + "% velocity";
							}
							if (num13 < 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.cpItem.knockBack != Main.toolTip.knockBack)
						{
							double num14 = (double)(Main.toolTip.knockBack - Main.cpItem.knockBack);
							num14 = num14 / (double)Main.cpItem.knockBack * 100.0;
							num14 = Math.Round(num14);
							if (num14 > 0.0)
							{
								array[num4] = "+" + num14 + "% knockback";
							}
							else
							{
								array[num4] = num14 + "% knockback";
							}
							if (num14 < 0.0)
							{
								array3[num4] = true;
							}
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 62)
						{
							array[num4] = "+1 defense";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 63)
						{
							array[num4] = "+2 defense";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 64)
						{
							array[num4] = "+3 defense";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 65)
						{
							array[num4] = "+4 defense";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 66)
						{
							array[num4] = "+20 mana";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 67)
						{
							array[num4] = "+1% critical strike chance";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 68)
						{
							array[num4] = "+2% critical strike chance";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 69)
						{
							array[num4] = "+1% damage";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 70)
						{
							array[num4] = "+2% damage";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 71)
						{
							array[num4] = "+3% damage";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 72)
						{
							array[num4] = "+4% damage";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 73)
						{
							array[num4] = "+1% movement speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 74)
						{
							array[num4] = "+2% movement speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 75)
						{
							array[num4] = "+3% movement speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 76)
						{
							array[num4] = "+4% movement speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 77)
						{
							array[num4] = "+1% melee speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 78)
						{
							array[num4] = "+2% melee speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 79)
						{
							array[num4] = "+3% melee speed";
							array2[num4] = true;
							num4++;
						}
						if (Main.toolTip.prefix == 80)
						{
							array[num4] = "+4% melee speed";
							array2[num4] = true;
							num4++;
						}
					}
					if (Main.toolTip.wornArmor && Main.player[Main.myPlayer].setBonus != "")
					{
						array[num4] = "Set bonus: " + Main.player[Main.myPlayer].setBonus;
						num4++;
					}
				}
				if (Main.npcShop > 0)
				{
					if (Main.toolTip.value > 0)
					{
						string text2 = "";
						int num15 = 0;
						int num16 = 0;
						int num17 = 0;
						int num18 = 0;
						int num19 = Main.toolTip.value * Main.toolTip.stack;
						if (!Main.toolTip.buy)
						{
							num19 = Main.toolTip.value / 5 * Main.toolTip.stack;
						}
						if (num19 < 1)
						{
							num19 = 1;
						}
						if (num19 >= 1000000)
						{
							num15 = num19 / 1000000;
							num19 -= num15 * 1000000;
						}
						if (num19 >= 10000)
						{
							num16 = num19 / 10000;
							num19 -= num16 * 10000;
						}
						if (num19 >= 100)
						{
							num17 = num19 / 100;
							num19 -= num17 * 100;
						}
						if (num19 >= 1)
						{
							num18 = num19;
						}
						if (num15 > 0)
						{
							text2 = text2 + num15 + " platinum ";
						}
						if (num16 > 0)
						{
							text2 = text2 + num16 + " gold ";
						}
						if (num17 > 0)
						{
							text2 = text2 + num17 + " silver ";
						}
						if (num18 > 0)
						{
							text2 = text2 + num18 + " copper ";
						}
						if (!Main.toolTip.buy)
						{
							array[num4] = "Sell price: " + text2;
						}
						else
						{
							array[num4] = "Buy price: " + text2;
						}
						num4++;
						num20 = (float)Main.mouseTextColor / 255f;
						if (num15 > 0)
						{
							color = new Color((int)((byte)(220f * num20)), (int)((byte)(220f * num20)), (int)((byte)(198f * num20)), (int)Main.mouseTextColor);
						}
						else
						{
							if (num16 > 0)
							{
								color = new Color((int)((byte)(224f * num20)), (int)((byte)(201f * num20)), (int)((byte)(92f * num20)), (int)Main.mouseTextColor);
							}
							else
							{
								if (num17 > 0)
								{
									color = new Color((int)((byte)(181f * num20)), (int)((byte)(192f * num20)), (int)((byte)(193f * num20)), (int)Main.mouseTextColor);
								}
								else
								{
									if (num18 > 0)
									{
										color = new Color((int)((byte)(246f * num20)), (int)((byte)(138f * num20)), (int)((byte)(96f * num20)), (int)Main.mouseTextColor);
									}
								}
							}
						}
					}
					else
					{
						num20 = (float)Main.mouseTextColor / 255f;
						array[num4] = "No value";
						num4++;
						color = new Color((int)((byte)(120f * num20)), (int)((byte)(120f * num20)), (int)((byte)(120f * num20)), (int)Main.mouseTextColor);
					}
				}
				Vector2 vector = default(Vector2);
				int num21 = 0;
				for (int j = 0; j < num4; j++)
				{
					Vector2 vector2 = Main.fontMouseText.MeasureString(array[j]);
					if (vector2.X > vector.X)
					{
						vector.X = vector2.X;
					}
					vector.Y += vector2.Y + (float)num21;
				}
				if ((float)num + vector.X + 4f > (float)Main.screenWidth)
				{
					num = (int)((float)Main.screenWidth - vector.X - 4f);
				}
				if ((float)num2 + vector.Y + 4f > (float)Main.screenHeight)
				{
					num2 = (int)((float)Main.screenHeight - vector.Y - 4f);
				}
				int num22 = 0;
				num20 = (float)Main.mouseTextColor / 255f;
				for (int k = 0; k < num4; k++)
				{
					for (int l = 0; l < 5; l++)
					{
						int num23 = num;
						int num24 = num2 + num22;
						Color color2 = Color.Black;
						if (l == 0)
						{
							num23 -= 2;
						}
						else
						{
							if (l == 1)
							{
								num23 += 2;
							}
							else
							{
								if (l == 2)
								{
									num24 -= 2;
								}
								else
								{
									if (l == 3)
									{
										num24 += 2;
									}
									else
									{
										color2 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
										if (k == 0)
										{
											if (rare == -1)
											{
												color2 = new Color((int)((byte)(130f * num20)), (int)((byte)(130f * num20)), (int)((byte)(130f * num20)), (int)Main.mouseTextColor);
											}
											if (rare == 1)
											{
												color2 = new Color((int)((byte)(150f * num20)), (int)((byte)(150f * num20)), (int)((byte)(255f * num20)), (int)Main.mouseTextColor);
											}
											if (rare == 2)
											{
												color2 = new Color((int)((byte)(150f * num20)), (int)((byte)(255f * num20)), (int)((byte)(150f * num20)), (int)Main.mouseTextColor);
											}
											if (rare == 3)
											{
												color2 = new Color((int)((byte)(255f * num20)), (int)((byte)(200f * num20)), (int)((byte)(150f * num20)), (int)Main.mouseTextColor);
											}
											if (rare == 4)
											{
												color2 = new Color((int)((byte)(255f * num20)), (int)((byte)(150f * num20)), (int)((byte)(150f * num20)), (int)Main.mouseTextColor);
											}
											if (rare == 5)
											{
												color2 = new Color((int)((byte)(255f * num20)), (int)((byte)(150f * num20)), (int)((byte)(255f * num20)), (int)Main.mouseTextColor);
											}
											if (rare == 6)
											{
												color2 = new Color((int)((byte)(210f * num20)), (int)((byte)(160f * num20)), (int)((byte)(255f * num20)), (int)Main.mouseTextColor);
											}
											if (diff == 1)
											{
												color2 = new Color((int)((byte)((float)Main.mcColor.R * num20)), (int)((byte)((float)Main.mcColor.G * num20)), (int)((byte)((float)Main.mcColor.B * num20)), (int)Main.mouseTextColor);
											}
											if (diff == 2)
											{
												color2 = new Color((int)((byte)((float)Main.hcColor.R * num20)), (int)((byte)((float)Main.hcColor.G * num20)), (int)((byte)((float)Main.hcColor.B * num20)), (int)Main.mouseTextColor);
											}
										}
										else
										{
											if (array2[k])
											{
												if (array3[k])
												{
													color2 = new Color((int)((byte)(190f * num20)), (int)((byte)(120f * num20)), (int)((byte)(120f * num20)), (int)Main.mouseTextColor);
												}
												else
												{
													color2 = new Color((int)((byte)(120f * num20)), (int)((byte)(190f * num20)), (int)((byte)(120f * num20)), (int)Main.mouseTextColor);
												}
											}
											else
											{
												if (k == num4 - 1)
												{
													color2 = color;
												}
											}
										}
									}
								}
							}
						}
						SpriteBatch arg_175D_0 = this.spriteBatch;
						SpriteFont arg_175D_1 = Main.fontMouseText;
						string arg_175D_2 = array[k];
						Vector2 arg_175D_3 = new Vector2((float)num23, (float)num24);
						Color arg_175D_4 = color2;
						float arg_175D_5 = 0f;
						origin = default(Vector2);
						arg_175D_0.DrawString(arg_175D_1, arg_175D_2, arg_175D_3, arg_175D_4, arg_175D_5, origin, 1f, SpriteEffects.None, 0f);
					}
					num22 += (int)(Main.fontMouseText.MeasureString(array[k]).Y + (float)num21);
				}
				return;
			}
			if (Main.buffString != "" && Main.buffString != null)
			{
				for (int m = 0; m < 5; m++)
				{
					int num25 = num;
					int num26 = num2 + (int)Main.fontMouseText.MeasureString(Main.buffString).Y;
					Color black = Color.Black;
					if (m == 0)
					{
						num25 -= 2;
					}
					else
					{
						if (m == 1)
						{
							num25 += 2;
						}
						else
						{
							if (m == 2)
							{
								num26 -= 2;
							}
							else
							{
								if (m == 3)
								{
									num26 += 2;
								}
								else
								{
									black = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
								}
							}
						}
					}
					this.spriteBatch.DrawString(Main.fontMouseText, Main.buffString, new Vector2((float)num25, (float)num26), black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
				}
			}
			Vector2 vector3 = Main.fontMouseText.MeasureString(cursorText);
			if ((float)num + vector3.X + 4f > (float)Main.screenWidth)
			{
				num = (int)((float)Main.screenWidth - vector3.X - 4f);
			}
			if ((float)num2 + vector3.Y + 4f > (float)Main.screenHeight)
			{
				num2 = (int)((float)Main.screenHeight - vector3.Y - 4f);
			}
			SpriteBatch arg_191E_0 = this.spriteBatch;
			SpriteFont arg_191E_1 = Main.fontMouseText;
			Vector2 arg_191E_3 = new Vector2((float)num, (float)(num2 - 2));
			Color arg_191E_4 = Color.Black;
			float arg_191E_5 = 0f;
			origin = default(Vector2);
			arg_191E_0.DrawString(arg_191E_1, cursorText, arg_191E_3, arg_191E_4, arg_191E_5, origin, 1f, SpriteEffects.None, 0f);
			SpriteBatch arg_1959_0 = this.spriteBatch;
			SpriteFont arg_1959_1 = Main.fontMouseText;
			Vector2 arg_1959_3 = new Vector2((float)num, (float)(num2 + 2));
			Color arg_1959_4 = Color.Black;
			float arg_1959_5 = 0f;
			origin = default(Vector2);
			arg_1959_0.DrawString(arg_1959_1, cursorText, arg_1959_3, arg_1959_4, arg_1959_5, origin, 1f, SpriteEffects.None, 0f);
			SpriteBatch arg_1994_0 = this.spriteBatch;
			SpriteFont arg_1994_1 = Main.fontMouseText;
			Vector2 arg_1994_3 = new Vector2((float)(num - 2), (float)num2);
			Color arg_1994_4 = Color.Black;
			float arg_1994_5 = 0f;
			origin = default(Vector2);
			arg_1994_0.DrawString(arg_1994_1, cursorText, arg_1994_3, arg_1994_4, arg_1994_5, origin, 1f, SpriteEffects.None, 0f);
			SpriteBatch arg_19CF_0 = this.spriteBatch;
			SpriteFont arg_19CF_1 = Main.fontMouseText;
			Vector2 arg_19CF_3 = new Vector2((float)(num + 2), (float)num2);
			Color arg_19CF_4 = Color.Black;
			float arg_19CF_5 = 0f;
			origin = default(Vector2);
			arg_19CF_0.DrawString(arg_19CF_1, cursorText, arg_19CF_3, arg_19CF_4, arg_19CF_5, origin, 1f, SpriteEffects.None, 0f);
			num20 = (float)Main.mouseTextColor / 255f;
			Color color3 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
			if (rare == -1)
			{
				color3 = new Color((int)((byte)(130f * num20)), (int)((byte)(130f * num20)), (int)((byte)(130f * num20)), (int)Main.mouseTextColor);
			}
			if (rare == 6)
			{
				color3 = new Color((int)((byte)(210f * num20)), (int)((byte)(160f * num20)), (int)((byte)(255f * num20)), (int)Main.mouseTextColor);
			}
			if (rare == 1)
			{
				color3 = new Color((int)((byte)(150f * num20)), (int)((byte)(150f * num20)), (int)((byte)(255f * num20)), (int)Main.mouseTextColor);
			}
			if (rare == 2)
			{
				color3 = new Color((int)((byte)(150f * num20)), (int)((byte)(255f * num20)), (int)((byte)(150f * num20)), (int)Main.mouseTextColor);
			}
			if (rare == 3)
			{
				color3 = new Color((int)((byte)(255f * num20)), (int)((byte)(200f * num20)), (int)((byte)(150f * num20)), (int)Main.mouseTextColor);
			}
			if (rare == 4)
			{
				color3 = new Color((int)((byte)(255f * num20)), (int)((byte)(150f * num20)), (int)((byte)(150f * num20)), (int)Main.mouseTextColor);
			}
			if (rare == 5)
			{
				color3 = new Color((int)((byte)(255f * num20)), (int)((byte)(150f * num20)), (int)((byte)(255f * num20)), (int)Main.mouseTextColor);
			}
			if (diff == 1)
			{
				color3 = new Color((int)((byte)((float)Main.mcColor.R * num20)), (int)((byte)((float)Main.mcColor.G * num20)), (int)((byte)((float)Main.mcColor.B * num20)), (int)Main.mouseTextColor);
			}
			if (diff == 2)
			{
				color3 = new Color((int)((byte)((float)Main.hcColor.R * num20)), (int)((byte)((float)Main.hcColor.G * num20)), (int)((byte)((float)Main.hcColor.B * num20)), (int)Main.mouseTextColor);
			}
			SpriteBatch arg_1BB9_0 = this.spriteBatch;
			SpriteFont arg_1BB9_1 = Main.fontMouseText;
			Vector2 arg_1BB9_3 = new Vector2((float)num, (float)num2);
			Color arg_1BB9_4 = color3;
			float arg_1BB9_5 = 0f;
			origin = default(Vector2);
			arg_1BB9_0.DrawString(arg_1BB9_1, cursorText, arg_1BB9_3, arg_1BB9_4, arg_1BB9_5, origin, 1f, SpriteEffects.None, 0f);
		}
		protected void DrawFPS()
		{
			if (Main.showFrameRate)
			{
				string text = string.Concat(Main.frameRate);
				object obj = text;
				text = string.Concat(new object[]
				{
					obj, 
					" (", 
					(int)(Main.gfxQuality * 100f), 
					"%)"
				});
				int num = 4;
				if (!Main.gameMenu)
				{
					num = Main.screenHeight - 24;
				}
				this.spriteBatch.DrawString(Main.fontMouseText, text + " " + Main.debugWords, new Vector2(4f, (float)num), new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			}
		}
		public static Color shine(Color newColor, int type)
		{
			int num = (int)newColor.R;
			int num2 = (int)newColor.R;
			int num3 = (int)newColor.R;
			float num4 = 0.6f;
			if (type == 25)
			{
				num = (int)((float)newColor.R * 0.95f);
				num2 = (int)((float)newColor.G * 0.85f);
				num3 = (int)((double)((float)newColor.B) * 1.1);
			}
			else
			{
				if (type == 117)
				{
					num = (int)((float)newColor.R * 1.1f);
					num2 = (int)((float)newColor.G * 1f);
					num3 = (int)((double)((float)newColor.B) * 1.2);
				}
				else
				{
					num = (int)((float)newColor.R * (1f + num4));
					num2 = (int)((float)newColor.G * (1f + num4));
					num3 = (int)((float)newColor.B * (1f + num4));
				}
			}
			if (num > 255)
			{
				num = 255;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			newColor.R = (byte)num;
			newColor.G = (byte)num2;
			newColor.B = (byte)num3;
			return new Color((int)((byte)num), (int)((byte)num2), (int)((byte)num3), (int)newColor.A);
		}
		protected void DrawTiles(bool solidOnly = true)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num = (int)(255f * (1f - Main.gfxQuality) + 30f * Main.gfxQuality);
			int num2 = (int)(50f * (1f - Main.gfxQuality) + 2f * Main.gfxQuality);
			Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				value = default(Vector2);
			}
			int num3 = 0;
			int[] array = new int[1000];
			int[] array2 = new int[1000];
			int num4 = (int)((Main.screenPosition.X - value.X) / 16f - 1f);
			int num5 = (int)((Main.screenPosition.X + (float)Main.screenWidth + value.X) / 16f) + 2;
			int num6 = (int)((Main.screenPosition.Y - value.Y) / 16f - 1f);
			int num7 = (int)((Main.screenPosition.Y + (float)Main.screenHeight + value.Y) / 16f) + 5;
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num5 > Main.maxTilesX)
			{
				num5 = Main.maxTilesX;
			}
			if (num6 < 0)
			{
				num6 = 0;
			}
			if (num7 > Main.maxTilesY)
			{
				num7 = Main.maxTilesY;
			}
			int height = 16;
			int num8 = 16;
			for (int i = num6; i < num7 + 4; i++)
			{
				for (int j = num4 - 2; j < num5 + 2; j++)
				{
					if (Main.tile[j, i] == null)
					{

					}
					bool flag = Main.tileSolid[(int)Main.tile[j, i].type];
					if (Main.tile[j, i].type == 11)
					{
						flag = true;
					}
					if (Main.tile[j, i].active && flag == solidOnly)
					{
						Color color = Lighting.GetColor(j, i);
						int num9 = 0;
						if (Main.tile[j, i].type == 78 || Main.tile[j, i].type == 85)
						{
							num9 = 2;
						}
						if (Main.tile[j, i].type == 33 || Main.tile[j, i].type == 49)
						{
							num9 = -4;
						}
						if (Main.tile[j, i].type == 3 || Main.tile[j, i].type == 4 || Main.tile[j, i].type == 5 || Main.tile[j, i].type == 24 || Main.tile[j, i].type == 33 || Main.tile[j, i].type == 49 || Main.tile[j, i].type == 61 || Main.tile[j, i].type == 71 || Main.tile[j, i].type == 110)
						{
							height = 20;
						}
						else
						{
							if (Main.tile[j, i].type == 15 || Main.tile[j, i].type == 14 || Main.tile[j, i].type == 16 || Main.tile[j, i].type == 17 || Main.tile[j, i].type == 18 || Main.tile[j, i].type == 20 || Main.tile[j, i].type == 21 || Main.tile[j, i].type == 26 || Main.tile[j, i].type == 27 || Main.tile[j, i].type == 32 || Main.tile[j, i].type == 69 || Main.tile[j, i].type == 72 || Main.tile[j, i].type == 77 || Main.tile[j, i].type == 80)
							{
								height = 18;
							}
							else
							{
								if (Main.tile[j, i].type == 137)
								{
									height = 18;
								}
								else
								{
									if (Main.tile[j, i].type == 135)
									{
										num9 = 2;
										height = 18;
									}
									else
									{
										if (Main.tile[j, i].type == 132)
										{
											num9 = 2;
											height = 18;
										}
										else
										{
											height = 16;
										}
									}
								}
							}
						}
						if (Main.tile[j, i].type == 4 || Main.tile[j, i].type == 5)
						{
							num8 = 20;
						}
						else
						{
							num8 = 16;
						}
						if (Main.tile[j, i].type == 73 || Main.tile[j, i].type == 74 || Main.tile[j, i].type == 113)
						{
							num9 -= 12;
							height = 32;
						}
						if (Main.tile[j, i].type == 81)
						{
							num9 -= 8;
							height = 26;
							num8 = 24;
						}
						if (Main.tile[j, i].type == 105)
						{
							num9 = 2;
						}
						if (Main.tile[j, i].type == 124)
						{
							height = 18;
						}
						if (Main.tile[j, i].type == 137)
						{
							height = 18;
						}
						if (Main.tile[j, i].type == 138)
						{
							height = 18;
						}
						if (Main.tile[j, i].type == 139 || Main.tile[j, i].type == 142 || Main.tile[j, i].type == 143)
						{
							num9 = 2;
						}
						if (Main.player[Main.myPlayer].findTreasure && (Main.tile[j, i].type == 6 || Main.tile[j, i].type == 7 || Main.tile[j, i].type == 8 || Main.tile[j, i].type == 9 || Main.tile[j, i].type == 12 || Main.tile[j, i].type == 21 || Main.tile[j, i].type == 22 || Main.tile[j, i].type == 28 || Main.tile[j, i].type == 107 || Main.tile[j, i].type == 108 || Main.tile[j, i].type == 111 || (Main.tile[j, i].type >= 63 && Main.tile[j, i].type <= 68) || Main.tileAlch[(int)Main.tile[j, i].type]))
						{
							if (color.R < Main.mouseTextColor / 2)
							{
								color.R = (byte)(Main.mouseTextColor / 2);
							}
							if (color.G < 70)
							{
								color.G = 70;
							}
							if (color.B < 210)
							{
								color.B = 210;
							}
							color.A = Main.mouseTextColor;
							if (!Main.gamePaused && base.IsActive && Main.rand.Next(150) == 0)
							{
								Vector2 arg_87F_0 = new Vector2((float)(j * 16), (float)(i * 16));
								int arg_87F_1 = 16;
								int arg_87F_2 = 16;
								int arg_87F_3 = 15;
								float arg_87F_4 = 0f;
								float arg_87F_5 = 0f;
								int arg_87F_6 = 150;
								Color newColor = default(Color);
								int num10 = Dust.NewDust(arg_87F_0, arg_87F_1, arg_87F_2, arg_87F_3, arg_87F_4, arg_87F_5, arg_87F_6, newColor, 0.8f);
								Dust expr_88E = Main.dust[num10];
								expr_88E.velocity *= 0.1f;
								Main.dust[num10].noLight = true;
							}
						}
						if (!Main.gamePaused && base.IsActive)
						{
							if (Main.tile[j, i].type == 4 && Main.rand.Next(40) == 0 && Main.tile[j, i].frameX < 66)
							{
								int num11 = (int)(Main.tile[j, i].frameY / 22);
								if (num11 == 0)
								{
									num11 = 6;
								}
								else
								{
									if (num11 == 8)
									{
										num11 = 75;
									}
									else
									{
										num11 = 58 + num11;
									}
								}
								if (Main.tile[j, i].frameX == 22)
								{
									Vector2 arg_986_0 = new Vector2((float)(j * 16 + 6), (float)(i * 16));
									int arg_986_1 = 4;
									int arg_986_2 = 4;
									int arg_986_3 = num11;
									float arg_986_4 = 0f;
									float arg_986_5 = 0f;
									int arg_986_6 = 100;
									Color newColor = default(Color);
									Dust.NewDust(arg_986_0, arg_986_1, arg_986_2, arg_986_3, arg_986_4, arg_986_5, arg_986_6, newColor, 1f);
								}
								if (Main.tile[j, i].frameX == 44)
								{
									Vector2 arg_9D5_0 = new Vector2((float)(j * 16 + 2), (float)(i * 16));
									int arg_9D5_1 = 4;
									int arg_9D5_2 = 4;
									int arg_9D5_3 = num11;
									float arg_9D5_4 = 0f;
									float arg_9D5_5 = 0f;
									int arg_9D5_6 = 100;
									Color newColor = default(Color);
									Dust.NewDust(arg_9D5_0, arg_9D5_1, arg_9D5_2, arg_9D5_3, arg_9D5_4, arg_9D5_5, arg_9D5_6, newColor, 1f);
								}
								else
								{
									Vector2 arg_A0F_0 = new Vector2((float)(j * 16 + 4), (float)(i * 16));
									int arg_A0F_1 = 4;
									int arg_A0F_2 = 4;
									int arg_A0F_3 = num11;
									float arg_A0F_4 = 0f;
									float arg_A0F_5 = 0f;
									int arg_A0F_6 = 100;
									Color newColor = default(Color);
									Dust.NewDust(arg_A0F_0, arg_A0F_1, arg_A0F_2, arg_A0F_3, arg_A0F_4, arg_A0F_5, arg_A0F_6, newColor, 1f);
								}
							}
							if (Main.tile[j, i].type == 33 && Main.rand.Next(40) == 0 && Main.tile[j, i].frameX == 0)
							{
								Vector2 arg_A82_0 = new Vector2((float)(j * 16 + 4), (float)(i * 16 - 4));
								int arg_A82_1 = 4;
								int arg_A82_2 = 4;
								int arg_A82_3 = 6;
								float arg_A82_4 = 0f;
								float arg_A82_5 = 0f;
								int arg_A82_6 = 100;
								Color newColor = default(Color);
								Dust.NewDust(arg_A82_0, arg_A82_1, arg_A82_2, arg_A82_3, arg_A82_4, arg_A82_5, arg_A82_6, newColor, 1f);
							}
							if (Main.tile[j, i].type == 93 && Main.rand.Next(40) == 0 && Main.tile[j, i].frameX == 0 && Main.tile[j, i].frameY == 0)
							{
								Vector2 arg_B0A_0 = new Vector2((float)(j * 16 + 4), (float)(i * 16 + 2));
								int arg_B0A_1 = 4;
								int arg_B0A_2 = 4;
								int arg_B0A_3 = 6;
								float arg_B0A_4 = 0f;
								float arg_B0A_5 = 0f;
								int arg_B0A_6 = 100;
								Color newColor = default(Color);
								Dust.NewDust(arg_B0A_0, arg_B0A_1, arg_B0A_2, arg_B0A_3, arg_B0A_4, arg_B0A_5, arg_B0A_6, newColor, 1f);
							}
							if (Main.tile[j, i].type == 100 && Main.rand.Next(40) == 0 && Main.tile[j, i].frameX < 36 && Main.tile[j, i].frameY == 0)
							{
								if (Main.tile[j, i].frameX == 0)
								{
									if (Main.rand.Next(3) == 0)
									{
										Vector2 arg_BC5_0 = new Vector2((float)(j * 16 + 4), (float)(i * 16 + 2));
										int arg_BC5_1 = 4;
										int arg_BC5_2 = 4;
										int arg_BC5_3 = 6;
										float arg_BC5_4 = 0f;
										float arg_BC5_5 = 0f;
										int arg_BC5_6 = 100;
										Color newColor = default(Color);
										Dust.NewDust(arg_BC5_0, arg_BC5_1, arg_BC5_2, arg_BC5_3, arg_BC5_4, arg_BC5_5, arg_BC5_6, newColor, 1f);
									}
									else
									{
										Vector2 arg_C04_0 = new Vector2((float)(j * 16 + 14), (float)(i * 16 + 2));
										int arg_C04_1 = 4;
										int arg_C04_2 = 4;
										int arg_C04_3 = 6;
										float arg_C04_4 = 0f;
										float arg_C04_5 = 0f;
										int arg_C04_6 = 100;
										Color newColor = default(Color);
										Dust.NewDust(arg_C04_0, arg_C04_1, arg_C04_2, arg_C04_3, arg_C04_4, arg_C04_5, arg_C04_6, newColor, 1f);
									}
								}
								else
								{
									if (Main.rand.Next(3) == 0)
									{
										Vector2 arg_C4C_0 = new Vector2((float)(j * 16 + 6), (float)(i * 16 + 2));
										int arg_C4C_1 = 4;
										int arg_C4C_2 = 4;
										int arg_C4C_3 = 6;
										float arg_C4C_4 = 0f;
										float arg_C4C_5 = 0f;
										int arg_C4C_6 = 100;
										Color newColor = default(Color);
										Dust.NewDust(arg_C4C_0, arg_C4C_1, arg_C4C_2, arg_C4C_3, arg_C4C_4, arg_C4C_5, arg_C4C_6, newColor, 1f);
									}
									else
									{
										Vector2 arg_C85_0 = new Vector2((float)(j * 16), (float)(i * 16 + 2));
										int arg_C85_1 = 4;
										int arg_C85_2 = 4;
										int arg_C85_3 = 6;
										float arg_C85_4 = 0f;
										float arg_C85_5 = 0f;
										int arg_C85_6 = 100;
										Color newColor = default(Color);
										Dust.NewDust(arg_C85_0, arg_C85_1, arg_C85_2, arg_C85_3, arg_C85_4, arg_C85_5, arg_C85_6, newColor, 1f);
									}
								}
							}
							if (Main.tile[j, i].type == 98 && Main.rand.Next(40) == 0 && Main.tile[j, i].frameY == 0 && Main.tile[j, i].frameX == 0)
							{
								Vector2 arg_D0E_0 = new Vector2((float)(j * 16 + 12), (float)(i * 16 + 2));
								int arg_D0E_1 = 4;
								int arg_D0E_2 = 4;
								int arg_D0E_3 = 6;
								float arg_D0E_4 = 0f;
								float arg_D0E_5 = 0f;
								int arg_D0E_6 = 100;
								Color newColor = default(Color);
								Dust.NewDust(arg_D0E_0, arg_D0E_1, arg_D0E_2, arg_D0E_3, arg_D0E_4, arg_D0E_5, arg_D0E_6, newColor, 1f);
							}
							if (Main.tile[j, i].type == 49 && Main.rand.Next(20) == 0)
							{
								Vector2 arg_D6D_0 = new Vector2((float)(j * 16 + 4), (float)(i * 16 - 4));
								int arg_D6D_1 = 4;
								int arg_D6D_2 = 4;
								int arg_D6D_3 = 29;
								float arg_D6D_4 = 0f;
								float arg_D6D_5 = 0f;
								int arg_D6D_6 = 100;
								Color newColor = default(Color);
								Dust.NewDust(arg_D6D_0, arg_D6D_1, arg_D6D_2, arg_D6D_3, arg_D6D_4, arg_D6D_5, arg_D6D_6, newColor, 1f);
							}
							if ((Main.tile[j, i].type == 34 || Main.tile[j, i].type == 35 || Main.tile[j, i].type == 36) && Main.rand.Next(40) == 0 && Main.tile[j, i].frameX < 54 && Main.tile[j, i].frameY == 18 && (Main.tile[j, i].frameX == 0 || Main.tile[j, i].frameX == 36))
							{
								Vector2 arg_E58_0 = new Vector2((float)(j * 16), (float)(i * 16 + 2));
								int arg_E58_1 = 14;
								int arg_E58_2 = 6;
								int arg_E58_3 = 6;
								float arg_E58_4 = 0f;
								float arg_E58_5 = 0f;
								int arg_E58_6 = 100;
								Color newColor = default(Color);
								Dust.NewDust(arg_E58_0, arg_E58_1, arg_E58_2, arg_E58_3, arg_E58_4, arg_E58_5, arg_E58_6, newColor, 1f);
							}
							if (Main.tile[j, i].type == 22 && Main.rand.Next(400) == 0)
							{
								Vector2 arg_EB7_0 = new Vector2((float)(j * 16), (float)(i * 16));
								int arg_EB7_1 = 16;
								int arg_EB7_2 = 16;
								int arg_EB7_3 = 14;
								float arg_EB7_4 = 0f;
								float arg_EB7_5 = 0f;
								int arg_EB7_6 = 0;
								Color newColor = default(Color);
								Dust.NewDust(arg_EB7_0, arg_EB7_1, arg_EB7_2, arg_EB7_3, arg_EB7_4, arg_EB7_5, arg_EB7_6, newColor, 1f);
							}
							else
							{
								if ((Main.tile[j, i].type == 23 || Main.tile[j, i].type == 24 || Main.tile[j, i].type == 32) && Main.rand.Next(500) == 0)
								{
									Vector2 arg_F49_0 = new Vector2((float)(j * 16), (float)(i * 16));
									int arg_F49_1 = 16;
									int arg_F49_2 = 16;
									int arg_F49_3 = 14;
									float arg_F49_4 = 0f;
									float arg_F49_5 = 0f;
									int arg_F49_6 = 0;
									Color newColor = default(Color);
									Dust.NewDust(arg_F49_0, arg_F49_1, arg_F49_2, arg_F49_3, arg_F49_4, arg_F49_5, arg_F49_6, newColor, 1f);
								}
								else
								{
									if (Main.tile[j, i].type == 25 && Main.rand.Next(700) == 0)
									{
										Vector2 arg_FAD_0 = new Vector2((float)(j * 16), (float)(i * 16));
										int arg_FAD_1 = 16;
										int arg_FAD_2 = 16;
										int arg_FAD_3 = 14;
										float arg_FAD_4 = 0f;
										float arg_FAD_5 = 0f;
										int arg_FAD_6 = 0;
										Color newColor = default(Color);
										Dust.NewDust(arg_FAD_0, arg_FAD_1, arg_FAD_2, arg_FAD_3, arg_FAD_4, arg_FAD_5, arg_FAD_6, newColor, 1f);
									}
									else
									{
										if (Main.tile[j, i].type == 112 && Main.rand.Next(700) == 0)
										{
											Vector2 arg_1011_0 = new Vector2((float)(j * 16), (float)(i * 16));
											int arg_1011_1 = 16;
											int arg_1011_2 = 16;
											int arg_1011_3 = 14;
											float arg_1011_4 = 0f;
											float arg_1011_5 = 0f;
											int arg_1011_6 = 0;
											Color newColor = default(Color);
											Dust.NewDust(arg_1011_0, arg_1011_1, arg_1011_2, arg_1011_3, arg_1011_4, arg_1011_5, arg_1011_6, newColor, 1f);
										}
										else
										{
											if (Main.tile[j, i].type == 31 && Main.rand.Next(20) == 0)
											{
												Vector2 arg_1073_0 = new Vector2((float)(j * 16), (float)(i * 16));
												int arg_1073_1 = 16;
												int arg_1073_2 = 16;
												int arg_1073_3 = 14;
												float arg_1073_4 = 0f;
												float arg_1073_5 = 0f;
												int arg_1073_6 = 100;
												Color newColor = default(Color);
												Dust.NewDust(arg_1073_0, arg_1073_1, arg_1073_2, arg_1073_3, arg_1073_4, arg_1073_5, arg_1073_6, newColor, 1f);
											}
											else
											{
												if (Main.tile[j, i].type == 26 && Main.rand.Next(20) == 0)
												{
													Vector2 arg_10D5_0 = new Vector2((float)(j * 16), (float)(i * 16));
													int arg_10D5_1 = 16;
													int arg_10D5_2 = 16;
													int arg_10D5_3 = 14;
													float arg_10D5_4 = 0f;
													float arg_10D5_5 = 0f;
													int arg_10D5_6 = 100;
													Color newColor = default(Color);
													Dust.NewDust(arg_10D5_0, arg_10D5_1, arg_10D5_2, arg_10D5_3, arg_10D5_4, arg_10D5_5, arg_10D5_6, newColor, 1f);
												}
												else
												{
													if ((Main.tile[j, i].type == 71 || Main.tile[j, i].type == 72) && Main.rand.Next(500) == 0)
													{
														Vector2 arg_1154_0 = new Vector2((float)(j * 16), (float)(i * 16));
														int arg_1154_1 = 16;
														int arg_1154_2 = 16;
														int arg_1154_3 = 41;
														float arg_1154_4 = 0f;
														float arg_1154_5 = 0f;
														int arg_1154_6 = 250;
														Color newColor = default(Color);
														Dust.NewDust(arg_1154_0, arg_1154_1, arg_1154_2, arg_1154_3, arg_1154_4, arg_1154_5, arg_1154_6, newColor, 0.8f);
													}
													else
													{
														if ((Main.tile[j, i].type == 17 || Main.tile[j, i].type == 77 || Main.tile[j, i].type == 133) && Main.rand.Next(40) == 0)
														{
															if (Main.tile[j, i].frameX == 18 & Main.tile[j, i].frameY == 18)
															{
																Vector2 arg_121A_0 = new Vector2((float)(j * 16 + 2), (float)(i * 16));
																int arg_121A_1 = 8;
																int arg_121A_2 = 6;
																int arg_121A_3 = 6;
																float arg_121A_4 = 0f;
																float arg_121A_5 = 0f;
																int arg_121A_6 = 100;
																Color newColor = default(Color);
																Dust.NewDust(arg_121A_0, arg_121A_1, arg_121A_2, arg_121A_3, arg_121A_4, arg_121A_5, arg_121A_6, newColor, 1f);
															}
														}
														else
														{
															if (Main.tile[j, i].type == 37 && Main.rand.Next(250) == 0)
															{
																Vector2 arg_1284_0 = new Vector2((float)(j * 16), (float)(i * 16));
																int arg_1284_1 = 16;
																int arg_1284_2 = 16;
																int arg_1284_3 = 6;
																float arg_1284_4 = 0f;
																float arg_1284_5 = 0f;
																int arg_1284_6 = 0;
																Color newColor = default(Color);
																int num12 = Dust.NewDust(arg_1284_0, arg_1284_1, arg_1284_2, arg_1284_3, arg_1284_4, arg_1284_5, arg_1284_6, newColor, (float)Main.rand.Next(3));
																if (Main.dust[num12].scale > 1f)
																{
																	Main.dust[num12].noGravity = true;
																}
															}
															else
															{
																if ((Main.tile[j, i].type == 58 || Main.tile[j, i].type == 76) && Main.rand.Next(250) == 0)
																{
																	Vector2 arg_132E_0 = new Vector2((float)(j * 16), (float)(i * 16));
																	int arg_132E_1 = 16;
																	int arg_132E_2 = 16;
																	int arg_132E_3 = 6;
																	float arg_132E_4 = 0f;
																	float arg_132E_5 = 0f;
																	int arg_132E_6 = 0;
																	Color newColor = default(Color);
																	int num13 = Dust.NewDust(arg_132E_0, arg_132E_1, arg_132E_2, arg_132E_3, arg_132E_4, arg_132E_5, arg_132E_6, newColor, (float)Main.rand.Next(3));
																	if (Main.dust[num13].scale > 1f)
																	{
																		Main.dust[num13].noGravity = true;
																	}
																	Main.dust[num13].noLight = true;
																}
																else
																{
																	if (Main.tile[j, i].type == 61)
																	{
																		if (Main.tile[j, i].frameX == 144)
																		{
																			if (Main.rand.Next(60) == 0)
																			{
																				Vector2 arg_13E4_0 = new Vector2((float)(j * 16), (float)(i * 16));
																				int arg_13E4_1 = 16;
																				int arg_13E4_2 = 16;
																				int arg_13E4_3 = 44;
																				float arg_13E4_4 = 0f;
																				float arg_13E4_5 = 0f;
																				int arg_13E4_6 = 250;
																				Color newColor = default(Color);
																				int num14 = Dust.NewDust(arg_13E4_0, arg_13E4_1, arg_13E4_2, arg_13E4_3, arg_13E4_4, arg_13E4_5, arg_13E4_6, newColor, 0.4f);
																				Main.dust[num14].fadeIn = 0.7f;
																			}
																			color.A = (byte)(245f - (float)Main.mouseTextColor * 1.5f);
																			color.R = (byte)(245f - (float)Main.mouseTextColor * 1.5f);
																			color.B = (byte)(245f - (float)Main.mouseTextColor * 1.5f);
																			color.G = (byte)(245f - (float)Main.mouseTextColor * 1.5f);
																		}
																	}
																	else
																	{
																		if (Main.tileShine[(int)Main.tile[j, i].type] > 0 && (color.R > 20 || color.B > 20 || color.G > 20))
																		{
																			int num15 = (int)color.R;
																			if ((int)color.G > num15)
																			{
																				num15 = (int)color.G;
																			}
																			if ((int)color.B > num15)
																			{
																				num15 = (int)color.B;
																			}
																			num15 /= 30;
																			if (Main.rand.Next(Main.tileShine[(int)Main.tile[j, i].type]) < num15 && (Main.tile[j, i].type != 21 || (Main.tile[j, i].frameX >= 36 && Main.tile[j, i].frameX < 180)))
																			{
																				Vector2 arg_158C_0 = new Vector2((float)(j * 16), (float)(i * 16));
																				int arg_158C_1 = 16;
																				int arg_158C_2 = 16;
																				int arg_158C_3 = 43;
																				float arg_158C_4 = 0f;
																				float arg_158C_5 = 0f;
																				int arg_158C_6 = 254;
																				Color newColor = default(Color);
																				int num16 = Dust.NewDust(arg_158C_0, arg_158C_1, arg_158C_2, arg_158C_3, arg_158C_4, arg_158C_5, arg_158C_6, newColor, 0.5f);
																				Dust expr_159B = Main.dust[num16];
																				expr_159B.velocity *= 0f;
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
						if (Main.tile[j, i].type == 128 && Main.tile[j, i].frameX >= 100)
						{
							array[num3] = j;
							array2[num3] = i;
							num3++;
						}
						if (Main.tile[j, i].type == 5 && Main.tile[j, i].frameY >= 198 && Main.tile[j, i].frameX >= 22)
						{
							array[num3] = j;
							array2[num3] = i;
							num3++;
						}
						if (Main.tile[j, i].type == 72 && Main.tile[j, i].frameX >= 36)
						{
							int num17 = 0;
							if (Main.tile[j, i].frameY == 18)
							{
								num17 = 1;
							}
							else
							{
								if (Main.tile[j, i].frameY == 36)
								{
									num17 = 2;
								}
							}
							SpriteBatch arg_1734_0 = this.spriteBatch;
							Texture2D arg_1734_1 = Main.shroomCapTexture;
							Vector2 arg_1734_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X - 22), (float)(i * 16 - (int)Main.screenPosition.Y - 26)) + value;
							Rectangle? arg_1734_3 = new Rectangle?(new Rectangle(num17 * 62, 0, 60, 42));
							Color arg_1734_4 = Lighting.GetColor(j, i);
							float arg_1734_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_1734_0.Draw(arg_1734_1, arg_1734_2, arg_1734_3, arg_1734_4, arg_1734_5, origin, 1f, SpriteEffects.None, 0f);
						}
						if (color.R > 1 || color.G > 1 || color.B > 1)
						{
							if (Main.tile[j - 1, i] == null)
							{

							}
							if (Main.tile[j + 1, i] == null)
							{

							}
							if (Main.tile[j, i - 1] == null)
							{

							}
							if (Main.tile[j, i + 1] == null)
							{

							}
							if (solidOnly && flag && !Main.tileSolidTop[(int)Main.tile[j, i].type] && (Main.tile[j - 1, i].liquid > 0 || Main.tile[j + 1, i].liquid > 0 || Main.tile[j, i - 1].liquid > 0 || Main.tile[j, i + 1].liquid > 0))
							{
								Color color2 = Lighting.GetColor(j, i);
								int num18 = 0;
								bool flag2 = false;
								bool flag3 = false;
								bool flag4 = false;
								bool flag5 = false;
								int num19 = 0;
								bool flag6 = false;
								if ((int)Main.tile[j - 1, i].liquid > num18)
								{
									num18 = (int)Main.tile[j - 1, i].liquid;
									flag2 = true;
								}
								else
								{
									if (Main.tile[j - 1, i].liquid > 0)
									{
										flag2 = true;
									}
								}
								if ((int)Main.tile[j + 1, i].liquid > num18)
								{
									num18 = (int)Main.tile[j + 1, i].liquid;
									flag3 = true;
								}
								else
								{
									if (Main.tile[j + 1, i].liquid > 0)
									{
										num18 = (int)Main.tile[j + 1, i].liquid;
										flag3 = true;
									}
								}
								if (Main.tile[j, i - 1].liquid > 0)
								{
									flag4 = true;
								}
								if (Main.tile[j, i + 1].liquid > 240)
								{
									flag5 = true;
								}
								if (Main.tile[j - 1, i].liquid > 0)
								{
									if (Main.tile[j - 1, i].lava)
									{
										num19 = 1;
									}
									else
									{
										flag6 = true;
									}
								}
								if (Main.tile[j + 1, i].liquid > 0)
								{
									if (Main.tile[j + 1, i].lava)
									{
										num19 = 1;
									}
									else
									{
										flag6 = true;
									}
								}
								if (Main.tile[j, i - 1].liquid > 0)
								{
									if (Main.tile[j, i - 1].lava)
									{
										num19 = 1;
									}
									else
									{
										flag6 = true;
									}
								}
								if (Main.tile[j, i + 1].liquid > 0)
								{
									if (Main.tile[j, i + 1].lava)
									{
										num19 = 1;
									}
									else
									{
										flag6 = true;
									}
								}
								if (!flag6 || num19 != 1)
								{
									Vector2 value2 = new Vector2((float)(j * 16), (float)(i * 16));
									Rectangle value3 = new Rectangle(0, 4, 16, 16);
									if (flag5 && (flag2 || flag3))
									{
										flag2 = true;
										flag3 = true;
									}
									if ((!flag4 || (!flag2 && !flag3)) && (!flag5 || !flag4))
									{
										if (flag4)
										{
											value3 = new Rectangle(0, 4, 16, 4);
										}
										else
										{
											if (flag5 && !flag2 && !flag3)
											{
												value2 = new Vector2((float)(j * 16), (float)(i * 16 + 12));
												value3 = new Rectangle(0, 4, 16, 4);
											}
											else
											{
												float num20 = (float)(256 - num18);
												num20 /= 32f;
												if (flag2 && flag3)
												{
													value2 = new Vector2((float)(j * 16), (float)(i * 16 + (int)num20 * 2));
													value3 = new Rectangle(0, 4, 16, 16 - (int)num20 * 2);
												}
												else
												{
													if (flag2)
													{
														value2 = new Vector2((float)(j * 16), (float)(i * 16 + (int)num20 * 2));
														value3 = new Rectangle(0, 4, 4, 16 - (int)num20 * 2);
													}
													else
													{
														value2 = new Vector2((float)(j * 16 + 12), (float)(i * 16 + (int)num20 * 2));
														value3 = new Rectangle(0, 4, 4, 16 - (int)num20 * 2);
													}
												}
											}
										}
									}
									float num21 = 0.5f;
									if (num19 == 1)
									{
										num21 *= 1.6f;
									}
									if ((double)i < Main.worldSurface || num21 > 1f)
									{
										num21 = 1f;
									}
									float num22 = (float)color2.R * num21;
									float num23 = (float)color2.G * num21;
									float num24 = (float)color2.B * num21;
									float num25 = (float)color2.A * num21;
									color2 = new Color((int)((byte)num22), (int)((byte)num23), (int)((byte)num24), (int)((byte)num25));
									SpriteBatch arg_1C7F_0 = this.spriteBatch;
									Texture2D arg_1C7F_1 = Main.liquidTexture[num19];
									Vector2 arg_1C7F_2 = value2 - Main.screenPosition + value;
									Rectangle? arg_1C7F_3 = new Rectangle?(value3);
									Color arg_1C7F_4 = color2;
									float arg_1C7F_5 = 0f;
									Vector2 origin = default(Vector2);
									arg_1C7F_0.Draw(arg_1C7F_1, arg_1C7F_2, arg_1C7F_3, arg_1C7F_4, arg_1C7F_5, origin, 1f, SpriteEffects.None, 0f);
								}
							}
							if (Main.tile[j, i].type == 51)
							{
								Color color3 = Lighting.GetColor(j, i);
								float num26 = 0.5f;
								float num27 = (float)color3.R * num26;
								float num28 = (float)color3.G * num26;
								float num29 = (float)color3.B * num26;
								float num30 = (float)color3.A * num26;
								color3 = new Color((int)((byte)num27), (int)((byte)num28), (int)((byte)num29), (int)((byte)num30));
								SpriteBatch arg_1DA8_0 = this.spriteBatch;
								Texture2D arg_1DA8_1 = Main.tileTexture[(int)Main.tile[j, i].type];
								Vector2 arg_1DA8_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num8 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num9)) + value;
								Rectangle? arg_1DA8_3 = new Rectangle?(new Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num8, height));
								Color arg_1DA8_4 = color3;
								float arg_1DA8_5 = 0f;
								Vector2 origin = default(Vector2);
								arg_1DA8_0.Draw(arg_1DA8_1, arg_1DA8_2, arg_1DA8_3, arg_1DA8_4, arg_1DA8_5, origin, 1f, SpriteEffects.None, 0f);
							}
							else
							{
								if (Main.tile[j, i].type == 129)
								{
									SpriteBatch arg_1E93_0 = this.spriteBatch;
									Texture2D arg_1E93_1 = Main.tileTexture[(int)Main.tile[j, i].type];
									Vector2 arg_1E93_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num8 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num9)) + value;
									Rectangle? arg_1E93_3 = new Rectangle?(new Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num8, height));
									Color arg_1E93_4 = new Color(200, 200, 200, 0);
									float arg_1E93_5 = 0f;
									Vector2 origin = default(Vector2);
									arg_1E93_0.Draw(arg_1E93_1, arg_1E93_2, arg_1E93_3, arg_1E93_4, arg_1E93_5, origin, 1f, SpriteEffects.None, 0f);
								}
								else
								{
									if (Main.tileAlch[(int)Main.tile[j, i].type])
									{
										height = 20;
										num9 = -1;
										int num31 = (int)Main.tile[j, i].type;
										int num32 = (int)(Main.tile[j, i].frameX / 18);
										if (num31 > 82)
										{
											if (num32 == 0 && Main.dayTime)
											{
												num31 = 84;
											}
											if (num32 == 1 && !Main.dayTime)
											{
												num31 = 84;
											}
											if (num32 == 3 && Main.bloodMoon)
											{
												num31 = 84;
											}
										}
										if (num31 == 84)
										{
											if (num32 == 0 && Main.rand.Next(100) == 0)
											{
												Vector2 arg_1F7C_0 = new Vector2((float)(j * 16), (float)(i * 16 - 4));
												int arg_1F7C_1 = 16;
												int arg_1F7C_2 = 16;
												int arg_1F7C_3 = 19;
												float arg_1F7C_4 = 0f;
												float arg_1F7C_5 = 0f;
												int arg_1F7C_6 = 160;
												Color newColor = default(Color);
												int num33 = Dust.NewDust(arg_1F7C_0, arg_1F7C_1, arg_1F7C_2, arg_1F7C_3, arg_1F7C_4, arg_1F7C_5, arg_1F7C_6, newColor, 0.1f);
												Dust expr_1F90_cp_0 = Main.dust[num33];
												expr_1F90_cp_0.velocity.X = expr_1F90_cp_0.velocity.X / 2f;
												Dust expr_1FAE_cp_0 = Main.dust[num33];
												expr_1FAE_cp_0.velocity.Y = expr_1FAE_cp_0.velocity.Y / 2f;
												Main.dust[num33].noGravity = true;
												Main.dust[num33].fadeIn = 1f;
											}
											if (num32 == 1 && Main.rand.Next(100) == 0)
											{
												Vector2 arg_2027_0 = new Vector2((float)(j * 16), (float)(i * 16));
												int arg_2027_1 = 16;
												int arg_2027_2 = 16;
												int arg_2027_3 = 41;
												float arg_2027_4 = 0f;
												float arg_2027_5 = 0f;
												int arg_2027_6 = 250;
												Color newColor = default(Color);
												Dust.NewDust(arg_2027_0, arg_2027_1, arg_2027_2, arg_2027_3, arg_2027_4, arg_2027_5, arg_2027_6, newColor, 0.8f);
											}
											if (num32 == 3)
											{
												if (Main.rand.Next(200) == 0)
												{
													Vector2 arg_2078_0 = new Vector2((float)(j * 16), (float)(i * 16));
													int arg_2078_1 = 16;
													int arg_2078_2 = 16;
													int arg_2078_3 = 14;
													float arg_2078_4 = 0f;
													float arg_2078_5 = 0f;
													int arg_2078_6 = 100;
													Color newColor = default(Color);
													int num34 = Dust.NewDust(arg_2078_0, arg_2078_1, arg_2078_2, arg_2078_3, arg_2078_4, arg_2078_5, arg_2078_6, newColor, 0.2f);
													Main.dust[num34].fadeIn = 1.2f;
												}
												if (Main.rand.Next(75) == 0)
												{
													Vector2 arg_20D1_0 = new Vector2((float)(j * 16), (float)(i * 16));
													int arg_20D1_1 = 16;
													int arg_20D1_2 = 16;
													int arg_20D1_3 = 27;
													float arg_20D1_4 = 0f;
													float arg_20D1_5 = 0f;
													int arg_20D1_6 = 100;
													Color newColor = default(Color);
													int num35 = Dust.NewDust(arg_20D1_0, arg_20D1_1, arg_20D1_2, arg_20D1_3, arg_20D1_4, arg_20D1_5, arg_20D1_6, newColor, 1f);
													Dust expr_20E5_cp_0 = Main.dust[num35];
													expr_20E5_cp_0.velocity.X = expr_20E5_cp_0.velocity.X / 2f;
													Dust expr_2103_cp_0 = Main.dust[num35];
													expr_2103_cp_0.velocity.Y = expr_2103_cp_0.velocity.Y / 2f;
												}
											}
											if (num32 == 4 && Main.rand.Next(150) == 0)
											{
												Vector2 arg_2160_0 = new Vector2((float)(j * 16), (float)(i * 16));
												int arg_2160_1 = 16;
												int arg_2160_2 = 8;
												int arg_2160_3 = 16;
												float arg_2160_4 = 0f;
												float arg_2160_5 = 0f;
												int arg_2160_6 = 0;
												Color newColor = default(Color);
												int num36 = Dust.NewDust(arg_2160_0, arg_2160_1, arg_2160_2, arg_2160_3, arg_2160_4, arg_2160_5, arg_2160_6, newColor, 1f);
												Dust expr_2174_cp_0 = Main.dust[num36];
												expr_2174_cp_0.velocity.X = expr_2174_cp_0.velocity.X / 3f;
												Dust expr_2192_cp_0 = Main.dust[num36];
												expr_2192_cp_0.velocity.Y = expr_2192_cp_0.velocity.Y / 3f;
												Dust expr_21B0_cp_0 = Main.dust[num36];
												expr_21B0_cp_0.velocity.Y = expr_21B0_cp_0.velocity.Y - 0.7f;
												Main.dust[num36].alpha = 50;
												Main.dust[num36].scale *= 0.1f;
												Main.dust[num36].fadeIn = 0.9f;
												Main.dust[num36].noGravity = true;
											}
											if (num32 == 5)
											{
												if (Main.rand.Next(40) == 0)
												{
													Vector2 arg_2251_0 = new Vector2((float)(j * 16), (float)(i * 16 - 6));
													int arg_2251_1 = 16;
													int arg_2251_2 = 16;
													int arg_2251_3 = 6;
													float arg_2251_4 = 0f;
													float arg_2251_5 = 0f;
													int arg_2251_6 = 0;
													Color newColor = default(Color);
													int num37 = Dust.NewDust(arg_2251_0, arg_2251_1, arg_2251_2, arg_2251_3, arg_2251_4, arg_2251_5, arg_2251_6, newColor, 1.5f);
													Dust expr_2265_cp_0 = Main.dust[num37];
													expr_2265_cp_0.velocity.Y = expr_2265_cp_0.velocity.Y - 2f;
													Main.dust[num37].noGravity = true;
												}
												color.A = (byte)(Main.mouseTextColor / 2);
												color.G = Main.mouseTextColor;
												color.B = Main.mouseTextColor;
											}
										}
										SpriteBatch arg_234B_0 = this.spriteBatch;
										Texture2D arg_234B_1 = Main.tileTexture[num31];
										Vector2 arg_234B_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num8 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num9)) + value;
										Rectangle? arg_234B_3 = new Rectangle?(new Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num8, height));
										Color arg_234B_4 = color;
										float arg_234B_5 = 0f;
										Vector2 origin = default(Vector2);
										arg_234B_0.Draw(arg_234B_1, arg_234B_2, arg_234B_3, arg_234B_4, arg_234B_5, origin, 1f, SpriteEffects.None, 0f);
									}
									else
									{
										if (Main.tile[j, i].type == 80)
										{
											bool flag7 = false;
											bool flag8 = false;
											int num38 = j;
											if (Main.tile[j, i].frameX == 36)
											{
												num38--;
											}
											if (Main.tile[j, i].frameX == 54)
											{
												num38++;
											}
											if (Main.tile[j, i].frameX == 108)
											{
												if (Main.tile[j, i].frameY == 16)
												{
													num38--;
												}
												else
												{
													num38++;
												}
											}
											int num39 = i;
											bool flag9 = false;
											if (Main.tile[num38, num39].type == 80 && Main.tile[num38, num39].active)
											{
												flag9 = true;
											}
											while (!Main.tile[num38, num39].active || !Main.tileSolid[(int)Main.tile[num38, num39].type] || !flag9)
											{
												if (Main.tile[num38, num39].type == 80 && Main.tile[num38, num39].active)
												{
													flag9 = true;
												}
												num39++;
												if (num39 > i + 20)
												{
													break;
												}
											}
											if (Main.tile[num38, num39].type == 112)
											{
												flag7 = true;
											}
											if (Main.tile[num38, num39].type == 116)
											{
												flag8 = true;
											}
											if (flag7)
											{
												SpriteBatch arg_2571_0 = this.spriteBatch;
												Texture2D arg_2571_1 = Main.evilCactusTexture;
												Vector2 arg_2571_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num8 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num9)) + value;
												Rectangle? arg_2571_3 = new Rectangle?(new Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num8, height));
												Color arg_2571_4 = color;
												float arg_2571_5 = 0f;
												Vector2 origin = default(Vector2);
												arg_2571_0.Draw(arg_2571_1, arg_2571_2, arg_2571_3, arg_2571_4, arg_2571_5, origin, 1f, SpriteEffects.None, 0f);
											}
											else
											{
												if (flag8)
												{
													SpriteBatch arg_261F_0 = this.spriteBatch;
													Texture2D arg_261F_1 = Main.goodCactusTexture;
													Vector2 arg_261F_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num8 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num9)) + value;
													Rectangle? arg_261F_3 = new Rectangle?(new Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num8, height));
													Color arg_261F_4 = color;
													float arg_261F_5 = 0f;
													Vector2 origin = default(Vector2);
													arg_261F_0.Draw(arg_261F_1, arg_261F_2, arg_261F_3, arg_261F_4, arg_261F_5, origin, 1f, SpriteEffects.None, 0f);
												}
												else
												{
													SpriteBatch arg_26DA_0 = this.spriteBatch;
													Texture2D arg_26DA_1 = Main.tileTexture[(int)Main.tile[j, i].type];
													Vector2 arg_26DA_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num8 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num9)) + value;
													Rectangle? arg_26DA_3 = new Rectangle?(new Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num8, height));
													Color arg_26DA_4 = color;
													float arg_26DA_5 = 0f;
													Vector2 origin = default(Vector2);
													arg_26DA_0.Draw(arg_26DA_1, arg_26DA_2, arg_26DA_3, arg_26DA_4, arg_26DA_5, origin, 1f, SpriteEffects.None, 0f);
												}
											}
										}
										else
										{
											if (Lighting.lightMode < 2 && Main.tileSolid[(int)Main.tile[j, i].type] && Main.tile[j, i].type != 137)
											{
												if ((int)color.R > num || (double)color.G > (double)num * 1.1 || (double)color.B > (double)num * 1.2)
												{
													for (int k = 0; k < 9; k++)
													{
														int num40 = 0;
														int num41 = 0;
														int width = 4;
														int height2 = 4;
														Color color4 = color;
														Color color5 = color;
														if (k == 0)
														{
															color5 = Lighting.GetColor(j - 1, i - 1);
														}
														if (k == 1)
														{
															width = 8;
															num40 = 4;
															color5 = Lighting.GetColor(j, i - 1);
														}
														if (k == 2)
														{
															color5 = Lighting.GetColor(j + 1, i - 1);
															num40 = 12;
														}
														if (k == 3)
														{
															color5 = Lighting.GetColor(j - 1, i);
															height2 = 8;
															num41 = 4;
														}
														if (k == 4)
														{
															width = 8;
															height2 = 8;
															num40 = 4;
															num41 = 4;
														}
														if (k == 5)
														{
															num40 = 12;
															num41 = 4;
															height2 = 8;
															color5 = Lighting.GetColor(j + 1, i);
														}
														if (k == 6)
														{
															color5 = Lighting.GetColor(j - 1, i + 1);
															num41 = 12;
														}
														if (k == 7)
														{
															width = 8;
															height2 = 4;
															num40 = 4;
															num41 = 12;
															color5 = Lighting.GetColor(j, i + 1);
														}
														if (k == 8)
														{
															color5 = Lighting.GetColor(j + 1, i + 1);
															num40 = 12;
															num41 = 12;
														}
														color4.R = (byte)((color.R + color5.R) / 2);
														color4.G = (byte)((color.G + color5.G) / 2);
														color4.B = (byte)((color.B + color5.B) / 2);
														if (Main.tileShine2[(int)Main.tile[j, i].type])
														{
															color4 = Main.shine(color4, (int)Main.tile[j, i].type);
														}
														SpriteBatch arg_299A_0 = this.spriteBatch;
														Texture2D arg_299A_1 = Main.tileTexture[(int)Main.tile[j, i].type];
														Vector2 arg_299A_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num8 - 16f) / 2f + (float)num40, (float)(i * 16 - (int)Main.screenPosition.Y + num9 + num41)) + value;
														Rectangle? arg_299A_3 = new Rectangle?(new Rectangle((int)Main.tile[j, i].frameX + num40, (int)Main.tile[j, i].frameY + num41, width, height2));
														Color arg_299A_4 = color4;
														float arg_299A_5 = 0f;
														Vector2 origin = default(Vector2);
														arg_299A_0.Draw(arg_299A_1, arg_299A_2, arg_299A_3, arg_299A_4, arg_299A_5, origin, 1f, SpriteEffects.None, 0f);
													}
												}
												else
												{
													if ((int)color.R > num2 || (double)color.G > (double)num2 * 1.1 || (double)color.B > (double)num2 * 1.2)
													{
														for (int l = 0; l < 4; l++)
														{
															int num42 = 0;
															int num43 = 0;
															Color color6 = color;
															Color color7 = color;
															if (l == 0)
															{
																if (Lighting.Brighter(j, i - 1, j - 1, i))
																{
																	color7 = Lighting.GetColor(j - 1, i);
																}
																else
																{
																	color7 = Lighting.GetColor(j, i - 1);
																}
															}
															if (l == 1)
															{
																if (Lighting.Brighter(j, i - 1, j + 1, i))
																{
																	color7 = Lighting.GetColor(j + 1, i);
																}
																else
																{
																	color7 = Lighting.GetColor(j, i - 1);
																}
																num42 = 8;
															}
															if (l == 2)
															{
																if (Lighting.Brighter(j, i + 1, j - 1, i))
																{
																	color7 = Lighting.GetColor(j - 1, i);
																}
																else
																{
																	color7 = Lighting.GetColor(j, i + 1);
																}
																num43 = 8;
															}
															if (l == 3)
															{
																if (Lighting.Brighter(j, i + 1, j + 1, i))
																{
																	color7 = Lighting.GetColor(j + 1, i);
																}
																else
																{
																	color7 = Lighting.GetColor(j, i + 1);
																}
																num42 = 8;
																num43 = 8;
															}
															color6.R = (byte)((color.R + color7.R) / 2);
															color6.G = (byte)((color.G + color7.G) / 2);
															color6.B = (byte)((color.B + color7.B) / 2);
															if (Main.tileShine2[(int)Main.tile[j, i].type])
															{
																color6 = Main.shine(color6, (int)Main.tile[j, i].type);
															}
															SpriteBatch arg_2C1B_0 = this.spriteBatch;
															Texture2D arg_2C1B_1 = Main.tileTexture[(int)Main.tile[j, i].type];
															Vector2 arg_2C1B_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num8 - 16f) / 2f + (float)num42, (float)(i * 16 - (int)Main.screenPosition.Y + num9 + num43)) + value;
															Rectangle? arg_2C1B_3 = new Rectangle?(new Rectangle((int)Main.tile[j, i].frameX + num42, (int)Main.tile[j, i].frameY + num43, 8, 8));
															Color arg_2C1B_4 = color6;
															float arg_2C1B_5 = 0f;
															Vector2 origin = default(Vector2);
															arg_2C1B_0.Draw(arg_2C1B_1, arg_2C1B_2, arg_2C1B_3, arg_2C1B_4, arg_2C1B_5, origin, 1f, SpriteEffects.None, 0f);
														}
													}
													else
													{
														if (Main.tileShine2[(int)Main.tile[j, i].type])
														{
															color = Main.shine(color, (int)Main.tile[j, i].type);
														}
														SpriteBatch arg_2D1B_0 = this.spriteBatch;
														Texture2D arg_2D1B_1 = Main.tileTexture[(int)Main.tile[j, i].type];
														Vector2 arg_2D1B_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num8 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num9)) + value;
														Rectangle? arg_2D1B_3 = new Rectangle?(new Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num8, height));
														Color arg_2D1B_4 = color;
														float arg_2D1B_5 = 0f;
														Vector2 origin = default(Vector2);
														arg_2D1B_0.Draw(arg_2D1B_1, arg_2D1B_2, arg_2D1B_3, arg_2D1B_4, arg_2D1B_5, origin, 1f, SpriteEffects.None, 0f);
													}
												}
											}
											else
											{
												if (Lighting.lightMode < 2 && Main.tileShine2[(int)Main.tile[j, i].type])
												{
													if (Main.tile[j, i].type == 21)
													{
														if (Main.tile[j, i].frameX >= 36 && Main.tile[j, i].frameX < 178)
														{
															color = Main.shine(color, (int)Main.tile[j, i].type);
														}
													}
													else
													{
														color = Main.shine(color, (int)Main.tile[j, i].type);
													}
												}
												if (Main.tile[j, i].type == 128)
												{
													int m;
													for (m = (int)Main.tile[j, i].frameX; m >= 100; m -= 100)
													{
													}
													SpriteBatch arg_2EB1_0 = this.spriteBatch;
													Texture2D arg_2EB1_1 = Main.tileTexture[(int)Main.tile[j, i].type];
													Vector2 arg_2EB1_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num8 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num9)) + value;
													Rectangle? arg_2EB1_3 = new Rectangle?(new Rectangle(m, (int)Main.tile[j, i].frameY, num8, height));
													Color arg_2EB1_4 = color;
													float arg_2EB1_5 = 0f;
													Vector2 origin = default(Vector2);
													arg_2EB1_0.Draw(arg_2EB1_1, arg_2EB1_2, arg_2EB1_3, arg_2EB1_4, arg_2EB1_5, origin, 1f, SpriteEffects.None, 0f);
												}
												else
												{
													SpriteBatch arg_2F6C_0 = this.spriteBatch;
													Texture2D arg_2F6C_1 = Main.tileTexture[(int)Main.tile[j, i].type];
													Vector2 arg_2F6C_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num8 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num9)) + value;
													Rectangle? arg_2F6C_3 = new Rectangle?(new Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num8, height));
													Color arg_2F6C_4 = color;
													float arg_2F6C_5 = 0f;
													Vector2 origin = default(Vector2);
													arg_2F6C_0.Draw(arg_2F6C_1, arg_2F6C_2, arg_2F6C_3, arg_2F6C_4, arg_2F6C_5, origin, 1f, SpriteEffects.None, 0f);
													if (Main.tile[j, i].type == 139)
													{
														SpriteBatch arg_303E_0 = this.spriteBatch;
														Texture2D arg_303E_1 = Main.MusicBoxTexture;
														Vector2 arg_303E_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num8 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num9)) + value;
														Rectangle? arg_303E_3 = new Rectangle?(new Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num8, height));
														Color arg_303E_4 = new Color(200, 200, 200, 0);
														float arg_303E_5 = 0f;
														origin = default(Vector2);
														arg_303E_0.Draw(arg_303E_1, arg_303E_2, arg_303E_3, arg_303E_4, arg_303E_5, origin, 1f, SpriteEffects.None, 0f);
													}
													if (Main.tile[j, i].type == 144)
													{
														SpriteBatch arg_3110_0 = this.spriteBatch;
														Texture2D arg_3110_1 = Main.timerTexture;
														Vector2 arg_3110_2 = new Vector2((float)(j * 16 - (int)Main.screenPosition.X) - ((float)num8 - 16f) / 2f, (float)(i * 16 - (int)Main.screenPosition.Y + num9)) + value;
														Rectangle? arg_3110_3 = new Rectangle?(new Rectangle((int)Main.tile[j, i].frameX, (int)Main.tile[j, i].frameY, num8, height));
														Color arg_3110_4 = new Color(200, 200, 200, 0);
														float arg_3110_5 = 0f;
														origin = default(Vector2);
														arg_3110_0.Draw(arg_3110_1, arg_3110_2, arg_3110_3, arg_3110_4, arg_3110_5, origin, 1f, SpriteEffects.None, 0f);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			for (int n = 0; n < num3; n++)
			{
				int num44 = array[n];
				int num45 = array2[n];
				if (Main.tile[num44, num45].type == 128 && Main.tile[num44, num45].frameX >= 100)
				{
					int num46 = (int)(Main.tile[num44, num45].frameY / 18);
					int num47 = (int)Main.tile[num44, num45].frameX;
					int num48 = 0;
					while (num47 >= 100)
					{
						num48++;
						num47 -= 100;
					}
					int num49 = -4;
					SpriteEffects effects = SpriteEffects.FlipHorizontally;
					if (num47 >= 36)
					{
						effects = SpriteEffects.None;
						num49 = -4;
					}
					if (num46 == 0)
					{
						SpriteBatch arg_325B_0 = this.spriteBatch;
						Texture2D arg_325B_1 = Main.armorHeadTexture[num48];
						Vector2 arg_325B_2 = new Vector2((float)(num44 * 16 - (int)Main.screenPosition.X + num49), (float)(num45 * 16 - (int)Main.screenPosition.Y - 12)) + value;
						Rectangle? arg_325B_3 = new Rectangle?(new Rectangle(0, 0, 40, 36));
						Color arg_325B_4 = Lighting.GetColor(num44, num45);
						float arg_325B_5 = 0f;
						Vector2 origin = default(Vector2);
						arg_325B_0.Draw(arg_325B_1, arg_325B_2, arg_325B_3, arg_325B_4, arg_325B_5, origin, 1f, effects, 0f);
					}
					else
					{
						if (num46 == 1)
						{
							SpriteBatch arg_32E4_0 = this.spriteBatch;
							Texture2D arg_32E4_1 = Main.armorBodyTexture[num48];
							Vector2 arg_32E4_2 = new Vector2((float)(num44 * 16 - (int)Main.screenPosition.X + num49), (float)(num45 * 16 - (int)Main.screenPosition.Y - 28)) + value;
							Rectangle? arg_32E4_3 = new Rectangle?(new Rectangle(0, 0, 40, 54));
							Color arg_32E4_4 = Lighting.GetColor(num44, num45);
							float arg_32E4_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_32E4_0.Draw(arg_32E4_1, arg_32E4_2, arg_32E4_3, arg_32E4_4, arg_32E4_5, origin, 1f, effects, 0f);
						}
						else
						{
							if (num46 == 2)
							{
								SpriteBatch arg_336A_0 = this.spriteBatch;
								Texture2D arg_336A_1 = Main.armorLegTexture[num48];
								Vector2 arg_336A_2 = new Vector2((float)(num44 * 16 - (int)Main.screenPosition.X + num49), (float)(num45 * 16 - (int)Main.screenPosition.Y - 44)) + value;
								Rectangle? arg_336A_3 = new Rectangle?(new Rectangle(0, 0, 40, 54));
								Color arg_336A_4 = Lighting.GetColor(num44, num45);
								float arg_336A_5 = 0f;
								Vector2 origin = default(Vector2);
								arg_336A_0.Draw(arg_336A_1, arg_336A_2, arg_336A_3, arg_336A_4, arg_336A_5, origin, 1f, effects, 0f);
							}
						}
					}
				}
				if (Main.tile[num44, num45].type == 5 && Main.tile[num44, num45].frameY >= 198 && Main.tile[num44, num45].frameX >= 22)
				{
					int num50 = 0;
					if (Main.tile[num44, num45].frameX == 22)
					{
						if (Main.tile[num44, num45].frameY == 220)
						{
							num50 = 1;
						}
						else
						{
							if (Main.tile[num44, num45].frameY == 242)
							{
								num50 = 2;
							}
						}
						int num51 = 0;
						int num52 = 80;
						int num53 = 80;
						int num54 = 32;
						int num55 = 0;
						int num56 = num45;
						while (num56 < num45 + 100)
						{
							if (Main.tile[num44, num56].type == 2)
							{
								num51 = 0;
								break;
							}
							if (Main.tile[num44, num56].type == 23)
							{
								num51 = 1;
								break;
							}
							if (Main.tile[num44, num56].type == 60)
							{
								num51 = 2;
								num52 = 114;
								num53 = 96;
								num54 = 48;
								break;
							}
							if (Main.tile[num44, num56].type == 109)
							{
								num51 = 3;
								num53 = 140;
								if (num44 % 3 == 1)
								{
									num50 += 3;
									break;
								}
								if (num44 % 3 == 2)
								{
									num50 += 6;
									break;
								}
								break;
							}
							else
							{
								num56++;
							}
						}
						SpriteBatch arg_3568_0 = this.spriteBatch;
						Texture2D arg_3568_1 = Main.treeTopTexture[num51];
						Vector2 arg_3568_2 = new Vector2((float)(num44 * 16 - (int)Main.screenPosition.X - num54), (float)(num45 * 16 - (int)Main.screenPosition.Y - num53 + 16 + num55)) + value;
						Rectangle? arg_3568_3 = new Rectangle?(new Rectangle(num50 * (num52 + 2), 0, num52, num53));
						Color arg_3568_4 = Lighting.GetColor(num44, num45);
						float arg_3568_5 = 0f;
						Vector2 origin = default(Vector2);
						arg_3568_0.Draw(arg_3568_1, arg_3568_2, arg_3568_3, arg_3568_4, arg_3568_5, origin, 1f, SpriteEffects.None, 0f);
					}
					else
					{
						if (Main.tile[num44, num45].frameX == 44)
						{
							if (Main.tile[num44, num45].frameY == 220)
							{
								num50 = 1;
							}
							else
							{
								if (Main.tile[num44, num45].frameY == 242)
								{
									num50 = 2;
								}
							}
							int num57 = 0;
							int num58 = num45;
							while (num58 < num45 + 100)
							{
								if (Main.tile[num44 + 1, num58].type == 2)
								{
									num57 = 0;
									break;
								}
								if (Main.tile[num44 + 1, num58].type == 23)
								{
									num57 = 1;
									break;
								}
								if (Main.tile[num44 + 1, num58].type == 60)
								{
									num57 = 2;
									break;
								}
								if (Main.tile[num44 + 1, num58].type == 109)
								{
									num57 = 3;
									if (num44 % 3 == 1)
									{
										num50 += 3;
										break;
									}
									if (num44 % 3 == 2)
									{
										num50 += 6;
										break;
									}
									break;
								}
								else
								{
									num58++;
								}
							}
							SpriteBatch arg_36F6_0 = this.spriteBatch;
							Texture2D arg_36F6_1 = Main.treeBranchTexture[num57];
							Vector2 arg_36F6_2 = new Vector2((float)(num44 * 16 - (int)Main.screenPosition.X - 24), (float)(num45 * 16 - (int)Main.screenPosition.Y - 12)) + value;
							Rectangle? arg_36F6_3 = new Rectangle?(new Rectangle(0, num50 * 42, 40, 40));
							Color arg_36F6_4 = Lighting.GetColor(num44, num45);
							float arg_36F6_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_36F6_0.Draw(arg_36F6_1, arg_36F6_2, arg_36F6_3, arg_36F6_4, arg_36F6_5, origin, 1f, SpriteEffects.None, 0f);
						}
						else
						{
							if (Main.tile[num44, num45].frameX == 66)
							{
								if (Main.tile[num44, num45].frameY == 220)
								{
									num50 = 1;
								}
								else
								{
									if (Main.tile[num44, num45].frameY == 242)
									{
										num50 = 2;
									}
								}
								int num59 = 0;
								int num60 = num45;
								while (num60 < num45 + 100)
								{
									if (Main.tile[num44 - 1, num60].type == 2)
									{
										num59 = 0;
										break;
									}
									if (Main.tile[num44 - 1, num60].type == 23)
									{
										num59 = 1;
										break;
									}
									if (Main.tile[num44 - 1, num60].type == 60)
									{
										num59 = 2;
										break;
									}
									if (Main.tile[num44 - 1, num60].type == 109)
									{
										num59 = 3;
										if (num44 % 3 == 1)
										{
											num50 += 3;
											break;
										}
										if (num44 % 3 == 2)
										{
											num50 += 6;
											break;
										}
										break;
									}
									else
									{
										num60++;
									}
								}
								SpriteBatch arg_3882_0 = this.spriteBatch;
								Texture2D arg_3882_1 = Main.treeBranchTexture[num59];
								Vector2 arg_3882_2 = new Vector2((float)(num44 * 16 - (int)Main.screenPosition.X), (float)(num45 * 16 - (int)Main.screenPosition.Y - 12)) + value;
								Rectangle? arg_3882_3 = new Rectangle?(new Rectangle(42, num50 * 42, 40, 40));
								Color arg_3882_4 = Lighting.GetColor(num44, num45);
								float arg_3882_5 = 0f;
								Vector2 origin = default(Vector2);
								arg_3882_0.Draw(arg_3882_1, arg_3882_2, arg_3882_3, arg_3882_4, arg_3882_5, origin, 1f, SpriteEffects.None, 0f);
							}
						}
					}
				}
			}
			if (solidOnly)
			{
				Main.renderTimer[0] = (float)stopwatch.ElapsedMilliseconds;
				return;
			}
			Main.renderTimer[1] = (float)stopwatch.ElapsedMilliseconds;
		}
		protected void DrawWater(bool bg = false)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				value = default(Vector2);
			}
			int num = (int)(255f * (1f - Main.gfxQuality) + 40f * Main.gfxQuality);
			int num2 = (int)(255f * (1f - Main.gfxQuality) + 140f * Main.gfxQuality);
			float num3 = (float)Main.evilTiles / 350f;
			if (num3 > 1f)
			{
				num3 = 1f;
			}
			if (num3 < 0f)
			{
				num3 = 0f;
			}
			float num4 = (255f - 100f * num3) / 255f;
			float num5 = (255f - 50f * num3) / 255f;
			int num6 = (int)((Main.screenPosition.X - value.X) / 16f - 1f);
			int num7 = (int)((Main.screenPosition.X + (float)Main.screenWidth + value.X) / 16f) + 2;
			int num8 = (int)((Main.screenPosition.Y - value.Y) / 16f - 1f);
			int num9 = (int)((Main.screenPosition.Y + (float)Main.screenHeight + value.Y) / 16f) + 5;
			if (num6 < 5)
			{
				num6 = 5;
			}
			if (num7 > Main.maxTilesX - 5)
			{
				num7 = Main.maxTilesX - 5;
			}
			if (num8 < 5)
			{
				num8 = 5;
			}
			if (num9 > Main.maxTilesY - 5)
			{
				num9 = Main.maxTilesY - 5;
			}
			for (int i = num8; i < num9 + 4; i++)
			{
				for (int j = num6 - 2; j < num7 + 2; j++)
				{
					if (Main.tile[j, i] == null)
					{

					}
					if (Main.tile[j, i].liquid > 0 && (!Main.tile[j, i].active || !Main.tileSolid[(int)Main.tile[j, i].type] || Main.tileSolidTop[(int)Main.tile[j, i].type]) && (Lighting.Brightness(j, i) > 0f || bg))
					{
						Color color = Lighting.GetColor(j, i);
						float num10 = (float)(256 - (int)Main.tile[j, i].liquid);
						num10 /= 32f;
						int num11 = 0;
						if (Main.tile[j, i].lava)
						{
							num11 = 1;
						}
						float num12 = 0.5f;
						if (bg)
						{
							num12 = 1f;
						}
						Vector2 value2 = new Vector2((float)(j * 16), (float)(i * 16 + (int)num10 * 2));
						Rectangle value3 = new Rectangle(0, 0, 16, 16 - (int)num10 * 2);
						if (Main.tile[j, i + 1].liquid < 245 && (!Main.tile[j, i + 1].active || !Main.tileSolid[(int)Main.tile[j, i + 1].type] || Main.tileSolidTop[(int)Main.tile[j, i + 1].type]))
						{
							float num13 = (float)(256 - (int)Main.tile[j, i + 1].liquid);
							num13 /= 32f;
							num12 = 0.5f * (8f - num10) / 4f;
							if ((double)num12 > 0.55)
							{
								num12 = 0.55f;
							}
							if ((double)num12 < 0.35)
							{
								num12 = 0.35f;
							}
							float num14 = num10 / 2f;
							if (Main.tile[j, i + 1].liquid < 200)
							{
								if (bg)
								{
									goto IL_CF9;
								}
								if (Main.tile[j, i - 1].liquid > 0 && Main.tile[j, i - 1].liquid > 0)
								{
									value3 = new Rectangle(0, 4, 16, 16);
									num12 = 0.5f;
								}
								else
								{
									if (Main.tile[j, i - 1].liquid > 0)
									{
										value2 = new Vector2((float)(j * 16), (float)(i * 16 + 4));
										value3 = new Rectangle(0, 4, 16, 12);
										num12 = 0.5f;
									}
									else
									{
										if (Main.tile[j, i + 1].liquid > 0)
										{
											value2 = new Vector2((float)(j * 16), (float)(i * 16 + (int)num10 * 2 + (int)num13 * 2));
											value3 = new Rectangle(0, 4, 16, 16 - (int)num10 * 2);
										}
										else
										{
											value2 = new Vector2((float)(j * 16 + (int)num14), (float)(i * 16 + (int)num14 * 2 + (int)num13 * 2));
											value3 = new Rectangle(0, 4, 16 - (int)num14 * 2, 16 - (int)num14 * 2);
										}
									}
								}
							}
							else
							{
								num12 = 0.5f;
								value3 = new Rectangle(0, 4, 16, 16 - (int)num10 * 2 + (int)num13 * 2);
							}
						}
						else
						{
							if (Main.tile[j, i - 1].liquid > 32)
							{
								value3 = new Rectangle(0, 4, value3.Width, value3.Height);
							}
							else
							{
								if (num10 < 1f && Main.tile[j, i - 1].active && Main.tileSolid[(int)Main.tile[j, i - 1].type] && !Main.tileSolidTop[(int)Main.tile[j, i - 1].type])
								{
									value2 = new Vector2((float)(j * 16), (float)(i * 16));
									value3 = new Rectangle(0, 4, 16, 16);
								}
								else
								{
									bool flag = true;
									int num15 = i + 1;
									while (num15 < i + 6 && (!Main.tile[j, num15].active || !Main.tileSolid[(int)Main.tile[j, num15].type] || Main.tileSolidTop[(int)Main.tile[j, num15].type]))
									{
										if (Main.tile[j, num15].liquid < 200)
										{
											flag = false;
											break;
										}
										num15++;
									}
									if (!flag)
									{
										num12 = 0.5f;
										value3 = new Rectangle(0, 4, 16, 16);
									}
									else
									{
										if (Main.tile[j, i - 1].liquid > 0)
										{
											value3 = new Rectangle(0, 2, value3.Width, value3.Height);
										}
									}
								}
							}
						}
						if (Main.tile[j, i].lava)
						{
							num12 *= 1.8f;
							if (num12 > 1f)
							{
								num12 = 1f;
							}
							if (base.IsActive && !Main.gamePaused && Dust.lavaBubbles < 200)
							{
								if (Main.tile[j, i].liquid > 200 && Main.rand.Next(700) == 0)
								{
									Dust.NewDust(new Vector2((float)(j * 16), (float)(i * 16)), 16, 16, 35, 0f, 0f, 0, default(Color), 1f);
								}
								if (value3.Y == 0 && Main.rand.Next(350) == 0)
								{
									int num16 = Dust.NewDust(new Vector2((float)(j * 16), (float)(i * 16) + num10 * 2f - 8f), 16, 8, 35, 0f, 0f, 50, default(Color), 1.5f);
									Dust expr_7BA = Main.dust[num16];
									expr_7BA.velocity *= 0.8f;
									Dust expr_7DC_cp_0 = Main.dust[num16];
									expr_7DC_cp_0.velocity.X = expr_7DC_cp_0.velocity.X * 2f;
									Dust expr_7FA_cp_0 = Main.dust[num16];
									expr_7FA_cp_0.velocity.Y = expr_7FA_cp_0.velocity.Y - (float)Main.rand.Next(1, 7) * 0.1f;
									if (Main.rand.Next(10) == 0)
									{
										Dust expr_834_cp_0 = Main.dust[num16];
										expr_834_cp_0.velocity.Y = expr_834_cp_0.velocity.Y * (float)Main.rand.Next(2, 5);
									}
									Main.dust[num16].noGravity = true;
								}
							}
						}
						float num17 = (float)color.R * num12;
						float num18 = (float)color.G * num12;
						float num19 = (float)color.B * num12;
						float num20 = (float)color.A * num12;
						if (num11 == 0)
						{
							num19 *= num4;
						}
						else
						{
							num17 *= num5;
						}
						color = new Color((int)((byte)num17), (int)((byte)num18), (int)((byte)num19), (int)((byte)num20));
						if (Lighting.lightMode < 2 && !bg)
						{
							Color color2 = color;
							if ((num11 == 0 && ((int)color2.R > num || (double)color2.G > (double)num * 1.1 || (double)color2.B > (double)num * 1.2)) || (int)color2.R > num2 || (double)color2.G > (double)num2 * 1.1 || (double)color2.B > (double)num2 * 1.2)
							{
								for (int k = 0; k < 4; k++)
								{
									int num21 = 0;
									int num22 = 0;
									int width = 8;
									int height = 8;
									Color color3 = color2;
									Color color4 = Lighting.GetColor(j, i);
									if (k == 0)
									{
										if (Lighting.Brighter(j, i - 1, j - 1, i))
										{
											if (!Main.tile[j - 1, i].active)
											{
												color4 = Lighting.GetColor(j - 1, i);
											}
											else
											{
												if (!Main.tile[j, i - 1].active)
												{
													color4 = Lighting.GetColor(j, i - 1);
												}
											}
										}
										if (value3.Height < 8)
										{
											height = value3.Height;
										}
									}
									if (k == 1)
									{
										if (Lighting.Brighter(j, i - 1, j + 1, i))
										{
											if (!Main.tile[j + 1, i].active)
											{
												color4 = Lighting.GetColor(j + 1, i);
											}
											else
											{
												if (!Main.tile[j, i - 1].active)
												{
													color4 = Lighting.GetColor(j, i - 1);
												}
											}
										}
										num21 = 8;
										if (value3.Height < 8)
										{
											height = value3.Height;
										}
									}
									if (k == 2)
									{
										if (Lighting.Brighter(j, i + 1, j - 1, i))
										{
											if (!Main.tile[j - 1, i].active)
											{
												color4 = Lighting.GetColor(j - 1, i);
											}
											else
											{
												if (!Main.tile[j, i + 1].active)
												{
													color4 = Lighting.GetColor(j, i + 1);
												}
											}
										}
										num22 = 8;
										height = 8 - (16 - value3.Height);
									}
									if (k == 3)
									{
										if (Lighting.Brighter(j, i + 1, j + 1, i))
										{
											if (!Main.tile[j + 1, i].active)
											{
												color4 = Lighting.GetColor(j + 1, i);
											}
											else
											{
												if (!Main.tile[j, i + 1].active)
												{
													color4 = Lighting.GetColor(j, i + 1);
												}
											}
										}
										num21 = 8;
										num22 = 8;
										height = 8 - (16 - value3.Height);
									}
									num17 = (float)color4.R * num12;
									num18 = (float)color4.G * num12;
									num19 = (float)color4.B * num12;
									num20 = (float)color4.A * num12;
									color4 = new Color((int)((byte)num17), (int)((byte)num18), (int)((byte)num19), (int)((byte)num20));
									color3.R = (byte)((color2.R + color4.R) / 2);
									color3.G = (byte)((color2.G + color4.G) / 2);
									color3.B = (byte)((color2.B + color4.B) / 2);
									color3.A = (byte)((color2.A + color4.A) / 2);
									this.spriteBatch.Draw(Main.liquidTexture[num11], value2 - Main.screenPosition + new Vector2((float)num21, (float)num22) + value, new Rectangle?(new Rectangle(value3.X + num21, value3.Y + num22, width, height)), color3, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
								}
							}
							else
							{
								this.spriteBatch.Draw(Main.liquidTexture[num11], value2 - Main.screenPosition + value, new Rectangle?(value3), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
						}
						else
						{
							this.spriteBatch.Draw(Main.liquidTexture[num11], value2 - Main.screenPosition + value, new Rectangle?(value3), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
						}
					}
					IL_CF9:;
				}
			}
			if (!bg)
			{
				Main.renderTimer[4] = (float)stopwatch.ElapsedMilliseconds;
			}
		}
		protected void DrawGore()
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.gore[i].active && Main.gore[i].type > 0)
				{
					Color alpha = Main.gore[i].GetAlpha(Lighting.GetColor((int)((double)Main.gore[i].position.X + (double)Main.goreTexture[Main.gore[i].type].Width * 0.5) / 16, (int)(((double)Main.gore[i].position.Y + (double)Main.goreTexture[Main.gore[i].type].Height * 0.5) / 16.0)));
					this.spriteBatch.Draw(Main.goreTexture[Main.gore[i].type], new Vector2(Main.gore[i].position.X - Main.screenPosition.X + (float)(Main.goreTexture[Main.gore[i].type].Width / 2), Main.gore[i].position.Y - Main.screenPosition.Y + (float)(Main.goreTexture[Main.gore[i].type].Height / 2)), new Rectangle?(new Rectangle(0, 0, Main.goreTexture[Main.gore[i].type].Width, Main.goreTexture[Main.gore[i].type].Height)), alpha, Main.gore[i].rotation, new Vector2((float)(Main.goreTexture[Main.gore[i].type].Width / 2), (float)(Main.goreTexture[Main.gore[i].type].Height / 2)), Main.gore[i].scale, SpriteEffects.None, 0f);
				}
			}
		}
		protected void DrawNPCs(bool behindTiles = false)
		{
			bool flag = false;
			Rectangle rectangle = new Rectangle((int)Main.screenPosition.X - 300, (int)Main.screenPosition.Y - 300, Main.screenWidth + 600, Main.screenHeight + 600);
			for (int i = 199; i >= 0; i--)
			{
				if (Main.npc[i].active && Main.npc[i].type > 0 && Main.npc[i].behindTiles == behindTiles)
				{
					if ((Main.npc[i].type == 125 || Main.npc[i].type == 126) && !flag)
					{
						flag = true;
						for (int j = 0; j < 200; j++)
						{
							if (Main.npc[j].active && i != j && (Main.npc[j].type == 125 || Main.npc[j].type == 126))
							{
								float num = Main.npc[j].position.X + (float)Main.npc[j].width * 0.5f;
								float num2 = Main.npc[j].position.Y + (float)Main.npc[j].height * 0.5f;
								Vector2 vector = new Vector2(Main.npc[i].position.X + (float)Main.npc[i].width * 0.5f, Main.npc[i].position.Y + (float)Main.npc[i].height * 0.5f);
								float num3 = num - vector.X;
								float num4 = num2 - vector.Y;
								float rotation = (float)Math.Atan2((double)num4, (double)num3) - 1.57f;
								bool flag2 = true;
								float num5 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
								if (num5 > 2000f)
								{
									flag2 = false;
								}
								while (flag2)
								{
									num5 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
									if (num5 < 40f)
									{
										flag2 = false;
									}
									else
									{
										num5 = (float)Main.chain12Texture.Height / num5;
										num3 *= num5;
										num4 *= num5;
										vector.X += num3;
										vector.Y += num4;
										num3 = num - vector.X;
										num4 = num2 - vector.Y;
										Color color = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16f));
										this.spriteBatch.Draw(Main.chain12Texture, new Vector2(vector.X - Main.screenPosition.X, vector.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain12Texture.Width, Main.chain12Texture.Height)), color, rotation, new Vector2((float)Main.chain12Texture.Width * 0.5f, (float)Main.chain12Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
									}
								}
							}
						}
					}
					if (rectangle.Intersects(new Rectangle((int)Main.npc[i].position.X, (int)Main.npc[i].position.Y, Main.npc[i].width, Main.npc[i].height)))
					{
						if (Main.npc[i].type == 101)
						{
							bool flag3 = true;
							Vector2 vector2 = new Vector2(Main.npc[i].position.X + (float)(Main.npc[i].width / 2), Main.npc[i].position.Y + (float)(Main.npc[i].height / 2));
							float num6 = Main.npc[i].ai[0] * 16f + 8f - vector2.X;
							float num7 = Main.npc[i].ai[1] * 16f + 8f - vector2.Y;
							float rotation2 = (float)Math.Atan2((double)num7, (double)num6) - 1.57f;
							bool flag4 = true;
							while (flag4)
							{
								float num8 = 0.75f;
								int height = 28;
								float num9 = (float)Math.Sqrt((double)(num6 * num6 + num7 * num7));
								if (num9 < 28f * num8)
								{
									height = (int)num9 - 40 + 28;
									flag4 = false;
								}
								num9 = 20f * num8 / num9;
								num6 *= num9;
								num7 *= num9;
								vector2.X += num6;
								vector2.Y += num7;
								num6 = Main.npc[i].ai[0] * 16f + 8f - vector2.X;
								num7 = Main.npc[i].ai[1] * 16f + 8f - vector2.Y;
								Color color2 = Lighting.GetColor((int)vector2.X / 16, (int)(vector2.Y / 16f));
								if (!flag3)
								{
									flag3 = true;
									this.spriteBatch.Draw(Main.chain10Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain10Texture.Width, height)), color2, rotation2, new Vector2((float)Main.chain10Texture.Width * 0.5f, (float)Main.chain10Texture.Height * 0.5f), num8, SpriteEffects.None, 0f);
								}
								else
								{
									flag3 = false;
									this.spriteBatch.Draw(Main.chain11Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain10Texture.Width, height)), color2, rotation2, new Vector2((float)Main.chain10Texture.Width * 0.5f, (float)Main.chain10Texture.Height * 0.5f), num8, SpriteEffects.None, 0f);
								}
							}
						}
						else
						{
							if (Main.npc[i].aiStyle == 13)
							{
								Vector2 vector3 = new Vector2(Main.npc[i].position.X + (float)(Main.npc[i].width / 2), Main.npc[i].position.Y + (float)(Main.npc[i].height / 2));
								float num10 = Main.npc[i].ai[0] * 16f + 8f - vector3.X;
								float num11 = Main.npc[i].ai[1] * 16f + 8f - vector3.Y;
								float rotation3 = (float)Math.Atan2((double)num11, (double)num10) - 1.57f;
								bool flag5 = true;
								while (flag5)
								{
									int height2 = 28;
									float num12 = (float)Math.Sqrt((double)(num10 * num10 + num11 * num11));
									if (num12 < 40f)
									{
										height2 = (int)num12 - 40 + 28;
										flag5 = false;
									}
									num12 = 28f / num12;
									num10 *= num12;
									num11 *= num12;
									vector3.X += num10;
									vector3.Y += num11;
									num10 = Main.npc[i].ai[0] * 16f + 8f - vector3.X;
									num11 = Main.npc[i].ai[1] * 16f + 8f - vector3.Y;
									Color color3 = Lighting.GetColor((int)vector3.X / 16, (int)(vector3.Y / 16f));
									if (Main.npc[i].type == 56)
									{
										this.spriteBatch.Draw(Main.chain5Texture, new Vector2(vector3.X - Main.screenPosition.X, vector3.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain4Texture.Width, height2)), color3, rotation3, new Vector2((float)Main.chain4Texture.Width * 0.5f, (float)Main.chain4Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
									}
									else
									{
										this.spriteBatch.Draw(Main.chain4Texture, new Vector2(vector3.X - Main.screenPosition.X, vector3.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain4Texture.Width, height2)), color3, rotation3, new Vector2((float)Main.chain4Texture.Width * 0.5f, (float)Main.chain4Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
									}
								}
							}
						}
						if (Main.npc[i].type == 36)
						{
							Vector2 vector4 = new Vector2(Main.npc[i].position.X + (float)Main.npc[i].width * 0.5f - 5f * Main.npc[i].ai[0], Main.npc[i].position.Y + 20f);
							for (int k = 0; k < 2; k++)
							{
								float num13 = Main.npc[(int)Main.npc[i].ai[1]].position.X + (float)(Main.npc[(int)Main.npc[i].ai[1]].width / 2) - vector4.X;
								float num14 = Main.npc[(int)Main.npc[i].ai[1]].position.Y + (float)(Main.npc[(int)Main.npc[i].ai[1]].height / 2) - vector4.Y;
								float num15 = 0f;
								if (k == 0)
								{
									num13 -= 200f * Main.npc[i].ai[0];
									num14 += 130f;
									num15 = (float)Math.Sqrt((double)(num13 * num13 + num14 * num14));
									num15 = 92f / num15;
									vector4.X += num13 * num15;
									vector4.Y += num14 * num15;
								}
								else
								{
									num13 -= 50f * Main.npc[i].ai[0];
									num14 += 80f;
									num15 = (float)Math.Sqrt((double)(num13 * num13 + num14 * num14));
									num15 = 60f / num15;
									vector4.X += num13 * num15;
									vector4.Y += num14 * num15;
								}
								float rotation4 = (float)Math.Atan2((double)num14, (double)num13) - 1.57f;
								Color color4 = Lighting.GetColor((int)vector4.X / 16, (int)(vector4.Y / 16f));
								this.spriteBatch.Draw(Main.boneArmTexture, new Vector2(vector4.X - Main.screenPosition.X, vector4.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color4, rotation4, new Vector2((float)Main.boneArmTexture.Width * 0.5f, (float)Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
								if (k == 0)
								{
									vector4.X += num13 * num15 / 2f;
									vector4.Y += num14 * num15 / 2f;
								}
								else
								{
									if (base.IsActive)
									{
										vector4.X += num13 * num15 - 16f;
										vector4.Y += num14 * num15 - 6f;
										Vector2 arg_C3E_0 = new Vector2(vector4.X, vector4.Y);
										int arg_C3E_1 = 30;
										int arg_C3E_2 = 10;
										int arg_C3E_3 = 5;
										float arg_C3E_4 = num13 * 0.02f;
										float arg_C3E_5 = num14 * 0.02f;
										int arg_C3E_6 = 0;
										Color color5 = default(Color);
										int num16 = Dust.NewDust(arg_C3E_0, arg_C3E_1, arg_C3E_2, arg_C3E_3, arg_C3E_4, arg_C3E_5, arg_C3E_6, color5, 2f);
										Main.dust[num16].noGravity = true;
									}
								}
							}
						}
						if (Main.npc[i].aiStyle >= 33 && Main.npc[i].aiStyle <= 36)
						{
							Vector2 vector5 = new Vector2(Main.npc[i].position.X + (float)Main.npc[i].width * 0.5f - 5f * Main.npc[i].ai[0], Main.npc[i].position.Y + 20f);
							for (int l = 0; l < 2; l++)
							{
								float num17 = Main.npc[(int)Main.npc[i].ai[1]].position.X + (float)(Main.npc[(int)Main.npc[i].ai[1]].width / 2) - vector5.X;
								float num18 = Main.npc[(int)Main.npc[i].ai[1]].position.Y + (float)(Main.npc[(int)Main.npc[i].ai[1]].height / 2) - vector5.Y;
								float num19 = 0f;
								if (l == 0)
								{
									num17 -= 200f * Main.npc[i].ai[0];
									num18 += 130f;
									num19 = (float)Math.Sqrt((double)(num17 * num17 + num18 * num18));
									num19 = 92f / num19;
									vector5.X += num17 * num19;
									vector5.Y += num18 * num19;
								}
								else
								{
									num17 -= 50f * Main.npc[i].ai[0];
									num18 += 80f;
									num19 = (float)Math.Sqrt((double)(num17 * num17 + num18 * num18));
									num19 = 60f / num19;
									vector5.X += num17 * num19;
									vector5.Y += num18 * num19;
								}
								float rotation5 = (float)Math.Atan2((double)num18, (double)num17) - 1.57f;
								Color color6 = Lighting.GetColor((int)vector5.X / 16, (int)(vector5.Y / 16f));
								this.spriteBatch.Draw(Main.boneArm2Texture, new Vector2(vector5.X - Main.screenPosition.X, vector5.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.boneArmTexture.Width, Main.boneArmTexture.Height)), color6, rotation5, new Vector2((float)Main.boneArmTexture.Width * 0.5f, (float)Main.boneArmTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
								if (l == 0)
								{
									vector5.X += num17 * num19 / 2f;
									vector5.Y += num18 * num19 / 2f;
								}
								else
								{
									if (base.IsActive)
									{
										vector5.X += num17 * num19 - 16f;
										vector5.Y += num18 * num19 - 6f;
										Vector2 arg_FC0_0 = new Vector2(vector5.X, vector5.Y);
										int arg_FC0_1 = 30;
										int arg_FC0_2 = 10;
										int arg_FC0_3 = 6;
										float arg_FC0_4 = num17 * 0.02f;
										float arg_FC0_5 = num18 * 0.02f;
										int arg_FC0_6 = 0;
										Color color5 = default(Color);
										int num20 = Dust.NewDust(arg_FC0_0, arg_FC0_1, arg_FC0_2, arg_FC0_3, arg_FC0_4, arg_FC0_5, arg_FC0_6, color5, 2.5f);
										Main.dust[num20].noGravity = true;
									}
								}
							}
						}
						if (Main.npc[i].aiStyle == 20)
						{
							Vector2 vector6 = new Vector2(Main.npc[i].position.X + (float)(Main.npc[i].width / 2), Main.npc[i].position.Y + (float)(Main.npc[i].height / 2));
							float num21 = Main.npc[i].ai[1] - vector6.X;
							float num22 = Main.npc[i].ai[2] - vector6.Y;
							float num23 = (float)Math.Atan2((double)num22, (double)num21) - 1.57f;
							Main.npc[i].rotation = num23;
							bool flag6 = true;
							while (flag6)
							{
								int height3 = 12;
								float num24 = (float)Math.Sqrt((double)(num21 * num21 + num22 * num22));
								if (num24 < 20f)
								{
									height3 = (int)num24 - 20 + 12;
									flag6 = false;
								}
								num24 = 12f / num24;
								num21 *= num24;
								num22 *= num24;
								vector6.X += num21;
								vector6.Y += num22;
								num21 = Main.npc[i].ai[1] - vector6.X;
								num22 = Main.npc[i].ai[2] - vector6.Y;
								Color color7 = Lighting.GetColor((int)vector6.X / 16, (int)(vector6.Y / 16f));
								this.spriteBatch.Draw(Main.chainTexture, new Vector2(vector6.X - Main.screenPosition.X, vector6.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chainTexture.Width, height3)), color7, num23, new Vector2((float)Main.chainTexture.Width * 0.5f, (float)Main.chainTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
							}
							this.spriteBatch.Draw(Main.spikeBaseTexture, new Vector2(Main.npc[i].ai[1] - Main.screenPosition.X, Main.npc[i].ai[2] - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.spikeBaseTexture.Width, Main.spikeBaseTexture.Height)), Lighting.GetColor((int)Main.npc[i].ai[1] / 16, (int)(Main.npc[i].ai[2] / 16f)), num23 - 0.75f, new Vector2((float)Main.spikeBaseTexture.Width * 0.5f, (float)Main.spikeBaseTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
						}
						Color color8 = Lighting.GetColor((int)((double)Main.npc[i].position.X + (double)Main.npc[i].width * 0.5) / 16, (int)(((double)Main.npc[i].position.Y + (double)Main.npc[i].height * 0.5) / 16.0));
						if (behindTiles && Main.npc[i].type != 113 && Main.npc[i].type != 114)
						{
							int num25 = (int)((Main.npc[i].position.X - 8f) / 16f);
							int num26 = (int)((Main.npc[i].position.X + (float)Main.npc[i].width + 8f) / 16f);
							int num27 = (int)((Main.npc[i].position.Y - 8f) / 16f);
							int num28 = (int)((Main.npc[i].position.Y + (float)Main.npc[i].height + 8f) / 16f);
							for (int m = num25; m <= num26; m++)
							{
								for (int n = num27; n <= num28; n++)
								{
									if (Lighting.Brightness(m, n) == 0f)
									{
										color8 = Color.Black;
									}
								}
							}
						}
						float num29 = 1f;
						float g = 1f;
						float num30 = 1f;
						float a = 1f;
						if (Main.npc[i].poisoned)
						{
							if (Main.rand.Next(30) == 0)
							{
								Vector2 arg_1494_0 = Main.npc[i].position;
								int arg_1494_1 = Main.npc[i].width;
								int arg_1494_2 = Main.npc[i].height;
								int arg_1494_3 = 46;
								float arg_1494_4 = 0f;
								float arg_1494_5 = 0f;
								int arg_1494_6 = 120;
								Color color5 = default(Color);
								int num31 = Dust.NewDust(arg_1494_0, arg_1494_1, arg_1494_2, arg_1494_3, arg_1494_4, arg_1494_5, arg_1494_6, color5, 0.2f);
								Main.dust[num31].noGravity = true;
								Main.dust[num31].fadeIn = 1.9f;
							}
							num29 *= 0.65f;
							num30 *= 0.75f;
							color8 = Main.buffColor(color8, num29, g, num30, a);
						}
						if (Main.npc[i].onFire)
						{
							if (Main.rand.Next(4) < 3)
							{
								Vector2 arg_1591_0 = new Vector2(Main.npc[i].position.X - 2f, Main.npc[i].position.Y - 2f);
								int arg_1591_1 = Main.npc[i].width + 4;
								int arg_1591_2 = Main.npc[i].height + 4;
								int arg_1591_3 = 6;
								float arg_1591_4 = Main.npc[i].velocity.X * 0.4f;
								float arg_1591_5 = Main.npc[i].velocity.Y * 0.4f;
								int arg_1591_6 = 100;
								Color color5 = default(Color);
								int num32 = Dust.NewDust(arg_1591_0, arg_1591_1, arg_1591_2, arg_1591_3, arg_1591_4, arg_1591_5, arg_1591_6, color5, 3.5f);
								Main.dust[num32].noGravity = true;
								Dust expr_15AE = Main.dust[num32];
								expr_15AE.velocity *= 1.8f;
								Dust expr_15D0_cp_0 = Main.dust[num32];
								expr_15D0_cp_0.velocity.Y = expr_15D0_cp_0.velocity.Y - 0.5f;
								if (Main.rand.Next(4) == 0)
								{
									Main.dust[num32].noGravity = false;
									Main.dust[num32].scale *= 0.5f;
								}
							}
							Lighting.addLight((int)(Main.npc[i].position.X / 16f), (int)(Main.npc[i].position.Y / 16f + 1f), 1f, 0.3f, 0.1f);
						}
						if (Main.npc[i].onFire2)
						{
							if (Main.rand.Next(4) < 3)
							{
								Vector2 arg_1711_0 = new Vector2(Main.npc[i].position.X - 2f, Main.npc[i].position.Y - 2f);
								int arg_1711_1 = Main.npc[i].width + 4;
								int arg_1711_2 = Main.npc[i].height + 4;
								int arg_1711_3 = 75;
								float arg_1711_4 = Main.npc[i].velocity.X * 0.4f;
								float arg_1711_5 = Main.npc[i].velocity.Y * 0.4f;
								int arg_1711_6 = 100;
								Color color5 = default(Color);
								int num33 = Dust.NewDust(arg_1711_0, arg_1711_1, arg_1711_2, arg_1711_3, arg_1711_4, arg_1711_5, arg_1711_6, color5, 3.5f);
								Main.dust[num33].noGravity = true;
								Dust expr_172E = Main.dust[num33];
								expr_172E.velocity *= 1.8f;
								Dust expr_1750_cp_0 = Main.dust[num33];
								expr_1750_cp_0.velocity.Y = expr_1750_cp_0.velocity.Y - 0.5f;
								if (Main.rand.Next(4) == 0)
								{
									Main.dust[num33].noGravity = false;
									Main.dust[num33].scale *= 0.5f;
								}
							}
							Lighting.addLight((int)(Main.npc[i].position.X / 16f), (int)(Main.npc[i].position.Y / 16f + 1f), 1f, 0.3f, 0.1f);
						}
						if (Main.player[Main.myPlayer].detectCreature && Main.npc[i].lifeMax > 1)
						{
							if (color8.R < 150)
							{
								color8.A = Main.mouseTextColor;
							}
							if (color8.R < 50)
							{
								color8.R = 50;
							}
							if (color8.G < 200)
							{
								color8.G = 200;
							}
							if (color8.B < 100)
							{
								color8.B = 100;
							}
							if (!Main.gamePaused && base.IsActive && Main.rand.Next(50) == 0)
							{
								Vector2 arg_18E7_0 = new Vector2(Main.npc[i].position.X, Main.npc[i].position.Y);
								int arg_18E7_1 = Main.npc[i].width;
								int arg_18E7_2 = Main.npc[i].height;
								int arg_18E7_3 = 15;
								float arg_18E7_4 = 0f;
								float arg_18E7_5 = 0f;
								int arg_18E7_6 = 150;
								Color color5 = default(Color);
								int num34 = Dust.NewDust(arg_18E7_0, arg_18E7_1, arg_18E7_2, arg_18E7_3, arg_18E7_4, arg_18E7_5, arg_18E7_6, color5, 0.8f);
								Dust expr_18F6 = Main.dust[num34];
								expr_18F6.velocity *= 0.1f;
								Main.dust[num34].noLight = true;
							}
						}
						if (Main.npc[i].type == 50)
						{
							Vector2 vector7 = default(Vector2);
							float num35 = 0f;
							vector7.Y -= Main.npc[i].velocity.Y;
							vector7.X -= Main.npc[i].velocity.X * 2f;
							num35 += Main.npc[i].velocity.X * 0.05f;
							if (Main.npc[i].frame.Y == 120)
							{
								vector7.Y += 2f;
							}
							if (Main.npc[i].frame.Y == 360)
							{
								vector7.Y -= 2f;
							}
							if (Main.npc[i].frame.Y == 480)
							{
								vector7.Y -= 6f;
							}
							this.spriteBatch.Draw(Main.ninjaTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) + vector7.X, Main.npc[i].position.Y - Main.screenPosition.Y + (float)(Main.npc[i].height / 2) + vector7.Y), new Rectangle?(new Rectangle(0, 0, Main.ninjaTexture.Width, Main.ninjaTexture.Height)), color8, num35, new Vector2((float)(Main.ninjaTexture.Width / 2), (float)(Main.ninjaTexture.Height / 2)), 1f, SpriteEffects.None, 0f);
						}
						if (Main.npc[i].type == 71)
						{
							Vector2 vector8 = default(Vector2);
							float num36 = 0f;
							vector8.Y -= Main.npc[i].velocity.Y * 0.3f;
							vector8.X -= Main.npc[i].velocity.X * 0.6f;
							num36 += Main.npc[i].velocity.X * 0.09f;
							if (Main.npc[i].frame.Y == 120)
							{
								vector8.Y += 2f;
							}
							if (Main.npc[i].frame.Y == 360)
							{
								vector8.Y -= 2f;
							}
							if (Main.npc[i].frame.Y == 480)
							{
								vector8.Y -= 6f;
							}
							this.spriteBatch.Draw(Main.itemTexture[327], new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) + vector8.X, Main.npc[i].position.Y - Main.screenPosition.Y + (float)(Main.npc[i].height / 2) + vector8.Y), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[327].Width, Main.itemTexture[327].Height)), color8, num36, new Vector2((float)(Main.itemTexture[327].Width / 2), (float)(Main.itemTexture[327].Height / 2)), 1f, SpriteEffects.None, 0f);
						}
						if (Main.npc[i].type == 69)
						{
							this.spriteBatch.Draw(Main.antLionTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2), Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height + 14f), new Rectangle?(new Rectangle(0, 0, Main.antLionTexture.Width, Main.antLionTexture.Height)), color8, -Main.npc[i].rotation * 0.3f, new Vector2((float)(Main.antLionTexture.Width / 2), (float)(Main.antLionTexture.Height / 2)), 1f, SpriteEffects.None, 0f);
						}
						float num37 = 0f;
						float num38 = 0f;
						Vector2 origin = new Vector2((float)(Main.npcTexture[Main.npc[i].type].Width / 2), (float)(Main.npcTexture[Main.npc[i].type].Height / Main.npcFrameCount[Main.npc[i].type] / 2));
						if (Main.npc[i].type == 108 || Main.npc[i].type == 124)
						{
							num37 = 2f;
						}
						if (Main.npc[i].type == 4)
						{
							origin = new Vector2(55f, 107f);
						}
						else
						{
							if (Main.npc[i].type == 125)
							{
								origin = new Vector2(55f, 107f);
								num38 = 30f;
							}
							else
							{
								if (Main.npc[i].type == 126)
								{
									origin = new Vector2(55f, 107f);
									num38 = 30f;
								}
								else
								{
									if (Main.npc[i].type == 6)
									{
										num38 = 26f;
									}
									else
									{
										if (Main.npc[i].type == 94)
										{
											num38 = 14f;
										}
										else
										{
											if (Main.npc[i].type == 7 || Main.npc[i].type == 8 || Main.npc[i].type == 9)
											{
												num38 = 13f;
											}
											else
											{
												if (Main.npc[i].type == 98 || Main.npc[i].type == 99 || Main.npc[i].type == 100)
												{
													num38 = 13f;
												}
												else
												{
													if (Main.npc[i].type == 95 || Main.npc[i].type == 96 || Main.npc[i].type == 97)
													{
														num38 = 13f;
													}
													else
													{
														if (Main.npc[i].type == 10 || Main.npc[i].type == 11 || Main.npc[i].type == 12)
														{
															num38 = 8f;
														}
														else
														{
															if (Main.npc[i].type == 13 || Main.npc[i].type == 14 || Main.npc[i].type == 15)
															{
																num38 = 26f;
															}
															else
															{
																if (Main.npc[i].type == 48)
																{
																	num38 = 32f;
																}
																else
																{
																	if (Main.npc[i].type == 49 || Main.npc[i].type == 51)
																	{
																		num38 = 4f;
																	}
																	else
																	{
																		if (Main.npc[i].type == 60)
																		{
																			num38 = 10f;
																		}
																		else
																		{
																			if (Main.npc[i].type == 62 || Main.npc[i].type == 66)
																			{
																				num38 = 14f;
																			}
																			else
																			{
																				if (Main.npc[i].type == 63 || Main.npc[i].type == 64 || Main.npc[i].type == 103)
																				{
																					num38 = 4f;
																					origin.Y += 4f;
																				}
																				else
																				{
																					if (Main.npc[i].type == 65)
																					{
																						num38 = 14f;
																					}
																					else
																					{
																						if (Main.npc[i].type == 69)
																						{
																							num38 = 4f;
																							origin.Y += 8f;
																						}
																						else
																						{
																							if (Main.npc[i].type == 70)
																							{
																								num38 = -4f;
																							}
																							else
																							{
																								if (Main.npc[i].type == 72)
																								{
																									num38 = -2f;
																								}
																								else
																								{
																									if (Main.npc[i].type == 83 || Main.npc[i].type == 84)
																									{
																										num38 = 20f;
																									}
																									else
																									{
																										if (Main.npc[i].type == 39 || Main.npc[i].type == 40 || Main.npc[i].type == 41)
																										{
																											num38 = 26f;
																										}
																										else
																										{
																											if (Main.npc[i].type >= 87 && Main.npc[i].type <= 92)
																											{
																												num38 = 56f;
																											}
																											else
																											{
																												if (Main.npc[i].type >= 134 && Main.npc[i].type <= 136)
																												{
																													num38 = 30f;
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
						num38 *= Main.npc[i].scale;
						if (Main.npc[i].aiStyle == 10 || Main.npc[i].type == 72)
						{
							color8 = Color.White;
						}
						SpriteEffects effects = SpriteEffects.None;
						if (Main.npc[i].spriteDirection == 1)
						{
							effects = SpriteEffects.FlipHorizontally;
						}
						if (Main.npc[i].type == 83 || Main.npc[i].type == 84)
						{
							this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Rectangle?(Main.npc[i].frame), Color.White, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
						}
						else
						{
							if (Main.npc[i].type >= 87 && Main.npc[i].type <= 92)
							{
								Color alpha = Main.npc[i].GetAlpha(color8);
								byte b = (byte)((Main.tileColor.R + Main.tileColor.G + Main.tileColor.B) / 3);
								if (alpha.R < b)
								{
									alpha.R = b;
								}
								if (alpha.G < b)
								{
									alpha.G = b;
								}
								if (alpha.B < b)
								{
									alpha.B = b;
								}
								this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Rectangle?(Main.npc[i].frame), alpha, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
							}
							else
							{
								if (Main.npc[i].type == 94)
								{
									for (int num39 = 1; num39 < 6; num39 += 2)
									{
										Vector2 arg_260D_0 = Main.npc[i].oldPos[num39];
										Color alpha2 = Main.npc[i].GetAlpha(color8);
										alpha2.R = (byte)((int)alpha2.R * (10 - num39) / 15);
										alpha2.G = (byte)((int)alpha2.G * (10 - num39) / 15);
										alpha2.B = (byte)((int)alpha2.B * (10 - num39) / 15);
										alpha2.A = (byte)((int)alpha2.A * (10 - num39) / 15);
										this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].oldPos[num39].X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].oldPos[num39].Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38), new Rectangle?(Main.npc[i].frame), alpha2, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
									}
								}
								if (Main.npc[i].type == 125 || Main.npc[i].type == 126 || Main.npc[i].type == 127 || Main.npc[i].type == 128 || Main.npc[i].type == 129 || Main.npc[i].type == 130 || Main.npc[i].type == 131 || Main.npc[i].type == 139 || Main.npc[i].type == 140)
								{
									for (int num40 = 9; num40 >= 0; num40 -= 2)
									{
										Vector2 arg_28AB_0 = Main.npc[i].oldPos[num40];
										Color alpha3 = Main.npc[i].GetAlpha(color8);
										alpha3.R = (byte)((int)alpha3.R * (10 - num40) / 20);
										alpha3.G = (byte)((int)alpha3.G * (10 - num40) / 20);
										alpha3.B = (byte)((int)alpha3.B * (10 - num40) / 20);
										alpha3.A = (byte)((int)alpha3.A * (10 - num40) / 20);
										this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].oldPos[num40].X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].oldPos[num40].Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38), new Rectangle?(Main.npc[i].frame), alpha3, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
									}
								}
								this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Rectangle?(Main.npc[i].frame), Main.npc[i].GetAlpha(color8), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
								Color arg_2BE7_0 = Main.npc[i].color;
								Color color5 = default(Color);
								if (arg_2BE7_0 != color5)
								{
									this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Rectangle?(Main.npc[i].frame), Main.npc[i].GetColor(color8), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
								}
								if (Main.npc[i].confused)
								{
									this.spriteBatch.Draw(Main.confuseTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37 - (float)Main.confuseTexture.Height - 20f), new Rectangle?(new Rectangle(0, 0, Main.confuseTexture.Width, Main.confuseTexture.Height)), new Color(250, 250, 250, 70), Main.npc[i].velocity.X * -0.05f, new Vector2((float)(Main.confuseTexture.Width / 2), (float)(Main.confuseTexture.Height / 2)), Main.essScale + 0.2f, SpriteEffects.None, 0f);
								}
								if (Main.npc[i].type >= 134 && Main.npc[i].type <= 136 && color8 != Color.Black)
								{
									this.spriteBatch.Draw(Main.destTexture[Main.npc[i].type - 134], new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Rectangle?(Main.npc[i].frame), new Color(255, 255, 255, 0), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
								}
								if (Main.npc[i].type == 125)
								{
									this.spriteBatch.Draw(Main.EyeLaserTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Rectangle?(Main.npc[i].frame), new Color(255, 255, 255, 0), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
								}
								if (Main.npc[i].type == 139)
								{
									this.spriteBatch.Draw(Main.probeTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Rectangle?(Main.npc[i].frame), new Color(255, 255, 255, 0), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
								}
								if (Main.npc[i].type == 127)
								{
									this.spriteBatch.Draw(Main.BoneEyesTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Rectangle?(Main.npc[i].frame), new Color(200, 200, 200, 0), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
								}
								if (Main.npc[i].type == 131)
								{
									this.spriteBatch.Draw(Main.BoneLaserTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38 + num37), new Rectangle?(Main.npc[i].frame), new Color(200, 200, 200, 0), Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
								}
								if (Main.npc[i].type == 120)
								{
									for (int num41 = 1; num41 < Main.npc[i].oldPos.Length; num41++)
									{
										Vector2 arg_3647_0 = Main.npc[i].oldPos[num41];
										Color color9 = default(Color);
										color9.R = (byte)(150 * (10 - num41) / 15);
										color9.G = (byte)(100 * (10 - num41) / 15);
										color9.B = (byte)(150 * (10 - num41) / 15);
										color9.A = (byte)(50 * (10 - num41) / 15);
										this.spriteBatch.Draw(Main.chaosTexture, new Vector2(Main.npc[i].oldPos[num41].X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].oldPos[num41].Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38), new Rectangle?(Main.npc[i].frame), color9, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
									}
								}
								else
								{
									if (Main.npc[i].type == 137 || Main.npc[i].type == 138)
									{
										for (int num42 = 1; num42 < Main.npc[i].oldPos.Length; num42++)
										{
											Vector2 arg_3851_0 = Main.npc[i].oldPos[num42];
											Color color10 = default(Color);
											color10.R = (byte)(150 * (10 - num42) / 15);
											color10.G = (byte)(100 * (10 - num42) / 15);
											color10.B = (byte)(150 * (10 - num42) / 15);
											color10.A = (byte)(50 * (10 - num42) / 15);
											this.spriteBatch.Draw(Main.npcTexture[Main.npc[i].type], new Vector2(Main.npc[i].oldPos[num42].X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].oldPos[num42].Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38), new Rectangle?(Main.npc[i].frame), color10, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
										}
									}
									else
									{
										if (Main.npc[i].type == 82)
										{
											this.spriteBatch.Draw(Main.wraithEyeTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38), new Rectangle?(Main.npc[i].frame), Color.White, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
											for (int num43 = 1; num43 < 10; num43++)
											{
												Color color11 = new Color(110 - num43 * 10, 110 - num43 * 10, 110 - num43 * 10, 110 - num43 * 10);
												this.spriteBatch.Draw(Main.wraithEyeTexture, new Vector2(Main.npc[i].position.X - Main.screenPosition.X + (float)(Main.npc[i].width / 2) - (float)Main.npcTexture[Main.npc[i].type].Width * Main.npc[i].scale / 2f + origin.X * Main.npc[i].scale, Main.npc[i].position.Y - Main.screenPosition.Y + (float)Main.npc[i].height - (float)Main.npcTexture[Main.npc[i].type].Height * Main.npc[i].scale / (float)Main.npcFrameCount[Main.npc[i].type] + 4f + origin.Y * Main.npc[i].scale + num38) - Main.npc[i].velocity * (float)num43 * 0.5f, new Rectangle?(Main.npc[i].frame), color11, Main.npc[i].rotation, origin, Main.npc[i].scale, effects, 0f);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		protected void DrawProj(int i)
		{
			if (Main.projectile[i].type == 32)
			{
				Vector2 vector = new Vector2(Main.projectile[i].position.X + (float)Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float)Main.projectile[i].height * 0.5f);
				float num = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector.X;
				float num2 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector.Y;
				float rotation = (float)Math.Atan2((double)num2, (double)num) - 1.57f;
				bool flag = true;
				if (num == 0f && num2 == 0f)
				{
					flag = false;
				}
				else
				{
					float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
					num3 = 8f / num3;
					num *= num3;
					num2 *= num3;
					vector.X -= num;
					vector.Y -= num2;
					num = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector.X;
					num2 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector.Y;
				}
				while (flag)
				{
					float num4 = (float)Math.Sqrt((double)(num * num + num2 * num2));
					if (num4 < 28f)
					{
						flag = false;
					}
					else
					{
						num4 = 28f / num4;
						num *= num4;
						num2 *= num4;
						vector.X += num;
						vector.Y += num2;
						num = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector.X;
						num2 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector.Y;
						Color color = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16f));
						this.spriteBatch.Draw(Main.chain5Texture, new Vector2(vector.X - Main.screenPosition.X, vector.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain5Texture.Width, Main.chain5Texture.Height)), color, rotation, new Vector2((float)Main.chain5Texture.Width * 0.5f, (float)Main.chain5Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
					}
				}
			}
			else
			{
				if (Main.projectile[i].type == 73)
				{
					Vector2 vector2 = new Vector2(Main.projectile[i].position.X + (float)Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float)Main.projectile[i].height * 0.5f);
					float num5 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
					float num6 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
					float rotation2 = (float)Math.Atan2((double)num6, (double)num5) - 1.57f;
					bool flag2 = true;
					while (flag2)
					{
						float num7 = (float)Math.Sqrt((double)(num5 * num5 + num6 * num6));
						if (num7 < 25f)
						{
							flag2 = false;
						}
						else
						{
							num7 = 12f / num7;
							num5 *= num7;
							num6 *= num7;
							vector2.X += num5;
							vector2.Y += num6;
							num5 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector2.X;
							num6 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector2.Y;
							Color color2 = Lighting.GetColor((int)vector2.X / 16, (int)(vector2.Y / 16f));
							this.spriteBatch.Draw(Main.chain8Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain8Texture.Width, Main.chain8Texture.Height)), color2, rotation2, new Vector2((float)Main.chain8Texture.Width * 0.5f, (float)Main.chain8Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
						}
					}
				}
				else
				{
					if (Main.projectile[i].type == 74)
					{
						Vector2 vector3 = new Vector2(Main.projectile[i].position.X + (float)Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float)Main.projectile[i].height * 0.5f);
						float num8 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector3.X;
						float num9 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector3.Y;
						float rotation3 = (float)Math.Atan2((double)num9, (double)num8) - 1.57f;
						bool flag3 = true;
						while (flag3)
						{
							float num10 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
							if (num10 < 25f)
							{
								flag3 = false;
							}
							else
							{
								num10 = 12f / num10;
								num8 *= num10;
								num9 *= num10;
								vector3.X += num8;
								vector3.Y += num9;
								num8 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector3.X;
								num9 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector3.Y;
								Color color3 = Lighting.GetColor((int)vector3.X / 16, (int)(vector3.Y / 16f));
								this.spriteBatch.Draw(Main.chain9Texture, new Vector2(vector3.X - Main.screenPosition.X, vector3.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain8Texture.Width, Main.chain8Texture.Height)), color3, rotation3, new Vector2((float)Main.chain8Texture.Width * 0.5f, (float)Main.chain8Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
							}
						}
					}
					else
					{
						if (Main.projectile[i].aiStyle == 7)
						{
							Vector2 vector4 = new Vector2(Main.projectile[i].position.X + (float)Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float)Main.projectile[i].height * 0.5f);
							float num11 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector4.X;
							float num12 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector4.Y;
							float rotation4 = (float)Math.Atan2((double)num12, (double)num11) - 1.57f;
							bool flag4 = true;
							while (flag4)
							{
								float num13 = (float)Math.Sqrt((double)(num11 * num11 + num12 * num12));
								if (num13 < 25f)
								{
									flag4 = false;
								}
								else
								{
									num13 = 12f / num13;
									num11 *= num13;
									num12 *= num13;
									vector4.X += num11;
									vector4.Y += num12;
									num11 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector4.X;
									num12 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector4.Y;
									Color color4 = Lighting.GetColor((int)vector4.X / 16, (int)(vector4.Y / 16f));
									this.spriteBatch.Draw(Main.chainTexture, new Vector2(vector4.X - Main.screenPosition.X, vector4.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chainTexture.Width, Main.chainTexture.Height)), color4, rotation4, new Vector2((float)Main.chainTexture.Width * 0.5f, (float)Main.chainTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
								}
							}
						}
						else
						{
							if (Main.projectile[i].aiStyle == 13)
							{
								float num14 = Main.projectile[i].position.X + 8f;
								float num15 = Main.projectile[i].position.Y + 2f;
								float num16 = Main.projectile[i].velocity.X;
								float num17 = Main.projectile[i].velocity.Y;
								float num18 = (float)Math.Sqrt((double)(num16 * num16 + num17 * num17));
								num18 = 20f / num18;
								if (Main.projectile[i].ai[0] == 0f)
								{
									num14 -= Main.projectile[i].velocity.X * num18;
									num15 -= Main.projectile[i].velocity.Y * num18;
								}
								else
								{
									num14 += Main.projectile[i].velocity.X * num18;
									num15 += Main.projectile[i].velocity.Y * num18;
								}
								Vector2 vector5 = new Vector2(num14, num15);
								num16 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector5.X;
								num17 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector5.Y;
								float rotation5 = (float)Math.Atan2((double)num17, (double)num16) - 1.57f;
								if (Main.projectile[i].alpha == 0)
								{
									int num19 = -1;
									if (Main.projectile[i].position.X + (float)(Main.projectile[i].width / 2) < Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2))
									{
										num19 = 1;
									}
									if (Main.player[Main.projectile[i].owner].direction == 1)
									{
										Main.player[Main.projectile[i].owner].itemRotation = (float)Math.Atan2((double)(num17 * (float)num19), (double)(num16 * (float)num19));
									}
									else
									{
										Main.player[Main.projectile[i].owner].itemRotation = (float)Math.Atan2((double)(num17 * (float)num19), (double)(num16 * (float)num19));
									}
								}
								bool flag5 = true;
								while (flag5)
								{
									float num20 = (float)Math.Sqrt((double)(num16 * num16 + num17 * num17));
									if (num20 < 25f)
									{
										flag5 = false;
									}
									else
									{
										num20 = 12f / num20;
										num16 *= num20;
										num17 *= num20;
										vector5.X += num16;
										vector5.Y += num17;
										num16 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector5.X;
										num17 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector5.Y;
										Color color5 = Lighting.GetColor((int)vector5.X / 16, (int)(vector5.Y / 16f));
										this.spriteBatch.Draw(Main.chainTexture, new Vector2(vector5.X - Main.screenPosition.X, vector5.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chainTexture.Width, Main.chainTexture.Height)), color5, rotation5, new Vector2((float)Main.chainTexture.Width * 0.5f, (float)Main.chainTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
									}
								}
							}
							else
							{
								if (Main.projectile[i].aiStyle == 15)
								{
									Vector2 vector6 = new Vector2(Main.projectile[i].position.X + (float)Main.projectile[i].width * 0.5f, Main.projectile[i].position.Y + (float)Main.projectile[i].height * 0.5f);
									float num21 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector6.X;
									float num22 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector6.Y;
									float rotation6 = (float)Math.Atan2((double)num22, (double)num21) - 1.57f;
									if (Main.projectile[i].alpha == 0)
									{
										int num23 = -1;
										if (Main.projectile[i].position.X + (float)(Main.projectile[i].width / 2) < Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2))
										{
											num23 = 1;
										}
										if (Main.player[Main.projectile[i].owner].direction == 1)
										{
											Main.player[Main.projectile[i].owner].itemRotation = (float)Math.Atan2((double)(num22 * (float)num23), (double)(num21 * (float)num23));
										}
										else
										{
											Main.player[Main.projectile[i].owner].itemRotation = (float)Math.Atan2((double)(num22 * (float)num23), (double)(num21 * (float)num23));
										}
									}
									bool flag6 = true;
									while (flag6)
									{
										float num24 = (float)Math.Sqrt((double)(num21 * num21 + num22 * num22));
										if (num24 < 25f)
										{
											flag6 = false;
										}
										else
										{
											num24 = 12f / num24;
											num21 *= num24;
											num22 *= num24;
											vector6.X += num21;
											vector6.Y += num22;
											num21 = Main.player[Main.projectile[i].owner].position.X + (float)(Main.player[Main.projectile[i].owner].width / 2) - vector6.X;
											num22 = Main.player[Main.projectile[i].owner].position.Y + (float)(Main.player[Main.projectile[i].owner].height / 2) - vector6.Y;
											Color color6 = Lighting.GetColor((int)vector6.X / 16, (int)(vector6.Y / 16f));
											if (Main.projectile[i].type == 25)
											{
												this.spriteBatch.Draw(Main.chain2Texture, new Vector2(vector6.X - Main.screenPosition.X, vector6.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain2Texture.Width, Main.chain2Texture.Height)), color6, rotation6, new Vector2((float)Main.chain2Texture.Width * 0.5f, (float)Main.chain2Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
											}
											else
											{
												if (Main.projectile[i].type == 35)
												{
													this.spriteBatch.Draw(Main.chain6Texture, new Vector2(vector6.X - Main.screenPosition.X, vector6.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain6Texture.Width, Main.chain6Texture.Height)), color6, rotation6, new Vector2((float)Main.chain6Texture.Width * 0.5f, (float)Main.chain6Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
												}
												else
												{
													if (Main.projectile[i].type == 63)
													{
														this.spriteBatch.Draw(Main.chain7Texture, new Vector2(vector6.X - Main.screenPosition.X, vector6.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain7Texture.Width, Main.chain7Texture.Height)), color6, rotation6, new Vector2((float)Main.chain7Texture.Width * 0.5f, (float)Main.chain7Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
													}
													else
													{
														this.spriteBatch.Draw(Main.chain3Texture, new Vector2(vector6.X - Main.screenPosition.X, vector6.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain3Texture.Width, Main.chain3Texture.Height)), color6, rotation6, new Vector2((float)Main.chain3Texture.Width * 0.5f, (float)Main.chain3Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			Color newColor = Lighting.GetColor((int)((double)Main.projectile[i].position.X + (double)Main.projectile[i].width * 0.5) / 16, (int)(((double)Main.projectile[i].position.Y + (double)Main.projectile[i].height * 0.5) / 16.0));
			if (Main.projectile[i].hide)
			{
				newColor = Lighting.GetColor((int)((double)Main.player[Main.projectile[i].owner].position.X + (double)Main.player[Main.projectile[i].owner].width * 0.5) / 16, (int)(((double)Main.player[Main.projectile[i].owner].position.Y + (double)Main.player[Main.projectile[i].owner].height * 0.5) / 16.0));
			}
			if (Main.projectile[i].type == 14)
			{
				newColor = Color.White;
			}
			int num25 = 0;
			int num26 = 0;
			if (Main.projectile[i].type == 16)
			{
				num25 = 6;
			}
			if (Main.projectile[i].type == 17 || Main.projectile[i].type == 31)
			{
				num25 = 2;
			}
			if (Main.projectile[i].type == 25 || Main.projectile[i].type == 26 || Main.projectile[i].type == 35 || Main.projectile[i].type == 63)
			{
				num25 = 6;
				num26 -= 6;
			}
			if (Main.projectile[i].type == 28 || Main.projectile[i].type == 37 || Main.projectile[i].type == 75)
			{
				num25 = 8;
			}
			if (Main.projectile[i].type == 29)
			{
				num25 = 11;
			}
			if (Main.projectile[i].type == 43)
			{
				num25 = 4;
			}
			if (Main.projectile[i].type == 69 || Main.projectile[i].type == 70)
			{
				num25 = 4;
				num26 = 4;
			}
			float num27 = (float)(Main.projectileTexture[Main.projectile[i].type].Width - Main.projectile[i].width) * 0.5f + (float)Main.projectile[i].width * 0.5f;
			if (Main.projectile[i].type == 50 || Main.projectile[i].type == 53)
			{
				num26 = -8;
			}
			if (Main.projectile[i].type == 72 || Main.projectile[i].type == 86 || Main.projectile[i].type == 87)
			{
				num26 = -16;
				num25 = 8;
			}
			if (Main.projectile[i].type == 74)
			{
				num26 = -6;
			}
			if (Main.projectile[i].type == 99)
			{
				num25 = 1;
			}
			SpriteEffects effects = SpriteEffects.None;
			if (Main.projectile[i].spriteDirection == -1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			if (Main.projFrames[Main.projectile[i].type] > 1)
			{
				int num28 = Main.projectileTexture[Main.projectile[i].type].Height / Main.projFrames[Main.projectile[i].type];
				int y = num28 * Main.projectile[i].frame;
				this.spriteBatch.Draw(Main.projectileTexture[Main.projectile[i].type], new Vector2(Main.projectile[i].position.X - Main.screenPosition.X + num27 + (float)num26, Main.projectile[i].position.Y - Main.screenPosition.Y + (float)(Main.projectile[i].height / 2)), new Rectangle?(new Rectangle(0, y, Main.projectileTexture[Main.projectile[i].type].Width, num28)), Main.projectile[i].GetAlpha(newColor), Main.projectile[i].rotation, new Vector2(num27, (float)(Main.projectile[i].height / 2 + num25)), Main.projectile[i].scale, effects, 0f);
				return;
			}
			if (Main.projectile[i].aiStyle == 19)
			{
				Vector2 origin = new Vector2(0f, 0f);
				if (Main.projectile[i].spriteDirection == -1)
				{
					origin.X = (float)Main.projectileTexture[Main.projectile[i].type].Width;
				}
				this.spriteBatch.Draw(Main.projectileTexture[Main.projectile[i].type], new Vector2(Main.projectile[i].position.X - Main.screenPosition.X + (float)(Main.projectile[i].width / 2), Main.projectile[i].position.Y - Main.screenPosition.Y + (float)(Main.projectile[i].height / 2)), new Rectangle?(new Rectangle(0, 0, Main.projectileTexture[Main.projectile[i].type].Width, Main.projectileTexture[Main.projectile[i].type].Height)), Main.projectile[i].GetAlpha(newColor), Main.projectile[i].rotation, origin, Main.projectile[i].scale, effects, 0f);
				return;
			}
			if (Main.projectile[i].type == 94 && Main.projectile[i].ai[1] > 6f)
			{
				for (int j = 0; j < 10; j++)
				{
					Color alpha = Main.projectile[i].GetAlpha(newColor);
					float num29 = (float)(9 - j) / 9f;
					alpha.R = (byte)((float)alpha.R * num29);
					alpha.G = (byte)((float)alpha.G * num29);
					alpha.B = (byte)((float)alpha.B * num29);
					alpha.A = (byte)((float)alpha.A * num29);
					float num30 = (float)(9 - j) / 9f;
					this.spriteBatch.Draw(Main.projectileTexture[Main.projectile[i].type], new Vector2(Main.projectile[i].oldPos[j].X - Main.screenPosition.X + num27 + (float)num26, Main.projectile[i].oldPos[j].Y - Main.screenPosition.Y + (float)(Main.projectile[i].height / 2)), new Rectangle?(new Rectangle(0, 0, Main.projectileTexture[Main.projectile[i].type].Width, Main.projectileTexture[Main.projectile[i].type].Height)), alpha, Main.projectile[i].rotation, new Vector2(num27, (float)(Main.projectile[i].height / 2 + num25)), num30 * Main.projectile[i].scale, effects, 0f);
				}
			}
			this.spriteBatch.Draw(Main.projectileTexture[Main.projectile[i].type], new Vector2(Main.projectile[i].position.X - Main.screenPosition.X + num27 + (float)num26, Main.projectile[i].position.Y - Main.screenPosition.Y + (float)(Main.projectile[i].height / 2)), new Rectangle?(new Rectangle(0, 0, Main.projectileTexture[Main.projectile[i].type].Width, Main.projectileTexture[Main.projectile[i].type].Height)), Main.projectile[i].GetAlpha(newColor), Main.projectile[i].rotation, new Vector2(num27, (float)(Main.projectile[i].height / 2 + num25)), Main.projectile[i].scale, effects, 0f);
			if (Main.projectile[i].type == 106)
			{
				this.spriteBatch.Draw(Main.lightDiscTexture, new Vector2(Main.projectile[i].position.X - Main.screenPosition.X + num27 + (float)num26, Main.projectile[i].position.Y - Main.screenPosition.Y + (float)(Main.projectile[i].height / 2)), new Rectangle?(new Rectangle(0, 0, Main.projectileTexture[Main.projectile[i].type].Width, Main.projectileTexture[Main.projectile[i].type].Height)), new Color(200, 200, 200, 0), Main.projectile[i].rotation, new Vector2(num27, (float)(Main.projectile[i].height / 2 + num25)), Main.projectile[i].scale, effects, 0f);
			}
		}
		private static Color buffColor(Color newColor, float R, float G, float B, float A)
		{
			newColor.R = (byte)((float)newColor.R * R);
			newColor.G = (byte)((float)newColor.G * G);
			newColor.B = (byte)((float)newColor.B * B);
			newColor.A = (byte)((float)newColor.A * A);
			return newColor;
		}
		protected void DrawWoF()
		{
			if (Main.wof >= 0 && Main.player[Main.myPlayer].gross)
			{
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active && Main.player[i].tongued && !Main.player[i].dead)
					{
						float num = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
						float num2 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2);
						Vector2 vector = new Vector2(Main.player[i].position.X + (float)Main.player[i].width * 0.5f, Main.player[i].position.Y + (float)Main.player[i].height * 0.5f);
						float num3 = num - vector.X;
						float num4 = num2 - vector.Y;
						float rotation = (float)Math.Atan2((double)num4, (double)num3) - 1.57f;
						bool flag = true;
						while (flag)
						{
							float num5 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
							if (num5 < 40f)
							{
								flag = false;
							}
							else
							{
								num5 = (float)Main.chain12Texture.Height / num5;
								num3 *= num5;
								num4 *= num5;
								vector.X += num3;
								vector.Y += num4;
								num3 = num - vector.X;
								num4 = num2 - vector.Y;
								Color color = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16f));
								this.spriteBatch.Draw(Main.chain12Texture, new Vector2(vector.X - Main.screenPosition.X, vector.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain12Texture.Width, Main.chain12Texture.Height)), color, rotation, new Vector2((float)Main.chain12Texture.Width * 0.5f, (float)Main.chain12Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
							}
						}
					}
				}
				for (int j = 0; j < 200; j++)
				{
					if (Main.npc[j].active && Main.npc[j].aiStyle == 29)
					{
						float num6 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
						float num7 = Main.npc[Main.wof].position.Y;
						float num8 = (float)(Main.wofB - Main.wofT);
						bool flag2 = false;
						if (Main.npc[j].frameCounter > 7.0)
						{
							flag2 = true;
						}
						num7 = (float)Main.wofT + num8 * Main.npc[j].ai[0];
						Vector2 vector2 = new Vector2(Main.npc[j].position.X + (float)(Main.npc[j].width / 2), Main.npc[j].position.Y + (float)(Main.npc[j].height / 2));
						float num9 = num6 - vector2.X;
						float num10 = num7 - vector2.Y;
						float rotation2 = (float)Math.Atan2((double)num10, (double)num9) - 1.57f;
						bool flag3 = true;
						while (flag3)
						{
							SpriteEffects effects = SpriteEffects.None;
							if (flag2)
							{
								effects = SpriteEffects.FlipHorizontally;
								flag2 = false;
							}
							else
							{
								flag2 = true;
							}
							int height = 28;
							float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
							if (num11 < 40f)
							{
								height = (int)num11 - 40 + 28;
								flag3 = false;
							}
							num11 = 28f / num11;
							num9 *= num11;
							num10 *= num11;
							vector2.X += num9;
							vector2.Y += num10;
							num9 = num6 - vector2.X;
							num10 = num7 - vector2.Y;
							Color color2 = Lighting.GetColor((int)vector2.X / 16, (int)(vector2.Y / 16f));
							this.spriteBatch.Draw(Main.chain12Texture, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, Main.chain4Texture.Width, height)), color2, rotation2, new Vector2((float)Main.chain4Texture.Width * 0.5f, (float)Main.chain4Texture.Height * 0.5f), 1f, effects, 0f);
						}
					}
				}
				int num12 = 140;
				float num13 = (float)Main.wofT;
				float num14 = (float)Main.wofB;
				num14 = Main.screenPosition.Y + (float)Main.screenHeight;
				float num15 = (float)((int)((num13 - Main.screenPosition.Y) / (float)num12) + 1);
				num15 *= (float)num12;
				if (num15 > 0f)
				{
					num13 -= num15;
				}
				float num16 = num13;
				float num17 = Main.npc[Main.wof].position.X;
				float num18 = num14 - num13;
				bool flag4 = true;
				SpriteEffects effects2 = SpriteEffects.None;
				if (Main.npc[Main.wof].spriteDirection == 1)
				{
					effects2 = SpriteEffects.FlipHorizontally;
				}
				if (Main.npc[Main.wof].direction > 0)
				{
					num17 -= 80f;
				}
				int num19 = 0;
				if (!Main.gamePaused)
				{
					Main.wofF++;
				}
				if (Main.wofF > 12)
				{
					num19 = 280;
					if (Main.wofF > 17)
					{
						Main.wofF = 0;
					}
				}
				else
				{
					if (Main.wofF > 6)
					{
						num19 = 140;
					}
				}
				while (flag4)
				{
					num18 = num14 - num16;
					if (num18 > (float)num12)
					{
						num18 = (float)num12;
					}
					bool flag5 = true;
					int num20 = 0;
					while (flag5)
					{
						int x = (int)(num17 + (float)(Main.wofTexture.Width / 2)) / 16;
						int y = (int)(num16 + (float)num20) / 16;
						this.spriteBatch.Draw(Main.wofTexture, new Vector2(num17 - Main.screenPosition.X, num16 + (float)num20 - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, num19 + num20, Main.wofTexture.Width, 16)), Lighting.GetColor(x, y), 0f, default(Vector2), 1f, effects2, 0f);
						num20 += 16;
						if ((float)num20 >= num18)
						{
							flag5 = false;
						}
					}
					num16 += (float)num12;
					if (num16 >= num14)
					{
						flag4 = false;
					}
				}
			}
		}
		protected void DrawGhost(Player drawPlayer)
		{
			SpriteEffects effects = SpriteEffects.None;
			if (drawPlayer.direction == 1)
			{
				effects = SpriteEffects.None;
			}
			else
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			Color immuneAlpha = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.5) / 16, new Color((int)(Main.mouseTextColor / 2 + 100), (int)(Main.mouseTextColor / 2 + 100), (int)(Main.mouseTextColor / 2 + 100), (int)(Main.mouseTextColor / 2 + 100))));
			Rectangle value = new Rectangle(0, Main.ghostTexture.Height / 4 * drawPlayer.ghostFrame, Main.ghostTexture.Width, Main.ghostTexture.Height / 4);
			Vector2 origin = new Vector2((float)value.Width * 0.5f, (float)value.Height * 0.5f);
			this.spriteBatch.Draw(Main.ghostTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X + (float)(value.Width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)(value.Height / 2)))), new Rectangle?(value), immuneAlpha, 0f, origin, 1f, effects, 0f);
		}
		protected void DrawPlayer(Player drawPlayer)
		{
			SpriteEffects effects = SpriteEffects.None;
			SpriteEffects effects2 = SpriteEffects.FlipHorizontally;
			Color color = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.25) / 16.0), Color.White));
			Color color2 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.25) / 16.0), drawPlayer.eyeColor));
			Color color3 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.25) / 16.0), drawPlayer.hairColor));
			Color color4 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.25) / 16.0), drawPlayer.skinColor));
			Color color5 = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.5) / 16.0), drawPlayer.skinColor));
			Color immuneAlpha = drawPlayer.GetImmuneAlpha(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.75) / 16.0), drawPlayer.skinColor));
			Color color6 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.5) / 16.0), drawPlayer.shirtColor));
			Color color7 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.5) / 16.0), drawPlayer.underShirtColor));
			Color color8 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.75) / 16.0), drawPlayer.pantsColor));
			Color color9 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.75) / 16.0), drawPlayer.shoeColor));
			Color color10 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.25) / 16, Color.White));
			Color color11 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.5) / 16, Color.White));
			Color color12 = drawPlayer.GetImmuneAlpha2(Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.75) / 16, Color.White));
			if (drawPlayer.shadow > 0f)
			{
				immuneAlpha = new Color(0, 0, 0, 0);
				color5 = new Color(0, 0, 0, 0);
				color4 = new Color(0, 0, 0, 0);
				color3 = new Color(0, 0, 0, 0);
				color2 = new Color(0, 0, 0, 0);
				color = new Color(0, 0, 0, 0);
			}
			float num = 1f;
			float num2 = 1f;
			float num3 = 1f;
			float num4 = 1f;
			if (drawPlayer.poisoned)
			{
				if (Main.rand.Next(50) == 0)
				{
					int num5 = Dust.NewDust(drawPlayer.position, drawPlayer.width, drawPlayer.height, 46, 0f, 0f, 150, default(Color), 0.2f);
					Main.dust[num5].noGravity = true;
					Main.dust[num5].fadeIn = 1.9f;
				}
				num *= 0.65f;
				num3 *= 0.75f;
			}
			if (drawPlayer.onFire)
			{
				if (Main.rand.Next(4) == 0)
				{
					int num6 = Dust.NewDust(new Vector2(drawPlayer.position.X - 2f, drawPlayer.position.Y - 2f), drawPlayer.width + 4, drawPlayer.height + 4, 6, drawPlayer.velocity.X * 0.4f, drawPlayer.velocity.Y * 0.4f, 100, default(Color), 3f);
					Main.dust[num6].noGravity = true;
					Dust expr_640 = Main.dust[num6];
					expr_640.velocity *= 1.8f;
					Dust expr_662_cp_0 = Main.dust[num6];
					expr_662_cp_0.velocity.Y = expr_662_cp_0.velocity.Y - 0.5f;
				}
				num3 *= 0.6f;
				num2 *= 0.7f;
			}
			if (drawPlayer.onFire2)
			{
				if (Main.rand.Next(4) == 0)
				{
					int num7 = Dust.NewDust(new Vector2(drawPlayer.position.X - 2f, drawPlayer.position.Y - 2f), drawPlayer.width + 4, drawPlayer.height + 4, 75, drawPlayer.velocity.X * 0.4f, drawPlayer.velocity.Y * 0.4f, 100, default(Color), 3f);
					Main.dust[num7].noGravity = true;
					Dust expr_72B = Main.dust[num7];
					expr_72B.velocity *= 1.8f;
					Dust expr_74D_cp_0 = Main.dust[num7];
					expr_74D_cp_0.velocity.Y = expr_74D_cp_0.velocity.Y - 0.5f;
				}
				num3 *= 0.6f;
				num2 *= 0.7f;
			}
			if (drawPlayer.noItems)
			{
				num2 *= 0.8f;
				num *= 0.65f;
			}
			if (drawPlayer.blind)
			{
				num2 *= 0.65f;
				num *= 0.7f;
			}
			if (drawPlayer.bleed)
			{
				num2 *= 0.9f;
				num3 *= 0.9f;
				if (!drawPlayer.dead && Main.rand.Next(30) == 0)
				{
					int num8 = Dust.NewDust(drawPlayer.position, drawPlayer.width, drawPlayer.height, 5, 0f, 0f, 0, default(Color), 1f);
					Dust expr_820_cp_0 = Main.dust[num8];
					expr_820_cp_0.velocity.Y = expr_820_cp_0.velocity.Y + 0.5f;
					Dust expr_839 = Main.dust[num8];
					expr_839.velocity *= 0.25f;
				}
			}
			if (num != 1f || num2 != 1f || num3 != 1f || num4 != 1f)
			{
				if (drawPlayer.onFire || drawPlayer.onFire2)
				{
					color = drawPlayer.GetImmuneAlpha(Color.White);
					color2 = drawPlayer.GetImmuneAlpha(drawPlayer.eyeColor);
					color3 = drawPlayer.GetImmuneAlpha(drawPlayer.hairColor);
					color4 = drawPlayer.GetImmuneAlpha(drawPlayer.skinColor);
					color5 = drawPlayer.GetImmuneAlpha(drawPlayer.skinColor);
					color6 = drawPlayer.GetImmuneAlpha(drawPlayer.shirtColor);
					color7 = drawPlayer.GetImmuneAlpha(drawPlayer.underShirtColor);
					color8 = drawPlayer.GetImmuneAlpha(drawPlayer.pantsColor);
					color9 = drawPlayer.GetImmuneAlpha(drawPlayer.shoeColor);
					color10 = drawPlayer.GetImmuneAlpha(Color.White);
					color11 = drawPlayer.GetImmuneAlpha(Color.White);
					color12 = drawPlayer.GetImmuneAlpha(Color.White);
				}
				else
				{
					color = Main.buffColor(color, num, num2, num3, num4);
					color2 = Main.buffColor(color2, num, num2, num3, num4);
					color3 = Main.buffColor(color3, num, num2, num3, num4);
					color4 = Main.buffColor(color4, num, num2, num3, num4);
					color5 = Main.buffColor(color5, num, num2, num3, num4);
					color6 = Main.buffColor(color6, num, num2, num3, num4);
					color7 = Main.buffColor(color7, num, num2, num3, num4);
					color8 = Main.buffColor(color8, num, num2, num3, num4);
					color9 = Main.buffColor(color9, num, num2, num3, num4);
					color10 = Main.buffColor(color10, num, num2, num3, num4);
					color11 = Main.buffColor(color11, num, num2, num3, num4);
					color12 = Main.buffColor(color12, num, num2, num3, num4);
				}
			}
			if (drawPlayer.gravDir == 1f)
			{
				if (drawPlayer.direction == 1)
				{
					effects = SpriteEffects.None;
					effects2 = SpriteEffects.None;
				}
				else
				{
					effects = SpriteEffects.FlipHorizontally;
					effects2 = SpriteEffects.FlipHorizontally;
				}
				if (!drawPlayer.dead)
				{
					drawPlayer.legPosition.Y = 0f;
					drawPlayer.headPosition.Y = 0f;
					drawPlayer.bodyPosition.Y = 0f;
				}
			}
			else
			{
				if (drawPlayer.direction == 1)
				{
					effects = SpriteEffects.FlipVertically;
					effects2 = SpriteEffects.FlipVertically;
				}
				else
				{
					effects = (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
					effects2 = (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
				}
				if (!drawPlayer.dead)
				{
					drawPlayer.legPosition.Y = 6f;
					drawPlayer.headPosition.Y = 6f;
					drawPlayer.bodyPosition.Y = 6f;
				}
			}
			Vector2 vector = new Vector2((float)drawPlayer.legFrame.Width * 0.5f, (float)drawPlayer.legFrame.Height * 0.75f);
			Vector2 origin = new Vector2((float)drawPlayer.legFrame.Width * 0.5f, (float)drawPlayer.legFrame.Height * 0.5f);
			Vector2 vector2 = new Vector2((float)drawPlayer.legFrame.Width * 0.5f, (float)drawPlayer.legFrame.Height * 0.4f);
			if (drawPlayer.merman)
			{
				drawPlayer.headRotation = drawPlayer.velocity.Y * (float)drawPlayer.direction * 0.1f;
				if ((double)drawPlayer.headRotation < -0.3)
				{
					drawPlayer.headRotation = -0.3f;
				}
				if ((double)drawPlayer.headRotation > 0.3)
				{
					drawPlayer.headRotation = 0.3f;
				}
			}
			else
			{
				if (!drawPlayer.dead)
				{
					drawPlayer.headRotation = 0f;
				}
			}
			if (drawPlayer.wings > 0)
			{
				this.spriteBatch.Draw(Main.wingsTexture[drawPlayer.wings], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X + (float)(drawPlayer.width / 2) - (float)(9 * drawPlayer.direction))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)(drawPlayer.height / 2) + 2f * drawPlayer.gravDir))), new Rectangle?(new Rectangle(0, Main.wingsTexture[drawPlayer.wings].Height / 4 * drawPlayer.wingFrame, Main.wingsTexture[drawPlayer.wings].Width, Main.wingsTexture[drawPlayer.wings].Height / 4)), color11, drawPlayer.bodyRotation, new Vector2((float)(Main.wingsTexture[drawPlayer.wings].Width / 2), (float)(Main.wingsTexture[drawPlayer.wings].Height / 8)), 1f, effects, 0f);
			}
			if (!drawPlayer.invis)
			{
				this.spriteBatch.Draw(Main.skinBodyTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				this.spriteBatch.Draw(Main.skinLegsTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.legFrame), immuneAlpha, drawPlayer.legRotation, origin, 1f, effects, 0f);
			}
			if (drawPlayer.legs > 0 && drawPlayer.legs < 24)
			{
				this.spriteBatch.Draw(Main.armorLegTexture[drawPlayer.legs], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.legFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.legFrame.Height + 4f))) + drawPlayer.legPosition + vector, new Rectangle?(drawPlayer.legFrame), color12, drawPlayer.legRotation, vector, 1f, effects, 0f);
			}
			else
			{
				if (!drawPlayer.invis)
				{
					if (!drawPlayer.male)
					{
						this.spriteBatch.Draw(Main.femalePantsTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.legFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.legFrame.Height + 4f))) + drawPlayer.legPosition + vector, new Rectangle?(drawPlayer.legFrame), color8, drawPlayer.legRotation, vector, 1f, effects, 0f);
						this.spriteBatch.Draw(Main.femaleShoesTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.legFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.legFrame.Height + 4f))) + drawPlayer.legPosition + vector, new Rectangle?(drawPlayer.legFrame), color9, drawPlayer.legRotation, vector, 1f, effects, 0f);
					}
					else
					{
						this.spriteBatch.Draw(Main.playerPantsTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.legFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.legFrame.Height + 4f))) + drawPlayer.legPosition + vector, new Rectangle?(drawPlayer.legFrame), color8, drawPlayer.legRotation, vector, 1f, effects, 0f);
						this.spriteBatch.Draw(Main.playerShoesTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.legFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.legFrame.Height + 4f))) + drawPlayer.legPosition + vector, new Rectangle?(drawPlayer.legFrame), color9, drawPlayer.legRotation, vector, 1f, effects, 0f);
					}
				}
			}
			if (drawPlayer.body > 0 && drawPlayer.body < 25)
			{
				if (!drawPlayer.male)
				{
					this.spriteBatch.Draw(Main.femaleBodyTexture[drawPlayer.body], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color11, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				}
				else
				{
					this.spriteBatch.Draw(Main.armorBodyTexture[drawPlayer.body], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color11, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				}
				if ((drawPlayer.body == 10 || drawPlayer.body == 11 || drawPlayer.body == 12 || drawPlayer.body == 13 || drawPlayer.body == 14 || drawPlayer.body == 15 || drawPlayer.body == 16 || drawPlayer.body == 20) && !drawPlayer.invis)
				{
					this.spriteBatch.Draw(Main.playerHandsTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				}
			}
			else
			{
				if (!drawPlayer.invis)
				{
					if (!drawPlayer.male)
					{
						this.spriteBatch.Draw(Main.femaleUnderShirtTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color7, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
						this.spriteBatch.Draw(Main.femaleShirtTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color6, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
					}
					else
					{
						this.spriteBatch.Draw(Main.playerUnderShirtTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color7, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
						this.spriteBatch.Draw(Main.playerShirtTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color6, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
					}
					this.spriteBatch.Draw(Main.playerHandsTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				}
			}
			if (!drawPlayer.invis && drawPlayer.head != 38)
			{
				this.spriteBatch.Draw(Main.playerHeadTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Rectangle?(drawPlayer.bodyFrame), color4, drawPlayer.headRotation, vector2, 1f, effects, 0f);
				this.spriteBatch.Draw(Main.playerEyeWhitesTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Rectangle?(drawPlayer.bodyFrame), color, drawPlayer.headRotation, vector2, 1f, effects, 0f);
				this.spriteBatch.Draw(Main.playerEyesTexture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Rectangle?(drawPlayer.bodyFrame), color2, drawPlayer.headRotation, vector2, 1f, effects, 0f);
			}
			if (drawPlayer.head == 10 || drawPlayer.head == 12 || drawPlayer.head == 28)
			{
				this.spriteBatch.Draw(Main.armorHeadTexture[drawPlayer.head], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Rectangle?(drawPlayer.bodyFrame), color10, drawPlayer.headRotation, vector2, 1f, effects, 0f);
				if (!drawPlayer.invis)
				{
					Rectangle bodyFrame = drawPlayer.bodyFrame;
					bodyFrame.Y -= 336;
					if (bodyFrame.Y < 0)
					{
						bodyFrame.Y = 0;
					}
					this.spriteBatch.Draw(Main.playerHairTexture[drawPlayer.hair], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Rectangle?(bodyFrame), color3, drawPlayer.headRotation, vector2, 1f, effects, 0f);
				}
			}
			if (drawPlayer.head == 23)
			{
				Rectangle bodyFrame2 = drawPlayer.bodyFrame;
				bodyFrame2.Y -= 336;
				if (bodyFrame2.Y < 0)
				{
					bodyFrame2.Y = 0;
				}
				if (!drawPlayer.invis)
				{
					this.spriteBatch.Draw(Main.playerHairTexture[drawPlayer.hair], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Rectangle?(bodyFrame2), color3, drawPlayer.headRotation, vector2, 1f, effects, 0f);
				}
				this.spriteBatch.Draw(Main.armorHeadTexture[drawPlayer.head], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Rectangle?(drawPlayer.bodyFrame), color10, drawPlayer.headRotation, vector2, 1f, effects, 0f);
			}
			else
			{
				if (drawPlayer.head == 14)
				{
					Rectangle bodyFrame3 = drawPlayer.bodyFrame;
					int num9 = 0;
					if (bodyFrame3.Y == bodyFrame3.Height * 6)
					{
						bodyFrame3.Height -= 2;
					}
					else
					{
						if (bodyFrame3.Y == bodyFrame3.Height * 7)
						{
							num9 = -2;
						}
						else
						{
							if (bodyFrame3.Y == bodyFrame3.Height * 8)
							{
								num9 = -2;
							}
							else
							{
								if (bodyFrame3.Y == bodyFrame3.Height * 9)
								{
									num9 = -2;
								}
								else
								{
									if (bodyFrame3.Y == bodyFrame3.Height * 10)
									{
										num9 = -2;
									}
									else
									{
										if (bodyFrame3.Y == bodyFrame3.Height * 13)
										{
											bodyFrame3.Height -= 2;
										}
										else
										{
											if (bodyFrame3.Y == bodyFrame3.Height * 14)
											{
												num9 = -2;
											}
											else
											{
												if (bodyFrame3.Y == bodyFrame3.Height * 15)
												{
													num9 = -2;
												}
												else
												{
													if (bodyFrame3.Y == bodyFrame3.Height * 16)
													{
														num9 = -2;
													}
												}
											}
										}
									}
								}
							}
						}
					}
					bodyFrame3.Y += num9;
					this.spriteBatch.Draw(Main.armorHeadTexture[drawPlayer.head], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f + (float)num9))) + drawPlayer.headPosition + vector2, new Rectangle?(bodyFrame3), color10, drawPlayer.headRotation, vector2, 1f, effects, 0f);
				}
				else
				{
					if (drawPlayer.head > 0 && drawPlayer.head < 44 && drawPlayer.head != 28)
					{
						this.spriteBatch.Draw(Main.armorHeadTexture[drawPlayer.head], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Rectangle?(drawPlayer.bodyFrame), color10, drawPlayer.headRotation, vector2, 1f, effects, 0f);
					}
					else
					{
						if (!drawPlayer.invis)
						{
							Rectangle bodyFrame4 = drawPlayer.bodyFrame;
							bodyFrame4.Y -= 336;
							if (bodyFrame4.Y < 0)
							{
								bodyFrame4.Y = 0;
							}
							this.spriteBatch.Draw(Main.playerHairTexture[drawPlayer.hair], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.headPosition + vector2, new Rectangle?(bodyFrame4), color3, drawPlayer.headRotation, vector2, 1f, effects, 0f);
						}
					}
				}
			}
			if (drawPlayer.heldProj >= 0)
			{
				this.DrawProj(drawPlayer.heldProj);
			}
			Color color13 = Lighting.GetColor((int)((double)drawPlayer.position.X + (double)drawPlayer.width * 0.5) / 16, (int)(((double)drawPlayer.position.Y + (double)drawPlayer.height * 0.5) / 16.0));
			if ((drawPlayer.itemAnimation > 0 || drawPlayer.inventory[drawPlayer.selectedItem].holdStyle > 0) && drawPlayer.inventory[drawPlayer.selectedItem].type > 0 && !drawPlayer.dead && !drawPlayer.inventory[drawPlayer.selectedItem].noUseGraphic && (!drawPlayer.wet || !drawPlayer.inventory[drawPlayer.selectedItem].noWet))
			{
				if (drawPlayer.inventory[drawPlayer.selectedItem].useStyle == 5)
				{
					int num10 = 10;
					Vector2 vector3 = new Vector2((float)(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width / 2), (float)(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height / 2));
					if (drawPlayer.inventory[drawPlayer.selectedItem].type == 95)
					{
						num10 = 10;
						vector3.Y += 2f * drawPlayer.gravDir;
					}
					else
					{
						if (drawPlayer.inventory[drawPlayer.selectedItem].type == 96)
						{
							num10 = -5;
						}
						else
						{
							if (drawPlayer.inventory[drawPlayer.selectedItem].type == 98)
							{
								num10 = -5;
								vector3.Y -= 2f * drawPlayer.gravDir;
							}
							else
							{
								if (drawPlayer.inventory[drawPlayer.selectedItem].type == 534)
								{
									num10 = -2;
									vector3.Y += 1f * drawPlayer.gravDir;
								}
								else
								{
									if (drawPlayer.inventory[drawPlayer.selectedItem].type == 533)
									{
										num10 = -7;
										vector3.Y -= 2f * drawPlayer.gravDir;
									}
									else
									{
										if (drawPlayer.inventory[drawPlayer.selectedItem].type == 506)
										{
											num10 = 0;
											vector3.Y -= 2f * drawPlayer.gravDir;
										}
										else
										{
											if (drawPlayer.inventory[drawPlayer.selectedItem].type == 494 || drawPlayer.inventory[drawPlayer.selectedItem].type == 508)
											{
												num10 = -2;
											}
											else
											{
												if (drawPlayer.inventory[drawPlayer.selectedItem].type == 434)
												{
													num10 = 0;
													vector3.Y -= 2f * drawPlayer.gravDir;
												}
												else
												{
													if (drawPlayer.inventory[drawPlayer.selectedItem].type == 514)
													{
														num10 = 0;
														vector3.Y += 3f * drawPlayer.gravDir;
													}
													else
													{
														if (drawPlayer.inventory[drawPlayer.selectedItem].type == 435 || drawPlayer.inventory[drawPlayer.selectedItem].type == 436 || drawPlayer.inventory[drawPlayer.selectedItem].type == 481 || drawPlayer.inventory[drawPlayer.selectedItem].type == 578)
														{
															num10 = -2;
															vector3.Y -= 2f * drawPlayer.gravDir;
														}
														else
														{
															if (drawPlayer.inventory[drawPlayer.selectedItem].type == 197)
															{
																num10 = -5;
																vector3.Y += 4f * drawPlayer.gravDir;
															}
															else
															{
																if (drawPlayer.inventory[drawPlayer.selectedItem].type == 126)
																{
																	num10 = 4;
																	vector3.Y += 4f * drawPlayer.gravDir;
																}
																else
																{
																	if (drawPlayer.inventory[drawPlayer.selectedItem].type == 127)
																	{
																		num10 = 4;
																		vector3.Y += 2f * drawPlayer.gravDir;
																	}
																	else
																	{
																		if (drawPlayer.inventory[drawPlayer.selectedItem].type == 157)
																		{
																			num10 = 6;
																			vector3.Y += 2f * drawPlayer.gravDir;
																		}
																		else
																		{
																			if (drawPlayer.inventory[drawPlayer.selectedItem].type == 160)
																			{
																				num10 = -8;
																			}
																			else
																			{
																				if (drawPlayer.inventory[drawPlayer.selectedItem].type == 164 || drawPlayer.inventory[drawPlayer.selectedItem].type == 219)
																				{
																					num10 = 2;
																					vector3.Y += 4f * drawPlayer.gravDir;
																				}
																				else
																				{
																					if (drawPlayer.inventory[drawPlayer.selectedItem].type == 165 || drawPlayer.inventory[drawPlayer.selectedItem].type == 272)
																					{
																						num10 = 4;
																						vector3.Y += 4f * drawPlayer.gravDir;
																					}
																					else
																					{
																						if (drawPlayer.inventory[drawPlayer.selectedItem].type == 266)
																						{
																							num10 = 0;
																							vector3.Y += 2f * drawPlayer.gravDir;
																						}
																						else
																						{
																							if (drawPlayer.inventory[drawPlayer.selectedItem].type == 281)
																							{
																								num10 = 6;
																								vector3.Y -= 6f * drawPlayer.gravDir;
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					Vector2 origin2 = new Vector2((float)(-(float)num10), (float)(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height / 2));
					if (drawPlayer.direction == -1)
					{
						origin2 = new Vector2((float)(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width + num10), (float)(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height / 2));
					}
					this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float)((int)(drawPlayer.itemLocation.X - Main.screenPosition.X + vector3.X)), (float)((int)(drawPlayer.itemLocation.Y - Main.screenPosition.Y + vector3.Y))), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(color13), drawPlayer.itemRotation, origin2, drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0f);
					if (drawPlayer.inventory[drawPlayer.selectedItem].color != default(Color))
					{
						this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float)((int)(drawPlayer.itemLocation.X - Main.screenPosition.X + vector3.X)), (float)((int)(drawPlayer.itemLocation.Y - Main.screenPosition.Y + vector3.Y))), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(color13), drawPlayer.itemRotation, origin2, drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0f);
					}
				}
				else
				{
					if (drawPlayer.gravDir == -1f)
					{
						this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float)((int)(drawPlayer.itemLocation.X - Main.screenPosition.X)), (float)((int)(drawPlayer.itemLocation.Y - Main.screenPosition.Y))), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(color13), drawPlayer.itemRotation, new Vector2((float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f - (float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f * (float)drawPlayer.direction, 0f), drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0f);
						if (drawPlayer.inventory[drawPlayer.selectedItem].color != default(Color))
						{
							this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float)((int)(drawPlayer.itemLocation.X - Main.screenPosition.X)), (float)((int)(drawPlayer.itemLocation.Y - Main.screenPosition.Y))), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(color13), drawPlayer.itemRotation, new Vector2((float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f - (float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f * (float)drawPlayer.direction, 0f), drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0f);
						}
					}
					else
					{
						if (drawPlayer.inventory[drawPlayer.selectedItem].type == 425 || drawPlayer.inventory[drawPlayer.selectedItem].type == 507)
						{
							if (drawPlayer.gravDir == 1f)
							{
								if (drawPlayer.direction == 1)
								{
									effects2 = SpriteEffects.FlipVertically;
								}
								else
								{
									effects2 = (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
								}
							}
							else
							{
								if (drawPlayer.direction == 1)
								{
									effects2 = SpriteEffects.None;
								}
								else
								{
									effects2 = SpriteEffects.FlipHorizontally;
								}
							}
						}
						this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float)((int)(drawPlayer.itemLocation.X - Main.screenPosition.X)), (float)((int)(drawPlayer.itemLocation.Y - Main.screenPosition.Y))), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(color13), drawPlayer.itemRotation, new Vector2((float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f - (float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f * (float)drawPlayer.direction, (float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0f);
						if (drawPlayer.inventory[drawPlayer.selectedItem].color != default(Color))
						{
							this.spriteBatch.Draw(Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type], new Vector2((float)((int)(drawPlayer.itemLocation.X - Main.screenPosition.X)), (float)((int)(drawPlayer.itemLocation.Y - Main.screenPosition.Y))), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width, Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height)), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(color13), drawPlayer.itemRotation, new Vector2((float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f - (float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Width * 0.5f * (float)drawPlayer.direction, (float)Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type].Height), drawPlayer.inventory[drawPlayer.selectedItem].scale, effects2, 0f);
						}
					}
				}
			}
			if (drawPlayer.body > 0 && drawPlayer.body < 25)
			{
				this.spriteBatch.Draw(Main.armorArmTexture[drawPlayer.body], new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color11, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				if ((drawPlayer.body == 10 || drawPlayer.body == 11 || drawPlayer.body == 12 || drawPlayer.body == 13 || drawPlayer.body == 14 || drawPlayer.body == 15 || drawPlayer.body == 16 || drawPlayer.body == 20) && !drawPlayer.invis)
				{
					this.spriteBatch.Draw(Main.playerHands2Texture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
					return;
				}
			}
			else
			{
				if (!drawPlayer.invis)
				{
					if (!drawPlayer.male)
					{
						this.spriteBatch.Draw(Main.femaleUnderShirt2Texture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color7, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
						this.spriteBatch.Draw(Main.femaleShirt2Texture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color6, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
					}
					else
					{
						this.spriteBatch.Draw(Main.playerUnderShirt2Texture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color7, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
					}
					this.spriteBatch.Draw(Main.playerHands2Texture, new Vector2((float)((int)(drawPlayer.position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(drawPlayer.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), new Rectangle?(drawPlayer.bodyFrame), color5, drawPlayer.bodyRotation, origin, 1f, effects, 0f);
				}
			}
		}
		private static void HelpText()
		{
			bool flag = false;
			if (Main.player[Main.myPlayer].statLifeMax > 100)
			{
				flag = true;
			}
			bool flag2 = false;
			if (Main.player[Main.myPlayer].statManaMax > 0)
			{
				flag2 = true;
			}
			bool flag3 = true;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			bool flag8 = false;
			bool flag9 = false;
			for (int i = 0; i < 48; i++)
			{
				if (Main.player[Main.myPlayer].inventory[i].pick > 0 && Main.player[Main.myPlayer].inventory[i].name != "Copper Pickaxe")
				{
					flag3 = false;
				}
				if (Main.player[Main.myPlayer].inventory[i].axe > 0 && Main.player[Main.myPlayer].inventory[i].name != "Copper Axe")
				{
					flag3 = false;
				}
				if (Main.player[Main.myPlayer].inventory[i].hammer > 0)
				{
					flag3 = false;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 11 || Main.player[Main.myPlayer].inventory[i].type == 12 || Main.player[Main.myPlayer].inventory[i].type == 13 || Main.player[Main.myPlayer].inventory[i].type == 14)
				{
					flag4 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 19 || Main.player[Main.myPlayer].inventory[i].type == 20 || Main.player[Main.myPlayer].inventory[i].type == 21 || Main.player[Main.myPlayer].inventory[i].type == 22)
				{
					flag5 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 75)
				{
					flag6 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 75)
				{
					flag7 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 68 || Main.player[Main.myPlayer].inventory[i].type == 70)
				{
					flag8 = true;
				}
				if (Main.player[Main.myPlayer].inventory[i].type == 84)
				{
					flag9 = true;
				}
			}
			bool flag10 = false;
			bool flag11 = false;
			bool flag12 = false;
			bool flag13 = false;
			bool flag14 = false;
			bool flag15 = false;
			bool flag16 = false;
			bool flag17 = false;
			bool flag18 = false;
			for (int j = 0; j < 200; j++)
			{
				if (Main.npc[j].active)
				{
					if (Main.npc[j].type == 17)
					{
						flag10 = true;
					}
					if (Main.npc[j].type == 18)
					{
						flag11 = true;
					}
					if (Main.npc[j].type == 19)
					{
						flag13 = true;
					}
					if (Main.npc[j].type == 20)
					{
						flag12 = true;
					}
					if (Main.npc[j].type == 54)
					{
						flag18 = true;
					}
					if (Main.npc[j].type == 124)
					{
						flag15 = true;
					}
					if (Main.npc[j].type == 107)
					{
						flag14 = true;
					}
					if (Main.npc[j].type == 108)
					{
						flag16 = true;
					}
					if (Main.npc[j].type == 38)
					{
						flag17 = true;
					}
				}
			}
			while (true)
			{
				Main.helpText++;
				if (flag3)
				{
					if (Main.helpText == 1)
					{
						break;
					}
					if (Main.helpText == 2)
					{
						goto Block_31;
					}
					if (Main.helpText == 3)
					{
						goto Block_32;
					}
					if (Main.helpText == 4)
					{
						goto Block_33;
					}
					if (Main.helpText == 5)
					{
						goto Block_34;
					}
					if (Main.helpText == 6)
					{
						goto Block_35;
					}
				}
				if (flag3 && !flag4 && !flag5 && Main.helpText == 11)
				{
					goto Block_39;
				}
				if (flag3 && flag4 && !flag5)
				{
					if (Main.helpText == 21)
					{
						goto Block_43;
					}
					if (Main.helpText == 22)
					{
						goto Block_44;
					}
				}
				if (flag3 && flag5)
				{
					if (Main.helpText == 31)
					{
						goto Block_47;
					}
					if (Main.helpText == 32)
					{
						goto Block_48;
					}
				}
				if (!flag && Main.helpText == 41)
				{
					goto Block_50;
				}
				if (!flag2 && Main.helpText == 42)
				{
					goto Block_52;
				}
				if (!flag2 && !flag6 && Main.helpText == 43)
				{
					goto Block_55;
				}
				if (!flag10 && !flag11)
				{
					if (Main.helpText == 51)
					{
						goto Block_58;
					}
					if (Main.helpText == 52)
					{
						goto Block_59;
					}
					if (Main.helpText == 53)
					{
						goto Block_60;
					}
					if (Main.helpText == 54)
					{
						goto Block_61;
					}
				}
				if (!flag10 && Main.helpText == 61)
				{
					goto Block_63;
				}
				if (!flag11 && Main.helpText == 62)
				{
					goto Block_65;
				}
				if (!flag13 && Main.helpText == 63)
				{
					goto Block_67;
				}
				if (!flag12 && Main.helpText == 64)
				{
					goto Block_69;
				}
				if (!flag15 && Main.helpText == 65 && NPC.downedBoss3)
				{
					goto Block_72;
				}
				if (!flag18 && Main.helpText == 66 && NPC.downedBoss3)
				{
					goto Block_75;
				}
				if (!flag14 && Main.helpText == 67)
				{
					goto Block_77;
				}
				if (!flag17 && NPC.downedBoss2 && Main.helpText == 68)
				{
					goto Block_80;
				}
				if (!flag16 && Main.hardMode && Main.helpText == 69)
				{
					goto Block_83;
				}
				if (flag7 && Main.helpText == 71)
				{
					goto Block_85;
				}
				if (flag8 && Main.helpText == 72)
				{
					goto Block_87;
				}
				if ((flag7 || flag8) && Main.helpText == 80)
				{
					goto Block_89;
				}
				if (!flag9 && Main.helpText == 201 && !Main.hardMode && !NPC.downedBoss3 && !NPC.downedBoss2)
				{
					goto Block_94;
				}
				if (Main.helpText == 1000 && !NPC.downedBoss1 && !NPC.downedBoss2)
				{
					goto Block_97;
				}
				if (Main.helpText == 1001 && !NPC.downedBoss1 && !NPC.downedBoss2)
				{
					goto Block_100;
				}
				if (Main.helpText == 1002 && !NPC.downedBoss3)
				{
					goto Block_102;
				}
				if (Main.helpText == 1050 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statLifeMax < 200)
				{
					goto Block_105;
				}
				if (Main.helpText == 1051 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statDefense <= 10)
				{
					goto Block_108;
				}
				if (Main.helpText == 1052 && !NPC.downedBoss1 && Main.player[Main.myPlayer].statLifeMax >= 200 && Main.player[Main.myPlayer].statDefense > 10)
				{
					goto Block_112;
				}
				if (Main.helpText == 1053 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax < 300)
				{
					goto Block_116;
				}
				if (Main.helpText == 1054 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax >= 300)
				{
					goto Block_120;
				}
				if (Main.helpText == 1055 && NPC.downedBoss1 && !NPC.downedBoss2 && Main.player[Main.myPlayer].statLifeMax >= 300)
				{
					goto Block_124;
				}
				if (Main.helpText == 1056 && NPC.downedBoss1 && NPC.downedBoss2 && !NPC.downedBoss3)
				{
					goto Block_128;
				}
				if (Main.helpText == 1057 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax < 400)
				{
					goto Block_134;
				}
				if (Main.helpText == 1058 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					goto Block_140;
				}
				if (Main.helpText == 1059 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					goto Block_146;
				}
				if (Main.helpText == 1060 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					goto Block_152;
				}
				if (Main.helpText == 1061 && Main.hardMode)
				{
					goto Block_154;
				}
				if (Main.helpText == 1062 && Main.hardMode)
				{
					goto Block_156;
				}
				if (Main.helpText > 1100)
				{
					Main.helpText = 0;
				}
			}
			Main.npcChatText = "You can use your pickaxe to dig through dirt, and your axe to chop down trees. Just place your cursor over the tile and click!";
			return;
			Block_31:
			Main.npcChatText = "If you want to survive, you will need to create weapons and shelter. Start by chopping down trees and gathering wood.";
			return;
			Block_32:
			Main.npcChatText = "Press ESC to access your crafting menu. When you have enough wood, create a workbench. This will allow you to create more complicated things, as long as you are standing close to it.";
			return;
			Block_33:
			Main.npcChatText = "You can build a shelter by placing wood or other blocks in the world. Don't forget to create and place walls.";
			return;
			Block_34:
			Main.npcChatText = "Once you have a wooden sword, you might try to gather some gel from the slimes. Combine wood and gel to make a torch!";
			return;
			Block_35:
			Main.npcChatText = "To interact with backgrounds and placed objects, use a hammer!";
			return;
			Block_39:
			Main.npcChatText = "You should do some mining to find metal ore. You can craft very useful things with it.";
			return;
			Block_43:
			Main.npcChatText = "Now that you have some ore, you will need to turn it into a bar in order to make items with it. This requires a furnace!";
			return;
			Block_44:
			Main.npcChatText = "You can create a furnace out of torches, wood, and stone. Make sure you are standing near a work bench.";
			return;
			Block_47:
			Main.npcChatText = "You will need an anvil to make most things out of metal bars.";
			return;
			Block_48:
			Main.npcChatText = "Anvils can be crafted out of iron, or purchased from a merchant.";
			return;
			Block_50:
			Main.npcChatText = "Underground are crystal hearts that can be used to increase your max life. You will need a hammer to obtain them.";
			return;
			Block_52:
			Main.npcChatText = "If you gather 10 fallen stars, they can be combined to create an item that will increase your magic capacity.";
			return;
			Block_55:
			Main.npcChatText = "Stars fall all over the world at night. They can be used for all sorts of usefull things. If you see one, be sure to grab it because they disappear after sunrise.";
			return;
			Block_58:
			Main.npcChatText = "There are many different ways you can attract people to move in to our town. They will of course need a home to live in.";
			return;
			Block_59:
			Main.npcChatText = "In order for a room to be considered a home, it needs to have a door, chair, table, and a light source.  Make sure the house has walls as well.";
			return;
			Block_60:
			Main.npcChatText = "Two people will not live in the same home. Also, if their home is destroyed, they will look for a new place to live.";
			return;
			Block_61:
			Main.npcChatText = "You can use the housing interface to assign and view housing. Open you inventory and click the house icon.";
			return;
			Block_63:
			Main.npcChatText = "If you want a merchant to move in, you will need to gather plenty of money. 50 silver coins should do the trick!";
			return;
			Block_65:
			Main.npcChatText = "For a nurse to move in, you might want to increase your maximum life.";
			return;
			Block_67:
			Main.npcChatText = "If you had a gun, I bet an arms dealer might show up to sell you some ammo!";
			return;
			Block_69:
			Main.npcChatText = "You should prove yourself by defeating a strong monster. That will get the attention of a dryad.";
			return;
			Block_72:
			Main.npcChatText = "Make sure to explore the dungeon thoroughly. There may be prisoners held deep within.";
			return;
			Block_75:
			Main.npcChatText = "Perhaps the old man by the dungeon would like to join us now that his curse has been lifted.";
			return;
			Block_77:
			Main.npcChatText = "Hang on to any bombs you might find. A demolitionist may want to have a look at them.";
			return;
			Block_80:
			Main.npcChatText = "Are goblins really so different from us that we couldn't live together peacefully?";
			return;
			Block_83:
			Main.npcChatText = "I heard there was a powerfully wizard who lives in these parts.  Make sure to keep an eye out for him next time you go underground.";
			return;
			Block_85:
			Main.npcChatText = "If you combine lenses at a demon altar, you might be able to find a way to summon a powerful monster. You will want to wait until night before using it, though.";
			return;
			Block_87:
			Main.npcChatText = "You can create worm bait with rotten chunks and vile powder. Make sure you are in a corrupt area before using it.";
			return;
			Block_89:
			Main.npcChatText = "Demonic altars can usually be found in the corruption. You will need to be near them to craft some items.";
			return;
			Block_94:
			Main.npcChatText = "You can make a grappling hook from a hook and 3 chains. Skeletons found deep underground usually carry hooks, and chains can be made from iron bars.";
			return;
			Block_97:
			Main.npcChatText = "If you see a pot, be sure to smash it open. They contain all sorts of useful supplies.";
			return;
			Block_100:
			Main.npcChatText = "There is treasure hidden all over the world. Some amazing things can be found deep underground!";
			return;
			Block_102:
			Main.npcChatText = "Smashing a shadow orb will sometimes cause a meteor to fall out of the sky. Shadow orbs can usually be found in the chasms around corrupt areas.";
			return;
			Block_105:
			Main.npcChatText = "You should focus on gathering more heart crystals to increase your maximum life.";
			return;
			Block_108:
			Main.npcChatText = "Your current equipment simply won't do. You need to make better armor.";
			return;
			Block_112:
			Main.npcChatText = "I think you are ready for your first major battle. Gather some lenses from the eyeballs at night and take them to a demon altar.";
			return;
			Block_116:
			Main.npcChatText = "You wil want to increase your life before facing your next challenge. Fifteen hearts should be enough.";
			return;
			Block_120:
			Main.npcChatText = "The ebonstone in the corruption can be purified using some powder from a dryad, or it can be destroyed with explosives.";
			return;
			Block_124:
			Main.npcChatText = "Your next step should be to explore the corrupt chasms.  Find and destroy any shadow orb you find.";
			return;
			Block_128:
			Main.npcChatText = "There is a old dungeon not far from here. Now would be a good time to go check it out.";
			return;
			Block_134:
			Main.npcChatText = "You should make an attempt to max out your available life. Try to gather twenty hearts.";
			return;
			Block_140:
			Main.npcChatText = "There are many treasures to be discovered in the jungle, if you are willing to dig deep enough.";
			return;
			Block_146:
			Main.npcChatText = "The underworld is made of a material called hellstone. It's perfect for making weapons and armor.";
			return;
			Block_152:
			Main.npcChatText = "When you are ready to challenge the keeper of the underworld, you will have to make a living sacrifice. Everything you need for it can be found in the underworld.";
			return;
			Block_154:
			Main.npcChatText = "Make sure to smash any demon altar you can find. Something good is bound to happen if you do!";
			return;
			Block_156:
			Main.npcChatText = "Souls can sometimes be gathered from fallen creatures in places of extreme light or dark.";
		}
		protected void DrawChat()
		{
			if (Main.player[Main.myPlayer].talkNPC < 0 && Main.player[Main.myPlayer].sign == -1)
			{
				Main.npcChatText = "";
				return;
			}
			Color color = new Color(200, 200, 200, 200);
			int num = (int)((Main.mouseTextColor * 2 + 255) / 3);
			Color color2 = new Color(num, num, num, num);
			int num2 = 10;
			int num3 = 0;
			string[] array = new string[num2];
			int num4 = 0;
			int num5 = 0;
			if (Main.npcChatText == null)
			{
				Main.npcChatText = "";
			}
			for (int i = 0; i < Main.npcChatText.Length; i++)
			{
				byte[] bytes = Encoding.ASCII.GetBytes(Main.npcChatText.Substring(i, 1));
				if (bytes[0] == 10)
				{
					array[num3] = Main.npcChatText.Substring(num4, i - num4);
					num3++;
					num4 = i + 1;
					num5 = i + 1;
				}
				else
				{
					if (Main.npcChatText.Substring(i, 1) == " " || i == Main.npcChatText.Length - 1)
					{
						if (Main.fontMouseText.MeasureString(Main.npcChatText.Substring(num4, i - num4)).X > 470f)
						{
							array[num3] = Main.npcChatText.Substring(num4, num5 - num4);
							num3++;
							num4 = num5 + 1;
						}
						num5 = i;
					}
				}
				if (num3 == 10)
				{
					Main.npcChatText = Main.npcChatText.Substring(0, i - 1);
					num4 = i - 1;
					num3 = 9;
					break;
				}
			}
			if (num3 < 10)
			{
				array[num3] = Main.npcChatText.Substring(num4, Main.npcChatText.Length - num4);
			}
			if (Main.editSign)
			{
				this.textBlinkerCount++;
				if (this.textBlinkerCount >= 20)
				{
					if (this.textBlinkerState == 0)
					{
						this.textBlinkerState = 1;
					}
					else
					{
						this.textBlinkerState = 0;
					}
					this.textBlinkerCount = 0;
				}
				if (this.textBlinkerState == 1)
				{
					string[] array2;
					IntPtr intPtr;
					(array2 = array)[(int)(intPtr = (IntPtr)num3)] = array2[(int)intPtr] + "|";
				}
			}
			num3++;
			this.spriteBatch.Draw(Main.chatBackTexture, new Vector2((float)(Main.screenWidth / 2 - Main.chatBackTexture.Width / 2), 100f), new Rectangle?(new Rectangle(0, 0, Main.chatBackTexture.Width, (num3 + 1) * 30)), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			this.spriteBatch.Draw(Main.chatBackTexture, new Vector2((float)(Main.screenWidth / 2 - Main.chatBackTexture.Width / 2), (float)(100 + (num3 + 1) * 30)), new Rectangle?(new Rectangle(0, Main.chatBackTexture.Height - 30, Main.chatBackTexture.Width, 30)), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			for (int j = 0; j < num3; j++)
			{
				for (int k = 0; k < 5; k++)
				{
					Color color3 = Color.Black;
					int num6 = 170 + (Main.screenWidth - 800) / 2;
					int num7 = 120 + j * 30;
					if (k == 0)
					{
						num6 -= 2;
					}
					if (k == 1)
					{
						num6 += 2;
					}
					if (k == 2)
					{
						num7 -= 2;
					}
					if (k == 3)
					{
						num7 += 2;
					}
					if (k == 4)
					{
						color3 = color2;
					}
					this.spriteBatch.DrawString(Main.fontMouseText, array[j], new Vector2((float)num6, (float)num7), color3, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
				}
			}
			num = (int)Main.mouseTextColor;
			color2 = new Color(num, (int)((double)num / 1.1), num / 2, num);
			string text = "";
			string text2 = "";
			int num8 = Main.player[Main.myPlayer].statLifeMax - Main.player[Main.myPlayer].statLife;
			for (int l = 0; l < 10; l++)
			{
				int num9 = Main.player[Main.myPlayer].buffType[l];
				if (Main.debuff[num9] && Main.player[Main.myPlayer].buffTime[l] > 0 && num9 != 28 && num9 != 34)
				{
					num8 += 1000;
				}
			}
			if (Main.player[Main.myPlayer].sign > -1)
			{
				if (Main.editSign)
				{
					text = "Save";
				}
				else
				{
					text = "Edit";
				}
			}
			else
			{
				if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
				{
					text = "Shop";
					text2 = "Status";
				}
				else
				{
					if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 17 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 19 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 38 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 54 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 108 || Main.npc[Main.player[Main.myPlayer].talkNPC].type == 124)
					{
						text = "Shop";
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
						{
							text2 = "Reforge";
						}
					}
					else
					{
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 37)
						{
							if (!Main.dayTime)
							{
								text = "Curse";
							}
						}
						else
						{
							if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
							{
								text = "Help";
								text2 = "Crafting";
							}
							else
							{
								if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 18)
								{
									string text3 = "";
									int num10 = 0;
									int num11 = 0;
									int num12 = 0;
									int num13 = 0;
									int num14 = num8;
									if (num14 > 0)
									{
										num14 = (int)((double)num14 * 0.75);
										if (num14 < 1)
										{
											num14 = 1;
										}
									}
									if (num14 < 0)
									{
										num14 = 0;
									}
									num8 = num14;
									if (num14 >= 1000000)
									{
										num10 = num14 / 1000000;
										num14 -= num10 * 1000000;
									}
									if (num14 >= 10000)
									{
										num11 = num14 / 10000;
										num14 -= num11 * 10000;
									}
									if (num14 >= 100)
									{
										num12 = num14 / 100;
										num14 -= num12 * 100;
									}
									if (num14 >= 1)
									{
										num13 = num14;
									}
									if (num10 > 0)
									{
										text3 = text3 + num10 + " platinum ";
									}
									if (num11 > 0)
									{
										text3 = text3 + num11 + " gold ";
									}
									if (num12 > 0)
									{
										text3 = text3 + num12 + " silver ";
									}
									if (num13 > 0)
									{
										text3 = text3 + num13 + " copper ";
									}
									float num15 = (float)Main.mouseTextColor / 255f;
									if (num10 > 0)
									{
										color2 = new Color((int)((byte)(220f * num15)), (int)((byte)(220f * num15)), (int)((byte)(198f * num15)), (int)Main.mouseTextColor);
									}
									else
									{
										if (num11 > 0)
										{
											color2 = new Color((int)((byte)(224f * num15)), (int)((byte)(201f * num15)), (int)((byte)(92f * num15)), (int)Main.mouseTextColor);
										}
										else
										{
											if (num12 > 0)
											{
												color2 = new Color((int)((byte)(181f * num15)), (int)((byte)(192f * num15)), (int)((byte)(193f * num15)), (int)Main.mouseTextColor);
											}
											else
											{
												if (num13 > 0)
												{
													color2 = new Color((int)((byte)(246f * num15)), (int)((byte)(138f * num15)), (int)((byte)(96f * num15)), (int)Main.mouseTextColor);
												}
											}
										}
									}
									text = "Heal (" + text3 + ")";
									if (num14 == 0)
									{
										text = "Heal";
									}
								}
							}
						}
					}
				}
			}
			int num16 = 180 + (Main.screenWidth - 800) / 2;
			int num17 = 130 + num3 * 30;
			float scale = 0.9f;
			if (Main.mouseX > num16 && (float)Main.mouseX < (float)num16 + Main.fontMouseText.MeasureString(text).X && Main.mouseY > num17 && (float)Main.mouseY < (float)num17 + Main.fontMouseText.MeasureString(text).Y)
			{
				Main.player[Main.myPlayer].mouseInterface = true;
				scale = 1.1f;
				if (!Main.npcChatFocus2)
				{
					Main.PlaySound(12, -1, -1, 1);
				}
				Main.npcChatFocus2 = true;
				Main.player[Main.myPlayer].releaseUseItem = false;
			}
			else
			{
				if (Main.npcChatFocus2)
				{
					Main.PlaySound(12, -1, -1, 1);
				}
				Main.npcChatFocus2 = false;
			}
			for (int m = 0; m < 5; m++)
			{
				int num18 = num16;
				int num19 = num17;
				Color color4 = Color.Black;
				if (m == 0)
				{
					num18 -= 2;
				}
				if (m == 1)
				{
					num18 += 2;
				}
				if (m == 2)
				{
					num19 -= 2;
				}
				if (m == 3)
				{
					num19 += 2;
				}
				if (m == 4)
				{
					color4 = color2;
				}
				Vector2 vector = Main.fontMouseText.MeasureString(text);
				vector *= 0.5f;
				this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2((float)num18 + vector.X, (float)num19 + vector.Y), color4, 0f, vector, scale, SpriteEffects.None, 0f);
			}
			color2 = new Color(num, (int)((double)num / 1.1), num / 2, num);
			num16 = num16 + (int)Main.fontMouseText.MeasureString(text).X + 20;
			num17 = 130 + num3 * 30;
			scale = 0.9f;
			if (Main.mouseX > num16 && (float)Main.mouseX < (float)num16 + Main.fontMouseText.MeasureString("Close").X && Main.mouseY > num17 && (float)Main.mouseY < (float)num17 + Main.fontMouseText.MeasureString("Close").Y)
			{
				scale = 1.1f;
				if (!Main.npcChatFocus1)
				{
					Main.PlaySound(12, -1, -1, 1);
				}
				Main.npcChatFocus1 = true;
				Main.player[Main.myPlayer].releaseUseItem = false;
				Main.player[Main.myPlayer].controlUseItem = false;
			}
			else
			{
				if (Main.npcChatFocus1)
				{
					Main.PlaySound(12, -1, -1, 1);
				}
				Main.npcChatFocus1 = false;
			}
			for (int n = 0; n < 5; n++)
			{
				int num20 = num16;
				int num21 = num17;
				Color color5 = Color.Black;
				if (n == 0)
				{
					num20 -= 2;
				}
				if (n == 1)
				{
					num20 += 2;
				}
				if (n == 2)
				{
					num21 -= 2;
				}
				if (n == 3)
				{
					num21 += 2;
				}
				if (n == 4)
				{
					color5 = color2;
				}
				Vector2 vector2 = Main.fontMouseText.MeasureString("Close");
				vector2 *= 0.5f;
				this.spriteBatch.DrawString(Main.fontMouseText, "Close", new Vector2((float)num20 + vector2.X, (float)num21 + vector2.Y), color5, 0f, vector2, scale, SpriteEffects.None, 0f);
			}
			if (text2 != "")
			{
				num16 = 296 + (Main.screenWidth - 800) / 2;
				num17 = 130 + num3 * 30;
				scale = 0.9f;
				if (Main.mouseX > num16 && (float)Main.mouseX < (float)num16 + Main.fontMouseText.MeasureString(text2).X && Main.mouseY > num17 && (float)Main.mouseY < (float)num17 + Main.fontMouseText.MeasureString(text2).Y)
				{
					Main.player[Main.myPlayer].mouseInterface = true;
					scale = 1.1f;
					if (!Main.npcChatFocus3)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					Main.npcChatFocus3 = true;
					Main.player[Main.myPlayer].releaseUseItem = false;
				}
				else
				{
					if (Main.npcChatFocus3)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					Main.npcChatFocus3 = false;
				}
				for (int num22 = 0; num22 < 5; num22++)
				{
					int num23 = num16;
					int num24 = num17;
					Color color6 = Color.Black;
					if (num22 == 0)
					{
						num23 -= 2;
					}
					if (num22 == 1)
					{
						num23 += 2;
					}
					if (num22 == 2)
					{
						num24 -= 2;
					}
					if (num22 == 3)
					{
						num24 += 2;
					}
					if (num22 == 4)
					{
						color6 = color2;
					}
					Vector2 vector3 = Main.fontMouseText.MeasureString(text);
					vector3 *= 0.5f;
					this.spriteBatch.DrawString(Main.fontMouseText, text2, new Vector2((float)num23 + vector3.X, (float)num24 + vector3.Y), color6, 0f, vector3, scale, SpriteEffects.None, 0f);
				}
			}
			if (Main.mouseLeft && Main.mouseLeftRelease)
			{
				Main.mouseLeftRelease = false;
				Main.player[Main.myPlayer].releaseUseItem = false;
				Main.player[Main.myPlayer].mouseInterface = true;
				if (Main.npcChatFocus1)
				{
					Main.player[Main.myPlayer].talkNPC = -1;
					Main.player[Main.myPlayer].sign = -1;
					Main.editSign = false;
					Main.npcChatText = "";
					Main.PlaySound(11, -1, -1, 1);
					return;
				}
				if (Main.npcChatFocus2)
				{
					if (Main.player[Main.myPlayer].sign != -1)
					{
						if (!Main.editSign)
						{
							Main.PlaySound(12, -1, -1, 1);
							Main.editSign = true;
							return;
						}
						Main.PlaySound(12, -1, -1, 1);
						int num25 = Main.player[Main.myPlayer].sign;
						Sign.TextSign(num25, Main.npcChatText);
						Main.editSign = false;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(47, -1, -1, "", num25, 0f, 0f, 0f, 0);
							return;
						}
					}
					else
					{
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 17)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 1;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 19)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 2;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 124)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 8;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 37)
						{
							if (Main.netMode == 0)
							{
								NPC.SpawnSkeletron();
							}
							else
							{
								NetMessage.SendData(51, -1, -1, "", Main.myPlayer, 1f, 0f, 0f, 0);
							}
							Main.npcChatText = "";
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 3;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 38)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 4;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 54)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 5;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 6;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 108)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.npcShop = 7;
							this.shop[Main.npcShop].SetupShop(Main.npcShop);
							Main.PlaySound(12, -1, -1, 1);
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
						{
							Main.PlaySound(12, -1, -1, 1);
							Main.HelpText();
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 18)
						{
							Main.PlaySound(12, -1, -1, 1);
							if (num8 > 0)
							{
								if (Main.player[Main.myPlayer].BuyItem(num8))
								{
									Main.PlaySound(2, -1, -1, 4);
									Main.player[Main.myPlayer].HealEffect(Main.player[Main.myPlayer].statLifeMax - Main.player[Main.myPlayer].statLife);
									if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.25)
									{
										Main.npcChatText = "I managed to sew your face back on. Be more careful next time.";
									}
									else
									{
										if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.5)
										{
											Main.npcChatText = "That's probably going to leave a scar.";
										}
										else
										{
											if ((double)Main.player[Main.myPlayer].statLife < (double)Main.player[Main.myPlayer].statLifeMax * 0.75)
											{
												Main.npcChatText = "All better. I don't want to see you jumping off anymore cliffs.";
											}
											else
											{
												Main.npcChatText = "That didn't hurt too bad, now did it?";
											}
										}
									}
									Main.player[Main.myPlayer].statLife = Main.player[Main.myPlayer].statLifeMax;
									for (int num26 = 0; num26 < 10; num26++)
									{
										int num27 = Main.player[Main.myPlayer].buffType[num26];
										if (Main.debuff[num27] && Main.player[Main.myPlayer].buffTime[num26] > 0 && num27 != 28 && num27 != 34)
										{
											Main.player[Main.myPlayer].DelBuff(num26);
										}
									}
									return;
								}
								int num28 = Main.rand.Next(3);
								if (num28 == 0)
								{
									Main.npcChatText = "I'm sorry, but you can't afford me.";
								}
								if (num28 == 1)
								{
									Main.npcChatText = "I'm gonna need more gold than that.";
								}
								if (num28 == 2)
								{
									Main.npcChatText = "I don't work for free you know.";
									return;
								}
							}
							else
							{
								int num29 = Main.rand.Next(3);
								if (num29 == 0)
								{
									Main.npcChatText = "I don't give happy endings.";
								}
								if (num29 == 1)
								{
									Main.npcChatText = "I can't do anymore for you without plastic surgery.";
								}
								if (num29 == 2)
								{
									Main.npcChatText = "Quit wasting my time.";
									return;
								}
							}
						}
					}
				}
				else
				{
					if (Main.npcChatFocus3 && Main.player[Main.myPlayer].talkNPC >= 0)
					{
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 20)
						{
							Main.PlaySound(12, -1, -1, 1);
							string str = "";
							if (WorldGen.tGood == 0)
							{
								str = string.Concat(new object[]
								{
									Main.worldName, 
									" is ", 
									WorldGen.tEvil, 
									"% corrupt."
								});
							}
							else
							{
								if (WorldGen.tEvil == 0)
								{
									str = string.Concat(new object[]
									{
										Main.worldName, 
										" is ", 
										WorldGen.tGood, 
										"% hallow."
									});
								}
								else
								{
									str = string.Concat(new object[]
									{
										Main.worldName, 
										" is ", 
										WorldGen.tGood, 
										"% hallow, and ", 
										WorldGen.tEvil, 
										"% corrupt."
									});
								}
							}
							if (WorldGen.tGood > WorldGen.tEvil)
							{
								str += " Keep up the good work!";
							}
							else
							{
								if (WorldGen.tEvil > WorldGen.tGood && WorldGen.tEvil > 20)
								{
									str += " Things are grim indeed.";
								}
								else
								{
									str += " You should try harder.";
								}
							}
							Main.npcChatText = str;
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 22)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.PlaySound(12, -1, -1, 1);
							Main.craftGuide = true;
							return;
						}
						if (Main.npc[Main.player[Main.myPlayer].talkNPC].type == 107)
						{
							Main.playerInventory = true;
							Main.npcChatText = "";
							Main.PlaySound(12, -1, -1, 1);
							Main.reforge = true;
						}
					}
				}
			}
		}
		private static bool AccCheck(Item newItem, int slot)
		{
			if (Main.player[Main.myPlayer].armor[slot].IsTheSameAs(newItem))
			{
				return false;
			}
			for (int i = 0; i < Main.player[Main.myPlayer].armor.Length; i++)
			{
				if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[i]))
				{
					return true;
				}
			}
			return false;
		}
		public static Item armorSwap(Item newItem)
		{
			for (int i = 0; i < Main.player[Main.myPlayer].armor.Length; i++)
			{
				if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[i]))
				{
					Main.accSlotCount = i;
				}
			}
			if (newItem.headSlot == -1 && newItem.bodySlot == -1 && newItem.legSlot == -1 && !newItem.accessory)
			{
				return newItem;
			}
			Item result = newItem;
			if (newItem.headSlot != -1)
			{
				result = (Item)Main.player[Main.myPlayer].armor[0].Clone();
				Main.player[Main.myPlayer].armor[0] = (Item)newItem.Clone();
			}
			else
			{
				if (newItem.bodySlot != -1)
				{
					result = (Item)Main.player[Main.myPlayer].armor[1].Clone();
					Main.player[Main.myPlayer].armor[1] = (Item)newItem.Clone();
				}
				else
				{
					if (newItem.legSlot != -1)
					{
						result = (Item)Main.player[Main.myPlayer].armor[2].Clone();
						Main.player[Main.myPlayer].armor[2] = (Item)newItem.Clone();
					}
					else
					{
						if (newItem.accessory)
						{
							for (int j = 3; j < 8; j++)
							{
								if (Main.player[Main.myPlayer].armor[j].type == 0)
								{
									Main.accSlotCount = j - 3;
									break;
								}
							}
							for (int k = 0; k < Main.player[Main.myPlayer].armor.Length; k++)
							{
								if (newItem.IsTheSameAs(Main.player[Main.myPlayer].armor[k]))
								{
									Main.accSlotCount = k - 3;
								}
							}
							result = (Item)Main.player[Main.myPlayer].armor[3 + Main.accSlotCount].Clone();
							Main.player[Main.myPlayer].armor[3 + Main.accSlotCount] = (Item)newItem.Clone();
							Main.accSlotCount++;
							if (Main.accSlotCount >= 5)
							{
								Main.accSlotCount = 0;
							}
						}
					}
				}
			}
			Main.PlaySound(7, -1, -1, 1);
			Recipe.FindRecipes();
			return result;
		}
		public static void BankCoins()
		{
			for (int i = 0; i < 20; i++)
			{
				if (Main.player[Main.myPlayer].bank[i].type >= 71 && Main.player[Main.myPlayer].bank[i].type <= 73 && Main.player[Main.myPlayer].bank[i].stack == Main.player[Main.myPlayer].bank[i].maxStack)
				{
					Main.player[Main.myPlayer].bank[i].SetDefaults(Main.player[Main.myPlayer].bank[i].type + 1, false);
					for (int j = 0; j < 20; j++)
					{
						if (j != i && Main.player[Main.myPlayer].bank[j].type == Main.player[Main.myPlayer].bank[i].type && Main.player[Main.myPlayer].bank[j].stack < Main.player[Main.myPlayer].bank[j].maxStack)
						{
							Main.player[Main.myPlayer].bank[j].stack++;
							Main.player[Main.myPlayer].bank[i].SetDefaults(0, false);
							Main.BankCoins();
						}
					}
				}
			}
		}
		public static void ChestCoins()
		{
			for (int i = 0; i < 20; i++)
			{
				if (Main.chest[Main.player[Main.myPlayer].chest].item[i].type >= 71 && Main.chest[Main.player[Main.myPlayer].chest].item[i].type <= 73 && Main.chest[Main.player[Main.myPlayer].chest].item[i].stack == Main.chest[Main.player[Main.myPlayer].chest].item[i].maxStack)
				{
					Main.chest[Main.player[Main.myPlayer].chest].item[i].SetDefaults(Main.chest[Main.player[Main.myPlayer].chest].item[i].type + 1, false);
					for (int j = 0; j < 20; j++)
					{
						if (j != i && Main.chest[Main.player[Main.myPlayer].chest].item[j].type == Main.chest[Main.player[Main.myPlayer].chest].item[i].type && Main.chest[Main.player[Main.myPlayer].chest].item[j].stack < Main.chest[Main.player[Main.myPlayer].chest].item[j].maxStack)
						{
							Main.chest[Main.player[Main.myPlayer].chest].item[j].stack++;
							Main.chest[Main.player[Main.myPlayer].chest].item[i].SetDefaults(0, false);
							Main.ChestCoins();
						}
					}
				}
			}
		}
		protected void DrawNPCHouse()
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].townNPC && !Main.npc[i].homeless && Main.npc[i].homeTileX > 0 && Main.npc[i].homeTileY > 0 && Main.npc[i].type != 37)
				{
					int num = 1;
					int num2 = Main.npc[i].homeTileX;
					int num3 = Main.npc[i].homeTileY - 1;
					if (Main.tile[num2, num3] != null)
					{
						bool flag = false;
						while (!Main.tile[num2, num3].active || !Main.tileSolid[(int)Main.tile[num2, num3].type])
						{
							num3--;
							if (num3 < 10)
							{
								break;
							}
							if (Main.tile[num2, num3] == null)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							int num4 = 8;
							int num5 = 18;
							if (Main.tile[num2, num3].type == 19)
							{
								num5 -= 8;
							}
							num3++;
							this.spriteBatch.Draw(Main.bannerTexture[num], new Vector2((float)(num2 * 16 - (int)Main.screenPosition.X + num4), (float)(num3 * 16 - (int)Main.screenPosition.Y + num5)), new Rectangle?(new Rectangle(0, 0, Main.bannerTexture[num].Width, Main.bannerTexture[num].Height)), Lighting.GetColor(num2, num3), 0f, new Vector2((float)(Main.bannerTexture[num].Width / 2), (float)(Main.bannerTexture[num].Height / 2)), 1f, SpriteEffects.None, 0f);
							int num6 = NPC.TypeToNum(Main.npc[i].type);
							float scale = 1f;
							float num7 = 0f;
							if (Main.npcHeadTexture[num6].Width > Main.npcHeadTexture[num6].Height)
							{
								num7 = (float)Main.npcHeadTexture[num6].Width;
							}
							else
							{
								num7 = (float)Main.npcHeadTexture[num6].Height;
							}
							if (num7 > 24f)
							{
								scale = 24f / num7;
							}
							this.spriteBatch.Draw(Main.npcHeadTexture[num6], new Vector2((float)(num2 * 16 - (int)Main.screenPosition.X + num4), (float)(num3 * 16 - (int)Main.screenPosition.Y + num5 + 2)), new Rectangle?(new Rectangle(0, 0, Main.npcHeadTexture[num6].Width, Main.npcHeadTexture[num6].Height)), Lighting.GetColor(num2, num3), 0f, new Vector2((float)(Main.npcHeadTexture[num6].Width / 2), (float)(Main.npcHeadTexture[num6].Height / 2)), scale, SpriteEffects.None, 0f);
							num2 = num2 * 16 - (int)Main.screenPosition.X + num4 - Main.bannerTexture[num].Width / 2;
							num3 = num3 * 16 - (int)Main.screenPosition.Y + num5 - Main.bannerTexture[num].Height / 2;
							if (Main.mouseX >= num2 && Main.mouseX <= num2 + Main.bannerTexture[num].Width && Main.mouseY >= num3 && Main.mouseY <= num3 + Main.bannerTexture[num].Height)
							{
								this.MouseText(Main.npc[i].displayName + " the " + Main.npc[i].name, 0, 0);
								if (Main.mouseRightRelease && Main.mouseRight)
								{
									Main.mouseRightRelease = false;
									WorldGen.kickOut(i);
									Main.PlaySound(12, -1, -1, 1);
								}
							}
						}
					}
				}
			}
		}
		protected void DrawInterface()
		{
			if (this.showNPCs)
			{
				this.DrawNPCHouse();
			}
			if (Main.player[Main.myPlayer].selectedItem == 48 && Main.player[Main.myPlayer].itemAnimation > 0)
			{
				Main.mouseLeftRelease = false;
			}
			Main.mouseHC = false;
			if (Main.hideUI)
			{
				Main.maxQ = true;
				return;
			}
			Vector2 origin;
			if (Main.player[Main.myPlayer].rulerAcc)
			{
				int num = (int)((float)((int)(Main.screenPosition.X / 16f) * 16) - Main.screenPosition.X);
				int num2 = (int)((float)((int)(Main.screenPosition.Y / 16f) * 16) - Main.screenPosition.Y);
				int num3 = Main.screenWidth / Main.gridTexture.Width;
				int num4 = Main.screenHeight / Main.gridTexture.Height;
				for (int i = 0; i <= num3 + 1; i++)
				{
					for (int j = 0; j <= num4 + 1; j++)
					{
						SpriteBatch arg_155_0 = this.spriteBatch;
						Texture2D arg_155_1 = Main.gridTexture;
						Vector2 arg_155_2 = new Vector2((float)(i * Main.gridTexture.Width + num), (float)(j * Main.gridTexture.Height + num2));
						Rectangle? arg_155_3 = new Rectangle?(new Rectangle(0, 0, Main.gridTexture.Width, Main.gridTexture.Height));
						Color arg_155_4 = new Color(100, 100, 100, 15);
						float arg_155_5 = 0f;
						origin = default(Vector2);
						arg_155_0.Draw(arg_155_1, arg_155_2, arg_155_3, arg_155_4, arg_155_5, origin, 1f, SpriteEffects.None, 0f);
					}
				}
			}
			if (Main.netDiag)
			{
				for (int k = 0; k < 4; k++)
				{
					string text = "";
					int num5 = 20;
					int num6 = 220;
					if (k == 0)
					{
						text = "RX Msgs: " + string.Format("{0:0,0}", Main.rxMsg);
						num6 += k * 20;
					}
					else
					{
						if (k == 1)
						{
							text = "RX Bytes: " + string.Format("{0:0,0}", Main.rxData);
							num6 += k * 20;
						}
						else
						{
							if (k == 2)
							{
								text = "TX Msgs: " + string.Format("{0:0,0}", Main.txMsg);
								num6 += k * 20;
							}
							else
							{
								if (k == 3)
								{
									text = "TX Bytes: " + string.Format("{0:0,0}", Main.txData);
									num6 += k * 20;
								}
							}
						}
					}
					SpriteBatch arg_29D_0 = this.spriteBatch;
					SpriteFont arg_29D_1 = Main.fontMouseText;
					string arg_29D_2 = text;
					Vector2 arg_29D_3 = new Vector2((float)num5, (float)num6);
					Color arg_29D_4 = Color.White;
					float arg_29D_5 = 0f;
					origin = default(Vector2);
					arg_29D_0.DrawString(arg_29D_1, arg_29D_2, arg_29D_3, arg_29D_4, arg_29D_5, origin, 1f, SpriteEffects.None, 0f);
				}
				for (int l = 0; l < Main.maxMsg; l++)
				{
					int num7 = 200;
					int num8 = 120;
					num8 += l * 15;
					string text2 = l + ": ";
					SpriteBatch arg_322_0 = this.spriteBatch;
					SpriteFont arg_322_1 = Main.fontMouseText;
					string arg_322_2 = text2;
					Vector2 arg_322_3 = new Vector2((float)num7, (float)num8);
					Color arg_322_4 = Color.White;
					float arg_322_5 = 0f;
					origin = default(Vector2);
					arg_322_0.DrawString(arg_322_1, arg_322_2, arg_322_3, arg_322_4, arg_322_5, origin, 0.8f, SpriteEffects.None, 0f);
					num7 += 30;
					text2 = "rx:" + string.Format("{0:0,0}", Main.rxMsgType[l]);
					SpriteBatch arg_38C_0 = this.spriteBatch;
					SpriteFont arg_38C_1 = Main.fontMouseText;
					string arg_38C_2 = text2;
					Vector2 arg_38C_3 = new Vector2((float)num7, (float)num8);
					Color arg_38C_4 = Color.White;
					float arg_38C_5 = 0f;
					origin = default(Vector2);
					arg_38C_0.DrawString(arg_38C_1, arg_38C_2, arg_38C_3, arg_38C_4, arg_38C_5, origin, 0.8f, SpriteEffects.None, 0f);
					num7 += 70;
					text2 = string.Format("{0:0,0}", Main.rxDataType[l]);
					SpriteBatch arg_3EC_0 = this.spriteBatch;
					SpriteFont arg_3EC_1 = Main.fontMouseText;
					string arg_3EC_2 = text2;
					Vector2 arg_3EC_3 = new Vector2((float)num7, (float)num8);
					Color arg_3EC_4 = Color.White;
					float arg_3EC_5 = 0f;
					origin = default(Vector2);
					arg_3EC_0.DrawString(arg_3EC_1, arg_3EC_2, arg_3EC_3, arg_3EC_4, arg_3EC_5, origin, 0.8f, SpriteEffects.None, 0f);
					num7 += 70;
					text2 = l + ": ";
					SpriteBatch arg_446_0 = this.spriteBatch;
					SpriteFont arg_446_1 = Main.fontMouseText;
					string arg_446_2 = text2;
					Vector2 arg_446_3 = new Vector2((float)num7, (float)num8);
					Color arg_446_4 = Color.White;
					float arg_446_5 = 0f;
					origin = default(Vector2);
					arg_446_0.DrawString(arg_446_1, arg_446_2, arg_446_3, arg_446_4, arg_446_5, origin, 0.8f, SpriteEffects.None, 0f);
					num7 += 30;
					text2 = "tx:" + string.Format("{0:0,0}", Main.txMsgType[l]);
					SpriteBatch arg_4B0_0 = this.spriteBatch;
					SpriteFont arg_4B0_1 = Main.fontMouseText;
					string arg_4B0_2 = text2;
					Vector2 arg_4B0_3 = new Vector2((float)num7, (float)num8);
					Color arg_4B0_4 = Color.White;
					float arg_4B0_5 = 0f;
					origin = default(Vector2);
					arg_4B0_0.DrawString(arg_4B0_1, arg_4B0_2, arg_4B0_3, arg_4B0_4, arg_4B0_5, origin, 0.8f, SpriteEffects.None, 0f);
					num7 += 70;
					text2 = string.Format("{0:0,0}", Main.txDataType[l]);
					SpriteBatch arg_510_0 = this.spriteBatch;
					SpriteFont arg_510_1 = Main.fontMouseText;
					string arg_510_2 = text2;
					Vector2 arg_510_3 = new Vector2((float)num7, (float)num8);
					Color arg_510_4 = Color.White;
					float arg_510_5 = 0f;
					origin = default(Vector2);
					arg_510_0.DrawString(arg_510_1, arg_510_2, arg_510_3, arg_510_4, arg_510_5, origin, 0.8f, SpriteEffects.None, 0f);
				}
			}
			if (Main.drawDiag)
			{
				for (int m = 0; m < 7; m++)
				{
					string text3 = "";
					int num9 = 20;
					int num10 = 220;
					num10 += m * 16;
					if (m == 0)
					{
						text3 = "Solid Tiles:";
					}
					if (m == 1)
					{
						text3 = "Misc. Tiles:";
					}
					if (m == 2)
					{
						text3 = "Walls Tiles:";
					}
					if (m == 3)
					{
						text3 = "Background Tiles:";
					}
					if (m == 4)
					{
						text3 = "Water Tiles:";
					}
					if (m == 5)
					{
						text3 = "Black Tiles:";
					}
					if (m == 6)
					{
						text3 = "Total Render:";
					}
					SpriteBatch arg_5E3_0 = this.spriteBatch;
					SpriteFont arg_5E3_1 = Main.fontMouseText;
					string arg_5E3_2 = text3;
					Vector2 arg_5E3_3 = new Vector2((float)num9, (float)num10);
					Color arg_5E3_4 = Color.White;
					float arg_5E3_5 = 0f;
					origin = default(Vector2);
					arg_5E3_0.DrawString(arg_5E3_1, arg_5E3_2, arg_5E3_3, arg_5E3_4, arg_5E3_5, origin, 1f, SpriteEffects.None, 0f);
				}
				for (int n = 0; n < 7; n++)
				{
					string text4 = "";
					int num11 = 180;
					int num12 = 220;
					num12 += n * 16;
					if (n == 0)
					{
						text4 = Main.renderTimer[n] + "ms";
					}
					if (n == 1)
					{
						text4 = Main.renderTimer[n] + "ms";
					}
					if (n == 2)
					{
						text4 = Main.renderTimer[n] + "ms";
					}
					if (n == 3)
					{
						text4 = Main.renderTimer[n] + "ms";
					}
					if (n == 4)
					{
						text4 = Main.renderTimer[n] + "ms";
					}
					if (n == 5)
					{
						text4 = Main.renderTimer[n] + "ms";
					}
					if (n == 6)
					{
						text4 = Main.renderTimer[0] + Main.renderTimer[1] + Main.renderTimer[2] + Main.renderTimer[3] + Main.renderTimer[4] + Main.renderTimer[5] + "ms";
					}
					SpriteBatch arg_750_0 = this.spriteBatch;
					SpriteFont arg_750_1 = Main.fontMouseText;
					string arg_750_2 = text4;
					Vector2 arg_750_3 = new Vector2((float)num11, (float)num12);
					Color arg_750_4 = Color.White;
					float arg_750_5 = 0f;
					origin = default(Vector2);
					arg_750_0.DrawString(arg_750_1, arg_750_2, arg_750_3, arg_750_4, arg_750_5, origin, 1f, SpriteEffects.None, 0f);
				}
				for (int num13 = 0; num13 < 6; num13++)
				{
					string text5 = "";
					int num14 = 20;
					int num15 = 346;
					num15 += num13 * 16;
					if (num13 == 0)
					{
						text5 = "Lighting Init:";
					}
					if (num13 == 1)
					{
						text5 = "Lighting Phase #1:";
					}
					if (num13 == 2)
					{
						text5 = "Lighting Phase #2:";
					}
					if (num13 == 3)
					{
						text5 = "Lighting Phase #3";
					}
					if (num13 == 4)
					{
						text5 = "Lighting Phase #4";
					}
					if (num13 == 5)
					{
						text5 = "Total Lighting:";
					}
					SpriteBatch arg_809_0 = this.spriteBatch;
					SpriteFont arg_809_1 = Main.fontMouseText;
					string arg_809_2 = text5;
					Vector2 arg_809_3 = new Vector2((float)num14, (float)num15);
					Color arg_809_4 = Color.White;
					float arg_809_5 = 0f;
					origin = default(Vector2);
					arg_809_0.DrawString(arg_809_1, arg_809_2, arg_809_3, arg_809_4, arg_809_5, origin, 1f, SpriteEffects.None, 0f);
				}
				for (int num16 = 0; num16 < 6; num16++)
				{
					string text6 = "";
					int num17 = 180;
					int num18 = 346;
					num18 += num16 * 16;
					if (num16 == 0)
					{
						text6 = Main.lightTimer[num16] + "ms";
					}
					if (num16 == 1)
					{
						text6 = Main.lightTimer[num16] + "ms";
					}
					if (num16 == 2)
					{
						text6 = Main.lightTimer[num16] + "ms";
					}
					if (num16 == 3)
					{
						text6 = Main.lightTimer[num16] + "ms";
					}
					if (num16 == 4)
					{
						text6 = Main.lightTimer[num16] + "ms";
					}
					if (num16 == 5)
					{
						text6 = Main.lightTimer[0] + Main.lightTimer[1] + Main.lightTimer[2] + Main.lightTimer[3] + Main.lightTimer[4] + "ms";
					}
					SpriteBatch arg_950_0 = this.spriteBatch;
					SpriteFont arg_950_1 = Main.fontMouseText;
					string arg_950_2 = text6;
					Vector2 arg_950_3 = new Vector2((float)num17, (float)num18);
					Color arg_950_4 = Color.White;
					float arg_950_5 = 0f;
					origin = default(Vector2);
					arg_950_0.DrawString(arg_950_1, arg_950_2, arg_950_3, arg_950_4, arg_950_5, origin, 1f, SpriteEffects.None, 0f);
				}
				int num19 = 5;
				for (int num20 = 0; num20 < num19; num20++)
				{
					int num21 = 20;
					int num22 = 456;
					num22 += num20 * 16;
					string text7 = "Render #" + num20 + ":";
					SpriteBatch arg_9DA_0 = this.spriteBatch;
					SpriteFont arg_9DA_1 = Main.fontMouseText;
					string arg_9DA_2 = text7;
					Vector2 arg_9DA_3 = new Vector2((float)num21, (float)num22);
					Color arg_9DA_4 = Color.White;
					float arg_9DA_5 = 0f;
					origin = default(Vector2);
					arg_9DA_0.DrawString(arg_9DA_1, arg_9DA_2, arg_9DA_3, arg_9DA_4, arg_9DA_5, origin, 1f, SpriteEffects.None, 0f);
				}
				for (int num23 = 0; num23 < num19; num23++)
				{
					int num24 = 180;
					int num25 = 456;
					num25 += num23 * 16;
					string text8 = Main.drawTimer[num23] + "ms";
					SpriteBatch arg_A63_0 = this.spriteBatch;
					SpriteFont arg_A63_1 = Main.fontMouseText;
					string arg_A63_2 = text8;
					Vector2 arg_A63_3 = new Vector2((float)num24, (float)num25);
					Color arg_A63_4 = Color.White;
					float arg_A63_5 = 0f;
					origin = default(Vector2);
					arg_A63_0.DrawString(arg_A63_1, arg_A63_2, arg_A63_3, arg_A63_4, arg_A63_5, origin, 1f, SpriteEffects.None, 0f);
				}
				for (int num26 = 0; num26 < num19; num26++)
				{
					int num27 = 230;
					int num28 = 456;
					num28 += num26 * 16;
					string text9 = Main.drawTimerMax[num26] + "ms";
					SpriteBatch arg_AEF_0 = this.spriteBatch;
					SpriteFont arg_AEF_1 = Main.fontMouseText;
					string arg_AEF_2 = text9;
					Vector2 arg_AEF_3 = new Vector2((float)num27, (float)num28);
					Color arg_AEF_4 = Color.White;
					float arg_AEF_5 = 0f;
					origin = default(Vector2);
					arg_AEF_0.DrawString(arg_AEF_1, arg_AEF_2, arg_AEF_3, arg_AEF_4, arg_AEF_5, origin, 1f, SpriteEffects.None, 0f);
				}
				int num29 = 20;
				int num30 = 456 + 16 * num19 + 16;
				string text10 = "Update:";
				SpriteBatch arg_B60_0 = this.spriteBatch;
				SpriteFont arg_B60_1 = Main.fontMouseText;
				string arg_B60_2 = text10;
				Vector2 arg_B60_3 = new Vector2((float)num29, (float)num30);
				Color arg_B60_4 = Color.White;
				float arg_B60_5 = 0f;
				origin = default(Vector2);
				arg_B60_0.DrawString(arg_B60_1, arg_B60_2, arg_B60_3, arg_B60_4, arg_B60_5, origin, 1f, SpriteEffects.None, 0f);
				num29 = 180;
				text10 = Main.upTimer + "ms";
				SpriteBatch arg_BC4_0 = this.spriteBatch;
				SpriteFont arg_BC4_1 = Main.fontMouseText;
				string arg_BC4_2 = text10;
				Vector2 arg_BC4_3 = new Vector2((float)num29, (float)num30);
				Color arg_BC4_4 = Color.White;
				float arg_BC4_5 = 0f;
				origin = default(Vector2);
				arg_BC4_0.DrawString(arg_BC4_1, arg_BC4_2, arg_BC4_3, arg_BC4_4, arg_BC4_5, origin, 1f, SpriteEffects.None, 0f);
				num29 = 230;
				text10 = Main.upTimerMax + "ms";
				SpriteBatch arg_C28_0 = this.spriteBatch;
				SpriteFont arg_C28_1 = Main.fontMouseText;
				string arg_C28_2 = text10;
				Vector2 arg_C28_3 = new Vector2((float)num29, (float)num30);
				Color arg_C28_4 = Color.White;
				float arg_C28_5 = 0f;
				origin = default(Vector2);
				arg_C28_0.DrawString(arg_C28_1, arg_C28_2, arg_C28_3, arg_C28_4, arg_C28_5, origin, 1f, SpriteEffects.None, 0f);
			}
			if (Main.signBubble)
			{
				int num31 = (int)((float)Main.signX - Main.screenPosition.X);
				int num32 = (int)((float)Main.signY - Main.screenPosition.Y);
				SpriteEffects effects = SpriteEffects.None;
				if ((float)Main.signX > Main.player[Main.myPlayer].position.X + (float)Main.player[Main.myPlayer].width)
				{
					effects = SpriteEffects.FlipHorizontally;
					num31 += -8 - Main.chat2Texture.Width;
				}
				else
				{
					num31 += 8;
				}
				num32 -= 22;
				SpriteBatch arg_D23_0 = this.spriteBatch;
				Texture2D arg_D23_1 = Main.chat2Texture;
				Vector2 arg_D23_2 = new Vector2((float)num31, (float)num32);
				Rectangle? arg_D23_3 = new Rectangle?(new Rectangle(0, 0, Main.chat2Texture.Width, Main.chat2Texture.Height));
				Color arg_D23_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
				float arg_D23_5 = 0f;
				origin = default(Vector2);
				arg_D23_0.Draw(arg_D23_1, arg_D23_2, arg_D23_3, arg_D23_4, arg_D23_5, origin, 1f, effects, 0f);
				Main.signBubble = false;
			}
			for (int num33 = 0; num33 < 255; num33++)
			{
				if (Main.player[num33].active && Main.myPlayer != num33 && !Main.player[num33].dead)
				{
					new Rectangle((int)((double)Main.player[num33].position.X + (double)Main.player[num33].width * 0.5 - 16.0), (int)(Main.player[num33].position.Y + (float)Main.player[num33].height - 48f), 32, 48);
					if (Main.player[Main.myPlayer].team > 0 && Main.player[Main.myPlayer].team == Main.player[num33].team)
					{
						new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
						string text11 = Main.player[num33].name;
						if (Main.player[num33].statLife < Main.player[num33].statLifeMax)
						{
							object obj = text11;
							text11 = string.Concat(new object[]
							{
								obj, 
								": ", 
								Main.player[num33].statLife, 
								"/", 
								Main.player[num33].statLifeMax
							});
						}
						Vector2 vector = Main.fontMouseText.MeasureString(text11);
						float num34 = 0f;
						if (Main.player[num33].chatShowTime > 0)
						{
							num34 = -vector.Y;
						}
						float num35 = 0f;
						float num36 = (float)Main.mouseTextColor / 255f;
						Color color = new Color((int)((byte)((float)Main.teamColor[Main.player[num33].team].R * num36)), (int)((byte)((float)Main.teamColor[Main.player[num33].team].G * num36)), (int)((byte)((float)Main.teamColor[Main.player[num33].team].B * num36)), (int)Main.mouseTextColor);
						Vector2 vector2 = new Vector2((float)(Main.screenWidth / 2) + Main.screenPosition.X, (float)(Main.screenHeight / 2) + Main.screenPosition.Y);
						float num37 = Main.player[num33].position.X + (float)(Main.player[num33].width / 2) - vector2.X;
						float num38 = Main.player[num33].position.Y - vector.Y - 2f + num34 - vector2.Y;
						float num39 = (float)Math.Sqrt((double)(num37 * num37 + num38 * num38));
						int num40 = Main.screenHeight;
						if (Main.screenHeight > Main.screenWidth)
						{
							num40 = Main.screenWidth;
						}
						num40 = num40 / 2 - 30;
						if (num40 < 100)
						{
							num40 = 100;
						}
						if (num39 < (float)num40)
						{
							vector.X = Main.player[num33].position.X + (float)(Main.player[num33].width / 2) - vector.X / 2f - Main.screenPosition.X;
							vector.Y = Main.player[num33].position.Y - vector.Y - 2f + num34 - Main.screenPosition.Y;
						}
						else
						{
							num35 = num39;
							num39 = (float)num40 / num39;
							vector.X = (float)(Main.screenWidth / 2) + num37 * num39 - vector.X / 2f;
							vector.Y = (float)(Main.screenHeight / 2) + num38 * num39;
						}
						if (num35 > 0f)
						{
							string text12 = "(" + (int)(num35 / 16f * 2f) + " ft)";
							Vector2 vector3 = Main.fontMouseText.MeasureString(text12);
							vector3.X = vector.X + Main.fontMouseText.MeasureString(text11).X / 2f - vector3.X / 2f;
							vector3.Y = vector.Y + Main.fontMouseText.MeasureString(text11).Y / 2f - vector3.Y / 2f - 20f;
							SpriteBatch arg_11F9_0 = this.spriteBatch;
							SpriteFont arg_11F9_1 = Main.fontMouseText;
							string arg_11F9_2 = text12;
							Vector2 arg_11F9_3 = new Vector2(vector3.X - 2f, vector3.Y);
							Color arg_11F9_4 = Color.Black;
							float arg_11F9_5 = 0f;
							origin = default(Vector2);
							arg_11F9_0.DrawString(arg_11F9_1, arg_11F9_2, arg_11F9_3, arg_11F9_4, arg_11F9_5, origin, 1f, SpriteEffects.None, 0f);
							SpriteBatch arg_1247_0 = this.spriteBatch;
							SpriteFont arg_1247_1 = Main.fontMouseText;
							string arg_1247_2 = text12;
							Vector2 arg_1247_3 = new Vector2(vector3.X + 2f, vector3.Y);
							Color arg_1247_4 = Color.Black;
							float arg_1247_5 = 0f;
							origin = default(Vector2);
							arg_1247_0.DrawString(arg_1247_1, arg_1247_2, arg_1247_3, arg_1247_4, arg_1247_5, origin, 1f, SpriteEffects.None, 0f);
							SpriteBatch arg_1295_0 = this.spriteBatch;
							SpriteFont arg_1295_1 = Main.fontMouseText;
							string arg_1295_2 = text12;
							Vector2 arg_1295_3 = new Vector2(vector3.X, vector3.Y - 2f);
							Color arg_1295_4 = Color.Black;
							float arg_1295_5 = 0f;
							origin = default(Vector2);
							arg_1295_0.DrawString(arg_1295_1, arg_1295_2, arg_1295_3, arg_1295_4, arg_1295_5, origin, 1f, SpriteEffects.None, 0f);
							SpriteBatch arg_12E3_0 = this.spriteBatch;
							SpriteFont arg_12E3_1 = Main.fontMouseText;
							string arg_12E3_2 = text12;
							Vector2 arg_12E3_3 = new Vector2(vector3.X, vector3.Y + 2f);
							Color arg_12E3_4 = Color.Black;
							float arg_12E3_5 = 0f;
							origin = default(Vector2);
							arg_12E3_0.DrawString(arg_12E3_1, arg_12E3_2, arg_12E3_3, arg_12E3_4, arg_12E3_5, origin, 1f, SpriteEffects.None, 0f);
							SpriteBatch arg_1317_0 = this.spriteBatch;
							SpriteFont arg_1317_1 = Main.fontMouseText;
							string arg_1317_2 = text12;
							Vector2 arg_1317_3 = vector3;
							Color arg_1317_4 = color;
							float arg_1317_5 = 0f;
							origin = default(Vector2);
							arg_1317_0.DrawString(arg_1317_1, arg_1317_2, arg_1317_3, arg_1317_4, arg_1317_5, origin, 1f, SpriteEffects.None, 0f);
						}
						SpriteBatch arg_1365_0 = this.spriteBatch;
						SpriteFont arg_1365_1 = Main.fontMouseText;
						string arg_1365_2 = text11;
						Vector2 arg_1365_3 = new Vector2(vector.X - 2f, vector.Y);
						Color arg_1365_4 = Color.Black;
						float arg_1365_5 = 0f;
						origin = default(Vector2);
						arg_1365_0.DrawString(arg_1365_1, arg_1365_2, arg_1365_3, arg_1365_4, arg_1365_5, origin, 1f, SpriteEffects.None, 0f);
						SpriteBatch arg_13B3_0 = this.spriteBatch;
						SpriteFont arg_13B3_1 = Main.fontMouseText;
						string arg_13B3_2 = text11;
						Vector2 arg_13B3_3 = new Vector2(vector.X + 2f, vector.Y);
						Color arg_13B3_4 = Color.Black;
						float arg_13B3_5 = 0f;
						origin = default(Vector2);
						arg_13B3_0.DrawString(arg_13B3_1, arg_13B3_2, arg_13B3_3, arg_13B3_4, arg_13B3_5, origin, 1f, SpriteEffects.None, 0f);
						SpriteBatch arg_1401_0 = this.spriteBatch;
						SpriteFont arg_1401_1 = Main.fontMouseText;
						string arg_1401_2 = text11;
						Vector2 arg_1401_3 = new Vector2(vector.X, vector.Y - 2f);
						Color arg_1401_4 = Color.Black;
						float arg_1401_5 = 0f;
						origin = default(Vector2);
						arg_1401_0.DrawString(arg_1401_1, arg_1401_2, arg_1401_3, arg_1401_4, arg_1401_5, origin, 1f, SpriteEffects.None, 0f);
						SpriteBatch arg_144F_0 = this.spriteBatch;
						SpriteFont arg_144F_1 = Main.fontMouseText;
						string arg_144F_2 = text11;
						Vector2 arg_144F_3 = new Vector2(vector.X, vector.Y + 2f);
						Color arg_144F_4 = Color.Black;
						float arg_144F_5 = 0f;
						origin = default(Vector2);
						arg_144F_0.DrawString(arg_144F_1, arg_144F_2, arg_144F_3, arg_144F_4, arg_144F_5, origin, 1f, SpriteEffects.None, 0f);
						SpriteBatch arg_1483_0 = this.spriteBatch;
						SpriteFont arg_1483_1 = Main.fontMouseText;
						string arg_1483_2 = text11;
						Vector2 arg_1483_3 = vector;
						Color arg_1483_4 = color;
						float arg_1483_5 = 0f;
						origin = default(Vector2);
						arg_1483_0.DrawString(arg_1483_1, arg_1483_2, arg_1483_3, arg_1483_4, arg_1483_5, origin, 1f, SpriteEffects.None, 0f);
					}
				}
			}
			if (Main.playerInventory)
			{
				Main.npcChatText = "";
				Main.player[Main.myPlayer].sign = -1;
			}
			if (Main.ignoreErrors)
			{
				try
				{
					if (Main.npcChatText != "" || Main.player[Main.myPlayer].sign != -1)
					{
						this.DrawChat();
					}
					goto IL_151C;
				}
				catch
				{
					goto IL_151C;
				}
			}
			if (Main.npcChatText != "" || Main.player[Main.myPlayer].sign != -1)
			{
				this.DrawChat();
			}
			IL_151C:
			Color color2 = new Color(220, 220, 220, 220);
			Main.invAlpha += Main.invDir * 0.2f;
			if (Main.invAlpha > 240f)
			{
				Main.invAlpha = 240f;
				Main.invDir = -1f;
			}
			if (Main.invAlpha < 180f)
			{
				Main.invAlpha = 180f;
				Main.invDir = 1f;
			}
			color2 = new Color((int)((byte)Main.invAlpha), (int)((byte)Main.invAlpha), (int)((byte)Main.invAlpha), (int)((byte)Main.invAlpha));
			bool flag = false;
			int rare = 0;
			int num41 = Main.screenWidth - 800;
			int num42 = Main.player[Main.myPlayer].statLifeMax / 20;
			if (num42 >= 10)
			{
				num42 = 10;
			}
			string text13 = string.Concat(new object[]
			{
				"Life: ", 
				Main.player[Main.myPlayer].statLifeMax, 
				"/", 
				Main.player[Main.myPlayer].statLifeMax
			});
			Vector2 vector4 = Main.fontMouseText.MeasureString(text13);
			if (!Main.player[Main.myPlayer].ghost)
			{
				SpriteBatch arg_16D1_0 = this.spriteBatch;
				SpriteFont arg_16D1_1 = Main.fontMouseText;
				string arg_16D1_2 = "Life: ";
				Vector2 arg_16D1_3 = new Vector2((float)(500 + 13 * num42) - vector4.X * 0.5f + (float)num41, 6f);
				Color arg_16D1_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
				float arg_16D1_5 = 0f;
				origin = default(Vector2);
				arg_16D1_0.DrawString(arg_16D1_1, arg_16D1_2, arg_16D1_3, arg_16D1_4, arg_16D1_5, origin, 1f, SpriteEffects.None, 0f);
				this.spriteBatch.DrawString(Main.fontMouseText, Main.player[Main.myPlayer].statLife + "/" + Main.player[Main.myPlayer].statLifeMax, new Vector2((float)(500 + 13 * num42) + vector4.X * 0.5f + (float)num41, 6f), new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), 0f, new Vector2(Main.fontMouseText.MeasureString(Main.player[Main.myPlayer].statLife + "/" + Main.player[Main.myPlayer].statLifeMax).X, 0f), 1f, SpriteEffects.None, 0f);
			}
			int num43 = 20;
			for (int num44 = 1; num44 < Main.player[Main.myPlayer].statLifeMax / num43 + 1; num44++)
			{
				int num45 = 255;
				float num46 = 1f;
				bool flag2 = false;
				if (Main.player[Main.myPlayer].statLife >= num44 * num43)
				{
					num45 = 255;
					if (Main.player[Main.myPlayer].statLife == num44 * num43)
					{
						flag2 = true;
					}
				}
				else
				{
					float num47 = (float)(Main.player[Main.myPlayer].statLife - (num44 - 1) * num43) / (float)num43;
					num45 = (int)(30f + 225f * num47);
					if (num45 < 30)
					{
						num45 = 30;
					}
					num46 = num47 / 4f + 0.75f;
					if ((double)num46 < 0.75)
					{
						num46 = 0.75f;
					}
					if (num47 > 0f)
					{
						flag2 = true;
					}
				}
				if (flag2)
				{
					num46 += Main.cursorScale - 1f;
				}
				int num48 = 0;
				int num49 = 0;
				if (num44 > 10)
				{
					num48 -= 260;
					num49 += 26;
				}
				int a = (int)((double)((float)num45) * 0.9);
				if (!Main.player[Main.myPlayer].ghost)
				{
					this.spriteBatch.Draw(Main.heartTexture, new Vector2((float)(500 + 26 * (num44 - 1) + num48 + num41 + Main.heartTexture.Width / 2), 32f + ((float)Main.heartTexture.Height - (float)Main.heartTexture.Height * num46) / 2f + (float)num49 + (float)(Main.heartTexture.Height / 2)), new Rectangle?(new Rectangle(0, 0, Main.heartTexture.Width, Main.heartTexture.Height)), new Color(num45, num45, num45, a), 0f, new Vector2((float)(Main.heartTexture.Width / 2), (float)(Main.heartTexture.Height / 2)), num46, SpriteEffects.None, 0f);
				}
			}
			int num50 = 20;
			if (Main.player[Main.myPlayer].statManaMax2 > 0)
			{
				int arg_19E7_0 = Main.player[Main.myPlayer].statManaMax2 / 20;
				SpriteBatch arg_1A42_0 = this.spriteBatch;
				SpriteFont arg_1A42_1 = Main.fontMouseText;
				string arg_1A42_2 = "Mana";
				Vector2 arg_1A42_3 = new Vector2((float)(750 + num41), 6f);
				Color arg_1A42_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
				float arg_1A42_5 = 0f;
				origin = default(Vector2);
				arg_1A42_0.DrawString(arg_1A42_1, arg_1A42_2, arg_1A42_3, arg_1A42_4, arg_1A42_5, origin, 1f, SpriteEffects.None, 0f);
				for (int num51 = 1; num51 < Main.player[Main.myPlayer].statManaMax2 / num50 + 1; num51++)
				{
					int num52 = 255;
					bool flag3 = false;
					float num53 = 1f;
					if (Main.player[Main.myPlayer].statMana >= num51 * num50)
					{
						num52 = 255;
						if (Main.player[Main.myPlayer].statMana == num51 * num50)
						{
							flag3 = true;
						}
					}
					else
					{
						float num54 = (float)(Main.player[Main.myPlayer].statMana - (num51 - 1) * num50) / (float)num50;
						num52 = (int)(30f + 225f * num54);
						if (num52 < 30)
						{
							num52 = 30;
						}
						num53 = num54 / 4f + 0.75f;
						if ((double)num53 < 0.75)
						{
							num53 = 0.75f;
						}
						if (num54 > 0f)
						{
							flag3 = true;
						}
					}
					if (flag3)
					{
						num53 += Main.cursorScale - 1f;
					}
					int a2 = (int)((double)((float)num52) * 0.9);
					this.spriteBatch.Draw(Main.manaTexture, new Vector2((float)(775 + num41), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num53) / 2f + (float)(28 * (num51 - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Color(num52, num52, num52, a2), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num53, SpriteEffects.None, 0f);
				}
			}
			if (Main.player[Main.myPlayer].breath < Main.player[Main.myPlayer].breathMax && !Main.player[Main.myPlayer].ghost)
			{
				int num55 = 76;
				int arg_1C4E_0 = Main.player[Main.myPlayer].breathMax / 20;
				SpriteBatch arg_1CCB_0 = this.spriteBatch;
				SpriteFont arg_1CCB_1 = Main.fontMouseText;
				string arg_1CCB_2 = "Breath";
				Vector2 arg_1CCB_3 = new Vector2((float)(500 + 13 * num42) - Main.fontMouseText.MeasureString("Breath").X * 0.5f + (float)num41, (float)(6 + num55));
				Color arg_1CCB_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
				float arg_1CCB_5 = 0f;
				origin = default(Vector2);
				arg_1CCB_0.DrawString(arg_1CCB_1, arg_1CCB_2, arg_1CCB_3, arg_1CCB_4, arg_1CCB_5, origin, 1f, SpriteEffects.None, 0f);
				int num56 = 20;
				for (int num57 = 1; num57 < Main.player[Main.myPlayer].breathMax / num56 + 1; num57++)
				{
					int num58 = 255;
					float num59 = 1f;
					if (Main.player[Main.myPlayer].breath >= num57 * num56)
					{
						num58 = 255;
					}
					else
					{
						float num60 = (float)(Main.player[Main.myPlayer].breath - (num57 - 1) * num56) / (float)num56;
						num58 = (int)(30f + 225f * num60);
						if (num58 < 30)
						{
							num58 = 30;
						}
						num59 = num60 / 4f + 0.75f;
						if ((double)num59 < 0.75)
						{
							num59 = 0.75f;
						}
					}
					int num61 = 0;
					int num62 = 0;
					if (num57 > 10)
					{
						num61 -= 260;
						num62 += 26;
					}
					SpriteBatch arg_1E20_0 = this.spriteBatch;
					Texture2D arg_1E20_1 = Main.bubbleTexture;
					Vector2 arg_1E20_2 = new Vector2((float)(500 + 26 * (num57 - 1) + num61 + num41), 32f + ((float)Main.bubbleTexture.Height - (float)Main.bubbleTexture.Height * num59) / 2f + (float)num62 + (float)num55);
					Rectangle? arg_1E20_3 = new Rectangle?(new Rectangle(0, 0, Main.bubbleTexture.Width, Main.bubbleTexture.Height));
					Color arg_1E20_4 = new Color(num58, num58, num58, num58);
					float arg_1E20_5 = 0f;
					origin = default(Vector2);
					arg_1E20_0.Draw(arg_1E20_1, arg_1E20_2, arg_1E20_3, arg_1E20_4, arg_1E20_5, origin, num59, SpriteEffects.None, 0f);
				}
			}
			Main.buffString = "";
			if (!Main.playerInventory)
			{
				int num63 = -1;
				for (int num64 = 0; num64 < 10; num64++)
				{
					if (Main.player[Main.myPlayer].buffType[num64] > 0)
					{
						int num65 = Main.player[Main.myPlayer].buffType[num64];
						int num66 = 32 + num64 * 38;
						int num67 = 76;
						Color color3 = new Color(Main.buffAlpha[num64], Main.buffAlpha[num64], Main.buffAlpha[num64], Main.buffAlpha[num64]);
						SpriteBatch arg_1F28_0 = this.spriteBatch;
						Texture2D arg_1F28_1 = Main.buffTexture[num65];
						Vector2 arg_1F28_2 = new Vector2((float)num66, (float)num67);
						Rectangle? arg_1F28_3 = new Rectangle?(new Rectangle(0, 0, Main.buffTexture[num65].Width, Main.buffTexture[num65].Height));
						Color arg_1F28_4 = color3;
						float arg_1F28_5 = 0f;
						origin = default(Vector2);
						arg_1F28_0.Draw(arg_1F28_1, arg_1F28_2, arg_1F28_3, arg_1F28_4, arg_1F28_5, origin, 1f, SpriteEffects.None, 0f);
						if (num65 != 28 && num65 != 34 && num65 != 37 && num65 != 38)
						{
							string text14 = "0 s";
							if (Main.player[Main.myPlayer].buffTime[num64] / 60 >= 60)
							{
								text14 = Math.Round((double)(Main.player[Main.myPlayer].buffTime[num64] / 60) / 60.0) + " m";
							}
							else
							{
								text14 = Math.Round((double)Main.player[Main.myPlayer].buffTime[num64] / 60.0) + " s";
							}
							SpriteBatch arg_2025_0 = this.spriteBatch;
							SpriteFont arg_2025_1 = Main.fontItemStack;
							string arg_2025_2 = text14;
							Vector2 arg_2025_3 = new Vector2((float)num66, (float)(num67 + Main.buffTexture[num65].Height));
							Color arg_2025_4 = color3;
							float arg_2025_5 = 0f;
							origin = default(Vector2);
							arg_2025_0.DrawString(arg_2025_1, arg_2025_2, arg_2025_3, arg_2025_4, arg_2025_5, origin, 0.8f, SpriteEffects.None, 0f);
						}
						if (Main.mouseX < num66 + Main.buffTexture[num65].Width && Main.mouseY < num67 + Main.buffTexture[num65].Height && Main.mouseX > num66 && Main.mouseY > num67)
						{
							num63 = num64;
							Main.buffAlpha[num64] += 0.1f;
							if (Main.mouseRight && Main.mouseRightRelease && !Main.debuff[num65])
							{
								Main.PlaySound(12, -1, -1, 1);
								Main.player[Main.myPlayer].DelBuff(num64);
							}
						}
						else
						{
							Main.buffAlpha[num64] -= 0.05f;
						}
						if (Main.buffAlpha[num64] > 1f)
						{
							Main.buffAlpha[num64] = 1f;
						}
						else
						{
							if ((double)Main.buffAlpha[num64] < 0.4)
							{
								Main.buffAlpha[num64] = 0.4f;
							}
						}
					}
					else
					{
						Main.buffAlpha[num64] = 0.4f;
					}
				}
				if (num63 >= 0)
				{
					int num68 = Main.player[Main.myPlayer].buffType[num63];
					if (num68 > 0)
					{
						Main.buffString = Main.buffTip[num68];
						this.MouseText(Main.buffName[num68], 0, 0);
					}
				}
			}
			if (Main.player[Main.myPlayer].dead)
			{
				Main.playerInventory = false;
			}
			if (!Main.playerInventory)
			{
				Main.player[Main.myPlayer].chest = -1;
				Main.craftGuide = false;
				Main.reforge = false;
			}
			string text15 = "";
			if (Main.playerInventory)
			{
				if (Main.netMode == 1)
				{
					int num69 = 675 + Main.screenWidth - 800;
					int num70 = 114;
					if (Main.player[Main.myPlayer].hostile)
					{
						SpriteBatch arg_2279_0 = this.spriteBatch;
						Texture2D arg_2279_1 = Main.itemTexture[4];
						Vector2 arg_2279_2 = new Vector2((float)(num69 - 2), (float)num70);
						Rectangle? arg_2279_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[4].Width, Main.itemTexture[4].Height));
						Color arg_2279_4 = Main.teamColor[Main.player[Main.myPlayer].team];
						float arg_2279_5 = 0f;
						origin = default(Vector2);
						arg_2279_0.Draw(arg_2279_1, arg_2279_2, arg_2279_3, arg_2279_4, arg_2279_5, origin, 1f, SpriteEffects.None, 0f);
						SpriteBatch arg_22F9_0 = this.spriteBatch;
						Texture2D arg_22F9_1 = Main.itemTexture[4];
						Vector2 arg_22F9_2 = new Vector2((float)(num69 + 2), (float)num70);
						Rectangle? arg_22F9_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[4].Width, Main.itemTexture[4].Height));
						Color arg_22F9_4 = Main.teamColor[Main.player[Main.myPlayer].team];
						float arg_22F9_5 = 0f;
						origin = default(Vector2);
						arg_22F9_0.Draw(arg_22F9_1, arg_22F9_2, arg_22F9_3, arg_22F9_4, arg_22F9_5, origin, 1f, SpriteEffects.FlipHorizontally, 0f);
					}
					else
					{
						SpriteBatch arg_2382_0 = this.spriteBatch;
						Texture2D arg_2382_1 = Main.itemTexture[4];
						Vector2 arg_2382_2 = new Vector2((float)(num69 - 16), (float)(num70 + 14));
						Rectangle? arg_2382_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[4].Width, Main.itemTexture[4].Height));
						Color arg_2382_4 = Main.teamColor[Main.player[Main.myPlayer].team];
						float arg_2382_5 = -0.785f;
						origin = default(Vector2);
						arg_2382_0.Draw(arg_2382_1, arg_2382_2, arg_2382_3, arg_2382_4, arg_2382_5, origin, 1f, SpriteEffects.None, 0f);
						SpriteBatch arg_2405_0 = this.spriteBatch;
						Texture2D arg_2405_1 = Main.itemTexture[4];
						Vector2 arg_2405_2 = new Vector2((float)(num69 + 2), (float)(num70 + 14));
						Rectangle? arg_2405_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[4].Width, Main.itemTexture[4].Height));
						Color arg_2405_4 = Main.teamColor[Main.player[Main.myPlayer].team];
						float arg_2405_5 = -0.785f;
						origin = default(Vector2);
						arg_2405_0.Draw(arg_2405_1, arg_2405_2, arg_2405_3, arg_2405_4, arg_2405_5, origin, 1f, SpriteEffects.None, 0f);
					}
					if (Main.mouseX > num69 && Main.mouseX < num69 + 34 && Main.mouseY > num70 - 2 && Main.mouseY < num70 + 34)
					{
						Main.player[Main.myPlayer].mouseInterface = true;
						if (Main.mouseLeft && Main.mouseLeftRelease)
						{
							if (Main.teamCooldown == 0)
							{
								Main.teamCooldown = Main.teamCooldownLen;
								Main.PlaySound(12, -1, -1, 1);
								if (Main.player[Main.myPlayer].hostile)
								{
									Main.player[Main.myPlayer].hostile = false;
								}
								else
								{
									Main.player[Main.myPlayer].hostile = true;
								}
								NetMessage.SendData(30, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
							}
							else
							{
								Main.NewText("You must wait " + (Main.teamCooldown / 60 + 1) + " seconds.", 255, 0, 0);
							}
						}
					}
					num69 -= 3;
					Rectangle value = new Rectangle(Main.mouseX, Main.mouseY, 1, 1);
					int width = Main.teamTexture.Width;
					int height = Main.teamTexture.Height;
					for (int num71 = 0; num71 < 5; num71++)
					{
						Rectangle rectangle = default(Rectangle);
						if (num71 == 0)
						{
							rectangle = new Rectangle(num69 + 50, num70 - 20, width, height);
						}
						if (num71 == 1)
						{
							rectangle = new Rectangle(num69 + 40, num70, width, height);
						}
						if (num71 == 2)
						{
							rectangle = new Rectangle(num69 + 60, num70, width, height);
						}
						if (num71 == 3)
						{
							rectangle = new Rectangle(num69 + 40, num70 + 20, width, height);
						}
						if (num71 == 4)
						{
							rectangle = new Rectangle(num69 + 60, num70 + 20, width, height);
						}
						if (rectangle.Intersects(value))
						{
							Main.player[Main.myPlayer].mouseInterface = true;
							if (Main.mouseLeft && Main.mouseLeftRelease && Main.player[Main.myPlayer].team != num71)
							{
								if (Main.teamCooldown == 0)
								{
									Main.teamCooldown = Main.teamCooldownLen;
									Main.PlaySound(12, -1, -1, 1);
									Main.player[Main.myPlayer].team = num71;
									NetMessage.SendData(45, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
								}
								else
								{
									Main.NewText("You must wait " + (Main.teamCooldown / 60 + 1) + " seconds.", 255, 0, 0);
								}
							}
						}
					}
					SpriteBatch arg_26FE_0 = this.spriteBatch;
					Texture2D arg_26FE_1 = Main.teamTexture;
					Vector2 arg_26FE_2 = new Vector2((float)(num69 + 50), (float)(num70 - 20));
					Rectangle? arg_26FE_3 = new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height));
					Color arg_26FE_4 = Main.teamColor[0];
					float arg_26FE_5 = 0f;
					origin = default(Vector2);
					arg_26FE_0.Draw(arg_26FE_1, arg_26FE_2, arg_26FE_3, arg_26FE_4, arg_26FE_5, origin, 1f, SpriteEffects.None, 0f);
					SpriteBatch arg_276A_0 = this.spriteBatch;
					Texture2D arg_276A_1 = Main.teamTexture;
					Vector2 arg_276A_2 = new Vector2((float)(num69 + 40), (float)num70);
					Rectangle? arg_276A_3 = new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height));
					Color arg_276A_4 = Main.teamColor[1];
					float arg_276A_5 = 0f;
					origin = default(Vector2);
					arg_276A_0.Draw(arg_276A_1, arg_276A_2, arg_276A_3, arg_276A_4, arg_276A_5, origin, 1f, SpriteEffects.None, 0f);
					SpriteBatch arg_27D6_0 = this.spriteBatch;
					Texture2D arg_27D6_1 = Main.teamTexture;
					Vector2 arg_27D6_2 = new Vector2((float)(num69 + 60), (float)num70);
					Rectangle? arg_27D6_3 = new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height));
					Color arg_27D6_4 = Main.teamColor[2];
					float arg_27D6_5 = 0f;
					origin = default(Vector2);
					arg_27D6_0.Draw(arg_27D6_1, arg_27D6_2, arg_27D6_3, arg_27D6_4, arg_27D6_5, origin, 1f, SpriteEffects.None, 0f);
					SpriteBatch arg_2845_0 = this.spriteBatch;
					Texture2D arg_2845_1 = Main.teamTexture;
					Vector2 arg_2845_2 = new Vector2((float)(num69 + 40), (float)(num70 + 20));
					Rectangle? arg_2845_3 = new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height));
					Color arg_2845_4 = Main.teamColor[3];
					float arg_2845_5 = 0f;
					origin = default(Vector2);
					arg_2845_0.Draw(arg_2845_1, arg_2845_2, arg_2845_3, arg_2845_4, arg_2845_5, origin, 1f, SpriteEffects.None, 0f);
					SpriteBatch arg_28B4_0 = this.spriteBatch;
					Texture2D arg_28B4_1 = Main.teamTexture;
					Vector2 arg_28B4_2 = new Vector2((float)(num69 + 60), (float)(num70 + 20));
					Rectangle? arg_28B4_3 = new Rectangle?(new Rectangle(0, 0, Main.teamTexture.Width, Main.teamTexture.Height));
					Color arg_28B4_4 = Main.teamColor[4];
					float arg_28B4_5 = 0f;
					origin = default(Vector2);
					arg_28B4_0.Draw(arg_28B4_1, arg_28B4_2, arg_28B4_3, arg_28B4_4, arg_28B4_5, origin, 1f, SpriteEffects.None, 0f);
				}
				bool flag4 = false;
				Main.inventoryScale = 0.85f;
				int num72 = 448;
				int num73 = 210;
				Color white = new Color(150, 150, 150, 150);
				if (Main.mouseX >= num72 && (float)Main.mouseX <= (float)num72 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num73 && (float)Main.mouseY <= (float)num73 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
				{
					Main.player[Main.myPlayer].mouseInterface = true;
					if (Main.mouseLeftRelease && Main.mouseLeft)
					{
						if (Main.mouseItem.type != 0)
						{
							Main.trashItem.SetDefaults(0, false);
						}
						Item item = Main.mouseItem;
						Main.mouseItem = Main.trashItem;
						Main.trashItem = item;
						if (Main.trashItem.type == 0 || Main.trashItem.stack < 1)
						{
							Main.trashItem = new Item();
						}
						if (Main.mouseItem.IsTheSameAs(Main.trashItem) && Main.trashItem.stack != Main.trashItem.maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
						{
							if (Main.mouseItem.stack + Main.trashItem.stack <= Main.mouseItem.maxStack)
							{
								Main.trashItem.stack += Main.mouseItem.stack;
								Main.mouseItem.stack = 0;
							}
							else
							{
								int num74 = Main.mouseItem.maxStack - Main.trashItem.stack;
								Main.trashItem.stack += num74;
								Main.mouseItem.stack -= num74;
							}
						}
						if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
						{
							Main.mouseItem = new Item();
						}
						if (Main.mouseItem.type > 0 || Main.trashItem.type > 0)
						{
							Main.PlaySound(7, -1, -1, 1);
						}
					}
					if (!flag4)
					{
						text15 = Main.trashItem.name;
						if (Main.trashItem.stack > 1)
						{
							object obj = text15;
							text15 = string.Concat(new object[]
							{
								obj, 
								" (", 
								Main.trashItem.stack, 
								")"
							});
						}
						Main.toolTip = (Item)Main.trashItem.Clone();
						if (text15 == null)
						{
							text15 = "Trash Can";
						}
					}
					else
					{
						text15 = "Trash Can";
					}
				}
				SpriteBatch arg_2BBF_0 = this.spriteBatch;
				Texture2D arg_2BBF_1 = Main.inventoryBack7Texture;
				Vector2 arg_2BBF_2 = new Vector2((float)num72, (float)num73);
				Rectangle? arg_2BBF_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
				Color arg_2BBF_4 = color2;
				float arg_2BBF_5 = 0f;
				origin = default(Vector2);
				arg_2BBF_0.Draw(arg_2BBF_1, arg_2BBF_2, arg_2BBF_3, arg_2BBF_4, arg_2BBF_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
				white = Color.White;
				if (Main.trashItem.type == 0 || Main.trashItem.stack == 0 || flag4)
				{
					white = new Color(100, 100, 100, 100);
					float num75 = Main.inventoryScale;
					SpriteBatch arg_2C95_0 = this.spriteBatch;
					Texture2D arg_2C95_1 = Main.trashTexture;
					Vector2 arg_2C95_2 = new Vector2((float)num72 + 26f * Main.inventoryScale - (float)Main.trashTexture.Width * 0.5f * num75, (float)num73 + 26f * Main.inventoryScale - (float)Main.trashTexture.Height * 0.5f * num75);
					Rectangle? arg_2C95_3 = new Rectangle?(new Rectangle(0, 0, Main.trashTexture.Width, Main.trashTexture.Height));
					Color arg_2C95_4 = white;
					float arg_2C95_5 = 0f;
					origin = default(Vector2);
					arg_2C95_0.Draw(arg_2C95_1, arg_2C95_2, arg_2C95_3, arg_2C95_4, arg_2C95_5, origin, num75, SpriteEffects.None, 0f);
				}
				else
				{
					float num76 = 1f;
					if (Main.itemTexture[Main.trashItem.type].Width > 32 || Main.itemTexture[Main.trashItem.type].Height > 32)
					{
						if (Main.itemTexture[Main.trashItem.type].Width > Main.itemTexture[Main.trashItem.type].Height)
						{
							num76 = 32f / (float)Main.itemTexture[Main.trashItem.type].Width;
						}
						else
						{
							num76 = 32f / (float)Main.itemTexture[Main.trashItem.type].Height;
						}
					}
					num76 *= Main.inventoryScale;
					SpriteBatch arg_2E22_0 = this.spriteBatch;
					Texture2D arg_2E22_1 = Main.itemTexture[Main.trashItem.type];
					Vector2 arg_2E22_2 = new Vector2((float)num72 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.trashItem.type].Width * 0.5f * num76, (float)num73 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.trashItem.type].Height * 0.5f * num76);
					Rectangle? arg_2E22_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.trashItem.type].Width, Main.itemTexture[Main.trashItem.type].Height));
					Color arg_2E22_4 = Main.trashItem.GetAlpha(white);
					float arg_2E22_5 = 0f;
					origin = default(Vector2);
					arg_2E22_0.Draw(arg_2E22_1, arg_2E22_2, arg_2E22_3, arg_2E22_4, arg_2E22_5, origin, num76, SpriteEffects.None, 0f);
					Color arg_2E3F_0 = Main.trashItem.color;
					Color b = default(Color);
					if (arg_2E3F_0 != b)
					{
						SpriteBatch arg_2F1F_0 = this.spriteBatch;
						Texture2D arg_2F1F_1 = Main.itemTexture[Main.trashItem.type];
						Vector2 arg_2F1F_2 = new Vector2((float)num72 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.trashItem.type].Width * 0.5f * num76, (float)num73 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.trashItem.type].Height * 0.5f * num76);
						Rectangle? arg_2F1F_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.trashItem.type].Width, Main.itemTexture[Main.trashItem.type].Height));
						Color arg_2F1F_4 = Main.trashItem.GetColor(white);
						float arg_2F1F_5 = 0f;
						origin = default(Vector2);
						arg_2F1F_0.Draw(arg_2F1F_1, arg_2F1F_2, arg_2F1F_3, arg_2F1F_4, arg_2F1F_5, origin, num76, SpriteEffects.None, 0f);
					}
					if (Main.trashItem.stack > 1)
					{
						SpriteBatch arg_2F90_0 = this.spriteBatch;
						SpriteFont arg_2F90_1 = Main.fontItemStack;
						string arg_2F90_2 = string.Concat(Main.trashItem.stack);
						Vector2 arg_2F90_3 = new Vector2((float)num72 + 10f * Main.inventoryScale, (float)num73 + 26f * Main.inventoryScale);
						Color arg_2F90_4 = white;
						float arg_2F90_5 = 0f;
						origin = default(Vector2);
						arg_2F90_0.DrawString(arg_2F90_1, arg_2F90_2, arg_2F90_3, arg_2F90_4, arg_2F90_5, origin, num76, SpriteEffects.None, 0f);
					}
				}
				SpriteBatch arg_2FEB_0 = this.spriteBatch;
				SpriteFont arg_2FEB_1 = Main.fontMouseText;
				string arg_2FEB_2 = "Inventory";
				Vector2 arg_2FEB_3 = new Vector2(40f, 0f);
				Color arg_2FEB_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
				float arg_2FEB_5 = 0f;
				origin = default(Vector2);
				arg_2FEB_0.DrawString(arg_2FEB_1, arg_2FEB_2, arg_2FEB_3, arg_2FEB_4, arg_2FEB_5, origin, 1f, SpriteEffects.None, 0f);
				Main.inventoryScale = 0.85f;
				if (Main.mouseX > 20 && Main.mouseX < (int)(20f + 560f * Main.inventoryScale) && Main.mouseY > 20 && Main.mouseY < (int)(20f + 224f * Main.inventoryScale))
				{
					Main.player[Main.myPlayer].mouseInterface = true;
				}
				for (int num77 = 0; num77 < 10; num77++)
				{
					for (int num78 = 0; num78 < 4; num78++)
					{
						int num79 = (int)(20f + (float)(num77 * 56) * Main.inventoryScale);
						int num80 = (int)(20f + (float)(num78 * 56) * Main.inventoryScale);
						int num81 = num77 + num78 * 10;
						Color white2 = new Color(100, 100, 100, 100);
						if (Main.mouseX >= num79 && (float)Main.mouseX <= (float)num79 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num80 && (float)Main.mouseY <= (float)num80 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
						{
							Main.player[Main.myPlayer].mouseInterface = true;
							if (Main.mouseLeftRelease && Main.mouseLeft)
							{
								if (Main.keyState.IsKeyDown(Keys.LeftShift))
								{
									if (Main.player[Main.myPlayer].inventory[num81].type > 0)
									{
										if (Main.npcShop > 0)
										{
											if (Main.player[Main.myPlayer].SellItem(Main.player[Main.myPlayer].inventory[num81].value, Main.player[Main.myPlayer].inventory[num81].stack))
											{
												this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[num81]);
												Main.player[Main.myPlayer].inventory[num81].SetDefaults(0, false);
												Main.PlaySound(18, -1, -1, 1);
											}
											else
											{
												if (Main.player[Main.myPlayer].inventory[num81].value == 0)
												{
													this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[num81]);
													Main.player[Main.myPlayer].inventory[num81].SetDefaults(0, false);
													Main.PlaySound(7, -1, -1, 1);
												}
											}
										}
										else
										{
											Recipe.FindRecipes();
											Main.PlaySound(7, -1, -1, 1);
											Main.trashItem = (Item)Main.player[Main.myPlayer].inventory[num81].Clone();
											Main.player[Main.myPlayer].inventory[num81].SetDefaults(0, false);
										}
									}
								}
								else
								{
									if (Main.player[Main.myPlayer].selectedItem != num81 || Main.player[Main.myPlayer].itemAnimation <= 0)
									{
										Item item2 = Main.mouseItem;
										Main.mouseItem = Main.player[Main.myPlayer].inventory[num81];
										Main.player[Main.myPlayer].inventory[num81] = item2;
										if (Main.player[Main.myPlayer].inventory[num81].type == 0 || Main.player[Main.myPlayer].inventory[num81].stack < 1)
										{
											Main.player[Main.myPlayer].inventory[num81] = new Item();
										}
										if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[num81]) && Main.player[Main.myPlayer].inventory[num81].stack != Main.player[Main.myPlayer].inventory[num81].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
										{
											if (Main.mouseItem.stack + Main.player[Main.myPlayer].inventory[num81].stack <= Main.mouseItem.maxStack)
											{
												Main.player[Main.myPlayer].inventory[num81].stack += Main.mouseItem.stack;
												Main.mouseItem.stack = 0;
											}
											else
											{
												int num82 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].inventory[num81].stack;
												Main.player[Main.myPlayer].inventory[num81].stack += num82;
												Main.mouseItem.stack -= num82;
											}
										}
										if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
										{
											Main.mouseItem = new Item();
										}
										if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].inventory[num81].type > 0)
										{
											Recipe.FindRecipes();
											Main.PlaySound(7, -1, -1, 1);
										}
									}
								}
							}
							else
							{
								if (Main.mouseRight && Main.mouseRightRelease && Main.player[Main.myPlayer].inventory[num81].maxStack == 1)
								{
									Main.player[Main.myPlayer].inventory[num81] = Main.armorSwap(Main.player[Main.myPlayer].inventory[num81]);
								}
								else
								{
									if (Main.stackSplit <= 1 && Main.mouseRight && Main.player[Main.myPlayer].inventory[num81].maxStack > 1 && Main.player[Main.myPlayer].inventory[num81].type > 0 && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[num81]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
									{
										if (Main.mouseItem.type == 0)
										{
											Main.mouseItem = (Item)Main.player[Main.myPlayer].inventory[num81].Clone();
											Main.mouseItem.stack = 0;
										}
										Main.mouseItem.stack++;
										Main.player[Main.myPlayer].inventory[num81].stack--;
										if (Main.player[Main.myPlayer].inventory[num81].stack <= 0)
										{
											Main.player[Main.myPlayer].inventory[num81] = new Item();
										}
										Recipe.FindRecipes();
										Main.soundInstanceMenuTick.Stop();
										Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
										Main.PlaySound(12, -1, -1, 1);
										if (Main.stackSplit == 0)
										{
											Main.stackSplit = 15;
										}
										else
										{
											Main.stackSplit = Main.stackDelay;
										}
									}
								}
							}
							text15 = Main.player[Main.myPlayer].inventory[num81].name;
							Main.toolTip = (Item)Main.player[Main.myPlayer].inventory[num81].Clone();
							if (Main.player[Main.myPlayer].inventory[num81].stack > 1)
							{
								object obj = text15;
								text15 = string.Concat(new object[]
								{
									obj, 
									" (", 
									Main.player[Main.myPlayer].inventory[num81].stack, 
									")"
								});
							}
						}
						if (num78 != 0)
						{
							SpriteBatch arg_37C9_0 = this.spriteBatch;
							Texture2D arg_37C9_1 = Main.inventoryBackTexture;
							Vector2 arg_37C9_2 = new Vector2((float)num79, (float)num80);
							Rectangle? arg_37C9_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
							Color arg_37C9_4 = color2;
							float arg_37C9_5 = 0f;
							origin = default(Vector2);
							arg_37C9_0.Draw(arg_37C9_1, arg_37C9_2, arg_37C9_3, arg_37C9_4, arg_37C9_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
						}
						else
						{
							SpriteBatch arg_3826_0 = this.spriteBatch;
							Texture2D arg_3826_1 = Main.inventoryBack9Texture;
							Vector2 arg_3826_2 = new Vector2((float)num79, (float)num80);
							Rectangle? arg_3826_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
							Color arg_3826_4 = color2;
							float arg_3826_5 = 0f;
							origin = default(Vector2);
							arg_3826_0.Draw(arg_3826_1, arg_3826_2, arg_3826_3, arg_3826_4, arg_3826_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
						}
						white2 = Color.White;
						if (Main.player[Main.myPlayer].inventory[num81].type > 0 && Main.player[Main.myPlayer].inventory[num81].stack > 0)
						{
							float num83 = 1f;
							if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Height > 32)
							{
								if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Width > Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Height)
								{
									num83 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Width;
								}
								else
								{
									num83 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Height;
								}
							}
							num83 *= Main.inventoryScale;
							SpriteBatch arg_3A9C_0 = this.spriteBatch;
							Texture2D arg_3A9C_1 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type];
							Vector2 arg_3A9C_2 = new Vector2((float)num79 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Width * 0.5f * num83, (float)num80 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Height * 0.5f * num83);
							Rectangle? arg_3A9C_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Height));
							Color arg_3A9C_4 = Main.player[Main.myPlayer].inventory[num81].GetAlpha(white2);
							float arg_3A9C_5 = 0f;
							origin = default(Vector2);
							arg_3A9C_0.Draw(arg_3A9C_1, arg_3A9C_2, arg_3A9C_3, arg_3A9C_4, arg_3A9C_5, origin, num83, SpriteEffects.None, 0f);
							Color arg_3AC7_0 = Main.player[Main.myPlayer].inventory[num81].color;
							Color b = default(Color);
							if (arg_3AC7_0 != b)
							{
								SpriteBatch arg_3BFB_0 = this.spriteBatch;
								Texture2D arg_3BFB_1 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type];
								Vector2 arg_3BFB_2 = new Vector2((float)num79 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Width * 0.5f * num83, (float)num80 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Height * 0.5f * num83);
								Rectangle? arg_3BFB_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num81].type].Height));
								Color arg_3BFB_4 = Main.player[Main.myPlayer].inventory[num81].GetColor(white2);
								float arg_3BFB_5 = 0f;
								origin = default(Vector2);
								arg_3BFB_0.Draw(arg_3BFB_1, arg_3BFB_2, arg_3BFB_3, arg_3BFB_4, arg_3BFB_5, origin, num83, SpriteEffects.None, 0f);
							}
							if (Main.player[Main.myPlayer].inventory[num81].stack > 1)
							{
								SpriteBatch arg_3C88_0 = this.spriteBatch;
								SpriteFont arg_3C88_1 = Main.fontItemStack;
								string arg_3C88_2 = string.Concat(Main.player[Main.myPlayer].inventory[num81].stack);
								Vector2 arg_3C88_3 = new Vector2((float)num79 + 10f * Main.inventoryScale, (float)num80 + 26f * Main.inventoryScale);
								Color arg_3C88_4 = white2;
								float arg_3C88_5 = 0f;
								origin = default(Vector2);
								arg_3C88_0.DrawString(arg_3C88_1, arg_3C88_2, arg_3C88_3, arg_3C88_4, arg_3C88_5, origin, num83, SpriteEffects.None, 0f);
							}
						}
						if (num78 == 0)
						{
							string text16 = string.Concat(num81 + 1);
							if (text16 == "10")
							{
								text16 = "0";
							}
							Color color4 = color2;
							if (Main.player[Main.myPlayer].selectedItem == num81)
							{
								color4.R = 0;
								color4.B = 0;
								color4.G = 255;
								color4.A = 50;
							}
							SpriteBatch arg_3D38_0 = this.spriteBatch;
							SpriteFont arg_3D38_1 = Main.fontItemStack;
							string arg_3D38_2 = text16;
							Vector2 arg_3D38_3 = new Vector2((float)(num79 + 6), (float)(num80 + 4));
							Color arg_3D38_4 = color4;
							float arg_3D38_5 = 0f;
							origin = default(Vector2);
							arg_3D38_0.DrawString(arg_3D38_1, arg_3D38_2, arg_3D38_3, arg_3D38_4, arg_3D38_5, origin, Main.inventoryScale * 0.8f, SpriteEffects.None, 0f);
						}
					}
				}
				int num84 = 0;
				int num85 = 2;
				int num86 = 32;
				if (!Main.player[Main.myPlayer].hbLocked)
				{
					num84 = 1;
				}
				SpriteBatch arg_3DD8_0 = this.spriteBatch;
				Texture2D arg_3DD8_1 = Main.HBLockTexture[num84];
				Vector2 arg_3DD8_2 = new Vector2((float)num85, (float)num86);
				Rectangle? arg_3DD8_3 = new Rectangle?(new Rectangle(0, 0, Main.HBLockTexture[num84].Width, Main.HBLockTexture[num84].Height));
				Color arg_3DD8_4 = color2;
				float arg_3DD8_5 = 0f;
				origin = default(Vector2);
				arg_3DD8_0.Draw(arg_3DD8_1, arg_3DD8_2, arg_3DD8_3, arg_3DD8_4, arg_3DD8_5, origin, 0.9f, SpriteEffects.None, 0f);
				if (Main.mouseX > num85 && (float)Main.mouseX < (float)num85 + (float)Main.HBLockTexture[num84].Width * 0.9f && Main.mouseY > num86 && (float)Main.mouseY < (float)num86 + (float)Main.HBLockTexture[num84].Height * 0.9f)
				{
					Main.player[Main.myPlayer].mouseInterface = true;
					if (!Main.player[Main.myPlayer].hbLocked)
					{
						this.MouseText("Hotbar unlocked", 0, 0);
						flag = true;
					}
					else
					{
						this.MouseText("Hotbar locked", 0, 0);
						flag = true;
					}
					if (Main.mouseLeft && Main.mouseLeftRelease)
					{
						Main.PlaySound(22, -1, -1, 1);
						if (!Main.player[Main.myPlayer].hbLocked)
						{
							Main.player[Main.myPlayer].hbLocked = true;
						}
						else
						{
							Main.player[Main.myPlayer].hbLocked = false;
						}
					}
				}
				if (Main.armorHide)
				{
					Main.armorAlpha -= 0.1f;
					if (Main.armorAlpha < 0f)
					{
						Main.armorAlpha = 0f;
					}
				}
				else
				{
					Main.armorAlpha += 0.025f;
					if (Main.armorAlpha > 1f)
					{
						Main.armorAlpha = 1f;
					}
				}
				Color color5 = new Color((int)((byte)((float)Main.mouseTextColor * Main.armorAlpha)), (int)((byte)((float)Main.mouseTextColor * Main.armorAlpha)), (int)((byte)((float)Main.mouseTextColor * Main.armorAlpha)), (int)((byte)((float)Main.mouseTextColor * Main.armorAlpha)));
				Main.armorHide = false;
				int num87 = 1;
				int num88 = Main.screenWidth - 152;
				int num89 = 128;
				if (Main.netMode == 0)
				{
					num88 += 72;
				}
				if (this.showNPCs)
				{
					num87 = 0;
				}
				SpriteBatch arg_3FF6_0 = this.spriteBatch;
				Texture2D arg_3FF6_1 = Main.npcToggleTexture[num87];
				Vector2 arg_3FF6_2 = new Vector2((float)num88, (float)num89);
				Rectangle? arg_3FF6_3 = new Rectangle?(new Rectangle(0, 0, Main.npcToggleTexture[num87].Width, Main.npcToggleTexture[num87].Height));
				Color arg_3FF6_4 = Color.White;
				float arg_3FF6_5 = 0f;
				origin = default(Vector2);
				arg_3FF6_0.Draw(arg_3FF6_1, arg_3FF6_2, arg_3FF6_3, arg_3FF6_4, arg_3FF6_5, origin, 0.9f, SpriteEffects.None, 0f);
				if (Main.mouseX > num88 && (float)Main.mouseX < (float)num88 + (float)Main.npcToggleTexture[num87].Width * 0.9f && Main.mouseY > num89 && (float)Main.mouseY < (float)num89 + (float)Main.npcToggleTexture[num87].Height * 0.9f)
				{
					Main.player[Main.myPlayer].mouseInterface = true;
					if (Main.mouseLeft && Main.mouseLeftRelease)
					{
						Main.PlaySound(12, -1, -1, 1);
						if (!this.showNPCs)
						{
							this.showNPCs = true;
						}
						else
						{
							this.showNPCs = false;
						}
					}
				}
				if (this.showNPCs)
				{
					SpriteBatch arg_40FB_0 = this.spriteBatch;
					SpriteFont arg_40FB_1 = Main.fontMouseText;
					string arg_40FB_2 = "Housing";
					Vector2 arg_40FB_3 = new Vector2((float)(Main.screenWidth - 64 - 28 - 3), 152f);
					Color arg_40FB_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float arg_40FB_5 = 0f;
					origin = default(Vector2);
					arg_40FB_0.DrawString(arg_40FB_1, arg_40FB_2, arg_40FB_3, arg_40FB_4, arg_40FB_5, origin, 0.8f, SpriteEffects.None, 0f);
					if (Main.mouseX > Main.screenWidth - 64 - 28 && Main.mouseX < (int)((float)(Main.screenWidth - 64 - 28) + 56f * Main.inventoryScale) && Main.mouseY > 174 && Main.mouseY < (int)(174f + 448f * Main.inventoryScale))
					{
						Main.player[Main.myPlayer].mouseInterface = true;
					}
					int num90 = 0;
					string text17 = "";
					for (int num91 = 0; num91 < 11; num91++)
					{
						bool flag5 = false;
						int num92 = 0;
						if (num91 == 0)
						{
							flag5 = true;
						}
						else
						{
							for (int num93 = 0; num93 < 200; num93++)
							{
								if (Main.npc[num93].active && NPC.TypeToNum(Main.npc[num93].type) == num91)
								{
									flag5 = true;
									num92 = num93;
									break;
								}
							}
						}
						if (flag5)
						{
							int num94 = Main.screenWidth - 64 - 28;
							int num95 = (int)(174f + (float)(num90 * 56) * Main.inventoryScale);
							Color white3 = new Color(100, 100, 100, 100);
							if (Main.screenHeight < 768 && num90 > 5)
							{
								num95 -= (int)(280f * Main.inventoryScale);
								num94 -= 48;
							}
							if (Main.mouseX >= num94 && (float)Main.mouseX <= (float)num94 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num95 && (float)Main.mouseY <= (float)num95 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
							{
								flag = true;
								if (num91 == 0)
								{
									text17 = "Housing Query";
								}
								else
								{
									text17 = Main.npc[num92].displayName + " the " + Main.npc[num92].name;
								}
								Main.player[Main.myPlayer].mouseInterface = true;
								if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseItem.type == 0)
								{
									Main.PlaySound(12, -1, -1, 1);
									this.mouseNPC = num91;
									Main.mouseLeftRelease = false;
								}
							}
							SpriteBatch arg_4350_0 = this.spriteBatch;
							Texture2D arg_4350_1 = Main.inventoryBack11Texture;
							Vector2 arg_4350_2 = new Vector2((float)num94, (float)num95);
							Rectangle? arg_4350_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
							Color arg_4350_4 = color2;
							float arg_4350_5 = 0f;
							origin = default(Vector2);
							arg_4350_0.Draw(arg_4350_1, arg_4350_2, arg_4350_3, arg_4350_4, arg_4350_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
							white3 = Color.White;
							int num96 = num91;
							float scale = 1f;
							float num97 = 0f;
							if (Main.npcHeadTexture[num96].Width > Main.npcHeadTexture[num96].Height)
							{
								num97 = (float)Main.npcHeadTexture[num96].Width;
							}
							else
							{
								num97 = (float)Main.npcHeadTexture[num96].Height;
							}
							if (num97 > 36f)
							{
								scale = 36f / num97;
							}
							this.spriteBatch.Draw(Main.npcHeadTexture[num96], new Vector2((float)num94 + 26f * Main.inventoryScale, (float)num95 + 26f * Main.inventoryScale), new Rectangle?(new Rectangle(0, 0, Main.npcHeadTexture[num96].Width, Main.npcHeadTexture[num96].Height)), white3, 0f, new Vector2((float)(Main.npcHeadTexture[num96].Width / 2), (float)(Main.npcHeadTexture[num96].Height / 2)), scale, SpriteEffects.None, 0f);
							num90++;
						}
					}
					if (text17 != "" && Main.mouseItem.type == 0)
					{
						this.MouseText(text17, 0, 0);
					}
				}
				else
				{
					SpriteBatch arg_44F2_0 = this.spriteBatch;
					SpriteFont arg_44F2_1 = Main.fontMouseText;
					string arg_44F2_2 = "Equip";
					Vector2 arg_44F2_3 = new Vector2((float)(Main.screenWidth - 64 - 28 + 4), 152f);
					Color arg_44F2_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float arg_44F2_5 = 0f;
					origin = default(Vector2);
					arg_44F2_0.DrawString(arg_44F2_1, arg_44F2_2, arg_44F2_3, arg_44F2_4, arg_44F2_5, origin, 0.8f, SpriteEffects.None, 0f);
					if (Main.mouseX > Main.screenWidth - 64 - 28 && Main.mouseX < (int)((float)(Main.screenWidth - 64 - 28) + 56f * Main.inventoryScale) && Main.mouseY > 174 && Main.mouseY < (int)(174f + 448f * Main.inventoryScale))
					{
						Main.player[Main.myPlayer].mouseInterface = true;
					}
					for (int num98 = 0; num98 < 8; num98++)
					{
						int num99 = Main.screenWidth - 64 - 28;
						int num100 = (int)(174f + (float)(num98 * 56) * Main.inventoryScale);
						Color white4 = new Color(100, 100, 100, 100);
						string text18 = "";
						if (num98 == 3)
						{
							text18 = "Accessories";
						}
						if (num98 == 7)
						{
							text18 = Main.player[Main.myPlayer].statDefense + " Defense";
						}
						Vector2 vector5 = Main.fontMouseText.MeasureString(text18);
						SpriteBatch arg_4645_0 = this.spriteBatch;
						SpriteFont arg_4645_1 = Main.fontMouseText;
						string arg_4645_2 = text18;
						Vector2 arg_4645_3 = new Vector2((float)num99 - vector5.X - 10f, (float)num100 + (float)Main.inventoryBackTexture.Height * 0.5f - vector5.Y * 0.5f);
						Color arg_4645_4 = color5;
						float arg_4645_5 = 0f;
						origin = default(Vector2);
						arg_4645_0.DrawString(arg_4645_1, arg_4645_2, arg_4645_3, arg_4645_4, arg_4645_5, origin, 1f, SpriteEffects.None, 0f);
						if (Main.mouseX >= num99 && (float)Main.mouseX <= (float)num99 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num100 && (float)Main.mouseY <= (float)num100 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
						{
							Main.armorHide = true;
							Main.player[Main.myPlayer].mouseInterface = true;
							if (Main.mouseLeftRelease && Main.mouseLeft && (Main.mouseItem.type == 0 || (Main.mouseItem.headSlot > -1 && num98 == 0) || (Main.mouseItem.bodySlot > -1 && num98 == 1) || (Main.mouseItem.legSlot > -1 && num98 == 2) || (Main.mouseItem.accessory && num98 > 2 && !Main.AccCheck(Main.mouseItem, num98))))
							{
								Item item3 = Main.mouseItem;
								Main.mouseItem = Main.player[Main.myPlayer].armor[num98];
								Main.player[Main.myPlayer].armor[num98] = item3;
								if (Main.player[Main.myPlayer].armor[num98].type == 0 || Main.player[Main.myPlayer].armor[num98].stack < 1)
								{
									Main.player[Main.myPlayer].armor[num98] = new Item();
								}
								if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
								{
									Main.mouseItem = new Item();
								}
								if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].armor[num98].type > 0)
								{
									Recipe.FindRecipes();
									Main.PlaySound(7, -1, -1, 1);
								}
							}
							text15 = Main.player[Main.myPlayer].armor[num98].name;
							Main.toolTip = (Item)Main.player[Main.myPlayer].armor[num98].Clone();
							if (num98 <= 2)
							{
								Main.toolTip.wornArmor = true;
							}
							if (Main.player[Main.myPlayer].armor[num98].stack > 1)
							{
								object obj = text15;
								text15 = string.Concat(new object[]
								{
									obj, 
									" (", 
									Main.player[Main.myPlayer].armor[num98].stack, 
									")"
								});
							}
						}
						SpriteBatch arg_492B_0 = this.spriteBatch;
						Texture2D arg_492B_1 = Main.inventoryBack3Texture;
						Vector2 arg_492B_2 = new Vector2((float)num99, (float)num100);
						Rectangle? arg_492B_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
						Color arg_492B_4 = color2;
						float arg_492B_5 = 0f;
						origin = default(Vector2);
						arg_492B_0.Draw(arg_492B_1, arg_492B_2, arg_492B_3, arg_492B_4, arg_492B_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
						white4 = Color.White;
						if (Main.player[Main.myPlayer].armor[num98].type > 0 && Main.player[Main.myPlayer].armor[num98].stack > 0)
						{
							float num101 = 1f;
							if (Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Height > 32)
							{
								if (Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Width > Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Height)
								{
									num101 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Width;
								}
								else
								{
									num101 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Height;
								}
							}
							num101 *= Main.inventoryScale;
							SpriteBatch arg_4BA1_0 = this.spriteBatch;
							Texture2D arg_4BA1_1 = Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type];
							Vector2 arg_4BA1_2 = new Vector2((float)num99 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Width * 0.5f * num101, (float)num100 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Height * 0.5f * num101);
							Rectangle? arg_4BA1_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Height));
							Color arg_4BA1_4 = Main.player[Main.myPlayer].armor[num98].GetAlpha(white4);
							float arg_4BA1_5 = 0f;
							origin = default(Vector2);
							arg_4BA1_0.Draw(arg_4BA1_1, arg_4BA1_2, arg_4BA1_3, arg_4BA1_4, arg_4BA1_5, origin, num101, SpriteEffects.None, 0f);
							Color arg_4BCC_0 = Main.player[Main.myPlayer].armor[num98].color;
							Color b = default(Color);
							if (arg_4BCC_0 != b)
							{
								SpriteBatch arg_4D00_0 = this.spriteBatch;
								Texture2D arg_4D00_1 = Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type];
								Vector2 arg_4D00_2 = new Vector2((float)num99 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Width * 0.5f * num101, (float)num100 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Height * 0.5f * num101);
								Rectangle? arg_4D00_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[num98].type].Height));
								Color arg_4D00_4 = Main.player[Main.myPlayer].armor[num98].GetColor(white4);
								float arg_4D00_5 = 0f;
								origin = default(Vector2);
								arg_4D00_0.Draw(arg_4D00_1, arg_4D00_2, arg_4D00_3, arg_4D00_4, arg_4D00_5, origin, num101, SpriteEffects.None, 0f);
							}
							if (Main.player[Main.myPlayer].armor[num98].stack > 1)
							{
								SpriteBatch arg_4D8D_0 = this.spriteBatch;
								SpriteFont arg_4D8D_1 = Main.fontItemStack;
								string arg_4D8D_2 = string.Concat(Main.player[Main.myPlayer].armor[num98].stack);
								Vector2 arg_4D8D_3 = new Vector2((float)num99 + 10f * Main.inventoryScale, (float)num100 + 26f * Main.inventoryScale);
								Color arg_4D8D_4 = white4;
								float arg_4D8D_5 = 0f;
								origin = default(Vector2);
								arg_4D8D_0.DrawString(arg_4D8D_1, arg_4D8D_2, arg_4D8D_3, arg_4D8D_4, arg_4D8D_5, origin, num101, SpriteEffects.None, 0f);
							}
						}
					}
					SpriteBatch arg_4E00_0 = this.spriteBatch;
					SpriteFont arg_4E00_1 = Main.fontMouseText;
					string arg_4E00_2 = "Social";
					Vector2 arg_4E00_3 = new Vector2((float)(Main.screenWidth - 64 - 28 - 44), 152f);
					Color arg_4E00_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float arg_4E00_5 = 0f;
					origin = default(Vector2);
					arg_4E00_0.DrawString(arg_4E00_1, arg_4E00_2, arg_4E00_3, arg_4E00_4, arg_4E00_5, origin, 0.8f, SpriteEffects.None, 0f);
					if (Main.mouseX > Main.screenWidth - 64 - 28 - 47 && Main.mouseX < (int)((float)(Main.screenWidth - 64 - 20 - 47) + 56f * Main.inventoryScale) && Main.mouseY > 174 && Main.mouseY < (int)(174f + 168f * Main.inventoryScale))
					{
						Main.player[Main.myPlayer].mouseInterface = true;
					}
					for (int num102 = 8; num102 < 11; num102++)
					{
						int num103 = Main.screenWidth - 64 - 28 - 47;
						int num104 = (int)(174f + (float)((num102 - 8) * 56) * Main.inventoryScale);
						Color white5 = new Color(100, 100, 100, 100);
						string text19 = "";
						if (num102 == 8)
						{
							text19 = "Helmet";
						}
						else
						{
							if (num102 == 9)
							{
								text19 = "Shirt";
							}
							else
							{
								if (num102 == 10)
								{
									text19 = "Pants";
								}
							}
						}
						Vector2 vector6 = Main.fontMouseText.MeasureString(text19);
						SpriteBatch arg_4F56_0 = this.spriteBatch;
						SpriteFont arg_4F56_1 = Main.fontMouseText;
						string arg_4F56_2 = text19;
						Vector2 arg_4F56_3 = new Vector2((float)num103 - vector6.X - 10f, (float)num104 + (float)Main.inventoryBackTexture.Height * 0.5f - vector6.Y * 0.5f);
						Color arg_4F56_4 = color5;
						float arg_4F56_5 = 0f;
						origin = default(Vector2);
						arg_4F56_0.DrawString(arg_4F56_1, arg_4F56_2, arg_4F56_3, arg_4F56_4, arg_4F56_5, origin, 1f, SpriteEffects.None, 0f);
						if (Main.mouseX >= num103 && (float)Main.mouseX <= (float)num103 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num104 && (float)Main.mouseY <= (float)num104 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
						{
							Main.player[Main.myPlayer].mouseInterface = true;
							Main.armorHide = true;
							if (Main.mouseLeftRelease && Main.mouseLeft)
							{
								if (Main.mouseItem.type == 0 || (Main.mouseItem.headSlot > -1 && num102 == 8) || (Main.mouseItem.bodySlot > -1 && num102 == 9) || (Main.mouseItem.legSlot > -1 && num102 == 10))
								{
									Item item4 = Main.mouseItem;
									Main.mouseItem = Main.player[Main.myPlayer].armor[num102];
									Main.player[Main.myPlayer].armor[num102] = item4;
									if (Main.player[Main.myPlayer].armor[num102].type == 0 || Main.player[Main.myPlayer].armor[num102].stack < 1)
									{
										Main.player[Main.myPlayer].armor[num102] = new Item();
									}
									if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
									{
										Main.mouseItem = new Item();
									}
									if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].armor[num102].type > 0)
									{
										Recipe.FindRecipes();
										Main.PlaySound(7, -1, -1, 1);
									}
								}
							}
							else
							{
								if (Main.mouseRight && Main.mouseRightRelease && Main.player[Main.myPlayer].armor[num102].maxStack == 1)
								{
									Main.player[Main.myPlayer].armor[num102] = Main.armorSwap(Main.player[Main.myPlayer].armor[num102]);
								}
							}
							text15 = Main.player[Main.myPlayer].armor[num102].name;
							Main.toolTip = (Item)Main.player[Main.myPlayer].armor[num102].Clone();
							Main.toolTip.social = true;
							if (num102 <= 2)
							{
								Main.toolTip.wornArmor = true;
							}
							if (Main.player[Main.myPlayer].armor[num102].stack > 1)
							{
								object obj = text15;
								text15 = string.Concat(new object[]
								{
									obj, 
									" (", 
									Main.player[Main.myPlayer].armor[num102].stack, 
									")"
								});
							}
						}
						SpriteBatch arg_527E_0 = this.spriteBatch;
						Texture2D arg_527E_1 = Main.inventoryBack8Texture;
						Vector2 arg_527E_2 = new Vector2((float)num103, (float)num104);
						Rectangle? arg_527E_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
						Color arg_527E_4 = color2;
						float arg_527E_5 = 0f;
						origin = default(Vector2);
						arg_527E_0.Draw(arg_527E_1, arg_527E_2, arg_527E_3, arg_527E_4, arg_527E_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
						white5 = Color.White;
						if (Main.player[Main.myPlayer].armor[num102].type > 0 && Main.player[Main.myPlayer].armor[num102].stack > 0)
						{
							float num105 = 1f;
							if (Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Height > 32)
							{
								if (Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Width > Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Height)
								{
									num105 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Width;
								}
								else
								{
									num105 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Height;
								}
							}
							num105 *= Main.inventoryScale;
							SpriteBatch arg_54F4_0 = this.spriteBatch;
							Texture2D arg_54F4_1 = Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type];
							Vector2 arg_54F4_2 = new Vector2((float)num103 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Width * 0.5f * num105, (float)num104 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Height * 0.5f * num105);
							Rectangle? arg_54F4_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Height));
							Color arg_54F4_4 = Main.player[Main.myPlayer].armor[num102].GetAlpha(white5);
							float arg_54F4_5 = 0f;
							origin = default(Vector2);
							arg_54F4_0.Draw(arg_54F4_1, arg_54F4_2, arg_54F4_3, arg_54F4_4, arg_54F4_5, origin, num105, SpriteEffects.None, 0f);
							Color arg_551F_0 = Main.player[Main.myPlayer].armor[num102].color;
							Color b = default(Color);
							if (arg_551F_0 != b)
							{
								SpriteBatch arg_5653_0 = this.spriteBatch;
								Texture2D arg_5653_1 = Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type];
								Vector2 arg_5653_2 = new Vector2((float)num103 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Width * 0.5f * num105, (float)num104 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Height * 0.5f * num105);
								Rectangle? arg_5653_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Width, Main.itemTexture[Main.player[Main.myPlayer].armor[num102].type].Height));
								Color arg_5653_4 = Main.player[Main.myPlayer].armor[num102].GetColor(white5);
								float arg_5653_5 = 0f;
								origin = default(Vector2);
								arg_5653_0.Draw(arg_5653_1, arg_5653_2, arg_5653_3, arg_5653_4, arg_5653_5, origin, num105, SpriteEffects.None, 0f);
							}
							if (Main.player[Main.myPlayer].armor[num102].stack > 1)
							{
								SpriteBatch arg_56E0_0 = this.spriteBatch;
								SpriteFont arg_56E0_1 = Main.fontItemStack;
								string arg_56E0_2 = string.Concat(Main.player[Main.myPlayer].armor[num102].stack);
								Vector2 arg_56E0_3 = new Vector2((float)num103 + 10f * Main.inventoryScale, (float)num104 + 26f * Main.inventoryScale);
								Color arg_56E0_4 = white5;
								float arg_56E0_5 = 0f;
								origin = default(Vector2);
								arg_56E0_0.DrawString(arg_56E0_1, arg_56E0_2, arg_56E0_3, arg_56E0_4, arg_56E0_5, origin, num105, SpriteEffects.None, 0f);
							}
						}
					}
				}
				int num106 = (Main.screenHeight - 600) / 2;
				int num107 = (int)((float)Main.screenHeight / 600f * 250f);
				if (Main.craftingHide)
				{
					Main.craftingAlpha -= 0.1f;
					if (Main.craftingAlpha < 0f)
					{
						Main.craftingAlpha = 0f;
					}
				}
				else
				{
					Main.craftingAlpha += 0.025f;
					if (Main.craftingAlpha > 1f)
					{
						Main.craftingAlpha = 1f;
					}
				}
				Color color6 = new Color((int)((byte)((float)Main.mouseTextColor * Main.craftingAlpha)), (int)((byte)((float)Main.mouseTextColor * Main.craftingAlpha)), (int)((byte)((float)Main.mouseTextColor * Main.craftingAlpha)), (int)((byte)((float)Main.mouseTextColor * Main.craftingAlpha)));
				Main.craftingHide = false;
				if (Main.reforge)
				{
					if (Main.mouseReforge)
					{
						if ((double)Main.reforgeScale < 1.3)
						{
							Main.reforgeScale += 0.02f;
						}
					}
					else
					{
						if (Main.reforgeScale > 1f)
						{
							Main.reforgeScale -= 0.02f;
						}
					}
					if (Main.player[Main.myPlayer].chest != -1 || Main.npcShop != 0 || Main.player[Main.myPlayer].talkNPC == -1 || Main.craftGuide)
					{
						Main.reforge = false;
						Main.player[Main.myPlayer].dropItemCheck();
						Recipe.FindRecipes();
					}
					else
					{
						int num108 = 101;
						int num109 = 241;
						string text20 = "Cost: ";
						if (Main.reforgeItem.type > 0)
						{
							int value2 = Main.reforgeItem.value;
							string text21 = "";
							int num110 = 0;
							int num111 = 0;
							int num112 = 0;
							int num113 = 0;
							int num114 = value2;
							if (num114 < 1)
							{
								num114 = 1;
							}
							if (num114 >= 1000000)
							{
								num110 = num114 / 1000000;
								num114 -= num110 * 1000000;
							}
							if (num114 >= 10000)
							{
								num111 = num114 / 10000;
								num114 -= num111 * 10000;
							}
							if (num114 >= 100)
							{
								num112 = num114 / 100;
								num114 -= num112 * 100;
							}
							if (num114 >= 1)
							{
								num113 = num114;
							}
							if (num110 > 0)
							{
								text21 = text21 + num110 + " platinum ";
							}
							if (num111 > 0)
							{
								text21 = text21 + num111 + " gold ";
							}
							if (num112 > 0)
							{
								text21 = text21 + num112 + " silver ";
							}
							if (num113 > 0)
							{
								text21 = text21 + num113 + " copper ";
							}
							float num115 = (float)Main.mouseTextColor / 255f;
							Color white6 = Color.White;
							if (num110 > 0)
							{
								white6 = new Color((int)((byte)(220f * num115)), (int)((byte)(220f * num115)), (int)((byte)(198f * num115)), (int)Main.mouseTextColor);
							}
							else
							{
								if (num111 > 0)
								{
									white6 = new Color((int)((byte)(224f * num115)), (int)((byte)(201f * num115)), (int)((byte)(92f * num115)), (int)Main.mouseTextColor);
								}
								else
								{
									if (num112 > 0)
									{
										white6 = new Color((int)((byte)(181f * num115)), (int)((byte)(192f * num115)), (int)((byte)(193f * num115)), (int)Main.mouseTextColor);
									}
									else
									{
										if (num113 > 0)
										{
											white6 = new Color((int)((byte)(246f * num115)), (int)((byte)(138f * num115)), (int)((byte)(96f * num115)), (int)Main.mouseTextColor);
										}
									}
								}
							}
							SpriteBatch arg_5A82_0 = this.spriteBatch;
							SpriteFont arg_5A82_1 = Main.fontMouseText;
							string arg_5A82_2 = text21;
							Vector2 arg_5A82_3 = new Vector2((float)(num108 + 50) + Main.fontMouseText.MeasureString(text20).X, (float)num109);
							Color arg_5A82_4 = white6;
							float arg_5A82_5 = 0f;
							origin = default(Vector2);
							arg_5A82_0.DrawString(arg_5A82_1, arg_5A82_2, arg_5A82_3, arg_5A82_4, arg_5A82_5, origin, 1f, SpriteEffects.None, 0f);
							int num116 = num108 + 70;
							int num117 = num109 + 40;
							this.spriteBatch.Draw(Main.reforgeTexture, new Vector2((float)num116, (float)num117), new Rectangle?(new Rectangle(0, 0, Main.reforgeTexture.Width, Main.reforgeTexture.Height)), Color.White, 0f, new Vector2((float)(Main.reforgeTexture.Width / 2), (float)(Main.reforgeTexture.Height / 2)), Main.reforgeScale, SpriteEffects.None, 0f);
							if (Main.mouseX > num116 - Main.reforgeTexture.Width / 2 && Main.mouseX < num116 + Main.reforgeTexture.Width / 2 && Main.mouseY > num117 - Main.reforgeTexture.Height / 2 && Main.mouseY < num117 + Main.reforgeTexture.Height / 2)
							{
								text15 = "Reforge";
								if (!Main.mouseReforge)
								{
									Main.PlaySound(12, -1, -1, 1);
								}
								Main.mouseReforge = true;
								Main.player[Main.myPlayer].mouseInterface = true;
								if (Main.mouseLeftRelease && Main.mouseLeft && Main.player[Main.myPlayer].BuyItem(value2))
								{
									Main.reforgeItem.SetDefaults(Main.reforgeItem.name);
									Main.reforgeItem.Prefix(-2);
									Main.reforgeItem.position.X = Main.player[Main.myPlayer].position.X + (float)(Main.player[Main.myPlayer].width / 2) - (float)(Main.reforgeItem.width / 2);
									Main.reforgeItem.position.Y = Main.player[Main.myPlayer].position.Y + (float)(Main.player[Main.myPlayer].height / 2) - (float)(Main.reforgeItem.height / 2);
									ItemText.NewText(Main.reforgeItem, Main.reforgeItem.stack);
									Main.PlaySound(2, -1, -1, 37);
								}
							}
							else
							{
								Main.mouseReforge = false;
							}
						}
						else
						{
							text20 = "Place an item here to reforge";
						}
						SpriteBatch arg_5CF0_0 = this.spriteBatch;
						SpriteFont arg_5CF0_1 = Main.fontMouseText;
						string arg_5CF0_2 = text20;
						Vector2 arg_5CF0_3 = new Vector2((float)(num108 + 50), (float)num109);
						Color arg_5CF0_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
						float arg_5CF0_5 = 0f;
						origin = default(Vector2);
						arg_5CF0_0.DrawString(arg_5CF0_1, arg_5CF0_2, arg_5CF0_3, arg_5CF0_4, arg_5CF0_5, origin, 1f, SpriteEffects.None, 0f);
						Color white7 = new Color(100, 100, 100, 100);
						if (Main.mouseX >= num108 && (float)Main.mouseX <= (float)num108 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num109 && (float)Main.mouseY <= (float)num109 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
						{
							Main.player[Main.myPlayer].mouseInterface = true;
							Main.craftingHide = true;
							if (Main.mouseItem.Prefix(-3) || Main.mouseItem.type == 0)
							{
								if (Main.mouseLeftRelease && Main.mouseLeft)
								{
									Item item5 = Main.mouseItem;
									Main.mouseItem = Main.reforgeItem;
									Main.reforgeItem = item5;
									if (Main.reforgeItem.type == 0 || Main.reforgeItem.stack < 1)
									{
										Main.reforgeItem = new Item();
									}
									if (Main.mouseItem.IsTheSameAs(Main.reforgeItem) && Main.reforgeItem.stack != Main.reforgeItem.maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
									{
										if (Main.mouseItem.stack + Main.reforgeItem.stack <= Main.mouseItem.maxStack)
										{
											Main.reforgeItem.stack += Main.mouseItem.stack;
											Main.mouseItem.stack = 0;
										}
										else
										{
											int num118 = Main.mouseItem.maxStack - Main.reforgeItem.stack;
											Main.reforgeItem.stack += num118;
											Main.mouseItem.stack -= num118;
										}
									}
									if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
									{
										Main.mouseItem = new Item();
									}
									if (Main.mouseItem.type > 0 || Main.reforgeItem.type > 0)
									{
										Recipe.FindRecipes();
										Main.PlaySound(7, -1, -1, 1);
									}
								}
								else
								{
									if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(Main.reforgeItem) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
									{
										if (Main.mouseItem.type == 0)
										{
											Main.mouseItem = (Item)Main.reforgeItem.Clone();
											Main.mouseItem.stack = 0;
										}
										Main.mouseItem.stack++;
										Main.reforgeItem.stack--;
										if (Main.reforgeItem.stack <= 0)
										{
											Main.reforgeItem = new Item();
										}
										Recipe.FindRecipes();
										Main.soundInstanceMenuTick.Stop();
										Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
										Main.PlaySound(12, -1, -1, 1);
										if (Main.stackSplit == 0)
										{
											Main.stackSplit = 15;
										}
										else
										{
											Main.stackSplit = Main.stackDelay;
										}
									}
								}
							}
							text15 = Main.reforgeItem.name;
							Main.toolTip = (Item)Main.reforgeItem.Clone();
							if (Main.reforgeItem.stack > 1)
							{
								object obj = text15;
								text15 = string.Concat(new object[]
								{
									obj, 
									" (", 
									Main.reforgeItem.stack, 
									")"
								});
							}
						}
						SpriteBatch arg_60D3_0 = this.spriteBatch;
						Texture2D arg_60D3_1 = Main.inventoryBack4Texture;
						Vector2 arg_60D3_2 = new Vector2((float)num108, (float)num109);
						Rectangle? arg_60D3_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
						Color arg_60D3_4 = color2;
						float arg_60D3_5 = 0f;
						origin = default(Vector2);
						arg_60D3_0.Draw(arg_60D3_1, arg_60D3_2, arg_60D3_3, arg_60D3_4, arg_60D3_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
						white7 = Color.White;
						if (Main.reforgeItem.type > 0 && Main.reforgeItem.stack > 0)
						{
							float num119 = 1f;
							if (Main.itemTexture[Main.reforgeItem.type].Width > 32 || Main.itemTexture[Main.reforgeItem.type].Height > 32)
							{
								if (Main.itemTexture[Main.reforgeItem.type].Width > Main.itemTexture[Main.reforgeItem.type].Height)
								{
									num119 = 32f / (float)Main.itemTexture[Main.reforgeItem.type].Width;
								}
								else
								{
									num119 = 32f / (float)Main.itemTexture[Main.reforgeItem.type].Height;
								}
							}
							num119 *= Main.inventoryScale;
							SpriteBatch arg_6282_0 = this.spriteBatch;
							Texture2D arg_6282_1 = Main.itemTexture[Main.reforgeItem.type];
							Vector2 arg_6282_2 = new Vector2((float)num108 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.reforgeItem.type].Width * 0.5f * num119, (float)num109 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.reforgeItem.type].Height * 0.5f * num119);
							Rectangle? arg_6282_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.reforgeItem.type].Width, Main.itemTexture[Main.reforgeItem.type].Height));
							Color arg_6282_4 = Main.reforgeItem.GetAlpha(white7);
							float arg_6282_5 = 0f;
							origin = default(Vector2);
							arg_6282_0.Draw(arg_6282_1, arg_6282_2, arg_6282_3, arg_6282_4, arg_6282_5, origin, num119, SpriteEffects.None, 0f);
							Color arg_629F_0 = Main.reforgeItem.color;
							Color b = default(Color);
							if (arg_629F_0 != b)
							{
								SpriteBatch arg_637F_0 = this.spriteBatch;
								Texture2D arg_637F_1 = Main.itemTexture[Main.reforgeItem.type];
								Vector2 arg_637F_2 = new Vector2((float)num108 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.reforgeItem.type].Width * 0.5f * num119, (float)num109 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.reforgeItem.type].Height * 0.5f * num119);
								Rectangle? arg_637F_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.reforgeItem.type].Width, Main.itemTexture[Main.reforgeItem.type].Height));
								Color arg_637F_4 = Main.reforgeItem.GetColor(white7);
								float arg_637F_5 = 0f;
								origin = default(Vector2);
								arg_637F_0.Draw(arg_637F_1, arg_637F_2, arg_637F_3, arg_637F_4, arg_637F_5, origin, num119, SpriteEffects.None, 0f);
							}
							if (Main.reforgeItem.stack > 1)
							{
								SpriteBatch arg_63F3_0 = this.spriteBatch;
								SpriteFont arg_63F3_1 = Main.fontItemStack;
								string arg_63F3_2 = string.Concat(Main.reforgeItem.stack);
								Vector2 arg_63F3_3 = new Vector2((float)num108 + 10f * Main.inventoryScale, (float)num109 + 26f * Main.inventoryScale);
								Color arg_63F3_4 = white7;
								float arg_63F3_5 = 0f;
								origin = default(Vector2);
								arg_63F3_0.DrawString(arg_63F3_1, arg_63F3_2, arg_63F3_3, arg_63F3_4, arg_63F3_5, origin, num119, SpriteEffects.None, 0f);
							}
						}
					}
				}
				else
				{
					if (Main.craftGuide)
					{
						if (Main.player[Main.myPlayer].chest != -1 || Main.npcShop != 0 || Main.player[Main.myPlayer].talkNPC == -1 || Main.reforge)
						{
							Main.craftGuide = false;
							Main.player[Main.myPlayer].dropItemCheck();
							Recipe.FindRecipes();
						}
						else
						{
							int num120 = 73;
							int num121 = 331;
							num121 += num106;
							string text22;
							if (Main.guideItem.type > 0)
							{
								text22 = "Showing recipes that use " + Main.guideItem.name;
								SpriteBatch arg_64D1_0 = this.spriteBatch;
								SpriteFont arg_64D1_1 = Main.fontMouseText;
								string arg_64D1_2 = "Required objects:";
								Vector2 arg_64D1_3 = new Vector2((float)num120, (float)(num121 + 118));
								Color arg_64D1_4 = color6;
								float arg_64D1_5 = 0f;
								origin = default(Vector2);
								arg_64D1_0.DrawString(arg_64D1_1, arg_64D1_2, arg_64D1_3, arg_64D1_4, arg_64D1_5, origin, 1f, SpriteEffects.None, 0f);
								int num122 = Main.focusRecipe;
								int num123 = 0;
								int num124 = 0;
								while (num124 < Recipe.maxRequirements)
								{
									int num125 = (num124 + 1) * 26;
									if (Main.recipe[Main.availableRecipe[num122]].requiredTile[num124] == -1)
									{
										if (num124 == 0 && !Main.recipe[Main.availableRecipe[num122]].needWater)
										{
											SpriteBatch arg_656A_0 = this.spriteBatch;
											SpriteFont arg_656A_1 = Main.fontMouseText;
											string arg_656A_2 = "None";
											Vector2 arg_656A_3 = new Vector2((float)num120, (float)(num121 + 118 + num125));
											Color arg_656A_4 = color6;
											float arg_656A_5 = 0f;
											origin = default(Vector2);
											arg_656A_0.DrawString(arg_656A_1, arg_656A_2, arg_656A_3, arg_656A_4, arg_656A_5, origin, 1f, SpriteEffects.None, 0f);
											break;
										}
										break;
									}
									else
									{
										num123++;
										SpriteBatch arg_65CF_0 = this.spriteBatch;
										SpriteFont arg_65CF_1 = Main.fontMouseText;
										string arg_65CF_2 = Main.tileName[Main.recipe[Main.availableRecipe[num122]].requiredTile[num124]];
										Vector2 arg_65CF_3 = new Vector2((float)num120, (float)(num121 + 118 + num125));
										Color arg_65CF_4 = color6;
										float arg_65CF_5 = 0f;
										origin = default(Vector2);
										arg_65CF_0.DrawString(arg_65CF_1, arg_65CF_2, arg_65CF_3, arg_65CF_4, arg_65CF_5, origin, 1f, SpriteEffects.None, 0f);
										num124++;
									}
								}
								if (Main.recipe[Main.availableRecipe[num122]].needWater)
								{
									int num126 = (num123 + 1) * 26;
									SpriteBatch arg_6645_0 = this.spriteBatch;
									SpriteFont arg_6645_1 = Main.fontMouseText;
									string arg_6645_2 = "None";
									Vector2 arg_6645_3 = new Vector2((float)num120, (float)(num121 + 118 + num126));
									Color arg_6645_4 = color6;
									float arg_6645_5 = 0f;
									origin = default(Vector2);
									arg_6645_0.DrawString(arg_6645_1, arg_6645_2, arg_6645_3, arg_6645_4, arg_6645_5, origin, 1f, SpriteEffects.None, 0f);
								}
							}
							else
							{
								text22 = "Place a material here to show recipes";
							}
							SpriteBatch arg_66A8_0 = this.spriteBatch;
							SpriteFont arg_66A8_1 = Main.fontMouseText;
							string arg_66A8_2 = text22;
							Vector2 arg_66A8_3 = new Vector2((float)(num120 + 50), (float)(num121 + 12));
							Color arg_66A8_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
							float arg_66A8_5 = 0f;
							origin = default(Vector2);
							arg_66A8_0.DrawString(arg_66A8_1, arg_66A8_2, arg_66A8_3, arg_66A8_4, arg_66A8_5, origin, 1f, SpriteEffects.None, 0f);
							Color white8 = new Color(100, 100, 100, 100);
							if (Main.mouseX >= num120 && (float)Main.mouseX <= (float)num120 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num121 && (float)Main.mouseY <= (float)num121 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
							{
								Main.player[Main.myPlayer].mouseInterface = true;
								Main.craftingHide = true;
								if (Main.mouseItem.material || Main.mouseItem.type == 0)
								{
									if (Main.mouseLeftRelease && Main.mouseLeft)
									{
										Item item6 = Main.mouseItem;
										Main.mouseItem = Main.guideItem;
										Main.guideItem = item6;
										if (Main.guideItem.type == 0 || Main.guideItem.stack < 1)
										{
											Main.guideItem = new Item();
										}
										if (Main.mouseItem.IsTheSameAs(Main.guideItem) && Main.guideItem.stack != Main.guideItem.maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
										{
											if (Main.mouseItem.stack + Main.guideItem.stack <= Main.mouseItem.maxStack)
											{
												Main.guideItem.stack += Main.mouseItem.stack;
												Main.mouseItem.stack = 0;
											}
											else
											{
												int num127 = Main.mouseItem.maxStack - Main.guideItem.stack;
												Main.guideItem.stack += num127;
												Main.mouseItem.stack -= num127;
											}
										}
										if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
										{
											Main.mouseItem = new Item();
										}
										if (Main.mouseItem.type > 0 || Main.guideItem.type > 0)
										{
											Recipe.FindRecipes();
											Main.PlaySound(7, -1, -1, 1);
										}
									}
									else
									{
										if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(Main.guideItem) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
										{
											if (Main.mouseItem.type == 0)
											{
												Main.mouseItem = (Item)Main.guideItem.Clone();
												Main.mouseItem.stack = 0;
											}
											Main.mouseItem.stack++;
											Main.guideItem.stack--;
											if (Main.guideItem.stack <= 0)
											{
												Main.guideItem = new Item();
											}
											Recipe.FindRecipes();
											Main.soundInstanceMenuTick.Stop();
											Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
											Main.PlaySound(12, -1, -1, 1);
											if (Main.stackSplit == 0)
											{
												Main.stackSplit = 15;
											}
											else
											{
												Main.stackSplit = Main.stackDelay;
											}
										}
									}
								}
								text15 = Main.guideItem.name;
								Main.toolTip = (Item)Main.guideItem.Clone();
								if (Main.guideItem.stack > 1)
								{
									object obj = text15;
									text15 = string.Concat(new object[]
									{
										obj, 
										" (", 
										Main.guideItem.stack, 
										")"
									});
								}
							}
							SpriteBatch arg_6A89_0 = this.spriteBatch;
							Texture2D arg_6A89_1 = Main.inventoryBack4Texture;
							Vector2 arg_6A89_2 = new Vector2((float)num120, (float)num121);
							Rectangle? arg_6A89_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
							Color arg_6A89_4 = color2;
							float arg_6A89_5 = 0f;
							origin = default(Vector2);
							arg_6A89_0.Draw(arg_6A89_1, arg_6A89_2, arg_6A89_3, arg_6A89_4, arg_6A89_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
							white8 = Color.White;
							if (Main.guideItem.type > 0 && Main.guideItem.stack > 0)
							{
								float num128 = 1f;
								if (Main.itemTexture[Main.guideItem.type].Width > 32 || Main.itemTexture[Main.guideItem.type].Height > 32)
								{
									if (Main.itemTexture[Main.guideItem.type].Width > Main.itemTexture[Main.guideItem.type].Height)
									{
										num128 = 32f / (float)Main.itemTexture[Main.guideItem.type].Width;
									}
									else
									{
										num128 = 32f / (float)Main.itemTexture[Main.guideItem.type].Height;
									}
								}
								num128 *= Main.inventoryScale;
								SpriteBatch arg_6C38_0 = this.spriteBatch;
								Texture2D arg_6C38_1 = Main.itemTexture[Main.guideItem.type];
								Vector2 arg_6C38_2 = new Vector2((float)num120 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.guideItem.type].Width * 0.5f * num128, (float)num121 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.guideItem.type].Height * 0.5f * num128);
								Rectangle? arg_6C38_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.guideItem.type].Width, Main.itemTexture[Main.guideItem.type].Height));
								Color arg_6C38_4 = Main.guideItem.GetAlpha(white8);
								float arg_6C38_5 = 0f;
								origin = default(Vector2);
								arg_6C38_0.Draw(arg_6C38_1, arg_6C38_2, arg_6C38_3, arg_6C38_4, arg_6C38_5, origin, num128, SpriteEffects.None, 0f);
								Color arg_6C55_0 = Main.guideItem.color;
								Color b = default(Color);
								if (arg_6C55_0 != b)
								{
									SpriteBatch arg_6D35_0 = this.spriteBatch;
									Texture2D arg_6D35_1 = Main.itemTexture[Main.guideItem.type];
									Vector2 arg_6D35_2 = new Vector2((float)num120 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.guideItem.type].Width * 0.5f * num128, (float)num121 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.guideItem.type].Height * 0.5f * num128);
									Rectangle? arg_6D35_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.guideItem.type].Width, Main.itemTexture[Main.guideItem.type].Height));
									Color arg_6D35_4 = Main.guideItem.GetColor(white8);
									float arg_6D35_5 = 0f;
									origin = default(Vector2);
									arg_6D35_0.Draw(arg_6D35_1, arg_6D35_2, arg_6D35_3, arg_6D35_4, arg_6D35_5, origin, num128, SpriteEffects.None, 0f);
								}
								if (Main.guideItem.stack > 1)
								{
									SpriteBatch arg_6DA6_0 = this.spriteBatch;
									SpriteFont arg_6DA6_1 = Main.fontItemStack;
									string arg_6DA6_2 = string.Concat(Main.guideItem.stack);
									Vector2 arg_6DA6_3 = new Vector2((float)num120 + 10f * Main.inventoryScale, (float)num121 + 26f * Main.inventoryScale);
									Color arg_6DA6_4 = white8;
									float arg_6DA6_5 = 0f;
									origin = default(Vector2);
									arg_6DA6_0.DrawString(arg_6DA6_1, arg_6DA6_2, arg_6DA6_3, arg_6DA6_4, arg_6DA6_5, origin, num128, SpriteEffects.None, 0f);
								}
							}
						}
					}
				}
				if (!Main.reforge)
				{
					if (Main.numAvailableRecipes > 0)
					{
						SpriteBatch arg_6E00_0 = this.spriteBatch;
						SpriteFont arg_6E00_1 = Main.fontMouseText;
						string arg_6E00_2 = "Crafting";
						Vector2 arg_6E00_3 = new Vector2(76f, (float)(414 + num106));
						Color arg_6E00_4 = color6;
						float arg_6E00_5 = 0f;
						origin = default(Vector2);
						arg_6E00_0.DrawString(arg_6E00_1, arg_6E00_2, arg_6E00_3, arg_6E00_4, arg_6E00_5, origin, 1f, SpriteEffects.None, 0f);
					}
					for (int num129 = 0; num129 < Recipe.maxRecipes; num129++)
					{
						Main.inventoryScale = 100f / (Math.Abs(Main.availableRecipeY[num129]) + 100f);
						if ((double)Main.inventoryScale < 0.75)
						{
							Main.inventoryScale = 0.75f;
						}
						if (Main.availableRecipeY[num129] < (float)((num129 - Main.focusRecipe) * 65))
						{
							if (Main.availableRecipeY[num129] == 0f)
							{
								Main.PlaySound(12, -1, -1, 1);
							}
							Main.availableRecipeY[num129] += 6.5f;
						}
						else
						{
							if (Main.availableRecipeY[num129] > (float)((num129 - Main.focusRecipe) * 65))
							{
								if (Main.availableRecipeY[num129] == 0f)
								{
									Main.PlaySound(12, -1, -1, 1);
								}
								Main.availableRecipeY[num129] -= 6.5f;
							}
						}
						if (num129 < Main.numAvailableRecipes && Math.Abs(Main.availableRecipeY[num129]) <= (float)num107)
						{
							int num130 = (int)(46f - 26f * Main.inventoryScale);
							int num131 = (int)(410f + Main.availableRecipeY[num129] * Main.inventoryScale - 30f * Main.inventoryScale + (float)num106);
							double num132 = (double)(color2.A + 50);
							double num133 = 255.0;
							if (Math.Abs(Main.availableRecipeY[num129]) > (float)(num107 - 100))
							{
								num132 = (double)(150f * (100f - (Math.Abs(Main.availableRecipeY[num129]) - (float)(num107 - 100)))) * 0.01;
								num133 = (double)(255f * (100f - (Math.Abs(Main.availableRecipeY[num129]) - (float)(num107 - 100)))) * 0.01;
							}
							new Color((int)((byte)num132), (int)((byte)num132), (int)((byte)num132), (int)((byte)num132));
							Color color7 = new Color((int)((byte)num133), (int)((byte)num133), (int)((byte)num133), (int)((byte)num133));
							if (Main.mouseX >= num130 && (float)Main.mouseX <= (float)num130 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num131 && (float)Main.mouseY <= (float)num131 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
							{
								Main.player[Main.myPlayer].mouseInterface = true;
								if (Main.focusRecipe == num129 && Main.guideItem.type == 0)
								{
									if (Main.mouseItem.type == 0 || (Main.mouseItem.IsTheSameAs(Main.recipe[Main.availableRecipe[num129]].createItem) && Main.mouseItem.stack + Main.recipe[Main.availableRecipe[num129]].createItem.stack <= Main.mouseItem.maxStack))
									{
										if (Main.mouseLeftRelease && Main.mouseLeft)
										{
											int stack = Main.mouseItem.stack;
											Main.mouseItem = (Item)Main.recipe[Main.availableRecipe[num129]].createItem.Clone();
											Main.mouseItem.Prefix(-1);
											Main.mouseItem.stack += stack;
											Main.mouseItem.position.X = Main.player[Main.myPlayer].position.X + (float)(Main.player[Main.myPlayer].width / 2) - (float)(Main.mouseItem.width / 2);
											Main.mouseItem.position.Y = Main.player[Main.myPlayer].position.Y + (float)(Main.player[Main.myPlayer].height / 2) - (float)(Main.mouseItem.height / 2);
											ItemText.NewText(Main.mouseItem, Main.recipe[Main.availableRecipe[num129]].createItem.stack);
											Main.recipe[Main.availableRecipe[num129]].Create();
											if (Main.mouseItem.type > 0 || Main.recipe[Main.availableRecipe[num129]].createItem.type > 0)
											{
												Main.PlaySound(7, -1, -1, 1);
											}
										}
										else
										{
											if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
											{
												if (Main.stackSplit == 0)
												{
													Main.stackSplit = 15;
												}
												else
												{
													Main.stackSplit = Main.stackDelay;
												}
												int stack2 = Main.mouseItem.stack;
												Main.mouseItem = (Item)Main.recipe[Main.availableRecipe[num129]].createItem.Clone();
												Main.mouseItem.stack += stack2;
												Main.mouseItem.position.X = Main.player[Main.myPlayer].position.X + (float)(Main.player[Main.myPlayer].width / 2) - (float)(Main.mouseItem.width / 2);
												Main.mouseItem.position.Y = Main.player[Main.myPlayer].position.Y + (float)(Main.player[Main.myPlayer].height / 2) - (float)(Main.mouseItem.height / 2);
												ItemText.NewText(Main.mouseItem, Main.recipe[Main.availableRecipe[num129]].createItem.stack);
												Main.recipe[Main.availableRecipe[num129]].Create();
												if (Main.mouseItem.type > 0 || Main.recipe[Main.availableRecipe[num129]].createItem.type > 0)
												{
													Main.PlaySound(7, -1, -1, 1);
												}
											}
										}
									}
								}
								else
								{
									if (Main.mouseLeftRelease && Main.mouseLeft)
									{
										Main.focusRecipe = num129;
									}
								}
								Main.craftingHide = true;
								text15 = Main.recipe[Main.availableRecipe[num129]].createItem.name;
								Main.toolTip = (Item)Main.recipe[Main.availableRecipe[num129]].createItem.Clone();
								if (Main.recipe[Main.availableRecipe[num129]].createItem.stack > 1)
								{
									object obj = text15;
									text15 = string.Concat(new object[]
									{
										obj, 
										" (", 
										Main.recipe[Main.availableRecipe[num129]].createItem.stack, 
										")"
									});
								}
							}
							if (Main.numAvailableRecipes > 0)
							{
								num132 -= 50.0;
								if (num132 < 0.0)
								{
									num132 = 0.0;
								}
								SpriteBatch arg_7516_0 = this.spriteBatch;
								Texture2D arg_7516_1 = Main.inventoryBack4Texture;
								Vector2 arg_7516_2 = new Vector2((float)num130, (float)num131);
								Rectangle? arg_7516_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
								Color arg_7516_4 = new Color((int)((byte)num132), (int)((byte)num132), (int)((byte)num132), (int)((byte)num132));
								float arg_7516_5 = 0f;
								origin = default(Vector2);
								arg_7516_0.Draw(arg_7516_1, arg_7516_2, arg_7516_3, arg_7516_4, arg_7516_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
								if (Main.recipe[Main.availableRecipe[num129]].createItem.type > 0 && Main.recipe[Main.availableRecipe[num129]].createItem.stack > 0)
								{
									float num134 = 1f;
									if (Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Width > 32 || Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Height > 32)
									{
										if (Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Width > Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Height)
										{
											num134 = 32f / (float)Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Width;
										}
										else
										{
											num134 = 32f / (float)Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Height;
										}
									}
									num134 *= Main.inventoryScale;
									SpriteBatch arg_7785_0 = this.spriteBatch;
									Texture2D arg_7785_1 = Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type];
									Vector2 arg_7785_2 = new Vector2((float)num130 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Width * 0.5f * num134, (float)num131 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Height * 0.5f * num134);
									Rectangle? arg_7785_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Height));
									Color arg_7785_4 = Main.recipe[Main.availableRecipe[num129]].createItem.GetAlpha(color7);
									float arg_7785_5 = 0f;
									origin = default(Vector2);
									arg_7785_0.Draw(arg_7785_1, arg_7785_2, arg_7785_3, arg_7785_4, arg_7785_5, origin, num134, SpriteEffects.None, 0f);
									Color arg_77B0_0 = Main.recipe[Main.availableRecipe[num129]].createItem.color;
									Color b = default(Color);
									if (arg_77B0_0 != b)
									{
										SpriteBatch arg_78E4_0 = this.spriteBatch;
										Texture2D arg_78E4_1 = Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type];
										Vector2 arg_78E4_2 = new Vector2((float)num130 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Width * 0.5f * num134, (float)num131 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Height * 0.5f * num134);
										Rectangle? arg_78E4_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[num129]].createItem.type].Height));
										Color arg_78E4_4 = Main.recipe[Main.availableRecipe[num129]].createItem.GetColor(color7);
										float arg_78E4_5 = 0f;
										origin = default(Vector2);
										arg_78E4_0.Draw(arg_78E4_1, arg_78E4_2, arg_78E4_3, arg_78E4_4, arg_78E4_5, origin, num134, SpriteEffects.None, 0f);
									}
									if (Main.recipe[Main.availableRecipe[num129]].createItem.stack > 1)
									{
										SpriteBatch arg_7971_0 = this.spriteBatch;
										SpriteFont arg_7971_1 = Main.fontItemStack;
										string arg_7971_2 = string.Concat(Main.recipe[Main.availableRecipe[num129]].createItem.stack);
										Vector2 arg_7971_3 = new Vector2((float)num130 + 10f * Main.inventoryScale, (float)num131 + 26f * Main.inventoryScale);
										Color arg_7971_4 = color7;
										float arg_7971_5 = 0f;
										origin = default(Vector2);
										arg_7971_0.DrawString(arg_7971_1, arg_7971_2, arg_7971_3, arg_7971_4, arg_7971_5, origin, num134, SpriteEffects.None, 0f);
									}
								}
							}
						}
					}
					if (Main.numAvailableRecipes > 0)
					{
						int num135 = 0;
						while (num135 < Recipe.maxRequirements && Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type != 0)
						{
							int num136 = 80 + num135 * 40;
							int num137 = 380 + num106;
							double num138 = (double)(color2.A + 50);
							double num139 = 255.0;
							Color white9 = Color.White;
							Color white10 = Color.White;
							num138 = (double)((float)(color2.A + 50) - Math.Abs(Main.availableRecipeY[Main.focusRecipe]) * 2f);
							num139 = (double)(255f - Math.Abs(Main.availableRecipeY[Main.focusRecipe]) * 2f);
							if (num138 < 0.0)
							{
								num138 = 0.0;
							}
							if (num139 < 0.0)
							{
								num139 = 0.0;
							}
							white9.R = (byte)num138;
							white9.G = (byte)num138;
							white9.B = (byte)num138;
							white9.A = (byte)num138;
							white10.R = (byte)num139;
							white10.G = (byte)num139;
							white10.B = (byte)num139;
							white10.A = (byte)num139;
							Main.inventoryScale = 0.6f;
							if (num138 == 0.0)
							{
								break;
							}
							if (Main.mouseX >= num136 && (float)Main.mouseX <= (float)num136 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num137 && (float)Main.mouseY <= (float)num137 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
							{
								Main.craftingHide = true;
								Main.player[Main.myPlayer].mouseInterface = true;
								text15 = Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].name;
								Main.toolTip = (Item)Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].Clone();
								if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].stack > 1)
								{
									object obj = text15;
									text15 = string.Concat(new object[]
									{
										obj, 
										" (", 
										Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].stack, 
										")"
									});
								}
							}
							num138 -= 50.0;
							if (num138 < 0.0)
							{
								num138 = 0.0;
							}
							SpriteBatch arg_7C9D_0 = this.spriteBatch;
							Texture2D arg_7C9D_1 = Main.inventoryBack4Texture;
							Vector2 arg_7C9D_2 = new Vector2((float)num136, (float)num137);
							Rectangle? arg_7C9D_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
							Color arg_7C9D_4 = new Color((int)((byte)num138), (int)((byte)num138), (int)((byte)num138), (int)((byte)num138));
							float arg_7C9D_5 = 0f;
							origin = default(Vector2);
							arg_7C9D_0.Draw(arg_7C9D_1, arg_7C9D_2, arg_7C9D_3, arg_7C9D_4, arg_7C9D_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
							if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type > 0 && Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].stack > 0)
							{
								float num140 = 1f;
								if (Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Width > 32 || Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Height > 32)
								{
									if (Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Width > Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Height)
									{
										num140 = 32f / (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Width;
									}
									else
									{
										num140 = 32f / (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Height;
									}
								}
								num140 *= Main.inventoryScale;
								SpriteBatch arg_7F60_0 = this.spriteBatch;
								Texture2D arg_7F60_1 = Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type];
								Vector2 arg_7F60_2 = new Vector2((float)num136 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Width * 0.5f * num140, (float)num137 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Height * 0.5f * num140);
								Rectangle? arg_7F60_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Height));
								Color arg_7F60_4 = Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].GetAlpha(white10);
								float arg_7F60_5 = 0f;
								origin = default(Vector2);
								arg_7F60_0.Draw(arg_7F60_1, arg_7F60_2, arg_7F60_3, arg_7F60_4, arg_7F60_5, origin, num140, SpriteEffects.None, 0f);
								Color arg_7F91_0 = Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].color;
								Color b = default(Color);
								if (arg_7F91_0 != b)
								{
									SpriteBatch arg_80E9_0 = this.spriteBatch;
									Texture2D arg_80E9_1 = Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type];
									Vector2 arg_80E9_2 = new Vector2((float)num136 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Width * 0.5f * num140, (float)num137 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Height * 0.5f * num140);
									Rectangle? arg_80E9_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Width, Main.itemTexture[Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].type].Height));
									Color arg_80E9_4 = Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].GetColor(white10);
									float arg_80E9_5 = 0f;
									origin = default(Vector2);
									arg_80E9_0.Draw(arg_80E9_1, arg_80E9_2, arg_80E9_3, arg_80E9_4, arg_80E9_5, origin, num140, SpriteEffects.None, 0f);
								}
								if (Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].stack > 1)
								{
									SpriteBatch arg_8182_0 = this.spriteBatch;
									SpriteFont arg_8182_1 = Main.fontItemStack;
									string arg_8182_2 = string.Concat(Main.recipe[Main.availableRecipe[Main.focusRecipe]].requiredItem[num135].stack);
									Vector2 arg_8182_3 = new Vector2((float)num136 + 10f * Main.inventoryScale, (float)num137 + 26f * Main.inventoryScale);
									Color arg_8182_4 = white10;
									float arg_8182_5 = 0f;
									origin = default(Vector2);
									arg_8182_0.DrawString(arg_8182_1, arg_8182_2, arg_8182_3, arg_8182_4, arg_8182_5, origin, num140, SpriteEffects.None, 0f);
								}
							}
							num135++;
						}
					}
				}
				SpriteBatch arg_81EF_0 = this.spriteBatch;
				SpriteFont arg_81EF_1 = Main.fontMouseText;
				string arg_81EF_2 = "Coins";
				Vector2 arg_81EF_3 = new Vector2(496f, 84f);
				Color arg_81EF_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
				float arg_81EF_5 = 0f;
				origin = default(Vector2);
				arg_81EF_0.DrawString(arg_81EF_1, arg_81EF_2, arg_81EF_3, arg_81EF_4, arg_81EF_5, origin, 0.75f, SpriteEffects.None, 0f);
				Main.inventoryScale = 0.6f;
				for (int num141 = 0; num141 < 4; num141++)
				{
					int num142 = 497;
					int num143 = (int)(85f + (float)(num141 * 56) * Main.inventoryScale + 20f);
					int num144 = num141 + 40;
					Color white11 = new Color(100, 100, 100, 100);
					if (Main.mouseX >= num142 && (float)Main.mouseX <= (float)num142 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num143 && (float)Main.mouseY <= (float)num143 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
					{
						Main.player[Main.myPlayer].mouseInterface = true;
						if (Main.mouseLeftRelease && Main.mouseLeft)
						{
							if (Main.keyState.IsKeyDown(Keys.LeftShift))
							{
								if (Main.player[Main.myPlayer].inventory[num144].type > 0)
								{
									if (Main.npcShop > 0)
									{
										if (Main.player[Main.myPlayer].SellItem(Main.player[Main.myPlayer].inventory[num144].value, Main.player[Main.myPlayer].inventory[num144].stack))
										{
											this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[num144]);
											Main.player[Main.myPlayer].inventory[num144].SetDefaults(0, false);
											Main.PlaySound(18, -1, -1, 1);
										}
										else
										{
											if (Main.player[Main.myPlayer].inventory[num144].value == 0)
											{
												this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[num144]);
												Main.player[Main.myPlayer].inventory[num144].SetDefaults(0, false);
												Main.PlaySound(7, -1, -1, 1);
											}
										}
									}
									else
									{
										Recipe.FindRecipes();
										Main.PlaySound(7, -1, -1, 1);
										Main.trashItem = (Item)Main.player[Main.myPlayer].inventory[num144].Clone();
										Main.player[Main.myPlayer].inventory[num144].SetDefaults(0, false);
									}
								}
							}
							else
							{
								if ((Main.player[Main.myPlayer].selectedItem != num144 || Main.player[Main.myPlayer].itemAnimation <= 0) && (Main.mouseItem.type == 0 || Main.mouseItem.type == 71 || Main.mouseItem.type == 72 || Main.mouseItem.type == 73 || Main.mouseItem.type == 74))
								{
									Item item7 = Main.mouseItem;
									Main.mouseItem = Main.player[Main.myPlayer].inventory[num144];
									Main.player[Main.myPlayer].inventory[num144] = item7;
									if (Main.player[Main.myPlayer].inventory[num144].type == 0 || Main.player[Main.myPlayer].inventory[num144].stack < 1)
									{
										Main.player[Main.myPlayer].inventory[num144] = new Item();
									}
									if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[num144]) && Main.player[Main.myPlayer].inventory[num144].stack != Main.player[Main.myPlayer].inventory[num144].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
									{
										if (Main.mouseItem.stack + Main.player[Main.myPlayer].inventory[num144].stack <= Main.mouseItem.maxStack)
										{
											Main.player[Main.myPlayer].inventory[num144].stack += Main.mouseItem.stack;
											Main.mouseItem.stack = 0;
										}
										else
										{
											int num145 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].inventory[num144].stack;
											Main.player[Main.myPlayer].inventory[num144].stack += num145;
											Main.mouseItem.stack -= num145;
										}
									}
									if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
									{
										Main.mouseItem = new Item();
									}
									if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].inventory[num144].type > 0)
									{
										Main.PlaySound(7, -1, -1, 1);
									}
									Recipe.FindRecipes();
								}
							}
						}
						else
						{
							if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[num144]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
							{
								if (Main.mouseItem.type == 0)
								{
									Main.mouseItem = (Item)Main.player[Main.myPlayer].inventory[num144].Clone();
									Main.mouseItem.stack = 0;
								}
								Main.mouseItem.stack++;
								Main.player[Main.myPlayer].inventory[num144].stack--;
								if (Main.player[Main.myPlayer].inventory[num144].stack <= 0)
								{
									Main.player[Main.myPlayer].inventory[num144] = new Item();
								}
								Recipe.FindRecipes();
								Main.soundInstanceMenuTick.Stop();
								Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
								Main.PlaySound(12, -1, -1, 1);
								if (Main.stackSplit == 0)
								{
									Main.stackSplit = 15;
								}
								else
								{
									Main.stackSplit = Main.stackDelay;
								}
							}
						}
						text15 = Main.player[Main.myPlayer].inventory[num144].name;
						Main.toolTip = (Item)Main.player[Main.myPlayer].inventory[num144].Clone();
						if (Main.player[Main.myPlayer].inventory[num144].stack > 1)
						{
							object obj = text15;
							text15 = string.Concat(new object[]
							{
								obj, 
								" (", 
								Main.player[Main.myPlayer].inventory[num144].stack, 
								")"
							});
						}
					}
					SpriteBatch arg_8910_0 = this.spriteBatch;
					Texture2D arg_8910_1 = Main.inventoryBackTexture;
					Vector2 arg_8910_2 = new Vector2((float)num142, (float)num143);
					Rectangle? arg_8910_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
					Color arg_8910_4 = color2;
					float arg_8910_5 = 0f;
					origin = default(Vector2);
					arg_8910_0.Draw(arg_8910_1, arg_8910_2, arg_8910_3, arg_8910_4, arg_8910_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
					white11 = Color.White;
					if (Main.player[Main.myPlayer].inventory[num144].type > 0 && Main.player[Main.myPlayer].inventory[num144].stack > 0)
					{
						float num146 = 1f;
						if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Height > 32)
						{
							if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Width > Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Height)
							{
								num146 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Width;
							}
							else
							{
								num146 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Height;
							}
						}
						num146 *= Main.inventoryScale;
						SpriteBatch arg_8B86_0 = this.spriteBatch;
						Texture2D arg_8B86_1 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type];
						Vector2 arg_8B86_2 = new Vector2((float)num142 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Width * 0.5f * num146, (float)num143 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Height * 0.5f * num146);
						Rectangle? arg_8B86_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Height));
						Color arg_8B86_4 = Main.player[Main.myPlayer].inventory[num144].GetAlpha(white11);
						float arg_8B86_5 = 0f;
						origin = default(Vector2);
						arg_8B86_0.Draw(arg_8B86_1, arg_8B86_2, arg_8B86_3, arg_8B86_4, arg_8B86_5, origin, num146, SpriteEffects.None, 0f);
						Color arg_8BB1_0 = Main.player[Main.myPlayer].inventory[num144].color;
						Color b = default(Color);
						if (arg_8BB1_0 != b)
						{
							SpriteBatch arg_8CE5_0 = this.spriteBatch;
							Texture2D arg_8CE5_1 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type];
							Vector2 arg_8CE5_2 = new Vector2((float)num142 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Width * 0.5f * num146, (float)num143 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Height * 0.5f * num146);
							Rectangle? arg_8CE5_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num144].type].Height));
							Color arg_8CE5_4 = Main.player[Main.myPlayer].inventory[num144].GetColor(white11);
							float arg_8CE5_5 = 0f;
							origin = default(Vector2);
							arg_8CE5_0.Draw(arg_8CE5_1, arg_8CE5_2, arg_8CE5_3, arg_8CE5_4, arg_8CE5_5, origin, num146, SpriteEffects.None, 0f);
						}
						if (Main.player[Main.myPlayer].inventory[num144].stack > 1)
						{
							SpriteBatch arg_8D72_0 = this.spriteBatch;
							SpriteFont arg_8D72_1 = Main.fontItemStack;
							string arg_8D72_2 = string.Concat(Main.player[Main.myPlayer].inventory[num144].stack);
							Vector2 arg_8D72_3 = new Vector2((float)num142 + 10f * Main.inventoryScale, (float)num143 + 26f * Main.inventoryScale);
							Color arg_8D72_4 = white11;
							float arg_8D72_5 = 0f;
							origin = default(Vector2);
							arg_8D72_0.DrawString(arg_8D72_1, arg_8D72_2, arg_8D72_3, arg_8D72_4, arg_8D72_5, origin, num146, SpriteEffects.None, 0f);
						}
					}
				}
				SpriteBatch arg_8DDB_0 = this.spriteBatch;
				SpriteFont arg_8DDB_1 = Main.fontMouseText;
				string arg_8DDB_2 = "Ammo";
				Vector2 arg_8DDB_3 = new Vector2(532f, 84f);
				Color arg_8DDB_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
				float arg_8DDB_5 = 0f;
				origin = default(Vector2);
				arg_8DDB_0.DrawString(arg_8DDB_1, arg_8DDB_2, arg_8DDB_3, arg_8DDB_4, arg_8DDB_5, origin, 0.75f, SpriteEffects.None, 0f);
				Main.inventoryScale = 0.6f;
				for (int num147 = 0; num147 < 4; num147++)
				{
					int num148 = 534;
					int num149 = (int)(85f + (float)(num147 * 56) * Main.inventoryScale + 20f);
					int num150 = 44 + num147;
					Color white12 = new Color(100, 100, 100, 100);
					if (Main.mouseX >= num148 && (float)Main.mouseX <= (float)num148 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num149 && (float)Main.mouseY <= (float)num149 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
					{
						Main.player[Main.myPlayer].mouseInterface = true;
						if (Main.mouseLeftRelease && Main.mouseLeft)
						{
							if (Main.keyState.IsKeyDown(Keys.LeftShift))
							{
								if (Main.player[Main.myPlayer].inventory[num150].type > 0)
								{
									if (Main.npcShop > 0)
									{
										if (Main.player[Main.myPlayer].SellItem(Main.player[Main.myPlayer].inventory[num150].value, Main.player[Main.myPlayer].inventory[num150].stack))
										{
											this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[num150]);
											Main.player[Main.myPlayer].inventory[num150].SetDefaults(0, false);
											Main.PlaySound(18, -1, -1, 1);
										}
										else
										{
											if (Main.player[Main.myPlayer].inventory[num150].value == 0)
											{
												this.shop[Main.npcShop].AddShop(Main.player[Main.myPlayer].inventory[num150]);
												Main.player[Main.myPlayer].inventory[num150].SetDefaults(0, false);
												Main.PlaySound(7, -1, -1, 1);
											}
										}
									}
									else
									{
										Recipe.FindRecipes();
										Main.PlaySound(7, -1, -1, 1);
										Main.trashItem = (Item)Main.player[Main.myPlayer].inventory[num150].Clone();
										Main.player[Main.myPlayer].inventory[num150].SetDefaults(0, false);
									}
								}
							}
							else
							{
								if ((Main.player[Main.myPlayer].selectedItem != num150 || Main.player[Main.myPlayer].itemAnimation <= 0) && (Main.mouseItem.type == 0 || Main.mouseItem.ammo > 0 || Main.mouseItem.type == 530))
								{
									Item item8 = Main.mouseItem;
									Main.mouseItem = Main.player[Main.myPlayer].inventory[num150];
									Main.player[Main.myPlayer].inventory[num150] = item8;
									if (Main.player[Main.myPlayer].inventory[num150].type == 0 || Main.player[Main.myPlayer].inventory[num150].stack < 1)
									{
										Main.player[Main.myPlayer].inventory[num150] = new Item();
									}
									if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[num150]) && Main.player[Main.myPlayer].inventory[num150].stack != Main.player[Main.myPlayer].inventory[num150].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
									{
										if (Main.mouseItem.stack + Main.player[Main.myPlayer].inventory[num150].stack <= Main.mouseItem.maxStack)
										{
											Main.player[Main.myPlayer].inventory[num150].stack += Main.mouseItem.stack;
											Main.mouseItem.stack = 0;
										}
										else
										{
											int num151 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].inventory[num150].stack;
											Main.player[Main.myPlayer].inventory[num150].stack += num151;
											Main.mouseItem.stack -= num151;
										}
									}
									if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
									{
										Main.mouseItem = new Item();
									}
									if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].inventory[num150].type > 0)
									{
										Main.PlaySound(7, -1, -1, 1);
									}
									Recipe.FindRecipes();
								}
							}
						}
						else
						{
							if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].inventory[num150]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
							{
								if (Main.mouseItem.type == 0)
								{
									Main.mouseItem = (Item)Main.player[Main.myPlayer].inventory[num150].Clone();
									Main.mouseItem.stack = 0;
								}
								Main.mouseItem.stack++;
								Main.player[Main.myPlayer].inventory[num150].stack--;
								if (Main.player[Main.myPlayer].inventory[num150].stack <= 0)
								{
									Main.player[Main.myPlayer].inventory[num150] = new Item();
								}
								Recipe.FindRecipes();
								Main.soundInstanceMenuTick.Stop();
								Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
								Main.PlaySound(12, -1, -1, 1);
								if (Main.stackSplit == 0)
								{
									Main.stackSplit = 15;
								}
								else
								{
									Main.stackSplit = Main.stackDelay;
								}
							}
						}
						text15 = Main.player[Main.myPlayer].inventory[num150].name;
						Main.toolTip = (Item)Main.player[Main.myPlayer].inventory[num150].Clone();
						if (Main.player[Main.myPlayer].inventory[num150].stack > 1)
						{
							object obj = text15;
							text15 = string.Concat(new object[]
							{
								obj, 
								" (", 
								Main.player[Main.myPlayer].inventory[num150].stack, 
								")"
							});
						}
					}
					SpriteBatch arg_94E2_0 = this.spriteBatch;
					Texture2D arg_94E2_1 = Main.inventoryBackTexture;
					Vector2 arg_94E2_2 = new Vector2((float)num148, (float)num149);
					Rectangle? arg_94E2_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
					Color arg_94E2_4 = color2;
					float arg_94E2_5 = 0f;
					origin = default(Vector2);
					arg_94E2_0.Draw(arg_94E2_1, arg_94E2_2, arg_94E2_3, arg_94E2_4, arg_94E2_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
					white12 = Color.White;
					if (Main.player[Main.myPlayer].inventory[num150].type > 0 && Main.player[Main.myPlayer].inventory[num150].stack > 0)
					{
						float num152 = 1f;
						if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Height > 32)
						{
							if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Width > Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Height)
							{
								num152 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Width;
							}
							else
							{
								num152 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Height;
							}
						}
						num152 *= Main.inventoryScale;
						SpriteBatch arg_9758_0 = this.spriteBatch;
						Texture2D arg_9758_1 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type];
						Vector2 arg_9758_2 = new Vector2((float)num148 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Width * 0.5f * num152, (float)num149 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Height * 0.5f * num152);
						Rectangle? arg_9758_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Height));
						Color arg_9758_4 = Main.player[Main.myPlayer].inventory[num150].GetAlpha(white12);
						float arg_9758_5 = 0f;
						origin = default(Vector2);
						arg_9758_0.Draw(arg_9758_1, arg_9758_2, arg_9758_3, arg_9758_4, arg_9758_5, origin, num152, SpriteEffects.None, 0f);
						Color arg_9783_0 = Main.player[Main.myPlayer].inventory[num150].color;
						Color b = default(Color);
						if (arg_9783_0 != b)
						{
							SpriteBatch arg_98B7_0 = this.spriteBatch;
							Texture2D arg_98B7_1 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type];
							Vector2 arg_98B7_2 = new Vector2((float)num148 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Width * 0.5f * num152, (float)num149 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Height * 0.5f * num152);
							Rectangle? arg_98B7_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num150].type].Height));
							Color arg_98B7_4 = Main.player[Main.myPlayer].inventory[num150].GetColor(white12);
							float arg_98B7_5 = 0f;
							origin = default(Vector2);
							arg_98B7_0.Draw(arg_98B7_1, arg_98B7_2, arg_98B7_3, arg_98B7_4, arg_98B7_5, origin, num152, SpriteEffects.None, 0f);
						}
						if (Main.player[Main.myPlayer].inventory[num150].stack > 1)
						{
							SpriteBatch arg_9944_0 = this.spriteBatch;
							SpriteFont arg_9944_1 = Main.fontItemStack;
							string arg_9944_2 = string.Concat(Main.player[Main.myPlayer].inventory[num150].stack);
							Vector2 arg_9944_3 = new Vector2((float)num148 + 10f * Main.inventoryScale, (float)num149 + 26f * Main.inventoryScale);
							Color arg_9944_4 = white12;
							float arg_9944_5 = 0f;
							origin = default(Vector2);
							arg_9944_0.DrawString(arg_9944_1, arg_9944_2, arg_9944_3, arg_9944_4, arg_9944_5, origin, num152, SpriteEffects.None, 0f);
						}
					}
				}
				if (Main.npcShop > 0 && (!Main.playerInventory || Main.player[Main.myPlayer].talkNPC == -1))
				{
					Main.npcShop = 0;
				}
				if (Main.npcShop > 0)
				{
					SpriteBatch arg_99E0_0 = this.spriteBatch;
					SpriteFont arg_99E0_1 = Main.fontMouseText;
					string arg_99E0_2 = "Shop";
					Vector2 arg_99E0_3 = new Vector2(284f, 210f);
					Color arg_99E0_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float arg_99E0_5 = 0f;
					origin = default(Vector2);
					arg_99E0_0.DrawString(arg_99E0_1, arg_99E0_2, arg_99E0_3, arg_99E0_4, arg_99E0_5, origin, 1f, SpriteEffects.None, 0f);
					Main.inventoryScale = 0.75f;
					if (Main.mouseX > 73 && Main.mouseX < (int)(73f + 280f * Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int)(210f + 224f * Main.inventoryScale))
					{
						Main.player[Main.myPlayer].mouseInterface = true;
					}
					for (int num153 = 0; num153 < 5; num153++)
					{
						for (int num154 = 0; num154 < 4; num154++)
						{
							int num155 = (int)(73f + (float)(num153 * 56) * Main.inventoryScale);
							int num156 = (int)(210f + (float)(num154 * 56) * Main.inventoryScale);
							int num157 = num153 + num154 * 5;
							Color white13 = new Color(100, 100, 100, 100);
							if (Main.mouseX >= num155 && (float)Main.mouseX <= (float)num155 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num156 && (float)Main.mouseY <= (float)num156 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
							{
								Main.player[Main.myPlayer].mouseInterface = true;
								if (Main.mouseLeftRelease && Main.mouseLeft)
								{
									if (Main.mouseItem.type == 0)
									{
										if ((Main.player[Main.myPlayer].selectedItem != num157 || Main.player[Main.myPlayer].itemAnimation <= 0) && Main.player[Main.myPlayer].BuyItem(this.shop[Main.npcShop].item[num157].value))
										{
											if (this.shop[Main.npcShop].item[num157].buyOnce)
											{
												int prefix = (int)this.shop[Main.npcShop].item[num157].prefix;
												Main.mouseItem.SetDefaults(this.shop[Main.npcShop].item[num157].name);
												Main.mouseItem.Prefix(prefix);
											}
											else
											{
												Main.mouseItem.SetDefaults(this.shop[Main.npcShop].item[num157].name);
												Main.mouseItem.Prefix(-1);
											}
											Main.mouseItem.position.X = Main.player[Main.myPlayer].position.X + (float)(Main.player[Main.myPlayer].width / 2) - (float)(Main.mouseItem.width / 2);
											Main.mouseItem.position.Y = Main.player[Main.myPlayer].position.Y + (float)(Main.player[Main.myPlayer].height / 2) - (float)(Main.mouseItem.height / 2);
											ItemText.NewText(Main.mouseItem, Main.mouseItem.stack);
											if (this.shop[Main.npcShop].item[num157].buyOnce)
											{
												this.shop[Main.npcShop].item[num157].stack--;
												if (this.shop[Main.npcShop].item[num157].stack <= 0)
												{
													this.shop[Main.npcShop].item[num157].SetDefaults(0, false);
												}
											}
											Main.PlaySound(18, -1, -1, 1);
										}
									}
									else
									{
										if (this.shop[Main.npcShop].item[num157].type == 0)
										{
											if (Main.player[Main.myPlayer].SellItem(Main.mouseItem.value, Main.mouseItem.stack))
											{
												this.shop[Main.npcShop].AddShop(Main.mouseItem);
												Main.mouseItem.stack = 0;
												Main.mouseItem.type = 0;
												Main.PlaySound(18, -1, -1, 1);
											}
											else
											{
												if (Main.mouseItem.value == 0)
												{
													this.shop[Main.npcShop].AddShop(Main.mouseItem);
													Main.mouseItem.stack = 0;
													Main.mouseItem.type = 0;
													Main.PlaySound(7, -1, -1, 1);
												}
											}
										}
									}
								}
								else
								{
									if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(this.shop[Main.npcShop].item[num157]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0) && Main.player[Main.myPlayer].BuyItem(this.shop[Main.npcShop].item[num157].value))
									{
										Main.PlaySound(18, -1, -1, 1);
										if (Main.mouseItem.type == 0)
										{
											Main.mouseItem.SetDefaults(this.shop[Main.npcShop].item[num157].name);
											Main.mouseItem.stack = 0;
										}
										Main.mouseItem.stack++;
										if (Main.stackSplit == 0)
										{
											Main.stackSplit = 15;
										}
										else
										{
											Main.stackSplit = Main.stackDelay;
										}
										if (this.shop[Main.npcShop].item[num157].buyOnce)
										{
											this.shop[Main.npcShop].item[num157].stack--;
											if (this.shop[Main.npcShop].item[num157].stack <= 0)
											{
												this.shop[Main.npcShop].item[num157].SetDefaults(0, false);
											}
										}
									}
								}
								text15 = this.shop[Main.npcShop].item[num157].name;
								Main.toolTip = (Item)this.shop[Main.npcShop].item[num157].Clone();
								Main.toolTip.buy = true;
								if (this.shop[Main.npcShop].item[num157].stack > 1)
								{
									object obj = text15;
									text15 = string.Concat(new object[]
									{
										obj, 
										" (", 
										this.shop[Main.npcShop].item[num157].stack, 
										")"
									});
								}
							}
							SpriteBatch arg_A092_0 = this.spriteBatch;
							Texture2D arg_A092_1 = Main.inventoryBack6Texture;
							Vector2 arg_A092_2 = new Vector2((float)num155, (float)num156);
							Rectangle? arg_A092_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
							Color arg_A092_4 = color2;
							float arg_A092_5 = 0f;
							origin = default(Vector2);
							arg_A092_0.Draw(arg_A092_1, arg_A092_2, arg_A092_3, arg_A092_4, arg_A092_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
							white13 = Color.White;
							if (this.shop[Main.npcShop].item[num157].type > 0 && this.shop[Main.npcShop].item[num157].stack > 0)
							{
								float num158 = 1f;
								if (Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Width > 32 || Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Height > 32)
								{
									if (Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Width > Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Height)
									{
										num158 = 32f / (float)Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Width;
									}
									else
									{
										num158 = 32f / (float)Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Height;
									}
								}
								num158 *= Main.inventoryScale;
								SpriteBatch arg_A316_0 = this.spriteBatch;
								Texture2D arg_A316_1 = Main.itemTexture[this.shop[Main.npcShop].item[num157].type];
								Vector2 arg_A316_2 = new Vector2((float)num155 + 26f * Main.inventoryScale - (float)Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Width * 0.5f * num158, (float)num156 + 26f * Main.inventoryScale - (float)Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Height * 0.5f * num158);
								Rectangle? arg_A316_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Width, Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Height));
								Color arg_A316_4 = this.shop[Main.npcShop].item[num157].GetAlpha(white13);
								float arg_A316_5 = 0f;
								origin = default(Vector2);
								arg_A316_0.Draw(arg_A316_1, arg_A316_2, arg_A316_3, arg_A316_4, arg_A316_5, origin, num158, SpriteEffects.None, 0f);
								Color arg_A342_0 = this.shop[Main.npcShop].item[num157].color;
								Color b = default(Color);
								if (arg_A342_0 != b)
								{
									SpriteBatch arg_A47C_0 = this.spriteBatch;
									Texture2D arg_A47C_1 = Main.itemTexture[this.shop[Main.npcShop].item[num157].type];
									Vector2 arg_A47C_2 = new Vector2((float)num155 + 26f * Main.inventoryScale - (float)Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Width * 0.5f * num158, (float)num156 + 26f * Main.inventoryScale - (float)Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Height * 0.5f * num158);
									Rectangle? arg_A47C_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Width, Main.itemTexture[this.shop[Main.npcShop].item[num157].type].Height));
									Color arg_A47C_4 = this.shop[Main.npcShop].item[num157].GetColor(white13);
									float arg_A47C_5 = 0f;
									origin = default(Vector2);
									arg_A47C_0.Draw(arg_A47C_1, arg_A47C_2, arg_A47C_3, arg_A47C_4, arg_A47C_5, origin, num158, SpriteEffects.None, 0f);
								}
								if (this.shop[Main.npcShop].item[num157].stack > 1)
								{
									SpriteBatch arg_A50B_0 = this.spriteBatch;
									SpriteFont arg_A50B_1 = Main.fontItemStack;
									string arg_A50B_2 = string.Concat(this.shop[Main.npcShop].item[num157].stack);
									Vector2 arg_A50B_3 = new Vector2((float)num155 + 10f * Main.inventoryScale, (float)num156 + 26f * Main.inventoryScale);
									Color arg_A50B_4 = white13;
									float arg_A50B_5 = 0f;
									origin = default(Vector2);
									arg_A50B_0.DrawString(arg_A50B_1, arg_A50B_2, arg_A50B_3, arg_A50B_4, arg_A50B_5, origin, num158, SpriteEffects.None, 0f);
								}
							}
						}
					}
				}
				if (Main.player[Main.myPlayer].chest > -1 && Main.tile[Main.player[Main.myPlayer].chestX, Main.player[Main.myPlayer].chestY].type != 21)
				{
					Main.player[Main.myPlayer].chest = -1;
				}
				if (Main.player[Main.myPlayer].chest != -1)
				{
					Main.inventoryScale = 0.75f;
					if (Main.mouseX > 73 && Main.mouseX < (int)(73f + 280f * Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int)(210f + 224f * Main.inventoryScale))
					{
						Main.player[Main.myPlayer].mouseInterface = true;
					}
					for (int num159 = 0; num159 < 3; num159++)
					{
						int num160 = 286;
						int num161 = 250;
						float num162 = this.chestLootScale;
						string text23 = "Loot All";
						if (num159 == 1)
						{
							num161 += 26;
							num162 = this.chestDepositScale;
							text23 = "Deposit All";
						}
						else
						{
							if (num159 == 2)
							{
								num161 += 52;
								num162 = this.chestStackScale;
								text23 = "Quick Stack";
							}
						}
						Vector2 vector7 = Main.fontMouseText.MeasureString(text23) / 2f;
						Color color8 = new Color((int)((byte)((float)Main.mouseTextColor * num162)), (int)((byte)((float)Main.mouseTextColor * num162)), (int)((byte)((float)Main.mouseTextColor * num162)), (int)((byte)((float)Main.mouseTextColor * num162)));
						num160 += (int)(vector7.X * num162);
						this.spriteBatch.DrawString(Main.fontMouseText, text23, new Vector2((float)num160, (float)num161), color8, 0f, vector7, num162, SpriteEffects.None, 0f);
						vector7 *= num162;
						if ((float)Main.mouseX > (float)num160 - vector7.X && (float)Main.mouseX < (float)num160 + vector7.X && (float)Main.mouseY > (float)num161 - vector7.Y && (float)Main.mouseY < (float)num161 + vector7.Y)
						{
							if (num159 == 0)
							{
								if (!this.chestLootHover)
								{
									Main.PlaySound(12, -1, -1, 1);
								}
								this.chestLootHover = true;
							}
							else
							{
								if (num159 == 1)
								{
									if (!this.chestDepositHover)
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									this.chestDepositHover = true;
								}
								else
								{
									if (!this.chestStackHover)
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									this.chestStackHover = true;
								}
							}
							Main.player[Main.myPlayer].mouseInterface = true;
							num162 += 0.05f;
							if (Main.mouseLeft && Main.mouseLeftRelease)
							{
								if (num159 == 0)
								{
									if (Main.player[Main.myPlayer].chest > -1)
									{
										for (int num163 = 0; num163 < 20; num163++)
										{
											if (Main.chest[Main.player[Main.myPlayer].chest].item[num163].type > 0)
											{
												Main.chest[Main.player[Main.myPlayer].chest].item[num163] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, Main.chest[Main.player[Main.myPlayer].chest].item[num163]);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num163, 0f, 0f, 0);
												}
											}
										}
									}
									else
									{
										if (Main.player[Main.myPlayer].chest == -3)
										{
											for (int num164 = 0; num164 < 20; num164++)
											{
												if (Main.player[Main.myPlayer].bank2[num164].type > 0)
												{
													Main.player[Main.myPlayer].bank2[num164] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, Main.player[Main.myPlayer].bank2[num164]);
												}
											}
										}
										else
										{
											for (int num165 = 0; num165 < 20; num165++)
											{
												if (Main.player[Main.myPlayer].bank[num165].type > 0)
												{
													Main.player[Main.myPlayer].bank[num165] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, Main.player[Main.myPlayer].bank[num165]);
												}
											}
										}
									}
								}
								else
								{
									if (num159 == 1)
									{
										for (int num166 = 40; num166 >= 10; num166--)
										{
											if (Main.player[Main.myPlayer].inventory[num166].stack > 0 && Main.player[Main.myPlayer].inventory[num166].type > 0)
											{
												if (Main.player[Main.myPlayer].inventory[num166].maxStack > 1)
												{
													for (int num167 = 0; num167 < 20; num167++)
													{
														if (Main.player[Main.myPlayer].chest > -1)
														{
															if (Main.chest[Main.player[Main.myPlayer].chest].item[num167].stack < Main.chest[Main.player[Main.myPlayer].chest].item[num167].maxStack && Main.player[Main.myPlayer].inventory[num166].IsTheSameAs(Main.chest[Main.player[Main.myPlayer].chest].item[num167]))
															{
																int num168 = Main.player[Main.myPlayer].inventory[num166].stack;
																if (Main.player[Main.myPlayer].inventory[num166].stack + Main.chest[Main.player[Main.myPlayer].chest].item[num167].stack > Main.chest[Main.player[Main.myPlayer].chest].item[num167].maxStack)
																{
																	num168 = Main.chest[Main.player[Main.myPlayer].chest].item[num167].maxStack - Main.chest[Main.player[Main.myPlayer].chest].item[num167].stack;
																}
																Main.player[Main.myPlayer].inventory[num166].stack -= num168;
																Main.chest[Main.player[Main.myPlayer].chest].item[num167].stack += num168;
																Main.ChestCoins();
																Main.PlaySound(7, -1, -1, 1);
																if (Main.player[Main.myPlayer].inventory[num166].stack <= 0)
																{
																	Main.player[Main.myPlayer].inventory[num166].SetDefaults(0, false);
																	if (Main.netMode == 1)
																	{
																		NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num167, 0f, 0f, 0);
																		break;
																	}
																	break;
																}
																else
																{
																	if (Main.chest[Main.player[Main.myPlayer].chest].item[num167].type == 0)
																	{
																		Main.chest[Main.player[Main.myPlayer].chest].item[num167] = (Item)Main.player[Main.myPlayer].inventory[num166].Clone();
																		Main.player[Main.myPlayer].inventory[num166].SetDefaults(0, false);
																	}
																	if (Main.netMode == 1)
																	{
																		NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num167, 0f, 0f, 0);
																	}
																}
															}
														}
														else
														{
															if (Main.player[Main.myPlayer].chest == -3)
															{
																if (Main.player[Main.myPlayer].bank2[num167].stack < Main.player[Main.myPlayer].bank2[num167].maxStack && Main.player[Main.myPlayer].inventory[num166].IsTheSameAs(Main.player[Main.myPlayer].bank2[num167]))
																{
																	int num169 = Main.player[Main.myPlayer].inventory[num166].stack;
																	if (Main.player[Main.myPlayer].inventory[num166].stack + Main.player[Main.myPlayer].bank2[num167].stack > Main.player[Main.myPlayer].bank2[num167].maxStack)
																	{
																		num169 = Main.player[Main.myPlayer].bank2[num167].maxStack - Main.player[Main.myPlayer].bank2[num167].stack;
																	}
																	Main.player[Main.myPlayer].inventory[num166].stack -= num169;
																	Main.player[Main.myPlayer].bank2[num167].stack += num169;
																	Main.PlaySound(7, -1, -1, 1);
																	Main.BankCoins();
																	if (Main.player[Main.myPlayer].inventory[num166].stack <= 0)
																	{
																		Main.player[Main.myPlayer].inventory[num166].SetDefaults(0, false);
																		break;
																	}
																	if (Main.player[Main.myPlayer].bank2[num167].type == 0)
																	{
																		Main.player[Main.myPlayer].bank2[num167] = (Item)Main.player[Main.myPlayer].inventory[num166].Clone();
																		Main.player[Main.myPlayer].inventory[num166].SetDefaults(0, false);
																	}
																}
															}
															else
															{
																if (Main.player[Main.myPlayer].bank[num167].stack < Main.player[Main.myPlayer].bank[num167].maxStack && Main.player[Main.myPlayer].inventory[num166].IsTheSameAs(Main.player[Main.myPlayer].bank[num167]))
																{
																	int num170 = Main.player[Main.myPlayer].inventory[num166].stack;
																	if (Main.player[Main.myPlayer].inventory[num166].stack + Main.player[Main.myPlayer].bank[num167].stack > Main.player[Main.myPlayer].bank[num167].maxStack)
																	{
																		num170 = Main.player[Main.myPlayer].bank[num167].maxStack - Main.player[Main.myPlayer].bank[num167].stack;
																	}
																	Main.player[Main.myPlayer].inventory[num166].stack -= num170;
																	Main.player[Main.myPlayer].bank[num167].stack += num170;
																	Main.PlaySound(7, -1, -1, 1);
																	Main.BankCoins();
																	if (Main.player[Main.myPlayer].inventory[num166].stack <= 0)
																	{
																		Main.player[Main.myPlayer].inventory[num166].SetDefaults(0, false);
																		break;
																	}
																	if (Main.player[Main.myPlayer].bank[num167].type == 0)
																	{
																		Main.player[Main.myPlayer].bank[num167] = (Item)Main.player[Main.myPlayer].inventory[num166].Clone();
																		Main.player[Main.myPlayer].inventory[num166].SetDefaults(0, false);
																	}
																}
															}
														}
													}
												}
												if (Main.player[Main.myPlayer].inventory[num166].stack > 0)
												{
													if (Main.player[Main.myPlayer].chest > -1)
													{
														int num171 = 0;
														while (num171 < 20)
														{
															if (Main.chest[Main.player[Main.myPlayer].chest].item[num171].stack == 0)
															{
																Main.PlaySound(7, -1, -1, 1);
																Main.chest[Main.player[Main.myPlayer].chest].item[num171] = (Item)Main.player[Main.myPlayer].inventory[num166].Clone();
																Main.player[Main.myPlayer].inventory[num166].SetDefaults(0, false);
																if (Main.netMode == 1)
																{
																	NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num171, 0f, 0f, 0);
																	break;
																}
																break;
															}
															else
															{
																num171++;
															}
														}
													}
													else
													{
														if (Main.player[Main.myPlayer].chest == -3)
														{
															for (int num172 = 0; num172 < 20; num172++)
															{
																if (Main.player[Main.myPlayer].bank2[num172].stack == 0)
																{
																	Main.PlaySound(7, -1, -1, 1);
																	Main.player[Main.myPlayer].bank2[num172] = (Item)Main.player[Main.myPlayer].inventory[num166].Clone();
																	Main.player[Main.myPlayer].inventory[num166].SetDefaults(0, false);
																	break;
																}
															}
														}
														else
														{
															for (int num173 = 0; num173 < 20; num173++)
															{
																if (Main.player[Main.myPlayer].bank[num173].stack == 0)
																{
																	Main.PlaySound(7, -1, -1, 1);
																	Main.player[Main.myPlayer].bank[num173] = (Item)Main.player[Main.myPlayer].inventory[num166].Clone();
																	Main.player[Main.myPlayer].inventory[num166].SetDefaults(0, false);
																	break;
																}
															}
														}
													}
												}
											}
										}
									}
									else
									{
										if (Main.player[Main.myPlayer].chest > -1)
										{
											for (int num174 = 0; num174 < 20; num174++)
											{
												if (Main.chest[Main.player[Main.myPlayer].chest].item[num174].type > 0 && Main.chest[Main.player[Main.myPlayer].chest].item[num174].stack < Main.chest[Main.player[Main.myPlayer].chest].item[num174].maxStack)
												{
													for (int num175 = 0; num175 < 48; num175++)
													{
														if (Main.chest[Main.player[Main.myPlayer].chest].item[num174].IsTheSameAs(Main.player[Main.myPlayer].inventory[num175]))
														{
															int num176 = Main.player[Main.myPlayer].inventory[num175].stack;
															if (Main.chest[Main.player[Main.myPlayer].chest].item[num174].stack + num176 > Main.chest[Main.player[Main.myPlayer].chest].item[num174].maxStack)
															{
																num176 = Main.chest[Main.player[Main.myPlayer].chest].item[num174].maxStack - Main.chest[Main.player[Main.myPlayer].chest].item[num174].stack;
															}
															Main.PlaySound(7, -1, -1, 1);
															Main.chest[Main.player[Main.myPlayer].chest].item[num174].stack += num176;
															Main.player[Main.myPlayer].inventory[num175].stack -= num176;
															Main.ChestCoins();
															if (Main.player[Main.myPlayer].inventory[num175].stack == 0)
															{
																Main.player[Main.myPlayer].inventory[num175].SetDefaults(0, false);
															}
															else
															{
																if (Main.chest[Main.player[Main.myPlayer].chest].item[num174].type == 0)
																{
																	Main.chest[Main.player[Main.myPlayer].chest].item[num174] = (Item)Main.player[Main.myPlayer].inventory[num175].Clone();
																	Main.player[Main.myPlayer].inventory[num175].SetDefaults(0, false);
																}
															}
															if (Main.netMode == 1)
															{
																NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num174, 0f, 0f, 0);
															}
														}
													}
												}
											}
										}
										else
										{
											if (Main.player[Main.myPlayer].chest == -3)
											{
												for (int num177 = 0; num177 < 20; num177++)
												{
													if (Main.player[Main.myPlayer].bank2[num177].type > 0 && Main.player[Main.myPlayer].bank2[num177].stack < Main.player[Main.myPlayer].bank2[num177].maxStack)
													{
														for (int num178 = 0; num178 < 48; num178++)
														{
															if (Main.player[Main.myPlayer].bank2[num177].IsTheSameAs(Main.player[Main.myPlayer].inventory[num178]))
															{
																int num179 = Main.player[Main.myPlayer].inventory[num178].stack;
																if (Main.player[Main.myPlayer].bank2[num177].stack + num179 > Main.player[Main.myPlayer].bank2[num177].maxStack)
																{
																	num179 = Main.player[Main.myPlayer].bank2[num177].maxStack - Main.player[Main.myPlayer].bank2[num177].stack;
																}
																Main.PlaySound(7, -1, -1, 1);
																Main.player[Main.myPlayer].bank2[num177].stack += num179;
																Main.player[Main.myPlayer].inventory[num178].stack -= num179;
																Main.BankCoins();
																if (Main.player[Main.myPlayer].inventory[num178].stack == 0)
																{
																	Main.player[Main.myPlayer].inventory[num178].SetDefaults(0, false);
																}
																else
																{
																	if (Main.player[Main.myPlayer].bank2[num177].type == 0)
																	{
																		Main.player[Main.myPlayer].bank2[num177] = (Item)Main.player[Main.myPlayer].inventory[num178].Clone();
																		Main.player[Main.myPlayer].inventory[num178].SetDefaults(0, false);
																	}
																}
															}
														}
													}
												}
											}
											else
											{
												for (int num180 = 0; num180 < 20; num180++)
												{
													if (Main.player[Main.myPlayer].bank[num180].type > 0 && Main.player[Main.myPlayer].bank[num180].stack < Main.player[Main.myPlayer].bank[num180].maxStack)
													{
														for (int num181 = 0; num181 < 48; num181++)
														{
															if (Main.player[Main.myPlayer].bank[num180].IsTheSameAs(Main.player[Main.myPlayer].inventory[num181]))
															{
																int num182 = Main.player[Main.myPlayer].inventory[num181].stack;
																if (Main.player[Main.myPlayer].bank[num180].stack + num182 > Main.player[Main.myPlayer].bank[num180].maxStack)
																{
																	num182 = Main.player[Main.myPlayer].bank[num180].maxStack - Main.player[Main.myPlayer].bank[num180].stack;
																}
																Main.PlaySound(7, -1, -1, 1);
																Main.player[Main.myPlayer].bank[num180].stack += num182;
																Main.player[Main.myPlayer].inventory[num181].stack -= num182;
																Main.BankCoins();
																if (Main.player[Main.myPlayer].inventory[num181].stack == 0)
																{
																	Main.player[Main.myPlayer].inventory[num181].SetDefaults(0, false);
																}
																else
																{
																	if (Main.player[Main.myPlayer].bank[num180].type == 0)
																	{
																		Main.player[Main.myPlayer].bank[num180] = (Item)Main.player[Main.myPlayer].inventory[num181].Clone();
																		Main.player[Main.myPlayer].inventory[num181].SetDefaults(0, false);
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
								Recipe.FindRecipes();
							}
						}
						else
						{
							num162 -= 0.05f;
							if (num159 == 0)
							{
								this.chestLootHover = false;
							}
							else
							{
								if (num159 == 1)
								{
									this.chestDepositHover = false;
								}
								else
								{
									this.chestStackHover = false;
								}
							}
						}
						if ((double)num162 < 0.75)
						{
							num162 = 0.75f;
						}
						if (num162 > 1f)
						{
							num162 = 1f;
						}
						if (num159 == 0)
						{
							this.chestLootScale = num162;
						}
						else
						{
							if (num159 == 1)
							{
								this.chestDepositScale = num162;
							}
							else
							{
								this.chestStackScale = num162;
							}
						}
					}
				}
				else
				{
					this.chestLootScale = 0.75f;
					this.chestDepositScale = 0.75f;
					this.chestStackScale = 0.75f;
					this.chestLootHover = false;
					this.chestDepositHover = false;
					this.chestStackHover = false;
				}
				if (Main.player[Main.myPlayer].chest > -1)
				{
					SpriteBatch arg_BC5E_0 = this.spriteBatch;
					SpriteFont arg_BC5E_1 = Main.fontMouseText;
					string arg_BC5E_2 = Main.chestText;
					Vector2 arg_BC5E_3 = new Vector2(284f, 210f);
					Color arg_BC5E_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float arg_BC5E_5 = 0f;
					origin = default(Vector2);
					arg_BC5E_0.DrawString(arg_BC5E_1, arg_BC5E_2, arg_BC5E_3, arg_BC5E_4, arg_BC5E_5, origin, 1f, SpriteEffects.None, 0f);
					Main.inventoryScale = 0.75f;
					if (Main.mouseX > 73 && Main.mouseX < (int)(73f + 280f * Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int)(210f + 224f * Main.inventoryScale))
					{
						Main.player[Main.myPlayer].mouseInterface = true;
					}
					for (int num183 = 0; num183 < 5; num183++)
					{
						for (int num184 = 0; num184 < 4; num184++)
						{
							int num185 = (int)(73f + (float)(num183 * 56) * Main.inventoryScale);
							int num186 = (int)(210f + (float)(num184 * 56) * Main.inventoryScale);
							int num187 = num183 + num184 * 5;
							Color white14 = new Color(100, 100, 100, 100);
							if (Main.mouseX >= num185 && (float)Main.mouseX <= (float)num185 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num186 && (float)Main.mouseY <= (float)num186 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
							{
								Main.player[Main.myPlayer].mouseInterface = true;
								if (Main.mouseLeftRelease && Main.mouseLeft)
								{
									if (Main.player[Main.myPlayer].selectedItem != num187 || Main.player[Main.myPlayer].itemAnimation <= 0)
									{
										Item item9 = Main.mouseItem;
										Main.mouseItem = Main.chest[Main.player[Main.myPlayer].chest].item[num187];
										Main.chest[Main.player[Main.myPlayer].chest].item[num187] = item9;
										if (Main.chest[Main.player[Main.myPlayer].chest].item[num187].type == 0 || Main.chest[Main.player[Main.myPlayer].chest].item[num187].stack < 1)
										{
											Main.chest[Main.player[Main.myPlayer].chest].item[num187] = new Item();
										}
										if (Main.mouseItem.IsTheSameAs(Main.chest[Main.player[Main.myPlayer].chest].item[num187]) && Main.chest[Main.player[Main.myPlayer].chest].item[num187].stack != Main.chest[Main.player[Main.myPlayer].chest].item[num187].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
										{
											if (Main.mouseItem.stack + Main.chest[Main.player[Main.myPlayer].chest].item[num187].stack <= Main.mouseItem.maxStack)
											{
												Main.chest[Main.player[Main.myPlayer].chest].item[num187].stack += Main.mouseItem.stack;
												Main.mouseItem.stack = 0;
											}
											else
											{
												int num188 = Main.mouseItem.maxStack - Main.chest[Main.player[Main.myPlayer].chest].item[num187].stack;
												Main.chest[Main.player[Main.myPlayer].chest].item[num187].stack += num188;
												Main.mouseItem.stack -= num188;
											}
										}
										if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
										{
											Main.mouseItem = new Item();
										}
										if (Main.mouseItem.type > 0 || Main.chest[Main.player[Main.myPlayer].chest].item[num187].type > 0)
										{
											Recipe.FindRecipes();
											Main.PlaySound(7, -1, -1, 1);
										}
										if (Main.netMode == 1)
										{
											NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num187, 0f, 0f, 0);
										}
									}
								}
								else
								{
									if (Main.mouseRight && Main.mouseRightRelease && Main.chest[Main.player[Main.myPlayer].chest].item[num187].maxStack == 1)
									{
										Main.chest[Main.player[Main.myPlayer].chest].item[num187] = Main.armorSwap(Main.chest[Main.player[Main.myPlayer].chest].item[num187]);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num187, 0f, 0f, 0);
										}
									}
									else
									{
										if (Main.stackSplit <= 1 && Main.mouseRight && Main.chest[Main.player[Main.myPlayer].chest].item[num187].maxStack > 1 && (Main.mouseItem.IsTheSameAs(Main.chest[Main.player[Main.myPlayer].chest].item[num187]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
										{
											if (Main.mouseItem.type == 0)
											{
												Main.mouseItem = (Item)Main.chest[Main.player[Main.myPlayer].chest].item[num187].Clone();
												Main.mouseItem.stack = 0;
											}
											Main.mouseItem.stack++;
											Main.chest[Main.player[Main.myPlayer].chest].item[num187].stack--;
											if (Main.chest[Main.player[Main.myPlayer].chest].item[num187].stack <= 0)
											{
												Main.chest[Main.player[Main.myPlayer].chest].item[num187] = new Item();
											}
											Recipe.FindRecipes();
											Main.soundInstanceMenuTick.Stop();
											Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
											Main.PlaySound(12, -1, -1, 1);
											if (Main.stackSplit == 0)
											{
												Main.stackSplit = 15;
											}
											else
											{
												Main.stackSplit = Main.stackDelay;
											}
											if (Main.netMode == 1)
											{
												NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num187, 0f, 0f, 0);
											}
										}
									}
								}
								text15 = Main.chest[Main.player[Main.myPlayer].chest].item[num187].name;
								Main.toolTip = (Item)Main.chest[Main.player[Main.myPlayer].chest].item[num187].Clone();
								if (Main.chest[Main.player[Main.myPlayer].chest].item[num187].stack > 1)
								{
									object obj = text15;
									text15 = string.Concat(new object[]
									{
										obj, 
										" (", 
										Main.chest[Main.player[Main.myPlayer].chest].item[num187].stack, 
										")"
									});
								}
							}
							SpriteBatch arg_C4C4_0 = this.spriteBatch;
							Texture2D arg_C4C4_1 = Main.inventoryBack5Texture;
							Vector2 arg_C4C4_2 = new Vector2((float)num185, (float)num186);
							Rectangle? arg_C4C4_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
							Color arg_C4C4_4 = color2;
							float arg_C4C4_5 = 0f;
							origin = default(Vector2);
							arg_C4C4_0.Draw(arg_C4C4_1, arg_C4C4_2, arg_C4C4_3, arg_C4C4_4, arg_C4C4_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
							white14 = Color.White;
							if (Main.chest[Main.player[Main.myPlayer].chest].item[num187].type > 0 && Main.chest[Main.player[Main.myPlayer].chest].item[num187].stack > 0)
							{
								float num189 = 1f;
								if (Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Width > 32 || Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Height > 32)
								{
									if (Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Width > Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Height)
									{
										num189 = 32f / (float)Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Width;
									}
									else
									{
										num189 = 32f / (float)Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Height;
									}
								}
								num189 *= Main.inventoryScale;
								SpriteBatch arg_C808_0 = this.spriteBatch;
								Texture2D arg_C808_1 = Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type];
								Vector2 arg_C808_2 = new Vector2((float)num185 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Width * 0.5f * num189, (float)num186 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Height * 0.5f * num189);
								Rectangle? arg_C808_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Width, Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Height));
								Color arg_C808_4 = Main.chest[Main.player[Main.myPlayer].chest].item[num187].GetAlpha(white14);
								float arg_C808_5 = 0f;
								origin = default(Vector2);
								arg_C808_0.Draw(arg_C808_1, arg_C808_2, arg_C808_3, arg_C808_4, arg_C808_5, origin, num189, SpriteEffects.None, 0f);
								Color arg_C840_0 = Main.chest[Main.player[Main.myPlayer].chest].item[num187].color;
								Color b = default(Color);
								if (arg_C840_0 != b)
								{
									SpriteBatch arg_C9CE_0 = this.spriteBatch;
									Texture2D arg_C9CE_1 = Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type];
									Vector2 arg_C9CE_2 = new Vector2((float)num185 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Width * 0.5f * num189, (float)num186 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Height * 0.5f * num189);
									Rectangle? arg_C9CE_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Width, Main.itemTexture[Main.chest[Main.player[Main.myPlayer].chest].item[num187].type].Height));
									Color arg_C9CE_4 = Main.chest[Main.player[Main.myPlayer].chest].item[num187].GetColor(white14);
									float arg_C9CE_5 = 0f;
									origin = default(Vector2);
									arg_C9CE_0.Draw(arg_C9CE_1, arg_C9CE_2, arg_C9CE_3, arg_C9CE_4, arg_C9CE_5, origin, num189, SpriteEffects.None, 0f);
								}
								if (Main.chest[Main.player[Main.myPlayer].chest].item[num187].stack > 1)
								{
									SpriteBatch arg_CA80_0 = this.spriteBatch;
									SpriteFont arg_CA80_1 = Main.fontItemStack;
									string arg_CA80_2 = string.Concat(Main.chest[Main.player[Main.myPlayer].chest].item[num187].stack);
									Vector2 arg_CA80_3 = new Vector2((float)num185 + 10f * Main.inventoryScale, (float)num186 + 26f * Main.inventoryScale);
									Color arg_CA80_4 = white14;
									float arg_CA80_5 = 0f;
									origin = default(Vector2);
									arg_CA80_0.DrawString(arg_CA80_1, arg_CA80_2, arg_CA80_3, arg_CA80_4, arg_CA80_5, origin, num189, SpriteEffects.None, 0f);
								}
							}
						}
					}
				}
				if (Main.player[Main.myPlayer].chest == -2)
				{
					SpriteBatch arg_CB1A_0 = this.spriteBatch;
					SpriteFont arg_CB1A_1 = Main.fontMouseText;
					string arg_CB1A_2 = "Piggy Bank";
					Vector2 arg_CB1A_3 = new Vector2(284f, 210f);
					Color arg_CB1A_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float arg_CB1A_5 = 0f;
					origin = default(Vector2);
					arg_CB1A_0.DrawString(arg_CB1A_1, arg_CB1A_2, arg_CB1A_3, arg_CB1A_4, arg_CB1A_5, origin, 1f, SpriteEffects.None, 0f);
					Main.inventoryScale = 0.75f;
					if (Main.mouseX > 73 && Main.mouseX < (int)(73f + 280f * Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int)(210f + 224f * Main.inventoryScale))
					{
						Main.player[Main.myPlayer].mouseInterface = true;
					}
					for (int num190 = 0; num190 < 5; num190++)
					{
						for (int num191 = 0; num191 < 4; num191++)
						{
							int num192 = (int)(73f + (float)(num190 * 56) * Main.inventoryScale);
							int num193 = (int)(210f + (float)(num191 * 56) * Main.inventoryScale);
							int num194 = num190 + num191 * 5;
							Color white15 = new Color(100, 100, 100, 100);
							if (Main.mouseX >= num192 && (float)Main.mouseX <= (float)num192 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num193 && (float)Main.mouseY <= (float)num193 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
							{
								Main.player[Main.myPlayer].mouseInterface = true;
								if (Main.mouseLeftRelease && Main.mouseLeft)
								{
									if (Main.player[Main.myPlayer].selectedItem != num194 || Main.player[Main.myPlayer].itemAnimation <= 0)
									{
										Item item10 = Main.mouseItem;
										Main.mouseItem = Main.player[Main.myPlayer].bank[num194];
										Main.player[Main.myPlayer].bank[num194] = item10;
										if (Main.player[Main.myPlayer].bank[num194].type == 0 || Main.player[Main.myPlayer].bank[num194].stack < 1)
										{
											Main.player[Main.myPlayer].bank[num194] = new Item();
										}
										if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].bank[num194]) && Main.player[Main.myPlayer].bank[num194].stack != Main.player[Main.myPlayer].bank[num194].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
										{
											if (Main.mouseItem.stack + Main.player[Main.myPlayer].bank[num194].stack <= Main.mouseItem.maxStack)
											{
												Main.player[Main.myPlayer].bank[num194].stack += Main.mouseItem.stack;
												Main.mouseItem.stack = 0;
											}
											else
											{
												int num195 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].bank[num194].stack;
												Main.player[Main.myPlayer].bank[num194].stack += num195;
												Main.mouseItem.stack -= num195;
											}
										}
										if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
										{
											Main.mouseItem = new Item();
										}
										if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].bank[num194].type > 0)
										{
											Recipe.FindRecipes();
											Main.PlaySound(7, -1, -1, 1);
										}
									}
								}
								else
								{
									if (Main.mouseRight && Main.mouseRightRelease && Main.player[Main.myPlayer].bank[num194].maxStack == 1)
									{
										Main.player[Main.myPlayer].bank[num194] = Main.armorSwap(Main.player[Main.myPlayer].bank[num194]);
									}
									else
									{
										if (Main.stackSplit <= 1 && Main.mouseRight && Main.player[Main.myPlayer].bank[num194].maxStack > 1 && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].bank[num194]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
										{
											if (Main.mouseItem.type == 0)
											{
												Main.mouseItem = (Item)Main.player[Main.myPlayer].bank[num194].Clone();
												Main.mouseItem.stack = 0;
											}
											Main.mouseItem.stack++;
											Main.player[Main.myPlayer].bank[num194].stack--;
											if (Main.player[Main.myPlayer].bank[num194].stack <= 0)
											{
												Main.player[Main.myPlayer].bank[num194] = new Item();
											}
											Recipe.FindRecipes();
											Main.soundInstanceMenuTick.Stop();
											Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
											Main.PlaySound(12, -1, -1, 1);
											if (Main.stackSplit == 0)
											{
												Main.stackSplit = 15;
											}
											else
											{
												Main.stackSplit = Main.stackDelay;
											}
										}
									}
								}
								text15 = Main.player[Main.myPlayer].bank[num194].name;
								Main.toolTip = (Item)Main.player[Main.myPlayer].bank[num194].Clone();
								if (Main.player[Main.myPlayer].bank[num194].stack > 1)
								{
									object obj = text15;
									text15 = string.Concat(new object[]
									{
										obj, 
										" (", 
										Main.player[Main.myPlayer].bank[num194].stack, 
										")"
									});
								}
							}
							SpriteBatch arg_D1B4_0 = this.spriteBatch;
							Texture2D arg_D1B4_1 = Main.inventoryBack2Texture;
							Vector2 arg_D1B4_2 = new Vector2((float)num192, (float)num193);
							Rectangle? arg_D1B4_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
							Color arg_D1B4_4 = color2;
							float arg_D1B4_5 = 0f;
							origin = default(Vector2);
							arg_D1B4_0.Draw(arg_D1B4_1, arg_D1B4_2, arg_D1B4_3, arg_D1B4_4, arg_D1B4_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
							white15 = Color.White;
							if (Main.player[Main.myPlayer].bank[num194].type > 0 && Main.player[Main.myPlayer].bank[num194].stack > 0)
							{
								float num196 = 1f;
								if (Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Height > 32)
								{
									if (Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Width > Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Height)
									{
										num196 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Width;
									}
									else
									{
										num196 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Height;
									}
								}
								num196 *= Main.inventoryScale;
								SpriteBatch arg_D45E_0 = this.spriteBatch;
								Texture2D arg_D45E_1 = Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type];
								Vector2 arg_D45E_2 = new Vector2((float)num192 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Width * 0.5f * num196, (float)num193 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Height * 0.5f * num196);
								Rectangle? arg_D45E_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Width, Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Height));
								Color arg_D45E_4 = Main.player[Main.myPlayer].bank[num194].GetAlpha(white15);
								float arg_D45E_5 = 0f;
								origin = default(Vector2);
								arg_D45E_0.Draw(arg_D45E_1, arg_D45E_2, arg_D45E_3, arg_D45E_4, arg_D45E_5, origin, num196, SpriteEffects.None, 0f);
								Color arg_D48B_0 = Main.player[Main.myPlayer].bank[num194].color;
								Color b = default(Color);
								if (arg_D48B_0 != b)
								{
									SpriteBatch arg_D5D7_0 = this.spriteBatch;
									Texture2D arg_D5D7_1 = Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type];
									Vector2 arg_D5D7_2 = new Vector2((float)num192 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Width * 0.5f * num196, (float)num193 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Height * 0.5f * num196);
									Rectangle? arg_D5D7_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Width, Main.itemTexture[Main.player[Main.myPlayer].bank[num194].type].Height));
									Color arg_D5D7_4 = Main.player[Main.myPlayer].bank[num194].GetColor(white15);
									float arg_D5D7_5 = 0f;
									origin = default(Vector2);
									arg_D5D7_0.Draw(arg_D5D7_1, arg_D5D7_2, arg_D5D7_3, arg_D5D7_4, arg_D5D7_5, origin, num196, SpriteEffects.None, 0f);
								}
								if (Main.player[Main.myPlayer].bank[num194].stack > 1)
								{
									SpriteBatch arg_D670_0 = this.spriteBatch;
									SpriteFont arg_D670_1 = Main.fontItemStack;
									string arg_D670_2 = string.Concat(Main.player[Main.myPlayer].bank[num194].stack);
									Vector2 arg_D670_3 = new Vector2((float)num192 + 10f * Main.inventoryScale, (float)num193 + 26f * Main.inventoryScale);
									Color arg_D670_4 = white15;
									float arg_D670_5 = 0f;
									origin = default(Vector2);
									arg_D670_0.DrawString(arg_D670_1, arg_D670_2, arg_D670_3, arg_D670_4, arg_D670_5, origin, num196, SpriteEffects.None, 0f);
								}
							}
						}
					}
				}
				if (Main.player[Main.myPlayer].chest == -3)
				{
					SpriteBatch arg_D70A_0 = this.spriteBatch;
					SpriteFont arg_D70A_1 = Main.fontMouseText;
					string arg_D70A_2 = "Safe";
					Vector2 arg_D70A_3 = new Vector2(284f, 210f);
					Color arg_D70A_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float arg_D70A_5 = 0f;
					origin = default(Vector2);
					arg_D70A_0.DrawString(arg_D70A_1, arg_D70A_2, arg_D70A_3, arg_D70A_4, arg_D70A_5, origin, 1f, SpriteEffects.None, 0f);
					Main.inventoryScale = 0.75f;
					if (Main.mouseX > 73 && Main.mouseX < (int)(73f + 280f * Main.inventoryScale) && Main.mouseY > 210 && Main.mouseY < (int)(210f + 224f * Main.inventoryScale))
					{
						Main.player[Main.myPlayer].mouseInterface = true;
					}
					for (int num197 = 0; num197 < 5; num197++)
					{
						for (int num198 = 0; num198 < 4; num198++)
						{
							int num199 = (int)(73f + (float)(num197 * 56) * Main.inventoryScale);
							int num200 = (int)(210f + (float)(num198 * 56) * Main.inventoryScale);
							int num201 = num197 + num198 * 5;
							Color white16 = new Color(100, 100, 100, 100);
							if (Main.mouseX >= num199 && (float)Main.mouseX <= (float)num199 + (float)Main.inventoryBackTexture.Width * Main.inventoryScale && Main.mouseY >= num200 && (float)Main.mouseY <= (float)num200 + (float)Main.inventoryBackTexture.Height * Main.inventoryScale)
							{
								Main.player[Main.myPlayer].mouseInterface = true;
								if (Main.mouseLeftRelease && Main.mouseLeft)
								{
									if (Main.player[Main.myPlayer].selectedItem != num201 || Main.player[Main.myPlayer].itemAnimation <= 0)
									{
										Item item11 = Main.mouseItem;
										Main.mouseItem = Main.player[Main.myPlayer].bank2[num201];
										Main.player[Main.myPlayer].bank2[num201] = item11;
										if (Main.player[Main.myPlayer].bank2[num201].type == 0 || Main.player[Main.myPlayer].bank2[num201].stack < 1)
										{
											Main.player[Main.myPlayer].bank2[num201] = new Item();
										}
										if (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].bank2[num201]) && Main.player[Main.myPlayer].bank2[num201].stack != Main.player[Main.myPlayer].bank2[num201].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
										{
											if (Main.mouseItem.stack + Main.player[Main.myPlayer].bank2[num201].stack <= Main.mouseItem.maxStack)
											{
												Main.player[Main.myPlayer].bank2[num201].stack += Main.mouseItem.stack;
												Main.mouseItem.stack = 0;
											}
											else
											{
												int num202 = Main.mouseItem.maxStack - Main.player[Main.myPlayer].bank2[num201].stack;
												Main.player[Main.myPlayer].bank2[num201].stack += num202;
												Main.mouseItem.stack -= num202;
											}
										}
										if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
										{
											Main.mouseItem = new Item();
										}
										if (Main.mouseItem.type > 0 || Main.player[Main.myPlayer].bank2[num201].type > 0)
										{
											Recipe.FindRecipes();
											Main.PlaySound(7, -1, -1, 1);
										}
									}
								}
								else
								{
									if (Main.mouseRight && Main.mouseRightRelease && Main.player[Main.myPlayer].bank2[num201].maxStack == 1)
									{
										Main.player[Main.myPlayer].bank2[num201] = Main.armorSwap(Main.player[Main.myPlayer].bank2[num201]);
									}
									else
									{
										if (Main.stackSplit <= 1 && Main.mouseRight && Main.player[Main.myPlayer].bank2[num201].maxStack > 1 && (Main.mouseItem.IsTheSameAs(Main.player[Main.myPlayer].bank2[num201]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
										{
											if (Main.mouseItem.type == 0)
											{
												Main.mouseItem = (Item)Main.player[Main.myPlayer].bank2[num201].Clone();
												Main.mouseItem.stack = 0;
											}
											Main.mouseItem.stack++;
											Main.player[Main.myPlayer].bank2[num201].stack--;
											if (Main.player[Main.myPlayer].bank2[num201].stack <= 0)
											{
												Main.player[Main.myPlayer].bank2[num201] = new Item();
											}
											Recipe.FindRecipes();
											Main.soundInstanceMenuTick.Stop();
											Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
											Main.PlaySound(12, -1, -1, 1);
											if (Main.stackSplit == 0)
											{
												Main.stackSplit = 15;
											}
											else
											{
												Main.stackSplit = Main.stackDelay;
											}
										}
									}
								}
								text15 = Main.player[Main.myPlayer].bank2[num201].name;
								Main.toolTip = (Item)Main.player[Main.myPlayer].bank2[num201].Clone();
								if (Main.player[Main.myPlayer].bank2[num201].stack > 1)
								{
									object obj = text15;
									text15 = string.Concat(new object[]
									{
										obj, 
										" (", 
										Main.player[Main.myPlayer].bank2[num201].stack, 
										")"
									});
								}
							}
							SpriteBatch arg_DDA4_0 = this.spriteBatch;
							Texture2D arg_DDA4_1 = Main.inventoryBack2Texture;
							Vector2 arg_DDA4_2 = new Vector2((float)num199, (float)num200);
							Rectangle? arg_DDA4_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
							Color arg_DDA4_4 = color2;
							float arg_DDA4_5 = 0f;
							origin = default(Vector2);
							arg_DDA4_0.Draw(arg_DDA4_1, arg_DDA4_2, arg_DDA4_3, arg_DDA4_4, arg_DDA4_5, origin, Main.inventoryScale, SpriteEffects.None, 0f);
							white16 = Color.White;
							if (Main.player[Main.myPlayer].bank2[num201].type > 0 && Main.player[Main.myPlayer].bank2[num201].stack > 0)
							{
								float num203 = 1f;
								if (Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Height > 32)
								{
									if (Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Width > Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Height)
									{
										num203 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Width;
									}
									else
									{
										num203 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Height;
									}
								}
								num203 *= Main.inventoryScale;
								SpriteBatch arg_E04E_0 = this.spriteBatch;
								Texture2D arg_E04E_1 = Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type];
								Vector2 arg_E04E_2 = new Vector2((float)num199 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Width * 0.5f * num203, (float)num200 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Height * 0.5f * num203);
								Rectangle? arg_E04E_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Width, Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Height));
								Color arg_E04E_4 = Main.player[Main.myPlayer].bank2[num201].GetAlpha(white16);
								float arg_E04E_5 = 0f;
								origin = default(Vector2);
								arg_E04E_0.Draw(arg_E04E_1, arg_E04E_2, arg_E04E_3, arg_E04E_4, arg_E04E_5, origin, num203, SpriteEffects.None, 0f);
								Color arg_E07B_0 = Main.player[Main.myPlayer].bank2[num201].color;
								Color b = default(Color);
								if (arg_E07B_0 != b)
								{
									SpriteBatch arg_E1C7_0 = this.spriteBatch;
									Texture2D arg_E1C7_1 = Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type];
									Vector2 arg_E1C7_2 = new Vector2((float)num199 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Width * 0.5f * num203, (float)num200 + 26f * Main.inventoryScale - (float)Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Height * 0.5f * num203);
									Rectangle? arg_E1C7_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Width, Main.itemTexture[Main.player[Main.myPlayer].bank2[num201].type].Height));
									Color arg_E1C7_4 = Main.player[Main.myPlayer].bank2[num201].GetColor(white16);
									float arg_E1C7_5 = 0f;
									origin = default(Vector2);
									arg_E1C7_0.Draw(arg_E1C7_1, arg_E1C7_2, arg_E1C7_3, arg_E1C7_4, arg_E1C7_5, origin, num203, SpriteEffects.None, 0f);
								}
								if (Main.player[Main.myPlayer].bank2[num201].stack > 1)
								{
									SpriteBatch arg_E260_0 = this.spriteBatch;
									SpriteFont arg_E260_1 = Main.fontItemStack;
									string arg_E260_2 = string.Concat(Main.player[Main.myPlayer].bank2[num201].stack);
									Vector2 arg_E260_3 = new Vector2((float)num199 + 10f * Main.inventoryScale, (float)num200 + 26f * Main.inventoryScale);
									Color arg_E260_4 = white16;
									float arg_E260_5 = 0f;
									origin = default(Vector2);
									arg_E260_0.DrawString(arg_E260_1, arg_E260_2, arg_E260_3, arg_E260_4, arg_E260_5, origin, num203, SpriteEffects.None, 0f);
								}
							}
						}
					}
				}
			}
			else
			{
				if (Main.npcChatText == null || Main.npcChatText == "")
				{
					bool flag6 = false;
					bool flag7 = false;
					bool flag8 = false;
					for (int num204 = 0; num204 < 3; num204++)
					{
						string text24 = "";
						if (Main.player[Main.myPlayer].accCompass > 0 && !flag8)
						{
							int num205 = (int)((Main.player[Main.myPlayer].position.X + (float)(Main.player[Main.myPlayer].width / 2)) * 2f / 16f - (float)Main.maxTilesX);
							if (num205 > 0)
							{
								text24 = "Position: " + num205 + " feet east";
								if (num205 == 1)
								{
									text24 = "Position: " + num205 + " foot east";
								}
							}
							else
							{
								if (num205 < 0)
								{
									num205 *= -1;
									text24 = "Position: " + num205 + " feet west";
									if (num205 == 1)
									{
										text24 = "Position: " + num205 + " foot west";
									}
								}
								else
								{
									text24 = "Position: center";
								}
							}
							flag8 = true;
						}
						else
						{
							if (Main.player[Main.myPlayer].accDepthMeter > 0 && !flag7)
							{
								int num206 = (int)((double)((Main.player[Main.myPlayer].position.Y + (float)Main.player[Main.myPlayer].height) * 2f / 16f) - Main.worldSurface * 2.0);
								if (num206 > 0)
								{
									text24 = "Depth: " + num206 + " feet below";
									if (num206 == 1)
									{
										text24 = "Depth: " + num206 + " foot below";
									}
								}
								else
								{
									if (num206 < 0)
									{
										num206 *= -1;
										text24 = "Depth: " + num206 + " feet above";
										if (num206 == 1)
										{
											text24 = "Depth: " + num206 + " foot above";
										}
									}
									else
									{
										text24 = "Depth: Level";
									}
								}
								flag7 = true;
							}
							else
							{
								if (Main.player[Main.myPlayer].accWatch > 0 && !flag6)
								{
									string text25 = "AM";
									double num207 = Main.time;
									if (!Main.dayTime)
									{
										num207 += 54000.0;
									}
									num207 = num207 / 86400.0 * 24.0;
									double num208 = 7.5;
									num207 = num207 - num208 - 12.0;
									if (num207 < 0.0)
									{
										num207 += 24.0;
									}
									if (num207 >= 12.0)
									{
										text25 = "PM";
									}
									int num209 = (int)num207;
									double num210 = num207 - (double)num209;
									num210 = (double)((int)(num210 * 60.0));
									string text26 = string.Concat(num210);
									if (num210 < 10.0)
									{
										text26 = "0" + text26;
									}
									if (num209 > 12)
									{
										num209 -= 12;
									}
									if (num209 == 0)
									{
										num209 = 12;
									}
									if (Main.player[Main.myPlayer].accWatch == 1)
									{
										text26 = "00";
									}
									else
									{
										if (Main.player[Main.myPlayer].accWatch == 2)
										{
											if (num210 < 30.0)
											{
												text26 = "00";
											}
											else
											{
												text26 = "30";
											}
										}
									}
									text24 = string.Concat(new object[]
									{
										"Time: ", 
										num209, 
										":", 
										text26, 
										" ", 
										text25
									});
									flag6 = true;
								}
							}
						}
						if (text24 != "")
						{
							for (int num211 = 0; num211 < 5; num211++)
							{
								int num212 = 0;
								int num213 = 0;
								Color black = Color.Black;
								if (num211 == 0)
								{
									num212 = -2;
								}
								if (num211 == 1)
								{
									num212 = 2;
								}
								if (num211 == 2)
								{
									num213 = -2;
								}
								if (num211 == 3)
								{
									num213 = 2;
								}
								if (num211 == 4)
								{
									black = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
								}
								SpriteBatch arg_E7BB_0 = this.spriteBatch;
								SpriteFont arg_E7BB_1 = Main.fontMouseText;
								string arg_E7BB_2 = text24;
								Vector2 arg_E7BB_3 = new Vector2((float)(22 + num212), (float)(110 + 22 * num204 + num213 + 48));
								Color arg_E7BB_4 = black;
								float arg_E7BB_5 = 0f;
								origin = default(Vector2);
								arg_E7BB_0.DrawString(arg_E7BB_1, arg_E7BB_2, arg_E7BB_3, arg_E7BB_4, arg_E7BB_5, origin, 1f, SpriteEffects.None, 0f);
							}
						}
					}
				}
			}
			if (Main.playerInventory || Main.player[Main.myPlayer].ghost)
			{
				string text27 = "Save & Exit";
				if (Main.netMode != 0)
				{
					text27 = "Disconnect";
				}
				Vector2 vector8 = Main.fontDeathText.MeasureString(text27);
				int num214 = Main.screenWidth - 110;
				int num215 = Main.screenHeight - 20;
				if (Main.mouseExit)
				{
					if (Main.exitScale < 1f)
					{
						Main.exitScale += 0.02f;
					}
				}
				else
				{
					if ((double)Main.exitScale > 0.8)
					{
						Main.exitScale -= 0.02f;
					}
				}
				for (int num216 = 0; num216 < 5; num216++)
				{
					int num217 = 0;
					int num218 = 0;
					Color color9 = Color.Black;
					if (num216 == 0)
					{
						num217 = -2;
					}
					if (num216 == 1)
					{
						num217 = 2;
					}
					if (num216 == 2)
					{
						num218 = -2;
					}
					if (num216 == 3)
					{
						num218 = 2;
					}
					if (num216 == 4)
					{
						color9 = Color.White;
					}
					this.spriteBatch.DrawString(Main.fontDeathText, text27, new Vector2((float)(num214 + num217), (float)(num215 + num218)), color9, 0f, new Vector2(vector8.X / 2f, vector8.Y / 2f), Main.exitScale - 0.2f, SpriteEffects.None, 0f);
				}
				if ((float)Main.mouseX > (float)num214 - vector8.X / 2f && (float)Main.mouseX < (float)num214 + vector8.X / 2f && (float)Main.mouseY > (float)num215 - vector8.Y / 2f && (float)Main.mouseY < (float)num215 + vector8.Y / 2f - 10f)
				{
					if (!Main.mouseExit)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					Main.mouseExit = true;
					Main.player[Main.myPlayer].mouseInterface = true;
					if (Main.mouseLeftRelease && Main.mouseLeft)
					{
						Main.menuMode = 10;
						WorldGen.SaveAndQuit();
					}
				}
				else
				{
					Main.mouseExit = false;
				}
			}
			if (!Main.playerInventory && !Main.player[Main.myPlayer].ghost)
			{
				string text28 = "Items";
				if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name != "" && Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name != null)
				{
					text28 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].AffixName();
				}
				Vector2 vector9 = Main.fontMouseText.MeasureString(text28) / 2f;
				SpriteBatch arg_EB5A_0 = this.spriteBatch;
				SpriteFont arg_EB5A_1 = Main.fontMouseText;
				string arg_EB5A_2 = text28;
				Vector2 arg_EB5A_3 = new Vector2(236f - vector9.X, 0f);
				Color arg_EB5A_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
				float arg_EB5A_5 = 0f;
				origin = default(Vector2);
				arg_EB5A_0.DrawString(arg_EB5A_1, arg_EB5A_2, arg_EB5A_3, arg_EB5A_4, arg_EB5A_5, origin, 1f, SpriteEffects.None, 0f);
				int num219 = 20;
				float num220 = 1f;
				for (int num221 = 0; num221 < 10; num221++)
				{
					if (num221 == Main.player[Main.myPlayer].selectedItem)
					{
						if (Main.hotbarScale[num221] < 1f)
						{
							Main.hotbarScale[num221] += 0.05f;
						}
					}
					else
					{
						if ((double)Main.hotbarScale[num221] > 0.75)
						{
							Main.hotbarScale[num221] -= 0.05f;
						}
					}
					float num222 = Main.hotbarScale[num221];
					int num223 = (int)(20f + 22f * (1f - num222));
					int a3 = (int)(75f + 150f * num222);
					Color color10 = new Color(255, 255, 255, a3);
					SpriteBatch arg_ECB3_0 = this.spriteBatch;
					Texture2D arg_ECB3_1 = Main.inventoryBackTexture;
					Vector2 arg_ECB3_2 = new Vector2((float)num219, (float)num223);
					Rectangle? arg_ECB3_3 = new Rectangle?(new Rectangle(0, 0, Main.inventoryBackTexture.Width, Main.inventoryBackTexture.Height));
					Color arg_ECB3_4 = new Color(100, 100, 100, 100);
					float arg_ECB3_5 = 0f;
					origin = default(Vector2);
					arg_ECB3_0.Draw(arg_ECB3_1, arg_ECB3_2, arg_ECB3_3, arg_ECB3_4, arg_ECB3_5, origin, num222, SpriteEffects.None, 0f);
					if (!Main.player[Main.myPlayer].hbLocked && Main.mouseX >= num219 && (float)Main.mouseX <= (float)num219 + (float)Main.inventoryBackTexture.Width * Main.hotbarScale[num221] && Main.mouseY >= num223 && (float)Main.mouseY <= (float)num223 + (float)Main.inventoryBackTexture.Height * Main.hotbarScale[num221] && !Main.player[Main.myPlayer].channel)
					{
						Main.player[Main.myPlayer].mouseInterface = true;
						if (Main.mouseLeft && !Main.player[Main.myPlayer].hbLocked)
						{
							Main.player[Main.myPlayer].changeItem = num221;
						}
						Main.player[Main.myPlayer].showItemIcon = false;
						text15 = Main.player[Main.myPlayer].inventory[num221].AffixName();
						if (Main.player[Main.myPlayer].inventory[num221].stack > 1)
						{
							object obj = text15;
							text15 = string.Concat(new object[]
							{
								obj, 
								" (", 
								Main.player[Main.myPlayer].inventory[num221].stack, 
								")"
							});
						}
						rare = Main.player[Main.myPlayer].inventory[num221].rare;
					}
					if (Main.player[Main.myPlayer].inventory[num221].type > 0 && Main.player[Main.myPlayer].inventory[num221].stack > 0)
					{
						num220 = 1f;
						if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Width > 32 || Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Height > 32)
						{
							if (Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Width > Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Height)
							{
								num220 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Width;
							}
							else
							{
								num220 = 32f / (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Height;
							}
						}
						num220 *= num222;
						SpriteBatch arg_F0E9_0 = this.spriteBatch;
						Texture2D arg_F0E9_1 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type];
						Vector2 arg_F0E9_2 = new Vector2((float)num219 + 26f * num222 - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Width * 0.5f * num220, (float)num223 + 26f * num222 - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Height * 0.5f * num220);
						Rectangle? arg_F0E9_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Height));
						Color arg_F0E9_4 = Main.player[Main.myPlayer].inventory[num221].GetAlpha(color10);
						float arg_F0E9_5 = 0f;
						origin = default(Vector2);
						arg_F0E9_0.Draw(arg_F0E9_1, arg_F0E9_2, arg_F0E9_3, arg_F0E9_4, arg_F0E9_5, origin, num220, SpriteEffects.None, 0f);
						Color arg_F116_0 = Main.player[Main.myPlayer].inventory[num221].color;
						Color b = default(Color);
						if (arg_F116_0 != b)
						{
							SpriteBatch arg_F260_0 = this.spriteBatch;
							Texture2D arg_F260_1 = Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type];
							Vector2 arg_F260_2 = new Vector2((float)num219 + 26f * num222 - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Width * 0.5f * num220, (float)num223 + 26f * num222 - (float)Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Height * 0.5f * num220);
							Rectangle? arg_F260_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[num221].type].Height));
							Color arg_F260_4 = Main.player[Main.myPlayer].inventory[num221].GetColor(color10);
							float arg_F260_5 = 0f;
							origin = default(Vector2);
							arg_F260_0.Draw(arg_F260_1, arg_F260_2, arg_F260_3, arg_F260_4, arg_F260_5, origin, num220, SpriteEffects.None, 0f);
						}
						if (Main.player[Main.myPlayer].inventory[num221].stack > 1)
						{
							SpriteBatch arg_F2F7_0 = this.spriteBatch;
							SpriteFont arg_F2F7_1 = Main.fontItemStack;
							string arg_F2F7_2 = string.Concat(Main.player[Main.myPlayer].inventory[num221].stack);
							Vector2 arg_F2F7_3 = new Vector2((float)num219 + 10f * num222, (float)num223 + 26f * num222);
							Color arg_F2F7_4 = color10;
							float arg_F2F7_5 = 0f;
							origin = default(Vector2);
							arg_F2F7_0.DrawString(arg_F2F7_1, arg_F2F7_2, arg_F2F7_3, arg_F2F7_4, arg_F2F7_5, origin, num220, SpriteEffects.None, 0f);
						}
						if (Main.player[Main.myPlayer].inventory[num221].useAmmo > 0)
						{
							int useAmmo = Main.player[Main.myPlayer].inventory[num221].useAmmo;
							int num224 = 0;
							for (int num225 = 0; num225 < 48; num225++)
							{
								if (Main.player[Main.myPlayer].inventory[num225].ammo == useAmmo)
								{
									num224 += Main.player[Main.myPlayer].inventory[num225].stack;
								}
							}
							SpriteBatch arg_F400_0 = this.spriteBatch;
							SpriteFont arg_F400_1 = Main.fontItemStack;
							string arg_F400_2 = string.Concat(num224);
							Vector2 arg_F400_3 = new Vector2((float)num219 + 8f * num222, (float)num223 + 30f * num222);
							Color arg_F400_4 = color10;
							float arg_F400_5 = 0f;
							origin = default(Vector2);
							arg_F400_0.DrawString(arg_F400_1, arg_F400_2, arg_F400_3, arg_F400_4, arg_F400_5, origin, num222 * 0.8f, SpriteEffects.None, 0f);
						}
						else
						{
							if (Main.player[Main.myPlayer].inventory[num221].type == 509)
							{
								int num226 = 0;
								for (int num227 = 0; num227 < 48; num227++)
								{
									if (Main.player[Main.myPlayer].inventory[num227].type == 530)
									{
										num226 += Main.player[Main.myPlayer].inventory[num227].stack;
									}
								}
								SpriteBatch arg_F4F5_0 = this.spriteBatch;
								SpriteFont arg_F4F5_1 = Main.fontItemStack;
								string arg_F4F5_2 = string.Concat(num226);
								Vector2 arg_F4F5_3 = new Vector2((float)num219 + 8f * num222, (float)num223 + 30f * num222);
								Color arg_F4F5_4 = color10;
								float arg_F4F5_5 = 0f;
								origin = default(Vector2);
								arg_F4F5_0.DrawString(arg_F4F5_1, arg_F4F5_2, arg_F4F5_3, arg_F4F5_4, arg_F4F5_5, origin, num222 * 0.8f, SpriteEffects.None, 0f);
							}
						}
						string text29 = string.Concat(num221 + 1);
						if (text29 == "10")
						{
							text29 = "0";
						}
						SpriteBatch arg_F5B5_0 = this.spriteBatch;
						SpriteFont arg_F5B5_1 = Main.fontItemStack;
						string arg_F5B5_2 = text29;
						Vector2 arg_F5B5_3 = new Vector2((float)num219 + 8f * Main.hotbarScale[num221], (float)num223 + 4f * Main.hotbarScale[num221]);
						Color arg_F5B5_4 = new Color((int)(color10.R / 2), (int)(color10.G / 2), (int)(color10.B / 2), (int)(color10.A / 2));
						float arg_F5B5_5 = 0f;
						origin = default(Vector2);
						arg_F5B5_0.DrawString(arg_F5B5_1, arg_F5B5_2, arg_F5B5_3, arg_F5B5_4, arg_F5B5_5, origin, num220, SpriteEffects.None, 0f);
						if (Main.player[Main.myPlayer].inventory[num221].potion)
						{
							Color alpha = Main.player[Main.myPlayer].inventory[num221].GetAlpha(color10);
							float num228 = (float)Main.player[Main.myPlayer].potionDelay / (float)Main.player[Main.myPlayer].potionDelayTime;
							float num229 = (float)alpha.R * num228;
							float num230 = (float)alpha.G * num228;
							float num231 = (float)alpha.B * num228;
							float num232 = (float)alpha.A * num228;
							alpha = new Color((int)((byte)num229), (int)((byte)num230), (int)((byte)num231), (int)((byte)num232));
							SpriteBatch arg_F736_0 = this.spriteBatch;
							Texture2D arg_F736_1 = Main.cdTexture;
							Vector2 arg_F736_2 = new Vector2((float)num219 + 26f * Main.hotbarScale[num221] - (float)Main.cdTexture.Width * 0.5f * num220, (float)num223 + 26f * Main.hotbarScale[num221] - (float)Main.cdTexture.Height * 0.5f * num220);
							Rectangle? arg_F736_3 = new Rectangle?(new Rectangle(0, 0, Main.cdTexture.Width, Main.cdTexture.Height));
							Color arg_F736_4 = alpha;
							float arg_F736_5 = 0f;
							origin = default(Vector2);
							arg_F736_0.Draw(arg_F736_1, arg_F736_2, arg_F736_3, arg_F736_4, arg_F736_5, origin, num220, SpriteEffects.None, 0f);
						}
					}
					num219 += (int)((float)Main.inventoryBackTexture.Width * Main.hotbarScale[num221]) + 4;
				}
			}
			if (Main.mouseItem.stack <= 0)
			{
				Main.mouseItem.type = 0;
			}
			if (text15 != null && text15 != "" && Main.mouseItem.type == 0)
			{
				Main.player[Main.myPlayer].showItemIcon = false;
				this.MouseText(text15, rare, 0);
				flag = true;
			}
			if (Main.chatMode)
			{
				this.textBlinkerCount++;
				if (this.textBlinkerCount >= 20)
				{
					if (this.textBlinkerState == 0)
					{
						this.textBlinkerState = 1;
					}
					else
					{
						this.textBlinkerState = 0;
					}
					this.textBlinkerCount = 0;
				}
				string text30 = Main.chatText;
				if (this.textBlinkerState == 1)
				{
					text30 += "|";
				}
				SpriteBatch arg_F895_0 = this.spriteBatch;
				Texture2D arg_F895_1 = Main.textBackTexture;
				Vector2 arg_F895_2 = new Vector2(78f, (float)(Main.screenHeight - 36));
				Rectangle? arg_F895_3 = new Rectangle?(new Rectangle(0, 0, Main.textBackTexture.Width, Main.textBackTexture.Height));
				Color arg_F895_4 = new Color(100, 100, 100, 100);
				float arg_F895_5 = 0f;
				origin = default(Vector2);
				arg_F895_0.Draw(arg_F895_1, arg_F895_2, arg_F895_3, arg_F895_4, arg_F895_5, origin, 1f, SpriteEffects.None, 0f);
				for (int num233 = 0; num233 < 5; num233++)
				{
					int num234 = 0;
					int num235 = 0;
					Color black2 = Color.Black;
					if (num233 == 0)
					{
						num234 = -2;
					}
					if (num233 == 1)
					{
						num234 = 2;
					}
					if (num233 == 2)
					{
						num235 = -2;
					}
					if (num233 == 3)
					{
						num235 = 2;
					}
					if (num233 == 4)
					{
						black2 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					}
					SpriteBatch arg_F958_0 = this.spriteBatch;
					SpriteFont arg_F958_1 = Main.fontMouseText;
					string arg_F958_2 = text30;
					Vector2 arg_F958_3 = new Vector2((float)(88 + num234), (float)(Main.screenHeight - 30 + num235));
					Color arg_F958_4 = black2;
					float arg_F958_5 = 0f;
					origin = default(Vector2);
					arg_F958_0.DrawString(arg_F958_1, arg_F958_2, arg_F958_3, arg_F958_4, arg_F958_5, origin, 1f, SpriteEffects.None, 0f);
				}
			}
			for (int num236 = 0; num236 < Main.numChatLines; num236++)
			{
				if (Main.chatMode || Main.chatLine[num236].showTime > 0)
				{
					float num237 = (float)Main.mouseTextColor / 255f;
					for (int num238 = 0; num238 < 5; num238++)
					{
						int num239 = 0;
						int num240 = 0;
						Color black3 = Color.Black;
						if (num238 == 0)
						{
							num239 = -2;
						}
						if (num238 == 1)
						{
							num239 = 2;
						}
						if (num238 == 2)
						{
							num240 = -2;
						}
						if (num238 == 3)
						{
							num240 = 2;
						}
						if (num238 == 4)
						{
							black3 = new Color((int)((byte)((float)Main.chatLine[num236].color.R * num237)), (int)((byte)((float)Main.chatLine[num236].color.G * num237)), (int)((byte)((float)Main.chatLine[num236].color.B * num237)), (int)Main.mouseTextColor);
						}
						SpriteBatch arg_FABD_0 = this.spriteBatch;
						SpriteFont arg_FABD_1 = Main.fontMouseText;
						string arg_FABD_2 = Main.chatLine[num236].text;
						Vector2 arg_FABD_3 = new Vector2((float)(88 + num239), (float)(Main.screenHeight - 30 + num240 - 28 - num236 * 21));
						Color arg_FABD_4 = black3;
						float arg_FABD_5 = 0f;
						origin = default(Vector2);
						arg_FABD_0.DrawString(arg_FABD_1, arg_FABD_2, arg_FABD_3, arg_FABD_4, arg_FABD_5, origin, 1f, SpriteEffects.None, 0f);
					}
				}
			}
			if (Main.player[Main.myPlayer].dead)
			{
				string text31 = "You were slain...";
				SpriteBatch arg_FB74_0 = this.spriteBatch;
				SpriteFont arg_FB74_1 = Main.fontDeathText;
				string arg_FB74_2 = text31;
				Vector2 arg_FB74_3 = new Vector2((float)(Main.screenWidth / 2 - text31.Length * 10), (float)(Main.screenHeight / 2 - 20));
				Color arg_FB74_4 = Main.player[Main.myPlayer].GetDeathAlpha(new Color(0, 0, 0, 0));
				float arg_FB74_5 = 0f;
				origin = default(Vector2);
				arg_FB74_0.DrawString(arg_FB74_1, arg_FB74_2, arg_FB74_3, arg_FB74_4, arg_FB74_5, origin, 1f, SpriteEffects.None, 0f);
			}
			SpriteBatch arg_FC2A_0 = this.spriteBatch;
			Texture2D arg_FC2A_1 = Main.cursorTexture;
			Vector2 arg_FC2A_2 = new Vector2((float)(Main.mouseX + 1), (float)(Main.mouseY + 1));
			Rectangle? arg_FC2A_3 = new Rectangle?(new Rectangle(0, 0, Main.cursorTexture.Width, Main.cursorTexture.Height));
			Color arg_FC2A_4 = new Color((int)((float)Main.cursorColor.R * 0.2f), (int)((float)Main.cursorColor.G * 0.2f), (int)((float)Main.cursorColor.B * 0.2f), (int)((float)Main.cursorColor.A * 0.5f));
			float arg_FC2A_5 = 0f;
			origin = default(Vector2);
			arg_FC2A_0.Draw(arg_FC2A_1, arg_FC2A_2, arg_FC2A_3, arg_FC2A_4, arg_FC2A_5, origin, Main.cursorScale * 1.1f, SpriteEffects.None, 0f);
			SpriteBatch arg_FC8E_0 = this.spriteBatch;
			Texture2D arg_FC8E_1 = Main.cursorTexture;
			Vector2 arg_FC8E_2 = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			Rectangle? arg_FC8E_3 = new Rectangle?(new Rectangle(0, 0, Main.cursorTexture.Width, Main.cursorTexture.Height));
			Color arg_FC8E_4 = Main.cursorColor;
			float arg_FC8E_5 = 0f;
			origin = default(Vector2);
			arg_FC8E_0.Draw(arg_FC8E_1, arg_FC8E_2, arg_FC8E_3, arg_FC8E_4, arg_FC8E_5, origin, Main.cursorScale, SpriteEffects.None, 0f);
			if (Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
			{
				this.mouseNPC = -1;
				Main.player[Main.myPlayer].showItemIcon = false;
				Main.player[Main.myPlayer].showItemIcon2 = 0;
				flag = true;
				float num241 = 1f;
				if (Main.itemTexture[Main.mouseItem.type].Width > 32 || Main.itemTexture[Main.mouseItem.type].Height > 32)
				{
					if (Main.itemTexture[Main.mouseItem.type].Width > Main.itemTexture[Main.mouseItem.type].Height)
					{
						num241 = 32f / (float)Main.itemTexture[Main.mouseItem.type].Width;
					}
					else
					{
						num241 = 32f / (float)Main.itemTexture[Main.mouseItem.type].Height;
					}
				}
				float num242 = 1f;
				num242 *= Main.cursorScale;
				Color white17 = Color.White;
				num241 *= num242;
				SpriteBatch arg_FE97_0 = this.spriteBatch;
				Texture2D arg_FE97_1 = Main.itemTexture[Main.mouseItem.type];
				Vector2 arg_FE97_2 = new Vector2((float)Main.mouseX + 26f * num242 - (float)Main.itemTexture[Main.mouseItem.type].Width * 0.5f * num241, (float)Main.mouseY + 26f * num242 - (float)Main.itemTexture[Main.mouseItem.type].Height * 0.5f * num241);
				Rectangle? arg_FE97_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.mouseItem.type].Width, Main.itemTexture[Main.mouseItem.type].Height));
				Color arg_FE97_4 = Main.mouseItem.GetAlpha(white17);
				float arg_FE97_5 = 0f;
				origin = default(Vector2);
				arg_FE97_0.Draw(arg_FE97_1, arg_FE97_2, arg_FE97_3, arg_FE97_4, arg_FE97_5, origin, num241, SpriteEffects.None, 0f);
				Color arg_FEB4_0 = Main.mouseItem.color;
				Color b = default(Color);
				if (arg_FEB4_0 != b)
				{
					SpriteBatch arg_FFA0_0 = this.spriteBatch;
					Texture2D arg_FFA0_1 = Main.itemTexture[Main.mouseItem.type];
					Vector2 arg_FFA0_2 = new Vector2((float)Main.mouseX + 26f * num242 - (float)Main.itemTexture[Main.mouseItem.type].Width * 0.5f * num241, (float)Main.mouseY + 26f * num242 - (float)Main.itemTexture[Main.mouseItem.type].Height * 0.5f * num241);
					Rectangle? arg_FFA0_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.mouseItem.type].Width, Main.itemTexture[Main.mouseItem.type].Height));
					Color arg_FFA0_4 = Main.mouseItem.GetColor(white17);
					float arg_FFA0_5 = 0f;
					origin = default(Vector2);
					arg_FFA0_0.Draw(arg_FFA0_1, arg_FFA0_2, arg_FFA0_3, arg_FFA0_4, arg_FFA0_5, origin, num241, SpriteEffects.None, 0f);
				}
				if (Main.mouseItem.stack > 1)
				{
					SpriteBatch arg_1001C_0 = this.spriteBatch;
					SpriteFont arg_1001C_1 = Main.fontItemStack;
					string arg_1001C_2 = string.Concat(Main.mouseItem.stack);
					Vector2 arg_1001C_3 = new Vector2((float)Main.mouseX + 10f * num242, (float)Main.mouseY + 26f * num242);
					Color arg_1001C_4 = white17;
					float arg_1001C_5 = 0f;
					origin = default(Vector2);
					arg_1001C_0.DrawString(arg_1001C_1, arg_1001C_2, arg_1001C_3, arg_1001C_4, arg_1001C_5, origin, num241, SpriteEffects.None, 0f);
				}
			}
			else
			{
				if (this.mouseNPC > -1)
				{
					Main.player[Main.myPlayer].mouseInterface = true;
					flag = false;
					float num243 = 1f;
					num243 *= Main.cursorScale;
					SpriteBatch arg_10122_0 = this.spriteBatch;
					Texture2D arg_10122_1 = Main.npcHeadTexture[this.mouseNPC];
					Vector2 arg_10122_2 = new Vector2((float)Main.mouseX + 26f * num243 - (float)Main.npcHeadTexture[this.mouseNPC].Width * 0.5f * num243, (float)Main.mouseY + 26f * num243 - (float)Main.npcHeadTexture[this.mouseNPC].Height * 0.5f * num243);
					Rectangle? arg_10122_3 = new Rectangle?(new Rectangle(0, 0, Main.npcHeadTexture[this.mouseNPC].Width, Main.npcHeadTexture[this.mouseNPC].Height));
					Color arg_10122_4 = Color.White;
					float arg_10122_5 = 0f;
					origin = default(Vector2);
					arg_10122_0.Draw(arg_10122_1, arg_10122_2, arg_10122_3, arg_10122_4, arg_10122_5, origin, num243, SpriteEffects.None, 0f);
					if (Main.mouseRight && Main.mouseRightRelease)
					{
						Main.PlaySound(12, -1, -1, 1);
						this.mouseNPC = -1;
					}
					if (Main.mouseLeft && Main.mouseLeftRelease)
					{
						if (this.mouseNPC == 0)
						{
							int x = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
							int y = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
							int n2 = -1;
							if (WorldGen.MoveNPC(x, y, n2))
							{
								Main.NewText("This housing is suitable.", 255, 240, 20);
							}
						}
						else
						{
							int num244 = 0;
							for (int num245 = 0; num245 < 200; num245++)
							{
								if (Main.npc[num245].active && Main.npc[num245].type == NPC.NumToType(this.mouseNPC))
								{
									num244 = num245;
									break;
								}
							}
							if (num244 >= 0)
							{
								int x2 = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
								int y2 = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
								if (WorldGen.MoveNPC(x2, y2, num244))
								{
									this.mouseNPC = -1;
									WorldGen.moveRoom(x2, y2, num244);
									Main.PlaySound(12, -1, -1, 1);
								}
							}
							else
							{
								this.mouseNPC = 0;
							}
						}
					}
				}
			}
			Rectangle rectangle2 = new Rectangle((int)((float)Main.mouseX + Main.screenPosition.X), (int)((float)Main.mouseY + Main.screenPosition.Y), 1, 1);
			if (!flag)
			{
				int num246 = 26 * Main.player[Main.myPlayer].statLifeMax / num43;
				int num247 = 0;
				if (Main.player[Main.myPlayer].statLifeMax > 200)
				{
					num246 = 260;
					num247 += 26;
				}
				if (Main.mouseX > 500 + num41 && Main.mouseX < 500 + num246 + num41 && Main.mouseY > 32 && Main.mouseY < 32 + Main.heartTexture.Height + num247)
				{
					Main.player[Main.myPlayer].showItemIcon = false;
					string cursorText = Main.player[Main.myPlayer].statLife + "/" + Main.player[Main.myPlayer].statLifeMax;
					this.MouseText(cursorText, 0, 0);
					flag = true;
				}
			}
			if (!flag)
			{
				int num248 = 24;
				int num249 = 28 * Main.player[Main.myPlayer].statManaMax2 / num50;
				if (Main.mouseX > 762 + num41 && Main.mouseX < 762 + num248 + num41 && Main.mouseY > 30 && Main.mouseY < 30 + num249)
				{
					Main.player[Main.myPlayer].showItemIcon = false;
					string cursorText2 = Main.player[Main.myPlayer].statMana + "/" + Main.player[Main.myPlayer].statManaMax2;
					this.MouseText(cursorText2, 0, 0);
					flag = true;
				}
			}
			if (!flag)
			{
				for (int num250 = 0; num250 < 200; num250++)
				{
					if (Main.item[num250].active)
					{
						Rectangle value3 = new Rectangle((int)((double)Main.item[num250].position.X + (double)Main.item[num250].width * 0.5 - (double)Main.itemTexture[Main.item[num250].type].Width * 0.5), (int)(Main.item[num250].position.Y + (float)Main.item[num250].height - (float)Main.itemTexture[Main.item[num250].type].Height), Main.itemTexture[Main.item[num250].type].Width, Main.itemTexture[Main.item[num250].type].Height);
						if (rectangle2.Intersects(value3))
						{
							Main.player[Main.myPlayer].showItemIcon = false;
							string text32 = Main.item[num250].AffixName();
							if (Main.item[num250].stack > 1)
							{
								object obj = text32;
								text32 = string.Concat(new object[]
								{
									obj, 
									" (", 
									Main.item[num250].stack, 
									")"
								});
							}
							if (Main.item[num250].owner < 255 && Main.showItemOwner)
							{
								text32 = text32 + " <" + Main.player[Main.item[num250].owner].name + ">";
							}
							rare = Main.item[num250].rare;
							this.MouseText(text32, rare, 0);
							flag = true;
							break;
						}
					}
				}
			}
			for (int num251 = 0; num251 < 255; num251++)
			{
				if (Main.player[num251].active && Main.myPlayer != num251 && !Main.player[num251].dead)
				{
					Rectangle value4 = new Rectangle((int)((double)Main.player[num251].position.X + (double)Main.player[num251].width * 0.5 - 16.0), (int)(Main.player[num251].position.Y + (float)Main.player[num251].height - 48f), 32, 48);
					if (!flag && rectangle2.Intersects(value4))
					{
						Main.player[Main.myPlayer].showItemIcon = false;
						int num252 = Main.player[num251].statLife;
						if (num252 < 0)
						{
							num252 = 0;
						}
						string text33 = string.Concat(new object[]
						{
							Main.player[num251].name, 
							": ", 
							num252, 
							"/", 
							Main.player[num251].statLifeMax
						});
						if (Main.player[num251].hostile)
						{
							text33 += " (PvP)";
						}
						this.MouseText(text33, 0, Main.player[num251].difficulty);
					}
				}
			}
			if (!flag)
			{
				for (int num253 = 0; num253 < 200; num253++)
				{
					if (Main.npc[num253].active)
					{
						Rectangle value5 = new Rectangle((int)((double)Main.npc[num253].position.X + (double)Main.npc[num253].width * 0.5 - (double)Main.npcTexture[Main.npc[num253].type].Width * 0.5), (int)(Main.npc[num253].position.Y + (float)Main.npc[num253].height - (float)(Main.npcTexture[Main.npc[num253].type].Height / Main.npcFrameCount[Main.npc[num253].type])), Main.npcTexture[Main.npc[num253].type].Width, Main.npcTexture[Main.npc[num253].type].Height / Main.npcFrameCount[Main.npc[num253].type]);
						if (Main.npc[num253].type >= 87 && Main.npc[num253].type <= 92)
						{
							value5 = new Rectangle((int)((double)Main.npc[num253].position.X + (double)Main.npc[num253].width * 0.5 - 32.0), (int)((double)Main.npc[num253].position.Y + (double)Main.npc[num253].height * 0.5 - 32.0), 64, 64);
						}
						if (rectangle2.Intersects(value5) && (Main.npc[num253].type != 85 || Main.npc[num253].ai[0] != 0f))
						{
							bool flag9 = false;
							if (Main.npc[num253].townNPC || Main.npc[num253].type == 105 || Main.npc[num253].type == 106 || Main.npc[num253].type == 123)
							{
								Rectangle rectangle3 = new Rectangle((int)(Main.player[Main.myPlayer].position.X + (float)(Main.player[Main.myPlayer].width / 2) - (float)(Player.tileRangeX * 16)), (int)(Main.player[Main.myPlayer].position.Y + (float)(Main.player[Main.myPlayer].height / 2) - (float)(Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
								Rectangle value6 = new Rectangle((int)Main.npc[num253].position.X, (int)Main.npc[num253].position.Y, Main.npc[num253].width, Main.npc[num253].height);
								if (rectangle3.Intersects(value6))
								{
									flag9 = true;
								}
							}
							if (flag9 && !Main.player[Main.myPlayer].dead)
							{
								int num254 = -(Main.npc[num253].width / 2 + 8);
								SpriteEffects effects2 = SpriteEffects.None;
								if (Main.npc[num253].spriteDirection == -1)
								{
									effects2 = SpriteEffects.FlipHorizontally;
									num254 = Main.npc[num253].width / 2 + 8;
								}
								SpriteBatch arg_10CF9_0 = this.spriteBatch;
								Texture2D arg_10CF9_1 = Main.chatTexture;
								Vector2 arg_10CF9_2 = new Vector2(Main.npc[num253].position.X + (float)(Main.npc[num253].width / 2) - Main.screenPosition.X - (float)(Main.chatTexture.Width / 2) - (float)num254, Main.npc[num253].position.Y - (float)Main.chatTexture.Height - Main.screenPosition.Y);
								Rectangle? arg_10CF9_3 = new Rectangle?(new Rectangle(0, 0, Main.chatTexture.Width, Main.chatTexture.Height));
								Color arg_10CF9_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
								float arg_10CF9_5 = 0f;
								origin = default(Vector2);
								arg_10CF9_0.Draw(arg_10CF9_1, arg_10CF9_2, arg_10CF9_3, arg_10CF9_4, arg_10CF9_5, origin, 1f, effects2, 0f);
								if (Main.mouseRight && Main.npcChatRelease)
								{
									Main.npcChatRelease = false;
									if (Main.player[Main.myPlayer].talkNPC != num253)
									{
										Main.player[Main.myPlayer].sign = -1;
										Main.editSign = false;
										Main.player[Main.myPlayer].talkNPC = num253;
										Main.playerInventory = false;
										Main.player[Main.myPlayer].chest = -1;
										Main.npcChatText = Main.npc[num253].GetChat();
										Main.PlaySound(24, -1, -1, 1);
									}
								}
							}
							Main.player[Main.myPlayer].showItemIcon = false;
							string text34 = Main.npc[num253].displayName;
							int num255 = num253;
							if (Main.npc[num253].realLife >= 0)
							{
								num255 = Main.npc[num253].realLife;
							}
							if (Main.npc[num255].lifeMax > 1 && !Main.npc[num255].dontTakeDamage)
							{
								object obj = text34;
								text34 = string.Concat(new object[]
								{
									obj, 
									": ", 
									Main.npc[num255].life, 
									"/", 
									Main.npc[num255].lifeMax
								});
							}
							this.MouseText(text34, 0, 0);
							break;
						}
					}
				}
			}
			if (Main.mouseRight)
			{
				Main.npcChatRelease = false;
			}
			else
			{
				Main.npcChatRelease = true;
			}
			if (Main.player[Main.myPlayer].showItemIcon && (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type > 0 || Main.player[Main.myPlayer].showItemIcon2 > 0))
			{
				int num256 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type;
				Color color11 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].GetAlpha(Color.White);
				Color color12 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].GetColor(Color.White);
				if (Main.player[Main.myPlayer].showItemIcon2 > 0)
				{
					num256 = Main.player[Main.myPlayer].showItemIcon2;
					color11 = Color.White;
					color12 = default(Color);
				}
				float scale2 = Main.cursorScale;
				SpriteBatch arg_1104A_0 = this.spriteBatch;
				Texture2D arg_1104A_1 = Main.itemTexture[num256];
				Vector2 arg_1104A_2 = new Vector2((float)(Main.mouseX + 10), (float)(Main.mouseY + 10));
				Rectangle? arg_1104A_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[num256].Width, Main.itemTexture[num256].Height));
				Color arg_1104A_4 = color11;
				float arg_1104A_5 = 0f;
				origin = default(Vector2);
				arg_1104A_0.Draw(arg_1104A_1, arg_1104A_2, arg_1104A_3, arg_1104A_4, arg_1104A_5, origin, scale2, SpriteEffects.None, 0f);
				if (Main.player[Main.myPlayer].showItemIcon2 == 0)
				{
					Color arg_11098_0 = Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].color;
					Color b = default(Color);
					if (arg_11098_0 != b)
					{
						SpriteBatch arg_1117A_0 = this.spriteBatch;
						Texture2D arg_1117A_1 = Main.itemTexture[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type];
						Vector2 arg_1117A_2 = new Vector2((float)(Main.mouseX + 10), (float)(Main.mouseY + 10));
						Rectangle? arg_1117A_3 = new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type].Width, Main.itemTexture[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type].Height));
						Color arg_1117A_4 = color12;
						float arg_1117A_5 = 0f;
						origin = default(Vector2);
						arg_1117A_0.Draw(arg_1117A_1, arg_1117A_2, arg_1117A_3, arg_1117A_4, arg_1117A_5, origin, scale2, SpriteEffects.None, 0f);
					}
				}
			}
			Main.player[Main.myPlayer].showItemIcon = false;
			Main.player[Main.myPlayer].showItemIcon2 = 0;
		}
		protected void QuitGame()
		{
			Steam.Kill();
			base.Exit();
		}
		protected Color randColor()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (num + num3 + num2 <= 150)
			{
				num = Main.rand.Next(256);
				num2 = Main.rand.Next(256);
				num3 = Main.rand.Next(256);
			}
			return new Color(num, num2, num3, 255);
		}
		protected void DrawMenu()
		{
			Main.render = false;
			Star.UpdateStars();
			Cloud.UpdateClouds();
			Main.holyTiles = 0;
			Main.evilTiles = 0;
			Main.jungleTiles = 0;
			Main.chatMode = false;
			for (int i = 0; i < Main.numChatLines; i++)
			{
				Main.chatLine[i] = new ChatLine();
			}
			this.DrawFPS();
			Main.screenLastPosition = Main.screenPosition;
			Main.screenPosition.Y = (float)(Main.worldSurface * 16.0 - (double)Main.screenHeight);
			if (Main.grabSky)
			{
				Main.screenPosition.X = Main.screenPosition.X + (float)(Main.mouseX - Main.screenWidth / 2) * 0.02f;
			}
			else
			{
				Main.screenPosition.X = Main.screenPosition.X + 2f;
			}
			if (Main.screenPosition.X > 2.14748352E+09f)
			{
				Main.screenPosition.X = 0f;
			}
			if (Main.screenPosition.X < -2.14748352E+09f)
			{
				Main.screenPosition.X = 0f;
			}
			Main.background = 0;
			byte b = (byte)((255 + Main.tileColor.R * 2) / 3);
			Color color = new Color((int)b, (int)b, (int)b, 255);
			this.logoRotation += this.logoRotationSpeed * 3E-05f;
			if ((double)this.logoRotation > 0.1)
			{
				this.logoRotationDirection = -1f;
			}
			else
			{
				if ((double)this.logoRotation < -0.1)
				{
					this.logoRotationDirection = 1f;
				}
			}
			if (this.logoRotationSpeed < 20f & this.logoRotationDirection == 1f)
			{
				this.logoRotationSpeed += 1f;
			}
			else
			{
				if (this.logoRotationSpeed > -20f & this.logoRotationDirection == -1f)
				{
					this.logoRotationSpeed -= 1f;
				}
			}
			this.logoScale += this.logoScaleSpeed * 1E-05f;
			if ((double)this.logoScale > 1.1)
			{
				this.logoScaleDirection = -1f;
			}
			else
			{
				if ((double)this.logoScale < 0.9)
				{
					this.logoScaleDirection = 1f;
				}
			}
			if (this.logoScaleSpeed < 50f & this.logoScaleDirection == 1f)
			{
				this.logoScaleSpeed += 1f;
			}
			else
			{
				if (this.logoScaleSpeed > -50f & this.logoScaleDirection == -1f)
				{
					this.logoScaleSpeed -= 1f;
				}
			}
			Color color2 = new Color((int)((byte)((float)color.R * ((float)Main.LogoA / 255f))), (int)((byte)((float)color.G * ((float)Main.LogoA / 255f))), (int)((byte)((float)color.B * ((float)Main.LogoA / 255f))), (int)((byte)((float)color.A * ((float)Main.LogoA / 255f))));
			Color color3 = new Color((int)((byte)((float)color.R * ((float)Main.LogoB / 255f))), (int)((byte)((float)color.G * ((float)Main.LogoB / 255f))), (int)((byte)((float)color.B * ((float)Main.LogoB / 255f))), (int)((byte)((float)color.A * ((float)Main.LogoB / 255f))));
			Main.LogoT = false;
			if (!Main.LogoT)
			{
				this.spriteBatch.Draw(Main.logoTexture, new Vector2((float)(Main.screenWidth / 2), 100f), new Rectangle?(new Rectangle(0, 0, Main.logoTexture.Width, Main.logoTexture.Height)), color2, this.logoRotation, new Vector2((float)(Main.logoTexture.Width / 2), (float)(Main.logoTexture.Height / 2)), this.logoScale, SpriteEffects.None, 0f);
			}
			else
			{
				this.spriteBatch.Draw(Main.logo3Texture, new Vector2((float)(Main.screenWidth / 2), 100f), new Rectangle?(new Rectangle(0, 0, Main.logoTexture.Width, Main.logoTexture.Height)), color2, this.logoRotation, new Vector2((float)(Main.logoTexture.Width / 2), (float)(Main.logoTexture.Height / 2)), this.logoScale, SpriteEffects.None, 0f);
			}
			this.spriteBatch.Draw(Main.logo2Texture, new Vector2((float)(Main.screenWidth / 2), 100f), new Rectangle?(new Rectangle(0, 0, Main.logoTexture.Width, Main.logoTexture.Height)), color3, this.logoRotation, new Vector2((float)(Main.logoTexture.Width / 2), (float)(Main.logoTexture.Height / 2)), this.logoScale, SpriteEffects.None, 0f);
			if (Main.dayTime)
			{
				Main.LogoA += 2;
				if (Main.LogoA > 255)
				{
					Main.LogoA = 255;
				}
				Main.LogoB--;
				if (Main.LogoB < 0)
				{
					Main.LogoB = 0;
				}
			}
			else
			{
				Main.LogoB += 2;
				if (Main.LogoB > 255)
				{
					Main.LogoB = 255;
				}
				Main.LogoA--;
				if (Main.LogoA < 0)
				{
					Main.LogoA = 0;
					Main.LogoT = true;
				}
			}
			int num = 250;
			int num2 = Main.screenWidth / 2;
			int num3 = 80;
			int num4 = 0;
			int num5 = Main.menuMode;
			int num6 = -1;
			int num7 = 0;
			int num8 = 0;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			int num9 = 0;
			bool[] array = new bool[Main.maxMenuItems];
			bool[] array2 = new bool[Main.maxMenuItems];
			int[] array3 = new int[Main.maxMenuItems];
			int[] array4 = new int[Main.maxMenuItems];
			byte[] array5 = new byte[Main.maxMenuItems];
			float[] array6 = new float[Main.maxMenuItems];
			bool[] array7 = new bool[Main.maxMenuItems];
			for (int j = 0; j < Main.maxMenuItems; j++)
			{
				array[j] = false;
				array2[j] = false;
				array3[j] = 0;
				array4[j] = 0;
				array6[j] = 1f;
			}
			string[] array8 = new string[Main.maxMenuItems];
			if (Main.menuMode == -1)
			{
				Main.menuMode = 0;
			}
			if (Main.netMode == 2)
			{
				bool flag4 = true;
				for (int k = 0; k < 8; k++)
				{
					if (k < 255)
					{
						try
						{
							array8[k] = Netplay.serverSock[k].statusText;
							if (Netplay.serverSock[k].active && Main.showSpam)
							{
								string[] array9;
								string[] expr_662 = array9 = array8;
								IntPtr intPtr;
								int expr_667 = (int)(intPtr = (IntPtr)k);
								object obj = array9[(int)intPtr];
								expr_662[expr_667] = string.Concat(new object[]
								{
									obj, 
									" (", 
									NetMessage.buffer[k].spamCount, 
									")"
								});
							}
						}
						catch
						{
							array8[k] = "";
						}
						array[k] = true;
						if (array8[k] != "" && array8[k] != null)
						{
							flag4 = false;
						}
					}
				}
				if (flag4)
				{
					array8[0] = "Start a new instance of Terraria to join!";
					array8[1] = "Running on port " + Netplay.serverPort + ".";
				}
				num4 = 11;
				array8[9] = Main.statusText;
				array[9] = true;
				num = 170;
				num3 = 30;
				array3[10] = 20;
				array3[10] = 40;
				array8[10] = "Disconnect";
				if (this.selectedMenu == 10)
				{
					Netplay.disconnect = true;
					Main.PlaySound(11, -1, -1, 1);
				}
			}
			else
			{
				if (Main.menuMode == 31)
				{
					string password = Netplay.password;
					Netplay.password = Main.GetInputText(Netplay.password);
					if (password != Netplay.password)
					{
						Main.PlaySound(12, -1, -1, 1);
					}
					array8[0] = "Server Requires Password:";
					this.textBlinkerCount++;
					if (this.textBlinkerCount >= 20)
					{
						if (this.textBlinkerState == 0)
						{
							this.textBlinkerState = 1;
						}
						else
						{
							this.textBlinkerState = 0;
						}
						this.textBlinkerCount = 0;
					}
					array8[1] = Netplay.password;
					if (this.textBlinkerState == 1)
					{
						string[] array9;
						(array9 = array8)[1] = array9[1] + "|";
						array4[1] = 1;
					}
					else
					{
						string[] array9;
						(array9 = array8)[1] = array9[1] + " ";
					}
					array[0] = true;
					array[1] = true;
					array3[1] = -20;
					array3[2] = 20;
					array8[2] = "Accept";
					array8[3] = "Back";
					num4 = 4;
					if (this.selectedMenu == 3)
					{
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 0;
						Netplay.disconnect = true;
						Netplay.password = "";
					}
					else
					{
						if (this.selectedMenu == 2 || Main.inputTextEnter)
						{
							NetMessage.SendData(38, -1, -1, Netplay.password, 0, 0f, 0f, 0f, 0);
							Main.menuMode = 14;
						}
					}
				}
				else
				{
					if (Main.netMode == 1 || Main.menuMode == 14)
					{
						num4 = 2;
						array8[0] = Main.statusText;
						array[0] = true;
						num = 300;
						array8[1] = "Cancel";
						if (this.selectedMenu != 1)
						{
							goto IL_3687;
						}
						Netplay.disconnect = true;
						Netplay.clientSock.tcpClient.Close();
						Main.PlaySound(11, -1, -1, 1);
						Main.menuMode = 0;
						Main.netMode = 0;
						try
						{
							this.tServer.Kill();
							goto IL_3687;
						}
						catch
						{
							goto IL_3687;
						}
					}
					if (Main.menuMode == 30)
					{
						string password2 = Netplay.password;
						Netplay.password = Main.GetInputText(Netplay.password);
						if (password2 != Netplay.password)
						{
							Main.PlaySound(12, -1, -1, 1);
						}
						array8[0] = "Enter Server Password:";
						this.textBlinkerCount++;
						if (this.textBlinkerCount >= 20)
						{
							if (this.textBlinkerState == 0)
							{
								this.textBlinkerState = 1;
							}
							else
							{
								this.textBlinkerState = 0;
							}
							this.textBlinkerCount = 0;
						}
						array8[1] = Netplay.password;
						if (this.textBlinkerState == 1)
						{
							string[] array9;
							(array9 = array8)[1] = array9[1] + "|";
							array4[1] = 1;
						}
						else
						{
							string[] array9;
							(array9 = array8)[1] = array9[1] + " ";
						}
						array[0] = true;
						array[1] = true;
						array3[1] = -20;
						array3[2] = 20;
						array8[2] = "Accept";
						array8[3] = "Back";
						num4 = 4;
						if (this.selectedMenu == 3)
						{
							Main.PlaySound(11, -1, -1, 1);
							Main.menuMode = 6;
							Netplay.password = "";
						}
						else
						{
							if (this.selectedMenu == 2 || Main.inputTextEnter || Main.autoPass)
							{
								this.tServer.StartInfo.FileName = "TerrariaServer.exe";
								this.tServer.StartInfo.Arguments = string.Concat(new string[]
								{
									"-autoshutdown -world \"", 
									Main.worldPathName, 
									"\" -password \"", 
									Netplay.password, 
									"\""
								});
								if (Main.libPath != "")
								{
									ProcessStartInfo expr_AEA = this.tServer.StartInfo;
									expr_AEA.Arguments = expr_AEA.Arguments + " -loadlib " + Main.libPath;
								}
								this.tServer.StartInfo.UseShellExecute = false;
								this.tServer.StartInfo.CreateNoWindow = true;
								this.tServer.Start();
								Netplay.SetIP("127.0.0.1");
								Main.autoPass = true;
								Main.statusText = "Starting server...";
								Netplay.StartClient();
								Main.menuMode = 10;
							}
						}
					}
					else
					{
						if (Main.menuMode == 15)
						{
							num4 = 2;
							array8[0] = Main.statusText;
							array[0] = true;
							num = 80;
							num3 = 400;
							array8[1] = "Back";
							if (this.selectedMenu == 1)
							{
								Netplay.disconnect = true;
								Main.PlaySound(11, -1, -1, 1);
								Main.menuMode = 0;
								Main.netMode = 0;
							}
						}
						else
						{
							if (Main.menuMode == 200)
							{
								num4 = 3;
								array8[0] = "Load failed!";
								array[0] = true;
								num -= 30;
								array3[1] = 70;
								array3[2] = 50;
								array8[1] = "Load Backup";
								array8[2] = "Cancel";
								if (this.selectedMenu == 1)
								{
									if (File.Exists(Main.worldPathName + ".bak"))
									{
										File.Copy(Main.worldPathName + ".bak", Main.worldPathName, true);
										File.Delete(Main.worldPathName + ".bak");
										Main.PlaySound(10, -1, -1, 1);
										WorldGen.playWorld();
										Main.menuMode = 10;
									}
									else
									{
										Main.PlaySound(11, -1, -1, 1);
										Main.menuMode = 0;
										Main.netMode = 0;
									}
								}
								if (this.selectedMenu == 2)
								{
									Main.PlaySound(11, -1, -1, 1);
									Main.menuMode = 0;
									Main.netMode = 0;
								}
							}
							else
							{
								if (Main.menuMode == 201)
								{
									num4 = 3;
									array8[0] = "Load failed!";
									array[0] = true;
									array[1] = true;
									num -= 30;
									array3[1] = -30;
									array3[2] = 50;
									array8[1] = "No backup found";
									array8[2] = "Back";
									if (this.selectedMenu == 2)
									{
										Main.PlaySound(11, -1, -1, 1);
										Main.menuMode = 0;
										Main.netMode = 0;
									}
								}
								else
								{
									if (Main.menuMode == 10)
									{
										num4 = 1;
										array8[0] = Main.statusText;
										array[0] = true;
										num = 300;
									}
									else
									{
										if (Main.menuMode == 100)
										{
											num4 = 1;
											array8[0] = Main.statusText;
											array[0] = true;
											num = 300;
										}
										else
										{
											if (Main.menuMode == 0)
											{
												Main.menuMultiplayer = false;
												Main.menuServer = false;
												Main.netMode = 0;
												array8[0] = "Single Player";
												array8[1] = "Multiplayer";
												array8[2] = "Settings";
												array8[3] = "Exit";
												num4 = 4;
												if (this.selectedMenu == 3)
												{
													this.QuitGame();
												}
												if (this.selectedMenu == 1)
												{
													Main.PlaySound(10, -1, -1, 1);
													Main.menuMode = 12;
												}
												if (this.selectedMenu == 2)
												{
													Main.PlaySound(10, -1, -1, 1);
													Main.menuMode = 11;
												}
												if (this.selectedMenu == 0)
												{
													Main.PlaySound(10, -1, -1, 1);
													Main.menuMode = 1;
													Main.LoadPlayers();
												}
											}
											else
											{
												if (Main.menuMode == 1)
												{
													Main.myPlayer = 0;
													num = 190;
													num3 = 50;
													array8[5] = "Create Character";
													array8[6] = "Delete";
													if (Main.numLoadPlayers == 5)
													{
														array2[5] = true;
														array8[5] = "";
													}
													else
													{
														if (Main.numLoadPlayers == 0)
														{
															array2[6] = true;
															array8[6] = "";
														}
													}
													array8[7] = "Back";
													for (int l = 0; l < 5; l++)
													{
														if (l < Main.numLoadPlayers)
														{
															array8[l] = Main.loadPlayer[l].name;
															array5[l] = Main.loadPlayer[l].difficulty;
														}
														else
														{
															array8[l] = null;
														}
													}
													num4 = 8;
													if (this.focusMenu >= 0 && this.focusMenu < Main.numLoadPlayers)
													{
														num6 = this.focusMenu;
														Vector2 vector = Main.fontDeathText.MeasureString(array8[num6]);
														num7 = (int)((double)(Main.screenWidth / 2) + (double)vector.X * 0.5 + 10.0);
														num8 = num + num3 * this.focusMenu + 4;
													}
													if (this.selectedMenu == 7)
													{
														Main.autoJoin = false;
														Main.autoPass = false;
														Main.PlaySound(11, -1, -1, 1);
														if (Main.menuMultiplayer)
														{
															Main.menuMode = 12;
															Main.menuMultiplayer = false;
															Main.menuServer = false;
														}
														else
														{
															Main.menuMode = 0;
														}
													}
													else
													{
														if (this.selectedMenu == 5)
														{
															Main.loadPlayer[Main.numLoadPlayers] = new Player();
															Main.loadPlayer[Main.numLoadPlayers].inventory[0].SetDefaults("Copper Shortsword");
															Main.loadPlayer[Main.numLoadPlayers].inventory[0].Prefix(-1);
															Main.loadPlayer[Main.numLoadPlayers].inventory[1].SetDefaults("Copper Pickaxe");
															Main.loadPlayer[Main.numLoadPlayers].inventory[1].Prefix(-1);
															Main.loadPlayer[Main.numLoadPlayers].inventory[2].SetDefaults("Copper Axe");
															Main.loadPlayer[Main.numLoadPlayers].inventory[2].Prefix(-1);
															Main.PlaySound(10, -1, -1, 1);
															Main.menuMode = 2;
														}
														else
														{
															if (this.selectedMenu == 6)
															{
																Main.PlaySound(10, -1, -1, 1);
																Main.menuMode = 4;
															}
															else
															{
																if (this.selectedMenu >= 0)
																{
																	if (Main.menuMultiplayer)
																	{
																		this.selectedPlayer = this.selectedMenu;
																		Main.player[Main.myPlayer] = (Player)Main.loadPlayer[this.selectedPlayer].Clone();
																		Main.playerPathName = Main.loadPlayerPath[this.selectedPlayer];
																		Main.PlaySound(10, -1, -1, 1);
																		if (Main.autoJoin)
																		{
																			if (Netplay.SetIP(Main.getIP))
																			{
																				Main.menuMode = 10;
																				Netplay.StartClient();
																			}
																			else
																			{
																				if (Netplay.SetIP2(Main.getIP))
																				{
																					Main.menuMode = 10;
																					Netplay.StartClient();
																				}
																			}
																			Main.autoJoin = false;
																		}
																		else
																		{
																			if (Main.menuServer)
																			{
																				Main.LoadWorlds();
																				Main.menuMode = 6;
																			}
																			else
																			{
																				Main.menuMode = 13;
																			}
																		}
																	}
																	else
																	{
																		Main.myPlayer = 0;
																		this.selectedPlayer = this.selectedMenu;
																		Main.player[Main.myPlayer] = (Player)Main.loadPlayer[this.selectedPlayer].Clone();
																		Main.playerPathName = Main.loadPlayerPath[this.selectedPlayer];
																		Main.LoadWorlds();
																		Main.PlaySound(10, -1, -1, 1);
																		Main.menuMode = 6;
																	}
																}
															}
														}
													}
												}
												else
												{
													if (Main.menuMode == 2)
													{
														if (this.selectedMenu == 0)
														{
															Main.menuMode = 17;
															Main.PlaySound(10, -1, -1, 1);
															this.selColor = Main.loadPlayer[Main.numLoadPlayers].hairColor;
														}
														if (this.selectedMenu == 1)
														{
															Main.menuMode = 18;
															Main.PlaySound(10, -1, -1, 1);
															this.selColor = Main.loadPlayer[Main.numLoadPlayers].eyeColor;
														}
														if (this.selectedMenu == 2)
														{
															Main.menuMode = 19;
															Main.PlaySound(10, -1, -1, 1);
															this.selColor = Main.loadPlayer[Main.numLoadPlayers].skinColor;
														}
														if (this.selectedMenu == 3)
														{
															Main.menuMode = 20;
															Main.PlaySound(10, -1, -1, 1);
														}
														array8[0] = "Hair";
														array8[1] = "Eyes";
														array8[2] = "Skin";
														array8[3] = "Clothes";
														num = 220;
														for (int m = 0; m < 9; m++)
														{
															if (m < 6)
															{
																array6[m] = 0.75f;
															}
															else
															{
																array6[m] = 0.9f;
															}
														}
														num3 = 38;
														array3[6] = 6;
														array3[7] = 12;
														array3[8] = 18;
														num6 = Main.numLoadPlayers;
														num7 = Main.screenWidth / 2 - 16;
														num8 = 176;
														if (Main.loadPlayer[num6].male)
														{
															array8[4] = "Male";
														}
														else
														{
															array8[4] = "Female";
														}
														if (this.selectedMenu == 4)
														{
															if (Main.loadPlayer[num6].male)
															{
																Main.PlaySound(20, -1, -1, 1);
																Main.loadPlayer[num6].male = false;
															}
															else
															{
																Main.PlaySound(1, -1, -1, 1);
																Main.loadPlayer[num6].male = true;
															}
														}
														if (Main.loadPlayer[num6].difficulty == 2)
														{
															array8[5] = "Hardcore";
															array5[5] = Main.loadPlayer[num6].difficulty;
														}
														else
														{
															if (Main.loadPlayer[num6].difficulty == 1)
															{
																array8[5] = "Mediumcore";
																array5[5] = Main.loadPlayer[num6].difficulty;
															}
															else
															{
																array8[5] = "Softcore";
															}
														}
														if (this.selectedMenu == 5)
														{
															Main.PlaySound(10, -1, -1, 1);
															Main.menuMode = 222;
														}
														if (this.selectedMenu == 7)
														{
															Main.PlaySound(12, -1, -1, 1);
															Main.loadPlayer[num6].hair = Main.rand.Next(36);
															Main.loadPlayer[num6].eyeColor = this.randColor();
															while ((int)(Main.loadPlayer[num6].eyeColor.R + Main.loadPlayer[num6].eyeColor.G + Main.loadPlayer[num6].eyeColor.B) > 300)
															{
																Main.loadPlayer[num6].eyeColor = this.randColor();
															}
															Main.loadPlayer[num6].hairColor = this.randColor();
															Main.loadPlayer[num6].pantsColor = this.randColor();
															Main.loadPlayer[num6].shirtColor = this.randColor();
															Main.loadPlayer[num6].shoeColor = this.randColor();
															Main.loadPlayer[num6].skinColor = this.randColor();
															float num10 = (float)Main.rand.Next(60, 120) * 0.01f;
															if (num10 > 1f)
															{
																num10 = 1f;
															}
															Main.loadPlayer[num6].skinColor.R = (byte)((float)Main.rand.Next(240, 255) * num10);
															Main.loadPlayer[num6].skinColor.G = (byte)((float)Main.rand.Next(110, 140) * num10);
															Main.loadPlayer[num6].skinColor.B = (byte)((float)Main.rand.Next(75, 110) * num10);
															Main.loadPlayer[num6].underShirtColor = this.randColor();
															int num11 = Main.loadPlayer[num6].hair + 1;
															if (num11 == 5 || num11 == 6 || num11 == 7 || num11 == 10 || num11 == 12 || num11 == 19 || num11 == 22 || num11 == 23 || num11 == 26 || num11 == 27 || num11 == 30 || num11 == 33)
															{
																Main.loadPlayer[num6].male = false;
															}
															else
															{
																Main.loadPlayer[num6].male = true;
															}
														}
														array8[7] = "Random";
														array8[6] = "Create";
														array8[8] = "Back";
														num4 = 9;
														if (this.selectedMenu == 8)
														{
															Main.PlaySound(11, -1, -1, 1);
															Main.menuMode = 1;
														}
														else
														{
															if (this.selectedMenu == 6)
															{
																Main.PlaySound(10, -1, -1, 1);
																Main.loadPlayer[Main.numLoadPlayers].name = "";
																Main.menuMode = 3;
															}
														}
													}
													else
													{
														if (Main.menuMode == 222)
														{
															if (this.focusMenu == 3)
															{
																array8[0] = "Hardcore characters die for good";
															}
															else
															{
																if (this.focusMenu == 2)
																{
																	array8[0] = "Mediumcore characters drop items on death";
																}
																else
																{
																	if (this.focusMenu == 1)
																	{
																		array8[0] = "Softcore characters drop money on death";
																	}
																	else
																	{
																		array8[0] = "Select difficulty";
																	}
																}
															}
															num3 = 50;
															array3[1] = 25;
															array3[2] = 25;
															array3[3] = 25;
															array[0] = true;
															array8[1] = "Softcore";
															array8[2] = "Mediumcore";
															array5[2] = 1;
															array8[3] = "Hardcore";
															array5[3] = 2;
															num4 = 4;
															if (this.selectedMenu == 1)
															{
																Main.loadPlayer[Main.numLoadPlayers].difficulty = 0;
																Main.menuMode = 2;
															}
															else
															{
																if (this.selectedMenu == 2)
																{
																	Main.menuMode = 2;
																	Main.loadPlayer[Main.numLoadPlayers].difficulty = 1;
																}
																else
																{
																	if (this.selectedMenu == 3)
																	{
																		Main.loadPlayer[Main.numLoadPlayers].difficulty = 2;
																		Main.menuMode = 2;
																	}
																}
															}
														}
														else
														{
															if (Main.menuMode == 20)
															{
																if (this.selectedMenu == 0)
																{
																	Main.menuMode = 21;
																	Main.PlaySound(10, -1, -1, 1);
																	this.selColor = Main.loadPlayer[Main.numLoadPlayers].shirtColor;
																}
																if (this.selectedMenu == 1)
																{
																	Main.menuMode = 22;
																	Main.PlaySound(10, -1, -1, 1);
																	this.selColor = Main.loadPlayer[Main.numLoadPlayers].underShirtColor;
																}
																if (this.selectedMenu == 2)
																{
																	Main.menuMode = 23;
																	Main.PlaySound(10, -1, -1, 1);
																	this.selColor = Main.loadPlayer[Main.numLoadPlayers].pantsColor;
																}
																if (this.selectedMenu == 3)
																{
																	this.selColor = Main.loadPlayer[Main.numLoadPlayers].shoeColor;
																	Main.menuMode = 24;
																	Main.PlaySound(10, -1, -1, 1);
																}
																array8[0] = "Shirt";
																array8[1] = "Undershirt";
																array8[2] = "Pants";
																array8[3] = "Shoes";
																num = 260;
																num3 = 50;
																array3[5] = 20;
																array8[5] = "Back";
																num4 = 6;
																num6 = Main.numLoadPlayers;
																num7 = Main.screenWidth / 2 - 16;
																num8 = 210;
																if (this.selectedMenu == 5)
																{
																	Main.PlaySound(11, -1, -1, 1);
																	Main.menuMode = 2;
																}
															}
															else
															{
																if (Main.menuMode == 17)
																{
																	num6 = Main.numLoadPlayers;
																	num7 = Main.screenWidth / 2 - 16;
																	num8 = 210;
																	flag = true;
																	num9 = 390;
																	num = 260;
																	num3 = 60;
																	Main.loadPlayer[num6].hairColor = this.selColor;
																	num4 = 3;
																	array8[0] = "Hair " + (Main.loadPlayer[num6].hair + 1);
																	array8[1] = "Hair Color";
																	array[1] = true;
																	array3[2] = 150;
																	array3[1] = 10;
																	array8[2] = "Back";
																	if (this.selectedMenu == 0)
																	{
																		Main.PlaySound(12, -1, -1, 1);
																		Main.loadPlayer[num6].hair++;
																		if (Main.loadPlayer[num6].hair >= 36)
																		{
																			Main.loadPlayer[num6].hair = 0;
																		}
																	}
																	else
																	{
																		if (this.selectedMenu2 == 0)
																		{
																			Main.PlaySound(12, -1, -1, 1);
																			Main.loadPlayer[num6].hair--;
																			if (Main.loadPlayer[num6].hair < 0)
																			{
																				Main.loadPlayer[num6].hair = 35;
																			}
																		}
																	}
																	if (this.selectedMenu == 2)
																	{
																		Main.menuMode = 2;
																		Main.PlaySound(11, -1, -1, 1);
																	}
																}
																else
																{
																	if (Main.menuMode == 18)
																	{
																		num6 = Main.numLoadPlayers;
																		num7 = Main.screenWidth / 2 - 16;
																		num8 = 210;
																		flag = true;
																		num9 = 370;
																		num = 240;
																		num3 = 60;
																		Main.loadPlayer[num6].eyeColor = this.selColor;
																		num4 = 3;
																		array8[0] = "";
																		array8[1] = "Eye Color";
																		array[1] = true;
																		array3[2] = 170;
																		array3[1] = 10;
																		array8[2] = "Back";
																		if (this.selectedMenu == 2)
																		{
																			Main.menuMode = 2;
																			Main.PlaySound(11, -1, -1, 1);
																		}
																	}
																	else
																	{
																		if (Main.menuMode == 19)
																		{
																			num6 = Main.numLoadPlayers;
																			num7 = Main.screenWidth / 2 - 16;
																			num8 = 210;
																			flag = true;
																			num9 = 370;
																			num = 240;
																			num3 = 60;
																			Main.loadPlayer[num6].skinColor = this.selColor;
																			num4 = 3;
																			array8[0] = "";
																			array8[1] = "Skin Color";
																			array[1] = true;
																			array3[2] = 170;
																			array3[1] = 10;
																			array8[2] = "Back";
																			if (this.selectedMenu == 2)
																			{
																				Main.menuMode = 2;
																				Main.PlaySound(11, -1, -1, 1);
																			}
																		}
																		else
																		{
																			if (Main.menuMode == 21)
																			{
																				num6 = Main.numLoadPlayers;
																				num7 = Main.screenWidth / 2 - 16;
																				num8 = 210;
																				flag = true;
																				num9 = 370;
																				num = 240;
																				num3 = 60;
																				Main.loadPlayer[num6].shirtColor = this.selColor;
																				num4 = 3;
																				array8[0] = "";
																				array8[1] = "Shirt Color";
																				array[1] = true;
																				array3[2] = 170;
																				array3[1] = 10;
																				array8[2] = "Back";
																				if (this.selectedMenu == 2)
																				{
																					Main.menuMode = 20;
																					Main.PlaySound(11, -1, -1, 1);
																				}
																			}
																			else
																			{
																				if (Main.menuMode == 22)
																				{
																					num6 = Main.numLoadPlayers;
																					num7 = Main.screenWidth / 2 - 16;
																					num8 = 210;
																					flag = true;
																					num9 = 370;
																					num = 240;
																					num3 = 60;
																					Main.loadPlayer[num6].underShirtColor = this.selColor;
																					num4 = 3;
																					array8[0] = "";
																					array8[1] = "Undershirt Color";
																					array[1] = true;
																					array3[2] = 170;
																					array3[1] = 10;
																					array8[2] = "Back";
																					if (this.selectedMenu == 2)
																					{
																						Main.menuMode = 20;
																						Main.PlaySound(11, -1, -1, 1);
																					}
																				}
																				else
																				{
																					if (Main.menuMode == 23)
																					{
																						num6 = Main.numLoadPlayers;
																						num7 = Main.screenWidth / 2 - 16;
																						num8 = 210;
																						flag = true;
																						num9 = 370;
																						num = 240;
																						num3 = 60;
																						Main.loadPlayer[num6].pantsColor = this.selColor;
																						num4 = 3;
																						array8[0] = "";
																						array8[1] = "Pants Color";
																						array[1] = true;
																						array3[2] = 170;
																						array3[1] = 10;
																						array8[2] = "Back";
																						if (this.selectedMenu == 2)
																						{
																							Main.menuMode = 20;
																							Main.PlaySound(11, -1, -1, 1);
																						}
																					}
																					else
																					{
																						if (Main.menuMode == 24)
																						{
																							num6 = Main.numLoadPlayers;
																							num7 = Main.screenWidth / 2 - 16;
																							num8 = 210;
																							flag = true;
																							num9 = 370;
																							num = 240;
																							num3 = 60;
																							Main.loadPlayer[num6].shoeColor = this.selColor;
																							num4 = 3;
																							array8[0] = "";
																							array8[1] = "Shoe Color";
																							array[1] = true;
																							array3[2] = 170;
																							array3[1] = 10;
																							array8[2] = "Back";
																							if (this.selectedMenu == 2)
																							{
																								Main.menuMode = 20;
																								Main.PlaySound(11, -1, -1, 1);
																							}
																						}
																						else
																						{
																							if (Main.menuMode == 3)
																							{
																								string name = Main.loadPlayer[Main.numLoadPlayers].name;
																								Main.loadPlayer[Main.numLoadPlayers].name = Main.GetInputText(Main.loadPlayer[Main.numLoadPlayers].name);
																								if (Main.loadPlayer[Main.numLoadPlayers].name.Length > Player.nameLen)
																								{
																									Main.loadPlayer[Main.numLoadPlayers].name = Main.loadPlayer[Main.numLoadPlayers].name.Substring(0, Player.nameLen);
																								}
																								if (name != Main.loadPlayer[Main.numLoadPlayers].name)
																								{
																									Main.PlaySound(12, -1, -1, 1);
																								}
																								array8[0] = "Enter Character Name:";
																								array2[2] = true;
																								if (Main.loadPlayer[Main.numLoadPlayers].name != "")
																								{
																									if (Main.loadPlayer[Main.numLoadPlayers].name.Substring(0, 1) == " ")
																									{
																										Main.loadPlayer[Main.numLoadPlayers].name = "";
																									}
																									for (int n = 0; n < Main.loadPlayer[Main.numLoadPlayers].name.Length; n++)
																									{
																										if (Main.loadPlayer[Main.numLoadPlayers].name.Substring(n, 1) != " ")
																										{
																											array2[2] = false;
																										}
																									}
																								}
																								this.textBlinkerCount++;
																								if (this.textBlinkerCount >= 20)
																								{
																									if (this.textBlinkerState == 0)
																									{
																										this.textBlinkerState = 1;
																									}
																									else
																									{
																										this.textBlinkerState = 0;
																									}
																									this.textBlinkerCount = 0;
																								}
																								array8[1] = Main.loadPlayer[Main.numLoadPlayers].name;
																								if (this.textBlinkerState == 1)
																								{
																									string[] array9;
																									(array9 = array8)[1] = array9[1] + "|";
																									array4[1] = 1;
																								}
																								else
																								{
																									string[] array9;
																									(array9 = array8)[1] = array9[1] + " ";
																								}
																								array[0] = true;
																								array[1] = true;
																								array3[1] = -20;
																								array3[2] = 20;
																								array8[2] = "Accept";
																								array8[3] = "Back";
																								num4 = 4;
																								if (this.selectedMenu == 3)
																								{
																									Main.PlaySound(11, -1, -1, 1);
																									Main.menuMode = 2;
																								}
																								if (this.selectedMenu == 2 || (!array2[2] && Main.inputTextEnter))
																								{
																									Main.loadPlayer[Main.numLoadPlayers].name.Trim();
																									Main.loadPlayerPath[Main.numLoadPlayers] = Main.nextLoadPlayer();
																									Player.SavePlayer(Main.loadPlayer[Main.numLoadPlayers], Main.loadPlayerPath[Main.numLoadPlayers]);
																									Main.LoadPlayers();
																									Main.PlaySound(10, -1, -1, 1);
																									Main.menuMode = 1;
																								}
																							}
																							else
																							{
																								if (Main.menuMode == 4)
																								{
																									num = 220;
																									num3 = 60;
																									array8[5] = "Back";
																									for (int num12 = 0; num12 < 5; num12++)
																									{
																										if (num12 < Main.numLoadPlayers)
																										{
																											array8[num12] = Main.loadPlayer[num12].name;
																											array5[num12] = Main.loadPlayer[num12].difficulty;
																										}
																										else
																										{
																											array8[num12] = null;
																										}
																									}
																									num4 = 6;
																									if (this.focusMenu >= 0 && this.focusMenu < Main.numLoadPlayers)
																									{
																										num6 = this.focusMenu;
																										Vector2 vector2 = Main.fontDeathText.MeasureString(array8[num6]);
																										num7 = (int)((double)(Main.screenWidth / 2) + (double)vector2.X * 0.5 + 10.0);
																										num8 = num + num3 * this.focusMenu + 4;
																									}
																									if (this.selectedMenu == 5)
																									{
																										Main.PlaySound(11, -1, -1, 1);
																										Main.menuMode = 1;
																									}
																									else
																									{
																										if (this.selectedMenu >= 0)
																										{
																											this.selectedPlayer = this.selectedMenu;
																											Main.PlaySound(10, -1, -1, 1);
																											Main.menuMode = 5;
																										}
																									}
																								}
																								else
																								{
																									if (Main.menuMode == 5)
																									{
																										array8[0] = "Delete " + Main.loadPlayer[this.selectedPlayer].name + "?";
																										array[0] = true;
																										array8[1] = "Yes";
																										array8[2] = "No";
																										num4 = 3;
																										if (this.selectedMenu == 1)
																										{
																											Main.ErasePlayer(this.selectedPlayer);
																											Main.PlaySound(10, -1, -1, 1);
																											Main.menuMode = 1;
																										}
																										else
																										{
																											if (this.selectedMenu == 2)
																											{
																												Main.PlaySound(11, -1, -1, 1);
																												Main.menuMode = 1;
																											}
																										}
																									}
																									else
																									{
																										if (Main.menuMode == 6)
																										{
																											num = 190;
																											num3 = 50;
																											array8[5] = "Create World";
																											array8[6] = "Delete";
																											if (Main.numLoadWorlds == 5)
																											{
																												array2[5] = true;
																												array8[5] = "";
																											}
																											else
																											{
																												if (Main.numLoadWorlds == 0)
																												{
																													array2[6] = true;
																													array8[6] = "";
																												}
																											}
																											array8[7] = "Back";
																											for (int num13 = 0; num13 < 5; num13++)
																											{
																												if (num13 < Main.numLoadWorlds)
																												{
																													array8[num13] = Main.loadWorld[num13];
																												}
																												else
																												{
																													array8[num13] = null;
																												}
																											}
																											num4 = 8;
																											if (this.selectedMenu == 7)
																											{
																												if (Main.menuMultiplayer)
																												{
																													Main.menuMode = 12;
																												}
																												else
																												{
																													Main.menuMode = 1;
																												}
																												Main.PlaySound(11, -1, -1, 1);
																											}
																											else
																											{
																												if (this.selectedMenu == 5)
																												{
																													Main.PlaySound(10, -1, -1, 1);
																													Main.menuMode = 16;
																													Main.newWorldName = "World " + (Main.numLoadWorlds + 1);
																												}
																												else
																												{
																													if (this.selectedMenu == 6)
																													{
																														Main.PlaySound(10, -1, -1, 1);
																														Main.menuMode = 8;
																													}
																													else
																													{
																														if (this.selectedMenu >= 0)
																														{
																															if (Main.menuMultiplayer)
																															{
																																Main.PlaySound(10, -1, -1, 1);
																																Main.worldPathName = Main.loadWorldPath[this.selectedMenu];
																																Main.menuMode = 30;
																															}
																															else
																															{
																																Main.PlaySound(10, -1, -1, 1);
																																Main.worldPathName = Main.loadWorldPath[this.selectedMenu];
																																WorldGen.playWorld();
																																Main.menuMode = 10;
																															}
																														}
																													}
																												}
																											}
																										}
																										else
																										{
																											if (Main.menuMode == 7)
																											{
																												string a = Main.newWorldName;
																												Main.newWorldName = Main.GetInputText(Main.newWorldName);
																												if (Main.newWorldName.Length > 20)
																												{
																													Main.newWorldName = Main.newWorldName.Substring(0, 20);
																												}
																												if (a != Main.newWorldName)
																												{
																													Main.PlaySound(12, -1, -1, 1);
																												}
																												array8[0] = "Enter World Name:";
																												array2[2] = true;
																												if (Main.newWorldName != "")
																												{
																													if (Main.newWorldName.Substring(0, 1) == " ")
																													{
																														Main.newWorldName = "";
																													}
																													for (int num14 = 0; num14 < Main.newWorldName.Length; num14++)
																													{
																														if (Main.newWorldName != " ")
																														{
																															array2[2] = false;
																														}
																													}
																												}
																												this.textBlinkerCount++;
																												if (this.textBlinkerCount >= 20)
																												{
																													if (this.textBlinkerState == 0)
																													{
																														this.textBlinkerState = 1;
																													}
																													else
																													{
																														this.textBlinkerState = 0;
																													}
																													this.textBlinkerCount = 0;
																												}
																												array8[1] = Main.newWorldName;
																												if (this.textBlinkerState == 1)
																												{
																													string[] array9;
																													(array9 = array8)[1] = array9[1] + "|";
																													array4[1] = 1;
																												}
																												else
																												{
																													string[] array9;
																													(array9 = array8)[1] = array9[1] + " ";
																												}
																												array[0] = true;
																												array[1] = true;
																												array3[1] = -20;
																												array3[2] = 20;
																												array8[2] = "Accept";
																												array8[3] = "Back";
																												num4 = 4;
																												if (this.selectedMenu == 3)
																												{
																													Main.PlaySound(11, -1, -1, 1);
																													Main.menuMode = 16;
																												}
																												if (this.selectedMenu == 2 || (!array2[2] && Main.inputTextEnter))
																												{
																													Main.menuMode = 10;
																													Main.worldName = Main.newWorldName;
																													Main.worldPathName = Main.nextLoadWorld();
																													WorldGen.CreateNewWorld();
																												}
																											}
																											else
																											{
																												if (Main.menuMode == 8)
																												{
																													num = 220;
																													num3 = 60;
																													array8[5] = "Back";
																													for (int num15 = 0; num15 < 5; num15++)
																													{
																														if (num15 < Main.numLoadWorlds)
																														{
																															array8[num15] = Main.loadWorld[num15];
																														}
																														else
																														{
																															array8[num15] = null;
																														}
																													}
																													num4 = 6;
																													if (this.selectedMenu == 5)
																													{
																														Main.PlaySound(11, -1, -1, 1);
																														Main.menuMode = 1;
																													}
																													else
																													{
																														if (this.selectedMenu >= 0)
																														{
																															this.selectedWorld = this.selectedMenu;
																															Main.PlaySound(10, -1, -1, 1);
																															Main.menuMode = 9;
																														}
																													}
																												}
																												else
																												{
																													if (Main.menuMode == 9)
																													{
																														array8[0] = "Delete " + Main.loadWorld[this.selectedWorld] + "?";
																														array[0] = true;
																														array8[1] = "Yes";
																														array8[2] = "No";
																														num4 = 3;
																														if (this.selectedMenu == 1)
																														{
																															Main.EraseWorld(this.selectedWorld);
																															Main.PlaySound(10, -1, -1, 1);
																															Main.menuMode = 6;
																														}
																														else
																														{
																															if (this.selectedMenu == 2)
																															{
																																Main.PlaySound(11, -1, -1, 1);
																																Main.menuMode = 6;
																															}
																														}
																													}
																													else
																													{
																														if (Main.menuMode == 1111)
																														{
																															num = 220;
																															num3 = 50;
																															array3[6] = 10;
																															num4 = 7;
																															if (this.graphics.IsFullScreen)
																															{
																																array8[0] = "Go Windowed";
																															}
																															else
																															{
																																array8[0] = "Go Fullscreen";
																															}
																															this.bgScroll = (int)Math.Round((double)((1f - Main.caveParrallax) * 500f));
																															array8[1] = "Resolution";
																															array8[2] = "Parallax";
																															if (Main.fixedTiming)
																															{
																																array8[3] = "Frame Skip Off (Not Recommended)";
																															}
																															else
																															{
																																array8[3] = "Frame Skip On (Recommended)";
																															}
																															if (Lighting.lightMode == 0)
																															{
																																array8[4] = "Lighting: Color";
																															}
																															else
																															{
																																if (Lighting.lightMode == 1)
																																{
																																	array8[4] = "Lighting: White";
																																}
																																else
																																{
																																	if (Lighting.lightMode == 2)
																																	{
																																		array8[4] = "Lighting: Retro";
																																	}
																																	else
																																	{
																																		if (Lighting.lightMode == 3)
																																		{
																																			array8[4] = "Lighting: Trippy";
																																		}
																																	}
																																}
																															}
																															if (Main.qaStyle == 0)
																															{
																																array8[5] = "Quality: Auto";
																															}
																															else
																															{
																																if (Main.qaStyle == 1)
																																{
																																	array8[5] = "Quality: High";
																																}
																																else
																																{
																																	if (Main.qaStyle == 2)
																																	{
																																		array8[5] = "Quality: Medium";
																																	}
																																	else
																																	{
																																		array8[5] = "Quality: Low";
																																	}
																																}
																															}
																															array8[6] = "Back";
																															if (this.selectedMenu == 6)
																															{
																																Main.PlaySound(11, -1, -1, 1);
																																this.SaveSettings();
																																Main.menuMode = 11;
																															}
																															if (this.selectedMenu == 5)
																															{
																																Main.PlaySound(12, -1, -1, 1);
																																Main.qaStyle++;
																																if (Main.qaStyle > 3)
																																{
																																	Main.qaStyle = 0;
																																}
																															}
																															if (this.selectedMenu == 4)
																															{
																																Main.PlaySound(12, -1, -1, 1);
																																Lighting.lightMode++;
																																if (Lighting.lightMode >= 4)
																																{
																																	Lighting.lightMode = 0;
																																}
																															}
																															if (this.selectedMenu == 3)
																															{
																																Main.PlaySound(12, -1, -1, 1);
																																if (Main.fixedTiming)
																																{
																																	Main.fixedTiming = false;
																																}
																																else
																																{
																																	Main.fixedTiming = true;
																																}
																															}
																															if (this.selectedMenu == 2)
																															{
																																Main.PlaySound(11, -1, -1, 1);
																																Main.menuMode = 28;
																															}
																															if (this.selectedMenu == 1)
																															{
																																Main.PlaySound(10, -1, -1, 1);
																																Main.menuMode = 111;
																															}
																															if (this.selectedMenu == 0)
																															{
																																this.graphics.ToggleFullScreen();
																															}
																														}
																														else
																														{
																															if (Main.menuMode == 11)
																															{
																																num = 180;
																																num3 = 48;
																																array3[7] = 10;
																																num4 = 8;
																																array8[0] = "Video";
																																array8[1] = "Cursor Color";
																																array8[2] = "Volume";
																																array8[3] = "Controls";
																																if (Main.autoSave)
																																{
																																	array8[4] = "Autosave On";
																																}
																																else
																																{
																																	array8[4] = "Autosave Off";
																																}
																																if (Main.autoPause)
																																{
																																	array8[5] = "Autopause On";
																																}
																																else
																																{
																																	array8[5] = "Autopause Off";
																																}
																																if (Main.showItemText)
																																{
																																	array8[6] = "Pickup Text On";
																																}
																																else
																																{
																																	array8[6] = "Pickup Text Off";
																																}
																																array8[7] = "Back";
																																if (this.selectedMenu == 7)
																																{
																																	Main.PlaySound(11, -1, -1, 1);
																																	this.SaveSettings();
																																	Main.menuMode = 0;
																																}
																																if (this.selectedMenu == 6)
																																{
																																	Main.PlaySound(12, -1, -1, 1);
																																	if (Main.showItemText)
																																	{
																																		Main.showItemText = false;
																																	}
																																	else
																																	{
																																		Main.showItemText = true;
																																	}
																																}
																																if (this.selectedMenu == 5)
																																{
																																	Main.PlaySound(12, -1, -1, 1);
																																	if (Main.autoPause)
																																	{
																																		Main.autoPause = false;
																																	}
																																	else
																																	{
																																		Main.autoPause = true;
																																	}
																																}
																																if (this.selectedMenu == 4)
																																{
																																	Main.PlaySound(12, -1, -1, 1);
																																	if (Main.autoSave)
																																	{
																																		Main.autoSave = false;
																																	}
																																	else
																																	{
																																		Main.autoSave = true;
																																	}
																																}
																																if (this.selectedMenu == 3)
																																{
																																	Main.PlaySound(11, -1, -1, 1);
																																	Main.menuMode = 27;
																																}
																																if (this.selectedMenu == 2)
																																{
																																	Main.PlaySound(11, -1, -1, 1);
																																	Main.menuMode = 26;
																																}
																																if (this.selectedMenu == 1)
																																{
																																	Main.PlaySound(10, -1, -1, 1);
																																	this.selColor = Main.mouseColor;
																																	Main.menuMode = 25;
																																}
																																if (this.selectedMenu == 0)
																																{
																																	Main.PlaySound(10, -1, -1, 1);
																																	Main.menuMode = 1111;
																																}
																															}
																															else
																															{
																																if (Main.menuMode == 111)
																																{
																																	num = 240;
																																	num3 = 60;
																																	num4 = 3;
																																	array8[0] = "Fullscreen Resolution";
																																	array8[1] = this.graphics.PreferredBackBufferWidth + "x" + this.graphics.PreferredBackBufferHeight;
																																	array[0] = true;
																																	array3[2] = 170;
																																	array3[1] = 10;
																																	array8[2] = "Back";
																																	if (this.selectedMenu == 1)
																																	{
																																		Main.PlaySound(12, -1, -1, 1);
																																		int num16 = 0;
																																		for (int num17 = 0; num17 < this.numDisplayModes; num17++)
																																		{
																																			if (this.displayWidth[num17] == this.graphics.PreferredBackBufferWidth && this.displayHeight[num17] == this.graphics.PreferredBackBufferHeight)
																																			{
																																				num16 = num17;
																																				break;
																																			}
																																		}
																																		num16++;
																																		if (num16 >= this.numDisplayModes)
																																		{
																																			num16 = 0;
																																		}
																																		this.graphics.PreferredBackBufferWidth = this.displayWidth[num16];
																																		this.graphics.PreferredBackBufferHeight = this.displayHeight[num16];
																																	}
																																	if (this.selectedMenu == 2)
																																	{
																																		if (this.graphics.IsFullScreen)
																																		{
																																			this.graphics.ApplyChanges();
																																		}
																																		Main.menuMode = 1111;
																																		Main.PlaySound(11, -1, -1, 1);
																																	}
																																}
																																else
																																{
																																	if (Main.menuMode == 25)
																																	{
																																		flag = true;
																																		num9 = 370;
																																		num = 240;
																																		num3 = 60;
																																		Main.mouseColor = this.selColor;
																																		num4 = 3;
																																		array8[0] = "";
																																		array8[1] = "Cursor Color";
																																		array[1] = true;
																																		array3[2] = 170;
																																		array3[1] = 10;
																																		array8[2] = "Back";
																																		if (this.selectedMenu == 2)
																																		{
																																			Main.menuMode = 11;
																																			Main.PlaySound(11, -1, -1, 1);
																																		}
																																	}
																																	else
																																	{
																																		if (Main.menuMode == 26)
																																		{
																																			flag2 = true;
																																			num = 240;
																																			num3 = 60;
																																			num4 = 3;
																																			array8[0] = "";
																																			array8[1] = "Volume";
																																			array[1] = true;
																																			array3[2] = 170;
																																			array3[1] = 10;
																																			array8[2] = "Back";
																																			if (this.selectedMenu == 2)
																																			{
																																				Main.menuMode = 11;
																																				Main.PlaySound(11, -1, -1, 1);
																																			}
																																		}
																																		else
																																		{
																																			if (Main.menuMode == 28)
																																			{
																																				Main.caveParrallax = 1f - (float)this.bgScroll / 500f;
																																				flag3 = true;
																																				num = 240;
																																				num3 = 60;
																																				num4 = 3;
																																				array8[0] = "";
																																				array8[1] = "Parallax";
																																				array[1] = true;
																																				array3[2] = 170;
																																				array3[1] = 10;
																																				array8[2] = "Back";
																																				if (this.selectedMenu == 2)
																																				{
																																					Main.menuMode = 1111;
																																					Main.PlaySound(11, -1, -1, 1);
																																				}
																																			}
																																			else
																																			{
																																				if (Main.menuMode == 27)
																																				{
																																					num = 176;
																																					num3 = 28;
																																					num4 = 14;
																																					string[] array10 = new string[]
																																					{
																																						Main.cUp, 
																																						Main.cDown, 
																																						Main.cLeft, 
																																						Main.cRight, 
																																						Main.cJump, 
																																						Main.cThrowItem, 
																																						Main.cInv, 
																																						Main.cHeal, 
																																						Main.cMana, 
																																						Main.cBuff, 
																																						Main.cHook, 
																																						Main.cTorch
																																					};
																																					if (this.setKey >= 0)
																																					{
																																						array10[this.setKey] = "_";
																																					}
																																					array8[0] = "Up             " + array10[0];
																																					array8[1] = "Down          " + array10[1];
																																					array8[2] = "Left            " + array10[2];
																																					array8[3] = "Right          " + array10[3];
																																					array8[4] = "Jump          " + array10[4];
																																					array8[5] = "Throw         " + array10[5];
																																					array8[6] = "Inventory      " + array10[6];
																																					array8[7] = "Quick Heal    " + array10[7];
																																					array8[8] = "Quick Mana   " + array10[8];
																																					array8[9] = "Quick Buff    " + array10[9];
																																					array8[10] = "Grapple        " + array10[10];
																																					array8[11] = "Auto Select    " + array10[11];
																																					for (int num18 = 0; num18 < 12; num18++)
																																					{
																																						array7[num18] = true;
																																						array6[num18] = 0.55f;
																																						array4[num18] = -80;
																																					}
																																					array6[12] = 0.8f;
																																					array6[13] = 0.8f;
																																					array3[12] = 6;
																																					array8[12] = "Reset to Default";
																																					array3[13] = 16;
																																					array8[13] = "Back";
																																					if (this.selectedMenu == 13)
																																					{
																																						Main.menuMode = 11;
																																						Main.PlaySound(11, -1, -1, 1);
																																					}
																																					else
																																					{
																																						if (this.selectedMenu == 12)
																																						{
																																							Main.cUp = "W";
																																							Main.cDown = "S";
																																							Main.cLeft = "A";
																																							Main.cRight = "D";
																																							Main.cJump = "Space";
																																							Main.cThrowItem = "T";
																																							Main.cInv = "Escape";
																																							Main.cHeal = "H";
																																							Main.cMana = "M";
																																							Main.cBuff = "B";
																																							Main.cHook = "E";
																																							Main.cTorch = "LeftShift";
																																							this.setKey = -1;
																																							Main.PlaySound(11, -1, -1, 1);
																																						}
																																						else
																																						{
																																							if (this.selectedMenu >= 0)
																																							{
																																								this.setKey = this.selectedMenu;
																																							}
																																						}
																																					}
																																					if (this.setKey >= 0)
																																					{
																																						Keys[] pressedKeys = Main.keyState.GetPressedKeys();
																																						if (pressedKeys.Length > 0)
																																						{
																																							string text = string.Concat(pressedKeys[0]);
																																							if (this.setKey == 0)
																																							{
																																								Main.cUp = text;
																																							}
																																							if (this.setKey == 1)
																																							{
																																								Main.cDown = text;
																																							}
																																							if (this.setKey == 2)
																																							{
																																								Main.cLeft = text;
																																							}
																																							if (this.setKey == 3)
																																							{
																																								Main.cRight = text;
																																							}
																																							if (this.setKey == 4)
																																							{
																																								Main.cJump = text;
																																							}
																																							if (this.setKey == 5)
																																							{
																																								Main.cThrowItem = text;
																																							}
																																							if (this.setKey == 6)
																																							{
																																								Main.cInv = text;
																																							}
																																							if (this.setKey == 7)
																																							{
																																								Main.cHeal = text;
																																							}
																																							if (this.setKey == 8)
																																							{
																																								Main.cMana = text;
																																							}
																																							if (this.setKey == 9)
																																							{
																																								Main.cBuff = text;
																																							}
																																							if (this.setKey == 10)
																																							{
																																								Main.cHook = text;
																																							}
																																							if (this.setKey == 11)
																																							{
																																								Main.cTorch = text;
																																							}
																																							this.setKey = -1;
																																						}
																																					}
																																				}
																																				else
																																				{
																																					if (Main.menuMode == 12)
																																					{
																																						Main.menuServer = false;
																																						array8[0] = "Join";
																																						array8[1] = "Host & Play";
																																						array8[2] = "Back";
																																						if (this.selectedMenu == 0)
																																						{
																																							Main.LoadPlayers();
																																							Main.menuMultiplayer = true;
																																							Main.PlaySound(10, -1, -1, 1);
																																							Main.menuMode = 1;
																																						}
																																						else
																																						{
																																							if (this.selectedMenu == 1)
																																							{
																																								Main.LoadPlayers();
																																								Main.PlaySound(10, -1, -1, 1);
																																								Main.menuMode = 1;
																																								Main.menuMultiplayer = true;
																																								Main.menuServer = true;
																																							}
																																						}
																																						if (this.selectedMenu == 2)
																																						{
																																							Main.PlaySound(11, -1, -1, 1);
																																							Main.menuMode = 0;
																																						}
																																						num4 = 3;
																																					}
																																					else
																																					{
																																						if (Main.menuMode == 13)
																																						{
																																							string a2 = Main.getIP;
																																							Main.getIP = Main.GetInputText(Main.getIP);
																																							if (a2 != Main.getIP)
																																							{
																																								Main.PlaySound(12, -1, -1, 1);
																																							}
																																							array8[0] = "Enter Server IP Address:";
																																							array2[9] = true;
																																							if (Main.getIP != "")
																																							{
																																								if (Main.getIP.Substring(0, 1) == " ")
																																								{
																																									Main.getIP = "";
																																								}
																																								for (int num19 = 0; num19 < Main.getIP.Length; num19++)
																																								{
																																									if (Main.getIP != " ")
																																									{
																																										array2[9] = false;
																																									}
																																								}
																																							}
																																							this.textBlinkerCount++;
																																							if (this.textBlinkerCount >= 20)
																																							{
																																								if (this.textBlinkerState == 0)
																																								{
																																									this.textBlinkerState = 1;
																																								}
																																								else
																																								{
																																									this.textBlinkerState = 0;
																																								}
																																								this.textBlinkerCount = 0;
																																							}
																																							array8[1] = Main.getIP;
																																							if (this.textBlinkerState == 1)
																																							{
																																								string[] array9;
																																								(array9 = array8)[1] = array9[1] + "|";
																																								array4[1] = 1;
																																							}
																																							else
																																							{
																																								string[] array9;
																																								(array9 = array8)[1] = array9[1] + " ";
																																							}
																																							array[0] = true;
																																							array[1] = true;
																																							array3[9] = 44;
																																							array3[10] = 64;
																																							array8[9] = "Accept";
																																							array8[10] = "Back";
																																							num4 = 11;
																																							num = 180;
																																							num3 = 30;
																																							array3[1] = 19;
																																							for (int num20 = 2; num20 < 9; num20++)
																																							{
																																								int num21 = num20 - 2;
																																								if (Main.recentWorld[num21] != null && Main.recentWorld[num21] != "")
																																								{
																																									array8[num20] = string.Concat(new object[]
																																									{
																																										Main.recentWorld[num21], 
																																										" (", 
																																										Main.recentIP[num21], 
																																										":", 
																																										Main.recentPort[num21], 
																																										")"
																																									});
																																								}
																																								else
																																								{
																																									array8[num20] = "";
																																									array[num20] = true;
																																								}
																																								array6[num20] = 0.6f;
																																								array3[num20] = 40;
																																							}
																																							if (this.selectedMenu >= 2 && this.selectedMenu < 9)
																																							{
																																								Main.autoPass = false;
																																								int num22 = this.selectedMenu - 2;
																																								Netplay.serverPort = Main.recentPort[num22];
																																								Main.getIP = Main.recentIP[num22];
																																								if (Netplay.SetIP(Main.getIP))
																																								{
																																									Main.menuMode = 10;
																																									Netplay.StartClient();
																																								}
																																								else
																																								{
																																									if (Netplay.SetIP2(Main.getIP))
																																									{
																																										Main.menuMode = 10;
																																										Netplay.StartClient();
																																									}
																																								}
																																							}
																																							if (this.selectedMenu == 10)
																																							{
																																								Main.PlaySound(11, -1, -1, 1);
																																								Main.menuMode = 1;
																																							}
																																							if (this.selectedMenu == 9 || (!array2[2] && Main.inputTextEnter))
																																							{
																																								Main.PlaySound(12, -1, -1, 1);
																																								Main.menuMode = 131;
																																							}
																																						}
																																						else
																																						{
																																							if (Main.menuMode == 131)
																																							{
																																								int num23 = 7777;
																																								string a3 = Main.getPort;
																																								Main.getPort = Main.GetInputText(Main.getPort);
																																								if (a3 != Main.getPort)
																																								{
																																									Main.PlaySound(12, -1, -1, 1);
																																								}
																																								array8[0] = "Enter Server Port:";
																																								array2[2] = true;
																																								if (Main.getPort != "")
																																								{
																																									bool flag5 = false;
																																									try
																																									{
																																										num23 = Convert.ToInt32(Main.getPort);
																																										if (num23 > 0 && num23 <= 65535)
																																										{
																																											flag5 = true;
																																										}
																																									}
																																									catch
																																									{
																																									}
																																									if (flag5)
																																									{
																																										array2[2] = false;
																																									}
																																								}
																																								this.textBlinkerCount++;
																																								if (this.textBlinkerCount >= 20)
																																								{
																																									if (this.textBlinkerState == 0)
																																									{
																																										this.textBlinkerState = 1;
																																									}
																																									else
																																									{
																																										this.textBlinkerState = 0;
																																									}
																																									this.textBlinkerCount = 0;
																																								}
																																								array8[1] = Main.getPort;
																																								if (this.textBlinkerState == 1)
																																								{
																																									string[] array9;
																																									(array9 = array8)[1] = array9[1] + "|";
																																									array4[1] = 1;
																																								}
																																								else
																																								{
																																									string[] array9;
																																									(array9 = array8)[1] = array9[1] + " ";
																																								}
																																								array[0] = true;
																																								array[1] = true;
																																								array3[1] = -20;
																																								array3[2] = 20;
																																								array8[2] = "Accept";
																																								array8[3] = "Back";
																																								num4 = 4;
																																								if (this.selectedMenu == 3)
																																								{
																																									Main.PlaySound(11, -1, -1, 1);
																																									Main.menuMode = 1;
																																								}
																																								if (this.selectedMenu == 2 || (!array2[2] && Main.inputTextEnter))
																																								{
																																									Netplay.serverPort = num23;
																																									Main.autoPass = false;
																																									if (Netplay.SetIP(Main.getIP))
																																									{
																																										Main.menuMode = 10;
																																										Netplay.StartClient();
																																									}
																																									else
																																									{
																																										if (Netplay.SetIP2(Main.getIP))
																																										{
																																											Main.menuMode = 10;
																																											Netplay.StartClient();
																																										}
																																									}
																																								}
																																							}
																																							else
																																							{
																																								if (Main.menuMode == 16)
																																								{
																																									num = 200;
																																									num3 = 60;
																																									array3[1] = 30;
																																									array3[2] = 30;
																																									array3[3] = 30;
																																									array3[4] = 70;
																																									array8[0] = "Choose world size:";
																																									array[0] = true;
																																									array8[1] = "Small";
																																									array8[2] = "Medium";
																																									array8[3] = "Large";
																																									array8[4] = "Back";
																																									num4 = 5;
																																									if (this.selectedMenu == 4)
																																									{
																																										Main.menuMode = 6;
																																										Main.PlaySound(11, -1, -1, 1);
																																									}
																																									else
																																									{
																																										if (this.selectedMenu > 0)
																																										{
																																											if (this.selectedMenu == 1)
																																											{
																																												Main.maxTilesX = 4200;
																																												Main.maxTilesY = 1200;
																																											}
																																											else
																																											{
																																												if (this.selectedMenu == 2)
																																												{
																																													Main.maxTilesX = 6400;
																																													Main.maxTilesY = 1800;
																																												}
																																												else
																																												{
																																													Main.maxTilesX = 8400;
																																													Main.maxTilesY = 2400;
																																												}
																																											}
																																											Main.menuMode = 7;
																																											Main.PlaySound(10, -1, -1, 1);
																																											WorldGen.setWorldSize();
																																										}
																																									}
																																								}
																																							}
																																						}
																																					}
																																				}
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			IL_3687:
			if (Main.menuMode != num5)
			{
				num4 = 0;
				for (int num24 = 0; num24 < Main.maxMenuItems; num24++)
				{
					this.menuItemScale[num24] = 0.8f;
				}
			}
			int num25 = this.focusMenu;
			this.selectedMenu = -1;
			this.selectedMenu2 = -1;
			this.focusMenu = -1;
			Vector2 origin;
			for (int num26 = 0; num26 < num4; num26++)
			{
				if (array8[num26] != null)
				{
					if (flag)
					{
						string text2 = "";
						for (int num27 = 0; num27 < 6; num27++)
						{
							int num28 = num9;
							int num29 = 370 + Main.screenWidth / 2 - 400;
							if (num27 == 0)
							{
								text2 = "Red:";
							}
							if (num27 == 1)
							{
								text2 = "Green:";
								num28 += 30;
							}
							if (num27 == 2)
							{
								text2 = "Blue:";
								num28 += 60;
							}
							if (num27 == 3)
							{
								text2 = string.Concat(this.selColor.R);
								num29 += 90;
							}
							if (num27 == 4)
							{
								text2 = string.Concat(this.selColor.G);
								num29 += 90;
								num28 += 30;
							}
							if (num27 == 5)
							{
								text2 = string.Concat(this.selColor.B);
								num29 += 90;
								num28 += 60;
							}
							for (int num30 = 0; num30 < 5; num30++)
							{
								Color color4 = Color.Black;
								if (num30 == 4)
								{
									color4 = color;
									color4.R = (byte)((255 + color4.R) / 2);
									color4.G = (byte)((255 + color4.R) / 2);
									color4.B = (byte)((255 + color4.R) / 2);
								}
								int num31 = 255;
								int num32 = (int)color4.R - (255 - num31);
								if (num32 < 0)
								{
									num32 = 0;
								}
								color4 = new Color((int)((byte)num32), (int)((byte)num32), (int)((byte)num32), (int)((byte)num31));
								int num33 = 0;
								int num34 = 0;
								if (num30 == 0)
								{
									num33 = -2;
								}
								if (num30 == 1)
								{
									num33 = 2;
								}
								if (num30 == 2)
								{
									num34 = -2;
								}
								if (num30 == 3)
								{
									num34 = 2;
								}
								SpriteBatch arg_38AC_0 = this.spriteBatch;
								SpriteFont arg_38AC_1 = Main.fontDeathText;
								string arg_38AC_2 = text2;
								Vector2 arg_38AC_3 = new Vector2((float)(num29 + num33), (float)(num28 + num34));
								Color arg_38AC_4 = color4;
								float arg_38AC_5 = 0f;
								origin = default(Vector2);
								arg_38AC_0.DrawString(arg_38AC_1, arg_38AC_2, arg_38AC_3, arg_38AC_4, arg_38AC_5, origin, 0.5f, SpriteEffects.None, 0f);
							}
						}
						bool flag6 = false;
						for (int num35 = 0; num35 < 2; num35++)
						{
							for (int num36 = 0; num36 < 3; num36++)
							{
								int num37 = num9 + num36 * 30 - 12;
								int num38 = 360 + Main.screenWidth / 2 - 400;
								float scale = 0.9f;
								if (num35 == 0)
								{
									num38 -= 70;
									num37 += 2;
								}
								else
								{
									num38 -= 40;
								}
								text2 = "-";
								if (num35 == 1)
								{
									text2 = "+";
								}
								Vector2 vector3 = new Vector2(24f, 24f);
								int num39 = 142;
								if (Main.mouseX > num38 && (float)Main.mouseX < (float)num38 + vector3.X && Main.mouseY > num37 + 13 && (float)Main.mouseY < (float)(num37 + 13) + vector3.Y)
								{
									if (this.focusColor != (num35 + 1) * (num36 + 10))
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									this.focusColor = (num35 + 1) * (num36 + 10);
									flag6 = true;
									num39 = 255;
									if (Main.mouseLeft)
									{
										if (this.colorDelay <= 1)
										{
											if (this.colorDelay == 0)
											{
												this.colorDelay = 40;
											}
											else
											{
												this.colorDelay = 3;
											}
											int num40 = num35;
											if (num35 == 0)
											{
												num40 = -1;
												if (this.selColor.R + this.selColor.G + this.selColor.B <= 150)
												{
													num40 = 0;
												}
											}
											if (num36 == 0 && (int)this.selColor.R + num40 >= 0 && (int)this.selColor.R + num40 <= 255)
											{
												this.selColor.R = (byte)((int)this.selColor.R + num40);
											}
											if (num36 == 1 && (int)this.selColor.G + num40 >= 0 && (int)this.selColor.G + num40 <= 255)
											{
												this.selColor.G = (byte)((int)this.selColor.G + num40);
											}
											if (num36 == 2 && (int)this.selColor.B + num40 >= 0 && (int)this.selColor.B + num40 <= 255)
											{
												this.selColor.B = (byte)((int)this.selColor.B + num40);
											}
										}
										this.colorDelay--;
									}
									else
									{
										this.colorDelay = 0;
									}
								}
								for (int num41 = 0; num41 < 5; num41++)
								{
									Color color5 = Color.Black;
									if (num41 == 4)
									{
										color5 = color;
										color5.R = (byte)((255 + color5.R) / 2);
										color5.G = (byte)((255 + color5.R) / 2);
										color5.B = (byte)((255 + color5.R) / 2);
									}
									int num42 = (int)color5.R - (255 - num39);
									if (num42 < 0)
									{
										num42 = 0;
									}
									color5 = new Color((int)((byte)num42), (int)((byte)num42), (int)((byte)num42), (int)((byte)num39));
									int num43 = 0;
									int num44 = 0;
									if (num41 == 0)
									{
										num43 = -2;
									}
									if (num41 == 1)
									{
										num43 = 2;
									}
									if (num41 == 2)
									{
										num44 = -2;
									}
									if (num41 == 3)
									{
										num44 = 2;
									}
									SpriteBatch arg_3C01_0 = this.spriteBatch;
									SpriteFont arg_3C01_1 = Main.fontDeathText;
									string arg_3C01_2 = text2;
									Vector2 arg_3C01_3 = new Vector2((float)(num38 + num43), (float)(num37 + num44));
									Color arg_3C01_4 = color5;
									float arg_3C01_5 = 0f;
									origin = default(Vector2);
									arg_3C01_0.DrawString(arg_3C01_1, arg_3C01_2, arg_3C01_3, arg_3C01_4, arg_3C01_5, origin, scale, SpriteEffects.None, 0f);
								}
							}
						}
						if (!flag6)
						{
							this.focusColor = 0;
							this.colorDelay = 0;
						}
					}
					if (flag3)
					{
						int num45 = 400;
						string text3 = "";
						for (int num46 = 0; num46 < 4; num46++)
						{
							int num47 = num45;
							int num48 = 370 + Main.screenWidth / 2 - 400;
							if (num46 == 0)
							{
								text3 = "Parallax: " + this.bgScroll;
							}
							for (int num49 = 0; num49 < 5; num49++)
							{
								Color color6 = Color.Black;
								if (num49 == 4)
								{
									color6 = color;
									color6.R = (byte)((255 + color6.R) / 2);
									color6.G = (byte)((255 + color6.R) / 2);
									color6.B = (byte)((255 + color6.R) / 2);
								}
								int num50 = 255;
								int num51 = (int)color6.R - (255 - num50);
								if (num51 < 0)
								{
									num51 = 0;
								}
								color6 = new Color((int)((byte)num51), (int)((byte)num51), (int)((byte)num51), (int)((byte)num50));
								int num52 = 0;
								int num53 = 0;
								if (num49 == 0)
								{
									num52 = -2;
								}
								if (num49 == 1)
								{
									num52 = 2;
								}
								if (num49 == 2)
								{
									num53 = -2;
								}
								if (num49 == 3)
								{
									num53 = 2;
								}
								SpriteBatch arg_3D84_0 = this.spriteBatch;
								SpriteFont arg_3D84_1 = Main.fontDeathText;
								string arg_3D84_2 = text3;
								Vector2 arg_3D84_3 = new Vector2((float)(num48 + num52), (float)(num47 + num53));
								Color arg_3D84_4 = color6;
								float arg_3D84_5 = 0f;
								origin = default(Vector2);
								arg_3D84_0.DrawString(arg_3D84_1, arg_3D84_2, arg_3D84_3, arg_3D84_4, arg_3D84_5, origin, 0.5f, SpriteEffects.None, 0f);
							}
						}
						bool flag7 = false;
						for (int num54 = 0; num54 < 2; num54++)
						{
							for (int num55 = 0; num55 < 1; num55++)
							{
								int num56 = num45 + num55 * 30 - 12;
								int num57 = 360 + Main.screenWidth / 2 - 400;
								float scale2 = 0.9f;
								if (num54 == 0)
								{
									num57 -= 70;
									num56 += 2;
								}
								else
								{
									num57 -= 40;
								}
								text3 = "-";
								if (num54 == 1)
								{
									text3 = "+";
								}
								Vector2 vector4 = new Vector2(24f, 24f);
								int num58 = 142;
								if (Main.mouseX > num57 && (float)Main.mouseX < (float)num57 + vector4.X && Main.mouseY > num56 + 13 && (float)Main.mouseY < (float)(num56 + 13) + vector4.Y)
								{
									if (this.focusColor != (num54 + 1) * (num55 + 10))
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									this.focusColor = (num54 + 1) * (num55 + 10);
									flag7 = true;
									num58 = 255;
									if (Main.mouseLeft)
									{
										if (this.colorDelay <= 1)
										{
											if (this.colorDelay == 0)
											{
												this.colorDelay = 40;
											}
											else
											{
												this.colorDelay = 3;
											}
											int num59 = (int?)num54 ?? -1;
											if (num55 == 0)
											{
												this.bgScroll += num59;
												if (this.bgScroll > 100)
												{
													this.bgScroll = 100;
												}
												if (this.bgScroll < 0)
												{
													this.bgScroll = 0;
												}
											}
										}
										this.colorDelay--;
									}
									else
									{
										this.colorDelay = 0;
									}
								}
								for (int num60 = 0; num60 < 5; num60++)
								{
									Color color7 = Color.Black;
									if (num60 == 4)
									{
										color7 = color;
										color7.R = (byte)((255 + color7.R) / 2);
										color7.G = (byte)((255 + color7.R) / 2);
										color7.B = (byte)((255 + color7.R) / 2);
									}
									int num61 = (int)color7.R - (255 - num58);
									if (num61 < 0)
									{
										num61 = 0;
									}
									color7 = new Color((int)((byte)num61), (int)((byte)num61), (int)((byte)num61), (int)((byte)num58));
									int num62 = 0;
									int num63 = 0;
									if (num60 == 0)
									{
										num62 = -2;
									}
									if (num60 == 1)
									{
										num62 = 2;
									}
									if (num60 == 2)
									{
										num63 = -2;
									}
									if (num60 == 3)
									{
										num63 = 2;
									}
									SpriteBatch arg_400D_0 = this.spriteBatch;
									SpriteFont arg_400D_1 = Main.fontDeathText;
									string arg_400D_2 = text3;
									Vector2 arg_400D_3 = new Vector2((float)(num57 + num62), (float)(num56 + num63));
									Color arg_400D_4 = color7;
									float arg_400D_5 = 0f;
									origin = default(Vector2);
									arg_400D_0.DrawString(arg_400D_1, arg_400D_2, arg_400D_3, arg_400D_4, arg_400D_5, origin, scale2, SpriteEffects.None, 0f);
								}
							}
						}
						if (!flag7)
						{
							this.focusColor = 0;
							this.colorDelay = 0;
						}
					}
					if (flag2)
					{
						int num64 = 400;
						string text4 = "";
						for (int num65 = 0; num65 < 4; num65++)
						{
							int num66 = num64;
							int num67 = 370 + Main.screenWidth / 2 - 400;
							if (num65 == 0)
							{
								text4 = "Sound:";
							}
							if (num65 == 1)
							{
								text4 = "Music:";
								num66 += 30;
							}
							if (num65 == 2)
							{
								text4 = Math.Round((double)(Main.soundVolume * 100f)) + "%";
								num67 += 90;
							}
							if (num65 == 3)
							{
								text4 = Math.Round((double)(Main.musicVolume * 100f)) + "%";
								num67 += 90;
								num66 += 30;
							}
							for (int num68 = 0; num68 < 5; num68++)
							{
								Color color8 = Color.Black;
								if (num68 == 4)
								{
									color8 = color;
									color8.R = (byte)((255 + color8.R) / 2);
									color8.G = (byte)((255 + color8.R) / 2);
									color8.B = (byte)((255 + color8.R) / 2);
								}
								int num69 = 255;
								int num70 = (int)color8.R - (255 - num69);
								if (num70 < 0)
								{
									num70 = 0;
								}
								color8 = new Color((int)((byte)num70), (int)((byte)num70), (int)((byte)num70), (int)((byte)num69));
								int num71 = 0;
								int num72 = 0;
								if (num68 == 0)
								{
									num71 = -2;
								}
								if (num68 == 1)
								{
									num71 = 2;
								}
								if (num68 == 2)
								{
									num72 = -2;
								}
								if (num68 == 3)
								{
									num72 = 2;
								}
								SpriteBatch arg_41F6_0 = this.spriteBatch;
								SpriteFont arg_41F6_1 = Main.fontDeathText;
								string arg_41F6_2 = text4;
								Vector2 arg_41F6_3 = new Vector2((float)(num67 + num71), (float)(num66 + num72));
								Color arg_41F6_4 = color8;
								float arg_41F6_5 = 0f;
								origin = default(Vector2);
								arg_41F6_0.DrawString(arg_41F6_1, arg_41F6_2, arg_41F6_3, arg_41F6_4, arg_41F6_5, origin, 0.5f, SpriteEffects.None, 0f);
							}
						}
						bool flag8 = false;
						for (int num73 = 0; num73 < 2; num73++)
						{
							for (int num74 = 0; num74 < 2; num74++)
							{
								int num75 = num64 + num74 * 30 - 12;
								int num76 = 360 + Main.screenWidth / 2 - 400;
								float scale3 = 0.9f;
								if (num73 == 0)
								{
									num76 -= 70;
									num75 += 2;
								}
								else
								{
									num76 -= 40;
								}
								text4 = "-";
								if (num73 == 1)
								{
									text4 = "+";
								}
								Vector2 vector5 = new Vector2(24f, 24f);
								int num77 = 142;
								if (Main.mouseX > num76 && (float)Main.mouseX < (float)num76 + vector5.X && Main.mouseY > num75 + 13 && (float)Main.mouseY < (float)(num75 + 13) + vector5.Y)
								{
									if (this.focusColor != (num73 + 1) * (num74 + 10))
									{
										Main.PlaySound(12, -1, -1, 1);
									}
									this.focusColor = (num73 + 1) * (num74 + 10);
									flag8 = true;
									num77 = 255;
									if (Main.mouseLeft)
									{
										if (this.colorDelay <= 1)
										{
											if (this.colorDelay == 0)
											{
												this.colorDelay = 40;
											}
											else
											{
												this.colorDelay = 3;
											}
											int num78 = (int?)num73 ?? -1;
											if (num74 == 0)
											{
												Main.soundVolume += (float)num78 * 0.01f;
												if (Main.soundVolume > 1f)
												{
													Main.soundVolume = 1f;
												}
												if (Main.soundVolume < 0f)
												{
													Main.soundVolume = 0f;
												}
											}
											if (num74 == 1)
											{
												Main.musicVolume += (float)num78 * 0.01f;
												if (Main.musicVolume > 1f)
												{
													Main.musicVolume = 1f;
												}
												if (Main.musicVolume < 0f)
												{
													Main.musicVolume = 0f;
												}
											}
										}
										this.colorDelay--;
									}
									else
									{
										this.colorDelay = 0;
									}
								}
								for (int num79 = 0; num79 < 5; num79++)
								{
									Color color9 = Color.Black;
									if (num79 == 4)
									{
										color9 = color;
										color9.R = (byte)((255 + color9.R) / 2);
										color9.G = (byte)((255 + color9.R) / 2);
										color9.B = (byte)((255 + color9.R) / 2);
									}
									int num80 = (int)color9.R - (255 - num77);
									if (num80 < 0)
									{
										num80 = 0;
									}
									color9 = new Color((int)((byte)num80), (int)((byte)num80), (int)((byte)num80), (int)((byte)num77));
									int num81 = 0;
									int num82 = 0;
									if (num79 == 0)
									{
										num81 = -2;
									}
									if (num79 == 1)
									{
										num81 = 2;
									}
									if (num79 == 2)
									{
										num82 = -2;
									}
									if (num79 == 3)
									{
										num82 = 2;
									}
									SpriteBatch arg_44D9_0 = this.spriteBatch;
									SpriteFont arg_44D9_1 = Main.fontDeathText;
									string arg_44D9_2 = text4;
									Vector2 arg_44D9_3 = new Vector2((float)(num76 + num81), (float)(num75 + num82));
									Color arg_44D9_4 = color9;
									float arg_44D9_5 = 0f;
									origin = default(Vector2);
									arg_44D9_0.DrawString(arg_44D9_1, arg_44D9_2, arg_44D9_3, arg_44D9_4, arg_44D9_5, origin, scale3, SpriteEffects.None, 0f);
								}
							}
						}
						if (!flag8)
						{
							this.focusColor = 0;
							this.colorDelay = 0;
						}
					}
					for (int num83 = 0; num83 < 5; num83++)
					{
						Color color10 = Color.Black;
						if (num83 == 4)
						{
							color10 = color;
							if (array5[num26] == 2)
							{
								color10 = Main.hcColor;
							}
							else
							{
								if (array5[num26] == 1)
								{
									color10 = Main.mcColor;
								}
							}
							color10.R = (byte)((255 + color10.R) / 2);
							color10.G = (byte)((255 + color10.G) / 2);
							color10.B = (byte)((255 + color10.B) / 2);
						}
						int num84 = (int)(255f * (this.menuItemScale[num26] * 2f - 1f));
						if (array[num26])
						{
							num84 = 255;
						}
						int num85 = (int)color10.R - (255 - num84);
						if (num85 < 0)
						{
							num85 = 0;
						}
						int num86 = (int)color10.G - (255 - num84);
						if (num86 < 0)
						{
							num86 = 0;
						}
						int num87 = (int)color10.B - (255 - num84);
						if (num87 < 0)
						{
							num87 = 0;
						}
						color10 = new Color((int)((byte)num85), (int)((byte)num86), (int)((byte)num87), (int)((byte)num84));
						int num88 = 0;
						int num89 = 0;
						if (num83 == 0)
						{
							num88 = -2;
						}
						if (num83 == 1)
						{
							num88 = 2;
						}
						if (num83 == 2)
						{
							num89 = -2;
						}
						if (num83 == 3)
						{
							num89 = 2;
						}
						Vector2 origin2 = Main.fontDeathText.MeasureString(array8[num26]);
						origin2.X *= 0.5f;
						origin2.Y *= 0.5f;
						float num90 = this.menuItemScale[num26];
						if (Main.menuMode == 15 && num26 == 0)
						{
							num90 *= 0.35f;
						}
						else
						{
							if (Main.netMode == 2)
							{
								num90 *= 0.5f;
							}
						}
						num90 *= array6[num26];
						if (!array7[num26])
						{
							this.spriteBatch.DrawString(Main.fontDeathText, array8[num26], new Vector2((float)(num2 + num88 + array4[num26]), (float)(num + num3 * num26 + num89) + origin2.Y * array6[num26] + (float)array3[num26]), color10, 0f, origin2, num90, SpriteEffects.None, 0f);
						}
						else
						{
							this.spriteBatch.DrawString(Main.fontDeathText, array8[num26], new Vector2((float)(num2 + num88 + array4[num26]), (float)(num + num3 * num26 + num89) + origin2.Y * array6[num26] + (float)array3[num26]), color10, 0f, new Vector2(0f, origin2.Y), num90, SpriteEffects.None, 0f);
						}
					}
					if (!array7[num26])
					{
						if ((float)Main.mouseX > (float)num2 - (float)(array8[num26].Length * 10) * array6[num26] + (float)array4[num26] && (float)Main.mouseX < (float)num2 + (float)(array8[num26].Length * 10) * array6[num26] + (float)array4[num26] && Main.mouseY > num + num3 * num26 + array3[num26] && (float)Main.mouseY < (float)(num + num3 * num26 + array3[num26]) + 50f * array6[num26] && Main.hasFocus)
						{
							this.focusMenu = num26;
							if (array[num26] || array2[num26])
							{
								this.focusMenu = -1;
							}
							else
							{
								if (num25 != this.focusMenu)
								{
									Main.PlaySound(12, -1, -1, 1);
								}
								if (Main.mouseLeftRelease && Main.mouseLeft)
								{
									this.selectedMenu = num26;
								}
								if (Main.mouseRightRelease && Main.mouseRight)
								{
									this.selectedMenu2 = num26;
								}
							}
						}
					}
					else
					{
						if (Main.mouseX > num2 + array4[num26] && (float)Main.mouseX < (float)num2 + (float)(array8[num26].Length * 20) * array6[num26] + (float)array4[num26] && Main.mouseY > num + num3 * num26 + array3[num26] && (float)Main.mouseY < (float)(num + num3 * num26 + array3[num26]) + 50f * array6[num26] && Main.hasFocus)
						{
							this.focusMenu = num26;
							if (array[num26] || array2[num26])
							{
								this.focusMenu = -1;
							}
							else
							{
								if (num25 != this.focusMenu)
								{
									Main.PlaySound(12, -1, -1, 1);
								}
								if (Main.mouseLeftRelease && Main.mouseLeft)
								{
									this.selectedMenu = num26;
								}
								if (Main.mouseRightRelease && Main.mouseRight)
								{
									this.selectedMenu2 = num26;
								}
							}
						}
					}
				}
			}
			for (int num91 = 0; num91 < Main.maxMenuItems; num91++)
			{
				if (num91 == this.focusMenu)
				{
					if (this.menuItemScale[num91] < 1f)
					{
						this.menuItemScale[num91] += 0.02f;
					}
					if (this.menuItemScale[num91] > 1f)
					{
						this.menuItemScale[num91] = 1f;
					}
				}
				else
				{
					if ((double)this.menuItemScale[num91] > 0.8)
					{
						this.menuItemScale[num91] -= 0.02f;
					}
				}
			}
			if (num6 >= 0)
			{
				Main.loadPlayer[num6].PlayerFrame();
				Main.loadPlayer[num6].position.X = (float)num7 + Main.screenPosition.X;
				Main.loadPlayer[num6].position.Y = (float)num8 + Main.screenPosition.Y;
				this.DrawPlayer(Main.loadPlayer[num6]);
			}
			for (int num92 = 0; num92 < 5; num92++)
			{
				Color color11 = Color.Black;
				if (num92 == 4)
				{
					color11 = color;
					color11.R = (byte)((255 + color11.R) / 2);
					color11.G = (byte)((255 + color11.R) / 2);
					color11.B = (byte)((255 + color11.R) / 2);
				}
				color11.A = (byte)((float)color11.A * 0.3f);
				int num93 = 0;
				int num94 = 0;
				if (num92 == 0)
				{
					num93 = -2;
				}
				if (num92 == 1)
				{
					num93 = 2;
				}
				if (num92 == 2)
				{
					num94 = -2;
				}
				if (num92 == 3)
				{
					num94 = 2;
				}
				string text5 = "Copyright © 2011 Re-Logic";
				Vector2 origin3 = Main.fontMouseText.MeasureString(text5);
				origin3.X *= 0.5f;
				origin3.Y *= 0.5f;
				this.spriteBatch.DrawString(Main.fontMouseText, text5, new Vector2((float)Main.screenWidth - origin3.X + (float)num93 - 10f, (float)Main.screenHeight - origin3.Y + (float)num94 - 2f), color11, 0f, origin3, 1f, SpriteEffects.None, 0f);
			}
			for (int num95 = 0; num95 < 5; num95++)
			{
				Color color12 = Color.Black;
				if (num95 == 4)
				{
					color12 = color;
					color12.R = (byte)((255 + color12.R) / 2);
					color12.G = (byte)((255 + color12.R) / 2);
					color12.B = (byte)((255 + color12.R) / 2);
				}
				color12.A = (byte)((float)color12.A * 0.3f);
				int num96 = 0;
				int num97 = 0;
				if (num95 == 0)
				{
					num96 = -2;
				}
				if (num95 == 1)
				{
					num96 = 2;
				}
				if (num95 == 2)
				{
					num97 = -2;
				}
				if (num95 == 3)
				{
					num97 = 2;
				}
				Vector2 origin4 = Main.fontMouseText.MeasureString(Main.versionNumber);
				origin4.X *= 0.5f;
				origin4.Y *= 0.5f;
				this.spriteBatch.DrawString(Main.fontMouseText, Main.versionNumber, new Vector2(origin4.X + (float)num96 + 10f, (float)Main.screenHeight - origin4.Y + (float)num97 - 2f), color12, 0f, origin4, 1f, SpriteEffects.None, 0f);
			}
			SpriteBatch arg_4DBA_0 = this.spriteBatch;
			Texture2D arg_4DBA_1 = Main.cursorTexture;
			Vector2 arg_4DBA_2 = new Vector2((float)(Main.mouseX + 1), (float)(Main.mouseY + 1));
			Rectangle? arg_4DBA_3 = new Rectangle?(new Rectangle(0, 0, Main.cursorTexture.Width, Main.cursorTexture.Height));
			Color arg_4DBA_4 = new Color((int)((float)Main.cursorColor.R * 0.2f), (int)((float)Main.cursorColor.G * 0.2f), (int)((float)Main.cursorColor.B * 0.2f), (int)((float)Main.cursorColor.A * 0.5f));
			float arg_4DBA_5 = 0f;
			origin = default(Vector2);
			arg_4DBA_0.Draw(arg_4DBA_1, arg_4DBA_2, arg_4DBA_3, arg_4DBA_4, arg_4DBA_5, origin, Main.cursorScale * 1.1f, SpriteEffects.None, 0f);
			SpriteBatch arg_4E1A_0 = this.spriteBatch;
			Texture2D arg_4E1A_1 = Main.cursorTexture;
			Vector2 arg_4E1A_2 = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			Rectangle? arg_4E1A_3 = new Rectangle?(new Rectangle(0, 0, Main.cursorTexture.Width, Main.cursorTexture.Height));
			Color arg_4E1A_4 = Main.cursorColor;
			float arg_4E1A_5 = 0f;
			origin = default(Vector2);
			arg_4E1A_0.Draw(arg_4E1A_1, arg_4E1A_2, arg_4E1A_3, arg_4E1A_4, arg_4E1A_5, origin, Main.cursorScale, SpriteEffects.None, 0f);
			if (Main.fadeCounter > 0)
			{
				Color white = Color.White;
				Main.fadeCounter--;
				float num98 = (float)Main.fadeCounter / 75f * 255f;
				byte b2 = (byte)num98;
				white = new Color((int)b2, (int)b2, (int)b2, (int)b2);
				this.spriteBatch.Draw(Main.fadeTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), white);
			}
			this.spriteBatch.End();
			if (Main.mouseLeft)
			{
				Main.mouseLeftRelease = false;
			}
			else
			{
				Main.mouseLeftRelease = true;
			}
			if (Main.mouseRight)
			{
				Main.mouseRightRelease = false;
				return;
			}
			Main.mouseRightRelease = true;
		}
		public static void CursorColor()
		{
			Main.cursorAlpha += (float)Main.cursorColorDirection * 0.015f;
			if (Main.cursorAlpha >= 1f)
			{
				Main.cursorAlpha = 1f;
				Main.cursorColorDirection = -1;
			}
			if ((double)Main.cursorAlpha <= 0.6)
			{
				Main.cursorAlpha = 0.6f;
				Main.cursorColorDirection = 1;
			}
			float num = Main.cursorAlpha * 0.3f + 0.7f;
			byte r = (byte)((float)Main.mouseColor.R * Main.cursorAlpha);
			byte g = (byte)((float)Main.mouseColor.G * Main.cursorAlpha);
			byte b = (byte)((float)Main.mouseColor.B * Main.cursorAlpha);
			byte a = (byte)(255f * num);
			Main.cursorColor = new Color((int)r, (int)g, (int)b, (int)a);
			Main.cursorScale = Main.cursorAlpha * 0.3f + 0.7f + 0.1f;
		}
		protected void DrawSplash(GameTime gameTime)
		{
			base.GraphicsDevice.Clear(Color.Black);
			base.Draw(gameTime);
			this.spriteBatch.Begin();
			this.splashCounter++;
			Color white = Color.White;
			byte b = 0;
			if (this.splashCounter <= 75)
			{
				float num = (float)this.splashCounter / 75f * 255f;
				b = (byte)num;
			}
			else
			{
				if (this.splashCounter <= 125)
				{
					b = 255;
				}
				else
				{
					if (this.splashCounter <= 200)
					{
						int num2 = 125 - this.splashCounter;
						float num3 = (float)num2 / 75f * 255f;
						b = (byte)num3;
					}
					else
					{
						Main.showSplash = false;
						Main.fadeCounter = 75;
					}
				}
			}
			white = new Color((int)b, (int)b, (int)b, (int)b);
			this.spriteBatch.Draw(Main.loTexture[Main.lo], new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), white);
			this.spriteBatch.End();
		}
		protected void DrawBackground()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num = (int)(255f * (1f - Main.gfxQuality) + 140f * Main.gfxQuality);
			int num2 = (int)(200f * (1f - Main.gfxQuality) + 40f * Main.gfxQuality);
			int num3 = 96;
			Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				value = default(Vector2);
			}
			float num4 = 0.9f;
			float num5 = num4;
			float num6 = num4;
			float num7 = num4;
			float num8 = 0f;
			if (Main.holyTiles > Main.evilTiles)
			{
				num8 = (float)Main.holyTiles / 800f;
			}
			else
			{
				if (Main.evilTiles > Main.holyTiles)
				{
					num8 = (float)Main.evilTiles / 800f;
				}
			}
			if (num8 > 1f)
			{
				num8 = 1f;
			}
			if (num8 < 0f)
			{
				num8 = 0f;
			}
			float num9 = (float)((double)Main.screenPosition.Y - Main.worldSurface * 16.0) / 300f;
			if (num9 < 0f)
			{
				num9 = 0f;
			}
			else
			{
				if (num9 > 1f)
				{
					num9 = 1f;
				}
			}
			float num10 = 1f * (1f - num9) + num5 * num9;
			Lighting.brightness = Lighting.defBrightness * (1f - num9) + 1f * num9;
			float num11 = (float)((double)(Main.screenPosition.Y - (float)(Main.screenHeight / 2) + 200f) - Main.rockLayer * 16.0) / 300f;
			if (num11 < 0f)
			{
				num11 = 0f;
			}
			else
			{
				if (num11 > 1f)
				{
					num11 = 1f;
				}
			}
			if (Main.evilTiles > 0)
			{
				num5 = 0.8f * num8 + num5 * (1f - num8);
				num6 = 0.75f * num8 + num6 * (1f - num8);
				num7 = 1.1f * num8 + num7 * (1f - num8);
			}
			else
			{
				if (Main.holyTiles > 0)
				{
					num5 = 1f * num8 + num5 * (1f - num8);
					num6 = 0.7f * num8 + num6 * (1f - num8);
					num7 = 0.9f * num8 + num7 * (1f - num8);
				}
			}
			num5 = 1f * (num10 - num11) + num5 * num11;
			num6 = 1f * (num10 - num11) + num6 * num11;
			num7 = 1f * (num10 - num11) + num7 * num11;
			Lighting.defBrightness = 1.2f * (1f - num11) + 1f * num11;
			this.bgParrallax = (double)Main.caveParrallax;
			this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num3) - (double)(num3 / 2));
			this.bgLoops = Main.screenWidth / num3 + 2;
			this.bgTop = (int)((float)((int)Main.worldSurface * 16 - Main.backgroundHeight[1]) - Main.screenPosition.Y + 16f);
			for (int i = 0; i < this.bgLoops; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					float num12 = (float)this.bgStart + Main.screenPosition.X;
					num12 = -(float)Math.IEEERemainder((double)num12, 16.0);
					num12 = (float)Math.Round((double)num12);
					int num13 = (int)num12;
					if (num13 == -8)
					{
						num13 = 8;
					}
					float num14 = (float)(this.bgStart + num3 * i + j * 16 + 8);
					float num15 = (float)this.bgTop;
					Color color = Lighting.GetColor((int)((num14 + Main.screenPosition.X) / 16f), (int)((Main.screenPosition.Y + num15) / 16f));
					color.R = (byte)((float)color.R * num5);
					color.G = (byte)((float)color.G * num6);
					color.B = (byte)((float)color.B * num7);
					this.spriteBatch.Draw(Main.backgroundTexture[1], new Vector2((float)(this.bgStart + num3 * i + 16 * j + num13), (float)this.bgTop) + value, new Rectangle?(new Rectangle(16 * j + num13 + 16, 0, 16, 16)), color);
				}
			}
			double num16 = (double)(Main.maxTilesY - 230);
			double num17 = (double)((int)((num16 - Main.worldSurface) / 6.0) * 6);
			num16 = Main.worldSurface + num17 - 5.0;
			bool flag = false;
			bool flag2 = false;
			this.bgTop = (int)((float)((int)Main.worldSurface * 16) - Main.screenPosition.Y + 16f);
			if (Main.worldSurface * 16.0 <= (double)(Main.screenPosition.Y + (float)Main.screenHeight + (float)Main.offScreenRange))
			{
				this.bgParrallax = (double)Main.caveParrallax;
				this.bgStart = (int)(-Math.IEEERemainder(96.0 + (double)Main.screenPosition.X * this.bgParrallax, (double)num3) - (double)(num3 / 2)) - (int)value.X;
				this.bgLoops = (Main.screenWidth + (int)value.X * 2) / num3 + 2;
				if (Main.worldSurface * 16.0 < (double)(Main.screenPosition.Y - 16f))
				{
					this.bgStartY = (int)(Math.IEEERemainder((double)this.bgTop, (double)Main.backgroundHeight[2]) - (double)Main.backgroundHeight[2]);
					this.bgLoopsY = (Main.screenHeight - this.bgStartY + (int)value.Y * 2) / Main.backgroundHeight[2] + 1;
				}
				else
				{
					this.bgStartY = this.bgTop;
					this.bgLoopsY = (Main.screenHeight - this.bgTop + (int)value.Y * 2) / Main.backgroundHeight[2] + 1;
				}
				if (Main.rockLayer * 16.0 < (double)(Main.screenPosition.Y + 600f))
				{
					this.bgLoopsY = (int)(Main.rockLayer * 16.0 - (double)Main.screenPosition.Y + 600.0 - (double)this.bgStartY) / Main.backgroundHeight[2];
					flag2 = true;
				}
				float num18 = (float)this.bgStart + Main.screenPosition.X;
				num18 = -(float)Math.IEEERemainder((double)num18, 16.0);
				num18 = (float)Math.Round((double)num18);
				int num19 = (int)num18;
				if (num19 == -8)
				{
					num19 = 8;
				}
				for (int k = 0; k < this.bgLoops; k++)
				{
					for (int l = 0; l < this.bgLoopsY; l++)
					{
						for (int m = 0; m < 6; m++)
						{
							for (int n = 0; n < 6; n++)
							{
								float num20 = (float)(this.bgStartY + l * 96 + n * 16 + 8);
								float num21 = (float)(this.bgStart + num3 * k + m * 16 + 8);
								int num22 = (int)((num21 + Main.screenPosition.X) / 16f);
								int num23 = (int)((num20 + Main.screenPosition.Y) / 16f);
								Color color2 = Lighting.GetColor(num22, num23);
								if (Main.tile[num22, num23] == null)
								{

								}
								if (color2.R > 0 || color2.G > 0 || color2.B > 0)
								{
									if (((int)color2.R > num || (double)color2.G > (double)num * 1.1 || (double)color2.B > (double)num * 1.2) && !Main.tile[num22, num23].active)
									{
										if (Main.tile[num22, num23].wall != 0)
										{
											if (Main.tile[num22, num23].wall != 21)
											{
												goto IL_B68;
											}
										}
										try
										{
											for (int num24 = 0; num24 < 9; num24++)
											{
												int num25 = 0;
												int num26 = 0;
												int width = 4;
												int height = 4;
												Color color3 = color2;
												Color color4 = color2;
												if (num24 == 0 && !Main.tile[num22 - 1, num23 - 1].active)
												{
													color4 = Lighting.GetColor(num22 - 1, num23 - 1);
												}
												if (num24 == 1)
												{
													width = 8;
													num25 = 4;
													if (!Main.tile[num22, num23 - 1].active)
													{
														color4 = Lighting.GetColor(num22, num23 - 1);
													}
												}
												if (num24 == 2)
												{
													if (!Main.tile[num22 + 1, num23 - 1].active)
													{
														color4 = Lighting.GetColor(num22 + 1, num23 - 1);
													}
													if (Main.tile[num22 + 1, num23 - 1] == null)
													{

													}
													num25 = 12;
												}
												if (num24 == 3)
												{
													if (!Main.tile[num22 - 1, num23].active)
													{
														color4 = Lighting.GetColor(num22 - 1, num23);
													}
													height = 8;
													num26 = 4;
												}
												if (num24 == 4)
												{
													width = 8;
													height = 8;
													num25 = 4;
													num26 = 4;
												}
												if (num24 == 5)
												{
													num25 = 12;
													num26 = 4;
													height = 8;
													if (!Main.tile[num22 + 1, num23].active)
													{
														color4 = Lighting.GetColor(num22 + 1, num23);
													}
												}
												if (num24 == 6)
												{
													if (!Main.tile[num22 - 1, num23 + 1].active)
													{
														color4 = Lighting.GetColor(num22 - 1, num23 + 1);
													}
													num26 = 12;
												}
												if (num24 == 7)
												{
													width = 8;
													height = 4;
													num25 = 4;
													num26 = 12;
													if (!Main.tile[num22, num23 + 1].active)
													{
														color4 = Lighting.GetColor(num22, num23 + 1);
													}
												}
												if (num24 == 8)
												{
													if (!Main.tile[num22 + 1, num23 + 1].active)
													{
														color4 = Lighting.GetColor(num22 + 1, num23 + 1);
													}
													num25 = 12;
													num26 = 12;
												}
												color3.R = (byte)((color2.R + color4.R) / 2);
												color3.G = (byte)((color2.G + color4.G) / 2);
												color3.B = (byte)((color2.B + color4.B) / 2);
												color3.R = (byte)((float)color3.R * num5);
												color3.G = (byte)((float)color3.G * num6);
												color3.B = (byte)((float)color3.B * num7);
												this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float)(this.bgStart + num3 * k + 16 * m + num25 + num19), (float)(this.bgStartY + Main.backgroundHeight[2] * l + 16 * n + num26)) + value, new Rectangle?(new Rectangle(16 * m + num25 + num19 + 16, 16 * n + num26, width, height)), color3);
											}
											goto IL_EEB;
										}
										catch
										{
											color2.R = (byte)((float)color2.R * num5);
											color2.G = (byte)((float)color2.G * num6);
											color2.B = (byte)((float)color2.B * num7);
											this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float)(this.bgStart + num3 * k + 16 * m + num19), (float)(this.bgStartY + Main.backgroundHeight[2] * l + 16 * n)) + value, new Rectangle?(new Rectangle(16 * m + num19 + 16, 16 * n, 16, 16)), color2);
											goto IL_EEB;
										}
									}
									IL_B68:
									if ((int)color2.R > num2 || (double)color2.G > (double)num2 * 1.1 || (double)color2.B > (double)num2 * 1.2)
									{
										for (int num27 = 0; num27 < 4; num27++)
										{
											int num28 = 0;
											int num29 = 0;
											Color color5 = color2;
											Color color6 = color2;
											if (num27 == 0)
											{
												if (Lighting.Brighter(num22, num23 - 1, num22 - 1, num23))
												{
													color6 = Lighting.GetColor(num22 - 1, num23);
												}
												else
												{
													color6 = Lighting.GetColor(num22, num23 - 1);
												}
											}
											if (num27 == 1)
											{
												if (Lighting.Brighter(num22, num23 - 1, num22 + 1, num23))
												{
													color6 = Lighting.GetColor(num22 + 1, num23);
												}
												else
												{
													color6 = Lighting.GetColor(num22, num23 - 1);
												}
												num28 = 8;
											}
											if (num27 == 2)
											{
												if (Lighting.Brighter(num22, num23 + 1, num22 - 1, num23))
												{
													color6 = Lighting.GetColor(num22 - 1, num23);
												}
												else
												{
													color6 = Lighting.GetColor(num22, num23 + 1);
												}
												num29 = 8;
											}
											if (num27 == 3)
											{
												if (Lighting.Brighter(num22, num23 + 1, num22 + 1, num23))
												{
													color6 = Lighting.GetColor(num22 + 1, num23);
												}
												else
												{
													color6 = Lighting.GetColor(num22, num23 + 1);
												}
												num28 = 8;
												num29 = 8;
											}
											color5.R = (byte)((color2.R + color6.R) / 2);
											color5.G = (byte)((color2.G + color6.G) / 2);
											color5.B = (byte)((color2.B + color6.B) / 2);
											color5.R = (byte)((float)color5.R * num5);
											color5.G = (byte)((float)color5.G * num6);
											color5.B = (byte)((float)color5.B * num7);
											this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float)(this.bgStart + num3 * k + 16 * m + num28 + num19), (float)(this.bgStartY + Main.backgroundHeight[2] * l + 16 * n + num29)) + value, new Rectangle?(new Rectangle(16 * m + num28 + num19 + 16, 16 * n + num29, 8, 8)), color5);
										}
									}
									else
									{
										color2.R = (byte)((float)color2.R * num5);
										color2.G = (byte)((float)color2.G * num6);
										color2.B = (byte)((float)color2.B * num7);
										this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float)(this.bgStart + num3 * k + 16 * m + num19), (float)(this.bgStartY + Main.backgroundHeight[2] * l + 16 * n)) + value, new Rectangle?(new Rectangle(16 * m + num19 + 16, 16 * n, 16, 16)), color2);
									}
								}
								else
								{
									color2.R = (byte)((float)color2.R * num5);
									color2.G = (byte)((float)color2.G * num6);
									color2.B = (byte)((float)color2.B * num7);
									this.spriteBatch.Draw(Main.backgroundTexture[2], new Vector2((float)(this.bgStart + num3 * k + 16 * m + num19), (float)(this.bgStartY + Main.backgroundHeight[2] * l + 16 * n)) + value, new Rectangle?(new Rectangle(16 * m + num19 + 16, 16 * n, 16, 16)), color2);
								}
								IL_EEB:;
							}
						}
					}
				}
				if (flag2)
				{
					this.bgParrallax = (double)Main.caveParrallax;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num3) - (double)(num3 / 2));
					this.bgLoops = (Main.screenWidth + (int)value.X * 2) / num3 + 2;
					this.bgTop = this.bgStartY + this.bgLoopsY * Main.backgroundHeight[2];
					if (this.bgTop > -32)
					{
						for (int num30 = 0; num30 < this.bgLoops; num30++)
						{
							for (int num31 = 0; num31 < 6; num31++)
							{
								float num32 = (float)(this.bgStart + num3 * num30 + num31 * 16 + 8);
								float num33 = (float)this.bgTop;
								Color color7 = Lighting.GetColor((int)((num32 + Main.screenPosition.X) / 16f), (int)((Main.screenPosition.Y + num33) / 16f));
								color7.R = (byte)((float)color7.R * num5);
								color7.G = (byte)((float)color7.G * num6);
								color7.B = (byte)((float)color7.B * num7);
								this.spriteBatch.Draw(Main.backgroundTexture[4], new Vector2((float)(this.bgStart + num3 * num30 + 16 * num31 + num19), (float)this.bgTop) + value, new Rectangle?(new Rectangle(16 * num31 + num19 + 16, 0, 16, 16)), color7);
							}
						}
					}
				}
			}
			this.bgTop = (int)((float)((int)Main.rockLayer * 16) - Main.screenPosition.Y + 16f + 600f - 8f);
			if (Main.rockLayer * 16.0 <= (double)(Main.screenPosition.Y + 600f))
			{
				this.bgParrallax = (double)Main.caveParrallax;
				this.bgStart = (int)(-Math.IEEERemainder(96.0 + (double)Main.screenPosition.X * this.bgParrallax, (double)num3) - (double)(num3 / 2)) - (int)value.X;
				this.bgLoops = (Main.screenWidth + (int)value.X * 2) / num3 + 2;
				if (Main.rockLayer * 16.0 + (double)Main.screenHeight < (double)(Main.screenPosition.Y - 16f))
				{
					this.bgStartY = (int)(Math.IEEERemainder((double)this.bgTop, (double)Main.backgroundHeight[3]) - (double)Main.backgroundHeight[3]);
					this.bgLoopsY = (Main.screenHeight - this.bgStartY + (int)value.Y * 2) / Main.backgroundHeight[2] + 1;
				}
				else
				{
					this.bgStartY = this.bgTop;
					this.bgLoopsY = (Main.screenHeight - this.bgTop + (int)value.Y * 2) / Main.backgroundHeight[2] + 1;
				}
				if (num16 * 16.0 < (double)(Main.screenPosition.Y + 600f))
				{
					this.bgLoopsY = (int)(num16 * 16.0 - (double)Main.screenPosition.Y + 600.0 - (double)this.bgStartY) / Main.backgroundHeight[2];
					flag = true;
				}
				float num34 = (float)this.bgStart + Main.screenPosition.X;
				num34 = -(float)Math.IEEERemainder((double)num34, 16.0);
				num34 = (float)Math.Round((double)num34);
				int num35 = (int)num34;
				if (num35 == -8)
				{
					num35 = 8;
				}
				for (int num36 = 0; num36 < this.bgLoops; num36++)
				{
					for (int num37 = 0; num37 < this.bgLoopsY; num37++)
					{
						for (int num38 = 0; num38 < 6; num38++)
						{
							for (int num39 = 0; num39 < 6; num39++)
							{
								float num40 = (float)(this.bgStartY + num37 * 96 + num39 * 16 + 8);
								float num41 = (float)(this.bgStart + num3 * num36 + num38 * 16 + 8);
								int num42 = (int)((num41 + Main.screenPosition.X) / 16f);
								int num43 = (int)((num40 + Main.screenPosition.Y) / 16f);
								Color color8 = Lighting.GetColor(num42, num43);
								if (Main.tile[num42, num43] == null)
								{

								}
								bool flag3 = false;
								if (Main.caveParrallax != 0f)
								{
									if (Main.tile[num42 - 1, num43] == null)
									{

									}
									if (Main.tile[num42 + 1, num43] == null)
									{

									}
									if (Main.tile[num42, num43].wall == 0 || Main.tile[num42, num43].wall == 21 || Main.tile[num42 - 1, num43].wall == 0 || Main.tile[num42 - 1, num43].wall == 21 || Main.tile[num42 + 1, num43].wall == 0 || Main.tile[num42 + 1, num43].wall == 21)
									{
										flag3 = true;
									}
								}
								else
								{
									if (Main.tile[num42, num43].wall == 0 || Main.tile[num42, num43].wall == 21)
									{
										flag3 = true;
									}
								}
								if ((flag3 || color8.R == 0 || color8.G == 0 || color8.B == 0) && (color8.R > 0 || color8.G > 0 || color8.B > 0) && (Main.tile[num42, num43].wall == 0 || Main.tile[num42, num43].wall == 21 || Main.caveParrallax != 0f))
								{
									if (Lighting.lightMode < 2 && color8.R < 230 && color8.G < 230 && color8.B < 230)
									{
										if (((int)color8.R > num || (double)color8.G > (double)num * 1.1 || (double)color8.B > (double)num * 1.2) && !Main.tile[num42, num43].active)
										{
											for (int num44 = 0; num44 < 9; num44++)
											{
												int num45 = 0;
												int num46 = 0;
												int width2 = 4;
												int height2 = 4;
												Color color9 = color8;
												Color color10 = color8;
												if (num44 == 0 && !Main.tile[num42 - 1, num43 - 1].active)
												{
													color10 = Lighting.GetColor(num42 - 1, num43 - 1);
												}
												if (num44 == 1)
												{
													width2 = 8;
													num45 = 4;
													if (!Main.tile[num42, num43 - 1].active)
													{
														color10 = Lighting.GetColor(num42, num43 - 1);
													}
												}
												if (num44 == 2)
												{
													if (!Main.tile[num42 + 1, num43 - 1].active)
													{
														color10 = Lighting.GetColor(num42 + 1, num43 - 1);
													}
													num45 = 12;
												}
												if (num44 == 3)
												{
													if (!Main.tile[num42 - 1, num43].active)
													{
														color10 = Lighting.GetColor(num42 - 1, num43);
													}
													height2 = 8;
													num46 = 4;
												}
												if (num44 == 4)
												{
													width2 = 8;
													height2 = 8;
													num45 = 4;
													num46 = 4;
												}
												if (num44 == 5)
												{
													num45 = 12;
													num46 = 4;
													height2 = 8;
													if (!Main.tile[num42 + 1, num43].active)
													{
														color10 = Lighting.GetColor(num42 + 1, num43);
													}
												}
												if (num44 == 6)
												{
													if (!Main.tile[num42 - 1, num43 + 1].active)
													{
														color10 = Lighting.GetColor(num42 - 1, num43 + 1);
													}
													num46 = 12;
												}
												if (num44 == 7)
												{
													width2 = 8;
													height2 = 4;
													num45 = 4;
													num46 = 12;
													if (!Main.tile[num42, num43 + 1].active)
													{
														color10 = Lighting.GetColor(num42, num43 + 1);
													}
												}
												if (num44 == 8)
												{
													if (!Main.tile[num42 + 1, num43 + 1].active)
													{
														color10 = Lighting.GetColor(num42 + 1, num43 + 1);
													}
													num45 = 12;
													num46 = 12;
												}
												color9.R = (byte)((color8.R + color10.R) / 2);
												color9.G = (byte)((color8.G + color10.G) / 2);
												color9.B = (byte)((color8.B + color10.B) / 2);
												color9.R = (byte)((float)color9.R * num5);
												color9.G = (byte)((float)color9.G * num6);
												color9.B = (byte)((float)color9.B * num7);
												this.spriteBatch.Draw(Main.backgroundTexture[3], new Vector2((float)(this.bgStart + num3 * num36 + 16 * num38 + num45 + num35), (float)(this.bgStartY + Main.backgroundHeight[2] * num37 + 16 * num39 + num46)) + value, new Rectangle?(new Rectangle(16 * num38 + num45 + num35 + 16, 16 * num39 + num46, width2, height2)), color9);
											}
										}
										else
										{
											if ((int)color8.R > num2 || (double)color8.G > (double)num2 * 1.1 || (double)color8.B > (double)num2 * 1.2)
											{
												for (int num47 = 0; num47 < 4; num47++)
												{
													int num48 = 0;
													int num49 = 0;
													Color color11 = color8;
													Color color12 = color8;
													if (num47 == 0)
													{
														if (Lighting.Brighter(num42, num43 - 1, num42 - 1, num43))
														{
															color12 = Lighting.GetColor(num42 - 1, num43);
														}
														else
														{
															color12 = Lighting.GetColor(num42, num43 - 1);
														}
													}
													if (num47 == 1)
													{
														if (Lighting.Brighter(num42, num43 - 1, num42 + 1, num43))
														{
															color12 = Lighting.GetColor(num42 + 1, num43);
														}
														else
														{
															color12 = Lighting.GetColor(num42, num43 - 1);
														}
														num48 = 8;
													}
													if (num47 == 2)
													{
														if (Lighting.Brighter(num42, num43 + 1, num42 - 1, num43))
														{
															color12 = Lighting.GetColor(num42 - 1, num43);
														}
														else
														{
															color12 = Lighting.GetColor(num42, num43 + 1);
														}
														num49 = 8;
													}
													if (num47 == 3)
													{
														if (Lighting.Brighter(num42, num43 + 1, num42 + 1, num43))
														{
															color12 = Lighting.GetColor(num42 + 1, num43);
														}
														else
														{
															color12 = Lighting.GetColor(num42, num43 + 1);
														}
														num48 = 8;
														num49 = 8;
													}
													color11.R = (byte)((color8.R + color12.R) / 2);
													color11.G = (byte)((color8.G + color12.G) / 2);
													color11.B = (byte)((color8.B + color12.B) / 2);
													color11.R = (byte)((float)color11.R * num5);
													color11.G = (byte)((float)color11.G * num6);
													color11.B = (byte)((float)color11.B * num7);
													this.spriteBatch.Draw(Main.backgroundTexture[3], new Vector2((float)(this.bgStart + num3 * num36 + 16 * num38 + num48 + num35), (float)(this.bgStartY + Main.backgroundHeight[2] * num37 + 16 * num39 + num49)) + value, new Rectangle?(new Rectangle(16 * num38 + num48 + num35 + 16, 16 * num39 + num49, 8, 8)), color11);
												}
											}
											else
											{
												color8.R = (byte)((float)color8.R * num5);
												color8.G = (byte)((float)color8.G * num6);
												color8.B = (byte)((float)color8.B * num7);
												this.spriteBatch.Draw(Main.backgroundTexture[3], new Vector2((float)(this.bgStart + num3 * num36 + 16 * num38 + num35), (float)(this.bgStartY + Main.backgroundHeight[2] * num37 + 16 * num39)) + value, new Rectangle?(new Rectangle(16 * num38 + num35 + 16, 16 * num39, 16, 16)), color8);
											}
										}
									}
									else
									{
										color8.R = (byte)((float)color8.R * num5);
										color8.G = (byte)((float)color8.G * num6);
										color8.B = (byte)((float)color8.B * num7);
										this.spriteBatch.Draw(Main.backgroundTexture[3], new Vector2((float)(this.bgStart + num3 * num36 + 16 * num38 + num35), (float)(this.bgStartY + Main.backgroundHeight[2] * num37 + 16 * num39)) + value, new Rectangle?(new Rectangle(16 * num38 + num35 + 16, 16 * num39, 16, 16)), color8);
									}
								}
							}
						}
					}
				}
				if (flag)
				{
					this.bgParrallax = (double)Main.caveParrallax;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num3) - (double)(num3 / 2));
					this.bgLoops = Main.screenWidth / num3 + 2;
					this.bgTop = this.bgStartY + this.bgLoopsY * Main.backgroundHeight[2];
					for (int num50 = 0; num50 < this.bgLoops; num50++)
					{
						for (int num51 = 0; num51 < 6; num51++)
						{
							float num52 = (float)(this.bgStart + num3 * num50 + num51 * 16 + 8);
							float num53 = (float)this.bgTop;
							Color color13 = Lighting.GetColor((int)((num52 + Main.screenPosition.X) / 16f), (int)((Main.screenPosition.Y + num53) / 16f));
							color13.R = (byte)((float)color13.R * num5);
							color13.G = (byte)((float)color13.G * num6);
							color13.B = (byte)((float)color13.B * num7);
							this.spriteBatch.Draw(Main.backgroundTexture[6], new Vector2((float)(this.bgStart + num3 * num50 + 16 * num51 + num35), (float)this.bgTop) + value, new Rectangle?(new Rectangle(16 * num51 + num35 + 16, Main.magmaBGFrame * 16, 16, 16)), color13);
						}
					}
				}
			}
			this.bgTop = (int)((float)((int)num16 * 16) - Main.screenPosition.Y + 16f + 600f) - 8;
			if (num16 * 16.0 <= (double)(Main.screenPosition.Y + 600f))
			{
				this.bgStart = (int)(-Math.IEEERemainder(96.0 + (double)Main.screenPosition.X * this.bgParrallax, (double)num3) - (double)(num3 / 2)) - (int)value.X;
				this.bgLoops = (Main.screenWidth + (int)value.X * 2) / num3 + 2;
				if (num16 * 16.0 + (double)Main.screenHeight < (double)(Main.screenPosition.Y - 16f))
				{
					this.bgStartY = (int)(Math.IEEERemainder((double)this.bgTop, (double)Main.backgroundHeight[2]) - (double)Main.backgroundHeight[2]);
					this.bgLoopsY = (Main.screenHeight - this.bgStartY + (int)value.Y * 2) / Main.backgroundHeight[2] + 1;
				}
				else
				{
					this.bgStartY = this.bgTop;
					this.bgLoopsY = (Main.screenHeight - this.bgTop + (int)value.Y * 2) / Main.backgroundHeight[2] + 1;
				}
				num = (int)((double)num * 1.5);
				num2 = (int)((double)num2 * 1.5);
				float num54 = (float)this.bgStart + Main.screenPosition.X;
				num54 = -(float)Math.IEEERemainder((double)num54, 16.0);
				num54 = (float)Math.Round((double)num54);
				int num55 = (int)num54;
				if (num55 == -8)
				{
					num55 = 8;
				}
				for (int num56 = 0; num56 < this.bgLoops; num56++)
				{
					for (int num57 = 0; num57 < this.bgLoopsY; num57++)
					{
						for (int num58 = 0; num58 < 6; num58++)
						{
							for (int num59 = 0; num59 < 6; num59++)
							{
								float num60 = (float)(this.bgStartY + num57 * 96 + num59 * 16 + 8);
								float num61 = (float)(this.bgStart + num3 * num56 + num58 * 16 + 8);
								int num62 = (int)((num61 + Main.screenPosition.X) / 16f);
								int num63 = (int)((num60 + Main.screenPosition.Y) / 16f);
								Color color14 = Lighting.GetColor(num62, num63);
								if (Main.tile[num62, num63] == null)
								{

								}
								bool flag4 = false;
								if (Main.caveParrallax != 0f)
								{
									if (Main.tile[num62 - 1, num63] == null)
									{

									}
									if (Main.tile[num62 + 1, num63] == null)
									{

									}
									if (Main.tile[num62, num63].wall == 0 || Main.tile[num62, num63].wall == 21 || Main.tile[num62 - 1, num63].wall == 0 || Main.tile[num62 - 1, num63].wall == 21 || Main.tile[num62 + 1, num63].wall == 0 || Main.tile[num62 + 1, num63].wall == 21)
									{
										flag4 = true;
									}
								}
								else
								{
									if (Main.tile[num62, num63].wall == 0 || Main.tile[num62, num63].wall == 21)
									{
										flag4 = true;
									}
								}
								if ((flag4 || color14.R == 0 || color14.G == 0 || color14.B == 0) && (color14.R > 0 || color14.G > 0 || color14.B > 0) && (Main.tile[num62, num63].wall == 0 || Main.tile[num62, num63].wall == 21 || Main.caveParrallax != 0f))
								{
									if (Lighting.lightMode < 2 && color14.R < 230 && color14.G < 230 && color14.B < 230)
									{
										if (((int)color14.R > num || (double)color14.G > (double)num * 1.1 || (double)color14.B > (double)num * 1.2) && !Main.tile[num62, num63].active)
										{
											for (int num64 = 0; num64 < 9; num64++)
											{
												int num65 = 0;
												int num66 = 0;
												int width3 = 4;
												int height3 = 4;
												Color color15 = color14;
												Color color16 = color14;
												if (num64 == 0 && !Main.tile[num62 - 1, num63 - 1].active)
												{
													color16 = Lighting.GetColor(num62 - 1, num63 - 1);
												}
												if (num64 == 1)
												{
													width3 = 8;
													num65 = 4;
													if (!Main.tile[num62, num63 - 1].active)
													{
														color16 = Lighting.GetColor(num62, num63 - 1);
													}
												}
												if (num64 == 2)
												{
													if (!Main.tile[num62 + 1, num63 - 1].active)
													{
														color16 = Lighting.GetColor(num62 + 1, num63 - 1);
													}
													num65 = 12;
												}
												if (num64 == 3)
												{
													if (!Main.tile[num62 - 1, num63].active)
													{
														color16 = Lighting.GetColor(num62 - 1, num63);
													}
													height3 = 8;
													num66 = 4;
												}
												if (num64 == 4)
												{
													width3 = 8;
													height3 = 8;
													num65 = 4;
													num66 = 4;
												}
												if (num64 == 5)
												{
													num65 = 12;
													num66 = 4;
													height3 = 8;
													if (!Main.tile[num62 + 1, num63].active)
													{
														color16 = Lighting.GetColor(num62 + 1, num63);
													}
												}
												if (num64 == 6)
												{
													if (!Main.tile[num62 - 1, num63 + 1].active)
													{
														color16 = Lighting.GetColor(num62 - 1, num63 + 1);
													}
													num66 = 12;
												}
												if (num64 == 7)
												{
													width3 = 8;
													height3 = 4;
													num65 = 4;
													num66 = 12;
													if (!Main.tile[num62, num63 + 1].active)
													{
														color16 = Lighting.GetColor(num62, num63 + 1);
													}
												}
												if (num64 == 8)
												{
													if (!Main.tile[num62 + 1, num63 + 1].active)
													{
														color16 = Lighting.GetColor(num62 + 1, num63 + 1);
													}
													num65 = 12;
													num66 = 12;
												}
												color15.R = (byte)((color14.R + color16.R) / 2);
												color15.G = (byte)((color14.G + color16.G) / 2);
												color15.B = (byte)((color14.B + color16.B) / 2);
												color15.R = (byte)((float)color15.R * num5);
												color15.G = (byte)((float)color15.G * num6);
												color15.B = (byte)((float)color15.B * num7);
												SpriteBatch arg_24CE_0 = this.spriteBatch;
												Texture2D arg_24CE_1 = Main.backgroundTexture[5];
												Vector2 arg_24CE_2 = new Vector2((float)(this.bgStart + num3 * num56 + 16 * num58 + num65 + num55), (float)(this.bgStartY + Main.backgroundHeight[2] * num57 + 16 * num59 + num66)) + value;
												Rectangle? arg_24CE_3 = new Rectangle?(new Rectangle(16 * num58 + num65 + num55 + 16, 16 * num59 + Main.backgroundHeight[2] * Main.magmaBGFrame + num66, width3, height3));
												Color arg_24CE_4 = color15;
												float arg_24CE_5 = 0f;
												Vector2 origin = default(Vector2);
												arg_24CE_0.Draw(arg_24CE_1, arg_24CE_2, arg_24CE_3, arg_24CE_4, arg_24CE_5, origin, 1f, SpriteEffects.None, 0f);
											}
										}
										else
										{
											if ((int)color14.R > num2 || (double)color14.G > (double)num2 * 1.1 || (double)color14.B > (double)num2 * 1.2)
											{
												for (int num67 = 0; num67 < 4; num67++)
												{
													int num68 = 0;
													int num69 = 0;
													Color color17 = color14;
													Color color18 = color14;
													if (num67 == 0)
													{
														if (Lighting.Brighter(num62, num63 - 1, num62 - 1, num63))
														{
															color18 = Lighting.GetColor(num62 - 1, num63);
														}
														else
														{
															color18 = Lighting.GetColor(num62, num63 - 1);
														}
													}
													if (num67 == 1)
													{
														if (Lighting.Brighter(num62, num63 - 1, num62 + 1, num63))
														{
															color18 = Lighting.GetColor(num62 + 1, num63);
														}
														else
														{
															color18 = Lighting.GetColor(num62, num63 - 1);
														}
														num68 = 8;
													}
													if (num67 == 2)
													{
														if (Lighting.Brighter(num62, num63 + 1, num62 - 1, num63))
														{
															color18 = Lighting.GetColor(num62 - 1, num63);
														}
														else
														{
															color18 = Lighting.GetColor(num62, num63 + 1);
														}
														num69 = 8;
													}
													if (num67 == 3)
													{
														if (Lighting.Brighter(num62, num63 + 1, num62 + 1, num63))
														{
															color18 = Lighting.GetColor(num62 + 1, num63);
														}
														else
														{
															color18 = Lighting.GetColor(num62, num63 + 1);
														}
														num68 = 8;
														num69 = 8;
													}
													color17.R = (byte)((color14.R + color18.R) / 2);
													color17.G = (byte)((color14.G + color18.G) / 2);
													color17.B = (byte)((color14.B + color18.B) / 2);
													color17.R = (byte)((float)color17.R * num5);
													color17.G = (byte)((float)color17.G * num6);
													color17.B = (byte)((float)color17.B * num7);
													SpriteBatch arg_272D_0 = this.spriteBatch;
													Texture2D arg_272D_1 = Main.backgroundTexture[5];
													Vector2 arg_272D_2 = new Vector2((float)(this.bgStart + num3 * num56 + 16 * num58 + num68 + num55), (float)(this.bgStartY + Main.backgroundHeight[2] * num57 + 16 * num59 + num69)) + value;
													Rectangle? arg_272D_3 = new Rectangle?(new Rectangle(16 * num58 + num68 + num55 + 16, 16 * num59 + Main.backgroundHeight[2] * Main.magmaBGFrame + num69, 8, 8));
													Color arg_272D_4 = color17;
													float arg_272D_5 = 0f;
													Vector2 origin = default(Vector2);
													arg_272D_0.Draw(arg_272D_1, arg_272D_2, arg_272D_3, arg_272D_4, arg_272D_5, origin, 1f, SpriteEffects.None, 0f);
												}
											}
											else
											{
												color14.R = (byte)((float)color14.R * num5);
												color14.G = (byte)((float)color14.G * num6);
												color14.B = (byte)((float)color14.B * num7);
												SpriteBatch arg_280C_0 = this.spriteBatch;
												Texture2D arg_280C_1 = Main.backgroundTexture[5];
												Vector2 arg_280C_2 = new Vector2((float)(this.bgStart + num3 * num56 + 16 * num58 + num55), (float)(this.bgStartY + Main.backgroundHeight[2] * num57 + 16 * num59)) + value;
												Rectangle? arg_280C_3 = new Rectangle?(new Rectangle(16 * num58 + num55 + 16, 16 * num59 + Main.backgroundHeight[2] * Main.magmaBGFrame, 16, 16));
												Color arg_280C_4 = color14;
												float arg_280C_5 = 0f;
												Vector2 origin = default(Vector2);
												arg_280C_0.Draw(arg_280C_1, arg_280C_2, arg_280C_3, arg_280C_4, arg_280C_5, origin, 1f, SpriteEffects.None, 0f);
											}
										}
									}
									else
									{
										color14.R = (byte)((float)color14.R * num5);
										color14.G = (byte)((float)color14.G * num6);
										color14.B = (byte)((float)color14.B * num7);
										SpriteBatch arg_28DD_0 = this.spriteBatch;
										Texture2D arg_28DD_1 = Main.backgroundTexture[5];
										Vector2 arg_28DD_2 = new Vector2((float)(this.bgStart + num3 * num56 + 16 * num58 + num55), (float)(this.bgStartY + Main.backgroundHeight[2] * num57 + 16 * num59)) + value;
										Rectangle? arg_28DD_3 = new Rectangle?(new Rectangle(16 * num58 + num55 + 16, 16 * num59 + Main.backgroundHeight[2] * Main.magmaBGFrame, 16, 16));
										Color arg_28DD_4 = color14;
										float arg_28DD_5 = 0f;
										Vector2 origin = default(Vector2);
										arg_28DD_0.Draw(arg_28DD_1, arg_28DD_2, arg_28DD_3, arg_28DD_4, arg_28DD_5, origin, 1f, SpriteEffects.None, 0f);
									}
								}
							}
						}
					}
				}
			}
			Lighting.brightness = Lighting.defBrightness;
			Main.renderTimer[3] = (float)stopwatch.ElapsedMilliseconds;
		}
		protected void RenderBackground()
		{
			if (Main.drawToScreen)
			{
				return;
			}
			base.GraphicsDevice.SetRenderTarget(this.backWaterTarget);
			base.GraphicsDevice.Clear(new Color(0, 0, 0, 0));
			this.spriteBatch.Begin();
			try
			{
				this.DrawWater(true);
			}
			catch
			{
			}
			this.spriteBatch.End();
			base.GraphicsDevice.SetRenderTarget(null);
			base.GraphicsDevice.SetRenderTarget(this.backgroundTarget);
			base.GraphicsDevice.Clear(new Color(0, 0, 0, 0));
			this.spriteBatch.Begin();
			this.DrawBackground();
			this.spriteBatch.End();
			base.GraphicsDevice.SetRenderTarget(null);
		}
		protected void RenderTiles()
		{
			if (Main.drawToScreen)
			{
				return;
			}
			this.RenderBlack();
			base.GraphicsDevice.SetRenderTarget(this.tileTarget);
			base.GraphicsDevice.Clear(new Color(0, 0, 0, 0));
			this.spriteBatch.Begin();
			this.DrawTiles(true);
			this.spriteBatch.End();
			base.GraphicsDevice.SetRenderTarget(null);
		}
		protected void RenderTiles2()
		{
			if (Main.drawToScreen)
			{
				return;
			}
			base.GraphicsDevice.SetRenderTarget(this.tile2Target);
			base.GraphicsDevice.Clear(new Color(0, 0, 0, 0));
			this.spriteBatch.Begin();
			this.DrawTiles(false);
			this.spriteBatch.End();
			base.GraphicsDevice.SetRenderTarget(null);
		}
		protected void RenderWater()
		{
			if (Main.drawToScreen)
			{
				return;
			}
			base.GraphicsDevice.SetRenderTarget(this.waterTarget);
			base.GraphicsDevice.Clear(new Color(0, 0, 0, 0));
			this.spriteBatch.Begin();
			try
			{
				this.DrawWater(false);
				if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].mech)
				{
					this.DrawWires();
				}
			}
			catch
			{
			}
			this.spriteBatch.End();
			base.GraphicsDevice.SetRenderTarget(null);
		}
		protected bool FullTile(int x, int y)
		{
			if (Main.tile[x, y].active && Main.tileSolid[(int)Main.tile[x, y].type] && !Main.tileSolidTop[(int)Main.tile[x, y].type] && Main.tile[x, y].type != 10 && Main.tile[x, y].type != 138)
			{
				int frameX = (int)Main.tile[x, y].frameX;
				int frameY = (int)Main.tile[x, y].frameY;
				if (frameY == 18)
				{
					if (frameX >= 18 && frameX <= 54)
					{
						return true;
					}
					if (frameX >= 108 && frameX <= 144)
					{
						return true;
					}
				}
				else
				{
					if (frameY >= 90 && frameY <= 196)
					{
						if (frameX <= 70)
						{
							return true;
						}
						if (frameX >= 144 && frameX <= 232)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		protected void DrawBlack()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				value = default(Vector2);
			}
			int num = (int)((Main.tileColor.R + Main.tileColor.G + Main.tileColor.B) / 3);
			float num2 = (float)((double)num * 0.4) / 255f;
			if (Lighting.lightMode >= 2)
			{
				num2 = (float)(Main.tileColor.R - 55) / 255f;
			}
			int num3 = (int)((Main.screenPosition.X - value.X) / 16f - 1f);
			int num4 = (int)((Main.screenPosition.X + (float)Main.screenWidth + value.X) / 16f) + 2;
			int num5 = (int)((Main.screenPosition.Y - value.Y) / 16f - 1f);
			int num6 = (int)((Main.screenPosition.Y + (float)Main.screenHeight + value.Y) / 16f) + 5;
			int num7 = Main.offScreenRange / 16;
			int num8 = Main.offScreenRange / 16;
			if (num3 - num7 < 0)
			{
				num3 = num7;
			}
			if (num4 + num7 > Main.maxTilesX)
			{
				num4 = Main.maxTilesX - num7;
			}
			if (num5 - num8 < 0)
			{
				num5 = num8;
			}
			if (num6 + num8 > Main.maxTilesY)
			{
				num6 = Main.maxTilesY - num8;
			}
			for (int i = num5 - num8; i < num6 + num8; i++)
			{
				if ((double)i <= Main.worldSurface)
				{
					for (int j = num3 - num7; j < num4 + num7; j++)
					{
						if (Main.tile[j, i] == null)
						{

						}
						if (Lighting.Brightness(j, i) < num2 && (Main.tile[j, i].liquid < 250 || WorldGen.SolidTile(j, i) || (Main.tile[j, i].liquid > 250 && Lighting.Brightness(j, i) == 0f)))
						{
							int num9 = j;
							j++;
							while (Main.tile[j, i] != null && Lighting.Brightness(j, i) < num2 && (Main.tile[j, i].liquid < 250 || WorldGen.SolidTile(j, i) || (Main.tile[j, i].liquid > 250 && Lighting.Brightness(j, i) == 0f)))
							{
								j++;
								if (j >= num4 + num7)
								{
									break;
								}
							}
							j--;
							int width = (j - num9 + 1) * 16;
							this.spriteBatch.Draw(Main.blackTileTexture, new Vector2((float)(num9 * 16 - (int)Main.screenPosition.X), (float)(i * 16 - (int)Main.screenPosition.Y)) + value, new Rectangle?(new Rectangle(0, 0, width, 16)), Color.Black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
						}
					}
				}
			}
			Main.renderTimer[5] = (float)stopwatch.ElapsedMilliseconds;
		}
		protected void RenderBlack()
		{
			if (Main.drawToScreen)
			{
				return;
			}
			base.GraphicsDevice.SetRenderTarget(this.blackTarget);
			base.GraphicsDevice.DepthStencilState = new DepthStencilState
			{
				DepthBufferEnable = true
			};
			base.GraphicsDevice.Clear(new Color(0, 0, 0, 0));
			this.spriteBatch.Begin();
			this.DrawBlack();
			this.spriteBatch.End();
			base.GraphicsDevice.SetRenderTarget(null);
		}
		protected void DrawWalls()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num = (int)(255f * (1f - Main.gfxQuality) + 100f * Main.gfxQuality);
			int num2 = (int)(120f * (1f - Main.gfxQuality) + 40f * Main.gfxQuality);
			Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				value = default(Vector2);
			}
			int num3 = (int)((Main.tileColor.R + Main.tileColor.G + Main.tileColor.B) / 3);
			float num4 = (float)((double)num3 * 0.53) / 255f;
			if (Lighting.lightMode >= 2)
			{
				num4 = (float)(Main.tileColor.R - 12) / 255f;
			}
			int num5 = (int)((Main.screenPosition.X - value.X) / 16f - 1f);
			int num6 = (int)((Main.screenPosition.X + (float)Main.screenWidth + value.X) / 16f) + 2;
			int num7 = (int)((Main.screenPosition.Y - value.Y) / 16f - 1f);
			int num8 = (int)((Main.screenPosition.Y + (float)Main.screenHeight + value.Y) / 16f) + 5;
			int num9 = Main.offScreenRange / 16;
			int num10 = Main.offScreenRange / 16;
			if (num5 - num9 < 0)
			{
				num5 = num9;
			}
			if (num6 + num9 > Main.maxTilesX)
			{
				num6 = Main.maxTilesX - num9;
			}
			if (num7 - num10 < 0)
			{
				num7 = num10;
			}
			if (num8 + num10 > Main.maxTilesY)
			{
				num8 = Main.maxTilesY - num10;
			}
			for (int i = num7 - num10; i < num8 + num10; i++)
			{
				if ((double)i <= Main.worldSurface)
				{
					for (int j = num5 - num9; j < num6 + num9; j++)
					{
						if (Main.tile[j, i] == null)
						{

						}
						if (Lighting.Brightness(j, i) < num4 && (Main.tile[j, i].liquid < 250 || WorldGen.SolidTile(j, i) || (Main.tile[j, i].liquid > 250 && Lighting.Brightness(j, i) == 0f)))
						{
							this.spriteBatch.Draw(Main.blackTileTexture, new Vector2((float)(j * 16 - (int)Main.screenPosition.X), (float)(i * 16 - (int)Main.screenPosition.Y)) + value, Lighting.GetBlackness(j, i));
						}
					}
				}
			}
			for (int k = num7 - num10; k < num8 + num10; k++)
			{
				for (int l = num5 - num9; l < num6 + num9; l++)
				{
					if (Main.tile[l, k] == null)
					{

					}
					if (Main.tile[l, k].wall > 0 && Lighting.Brightness(l, k) > 0f && !this.FullTile(l, k))
					{
						Color color = Lighting.GetColor(l, k);
						if (Lighting.lightMode < 2 && Main.tile[l, k].wall != 21 && !WorldGen.SolidTile(l, k))
						{
							if ((int)color.R > num || (double)color.G > (double)num * 1.1 || (double)color.B > (double)num * 1.2)
							{
								for (int m = 0; m < 9; m++)
								{
									int num11 = 0;
									int num12 = 0;
									int width = 12;
									int height = 12;
									Color color2 = color;
									Color color3 = color;
									if (m == 0)
									{
										color3 = Lighting.GetColor(l - 1, k - 1);
									}
									if (m == 1)
									{
										width = 8;
										num11 = 12;
										color3 = Lighting.GetColor(l, k - 1);
									}
									if (m == 2)
									{
										color3 = Lighting.GetColor(l + 1, k - 1);
										num11 = 20;
									}
									if (m == 3)
									{
										color3 = Lighting.GetColor(l - 1, k);
										height = 8;
										num12 = 12;
									}
									if (m == 4)
									{
										width = 8;
										height = 8;
										num11 = 12;
										num12 = 12;
									}
									if (m == 5)
									{
										num11 = 20;
										num12 = 12;
										height = 8;
										color3 = Lighting.GetColor(l + 1, k);
									}
									if (m == 6)
									{
										color3 = Lighting.GetColor(l - 1, k + 1);
										num12 = 20;
									}
									if (m == 7)
									{
										width = 12;
										num11 = 12;
										num12 = 20;
										color3 = Lighting.GetColor(l, k + 1);
									}
									if (m == 8)
									{
										color3 = Lighting.GetColor(l + 1, k + 1);
										num11 = 20;
										num12 = 20;
									}
									color2.R = (byte)((color.R + color3.R) / 2);
									color2.G = (byte)((color.G + color3.G) / 2);
									color2.B = (byte)((color.B + color3.B) / 2);
									//this.spriteBatch.Draw(Main.wallTexture[(int)Main.tile[l, k].wall], new Vector2((float)(l * 16 - (int)Main.screenPosition.X - 8 + num11), (float)(k * 16 - (int)Main.screenPosition.Y - 8 + num12)) + value, new Rectangle?(new Rectangle((int)(Main.tile[l, k].wallFrameX * 2) + num11, (int)(Main.tile[l, k].wallFrameY * 2) + num12, width, height)), color2, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
								}
							}
							else
							{
								if ((int)color.R > num2 || (double)color.G > (double)num2 * 1.1 || (double)color.B > (double)num2 * 1.2)
								{
									for (int n = 0; n < 4; n++)
									{
										int num13 = 0;
										int num14 = 0;
										Color color4 = color;
										Color color5 = color;
										if (n == 0)
										{
											if (Lighting.Brighter(l, k - 1, l - 1, k))
											{
												color5 = Lighting.GetColor(l - 1, k);
											}
											else
											{
												color5 = Lighting.GetColor(l, k - 1);
											}
										}
										if (n == 1)
										{
											if (Lighting.Brighter(l, k - 1, l + 1, k))
											{
												color5 = Lighting.GetColor(l + 1, k);
											}
											else
											{
												color5 = Lighting.GetColor(l, k - 1);
											}
											num13 = 16;
										}
										if (n == 2)
										{
											if (Lighting.Brighter(l, k + 1, l - 1, k))
											{
												color5 = Lighting.GetColor(l - 1, k);
											}
											else
											{
												color5 = Lighting.GetColor(l, k + 1);
											}
											num14 = 16;
										}
										if (n == 3)
										{
											if (Lighting.Brighter(l, k + 1, l + 1, k))
											{
												color5 = Lighting.GetColor(l + 1, k);
											}
											else
											{
												color5 = Lighting.GetColor(l, k + 1);
											}
											num13 = 16;
											num14 = 16;
										}
										color4.R = (byte)((color.R + color5.R) / 2);
										color4.G = (byte)((color.G + color5.G) / 2);
										color4.B = (byte)((color.B + color5.B) / 2);
										//this.spriteBatch.Draw(Main.wallTexture[(int)Main.tile[l, k].wall], new Vector2((float)(l * 16 - (int)Main.screenPosition.X - 8 + num13), (float)(k * 16 - (int)Main.screenPosition.Y - 8 + num14)) + value, new Rectangle?(new Rectangle((int)(Main.tile[l, k].wallFrameX * 2) + num13, (int)(Main.tile[l, k].wallFrameY * 2) + num14, 16, 16)), color4, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
									}
								}
								else
								{
									//Rectangle value2 = new Rectangle((int)(Main.tile[l, k].wallFrameX * 2), (int)(Main.tile[l, k].wallFrameY * 2), 32, 32);
									//this.spriteBatch.Draw(Main.wallTexture[(int)Main.tile[l, k].wall], new Vector2((float)(l * 16 - (int)Main.screenPosition.X - 8), (float)(k * 16 - (int)Main.screenPosition.Y - 8)) + value, new Rectangle?(value2), Lighting.GetColor(l, k), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
								}
							}
						}
						else
						{
							//Rectangle value2 = new Rectangle((int)(Main.tile[l, k].wallFrameX * 2), (int)(Main.tile[l, k].wallFrameY * 2), 32, 32);
							//this.spriteBatch.Draw(Main.wallTexture[(int)Main.tile[l, k].wall], new Vector2((float)(l * 16 - (int)Main.screenPosition.X - 8), (float)(k * 16 - (int)Main.screenPosition.Y - 8)) + value, new Rectangle?(value2), Lighting.GetColor(l, k), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
						}
						if ((double)color.R > (double)num2 * 0.4 || (double)color.G > (double)num2 * 0.35 || (double)color.B > (double)num2 * 0.3)
						{
							bool flag = false;
							if (Main.tile[l - 1, k].wall > 0 && Main.wallBlend[(int)Main.tile[l - 1, k].wall] != Main.wallBlend[(int)Main.tile[l, k].wall])
							{
								flag = true;
							}
							bool flag2 = false;
							if (Main.tile[l + 1, k].wall > 0 && Main.wallBlend[(int)Main.tile[l + 1, k].wall] != Main.wallBlend[(int)Main.tile[l, k].wall])
							{
								flag2 = true;
							}
							bool flag3 = false;
							if (Main.tile[l, k - 1].wall > 0 && Main.wallBlend[(int)Main.tile[l, k - 1].wall] != Main.wallBlend[(int)Main.tile[l, k].wall])
							{
								flag3 = true;
							}
							bool flag4 = false;
							if (Main.tile[l, k + 1].wall > 0 && Main.wallBlend[(int)Main.tile[l, k + 1].wall] != Main.wallBlend[(int)Main.tile[l, k].wall])
							{
								flag4 = true;
							}
							if (flag)
							{
								this.spriteBatch.Draw(Main.wallOutlineTexture, new Vector2((float)(l * 16 - (int)Main.screenPosition.X), (float)(k * 16 - (int)Main.screenPosition.Y)) + value, new Rectangle?(new Rectangle(0, 0, 2, 16)), Lighting.GetColor(l, k), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
							if (flag2)
							{
								this.spriteBatch.Draw(Main.wallOutlineTexture, new Vector2((float)(l * 16 - (int)Main.screenPosition.X + 14), (float)(k * 16 - (int)Main.screenPosition.Y)) + value, new Rectangle?(new Rectangle(14, 0, 2, 16)), Lighting.GetColor(l, k), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
							if (flag3)
							{
								this.spriteBatch.Draw(Main.wallOutlineTexture, new Vector2((float)(l * 16 - (int)Main.screenPosition.X), (float)(k * 16 - (int)Main.screenPosition.Y)) + value, new Rectangle?(new Rectangle(0, 0, 16, 2)), Lighting.GetColor(l, k), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
							if (flag4)
							{
								this.spriteBatch.Draw(Main.wallOutlineTexture, new Vector2((float)(l * 16 - (int)Main.screenPosition.X), (float)(k * 16 - (int)Main.screenPosition.Y + 14)) + value, new Rectangle?(new Rectangle(0, 14, 16, 2)), Lighting.GetColor(l, k), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
						}
					}
				}
			}
			Main.renderTimer[2] = (float)stopwatch.ElapsedMilliseconds;
		}
		protected void RenderWalls()
		{
			if (Main.drawToScreen)
			{
				return;
			}
			base.GraphicsDevice.SetRenderTarget(this.wallTarget);
			base.GraphicsDevice.DepthStencilState = new DepthStencilState
			{
				DepthBufferEnable = true
			};
			base.GraphicsDevice.Clear(new Color(0, 0, 0, 0));
			this.spriteBatch.Begin();
			this.DrawWalls();
			this.spriteBatch.End();
			base.GraphicsDevice.SetRenderTarget(null);
		}
		protected void ReleaseTargets()
		{
			if (Main.dedServ)
			{
				return;
			}
			Main.offScreenRange = 0;
			Main.targetSet = false;
			this.waterTarget.Dispose();
			this.backWaterTarget.Dispose();
			this.blackTarget.Dispose();
			this.tileTarget.Dispose();
			this.tile2Target.Dispose();
			this.wallTarget.Dispose();
			this.backgroundTarget.Dispose();
		}
		protected void InitTargets()
		{
			if (Main.dedServ)
			{
				return;
			}
			Main.offScreenRange = 192;
			Main.targetSet = true;
			if (base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2 > 2048)
			{
				Main.offScreenRange = (2048 - base.GraphicsDevice.PresentationParameters.BackBufferWidth) / 2;
			}
			this.waterTarget = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
			this.backWaterTarget = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
			this.blackTarget = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
			this.tileTarget = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
			this.tile2Target = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
			this.wallTarget = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
			this.backgroundTarget = new RenderTarget2D(base.GraphicsDevice, base.GraphicsDevice.PresentationParameters.BackBufferWidth + Main.offScreenRange * 2, base.GraphicsDevice.PresentationParameters.BackBufferHeight + Main.offScreenRange * 2, false, base.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
		}
		protected void DrawWires()
		{
			int num = (int)(50f * (1f - Main.gfxQuality) + 2f * Main.gfxQuality);
			Vector2 value = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				value = default(Vector2);
			}
			int num2 = (int)((Main.screenPosition.X - value.X) / 16f - 1f);
			int num3 = (int)((Main.screenPosition.X + (float)Main.screenWidth + value.X) / 16f) + 2;
			int num4 = (int)((Main.screenPosition.Y - value.Y) / 16f - 1f);
			int num5 = (int)((Main.screenPosition.Y + (float)Main.screenHeight + value.Y) / 16f) + 5;
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num3 > Main.maxTilesX)
			{
				num3 = Main.maxTilesX;
			}
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num5 > Main.maxTilesY)
			{
				num5 = Main.maxTilesY;
			}
			for (int i = num4; i < num5; i++)
			{
				for (int j = num2; j < num3; j++)
				{
					if (Main.tile[j, i].wire && Lighting.Brightness(j, i) > 0f)
					{
						Rectangle value2 = new Rectangle(0, 0, 16, 16);
						bool wire = Main.tile[j, i - 1].wire;
						bool wire2 = Main.tile[j, i + 1].wire;
						bool wire3 = Main.tile[j - 1, i].wire;
						bool wire4 = Main.tile[j + 1, i].wire;
						if (wire)
						{
							if (wire2)
							{
								if (wire3)
								{
									if (wire4)
									{
										value2 = new Rectangle(18, 18, 16, 16);
									}
									else
									{
										value2 = new Rectangle(54, 0, 16, 16);
									}
								}
								else
								{
									if (wire4)
									{
										value2 = new Rectangle(36, 0, 16, 16);
									}
									else
									{
										value2 = new Rectangle(0, 0, 16, 16);
									}
								}
							}
							else
							{
								if (wire3)
								{
									if (wire4)
									{
										value2 = new Rectangle(0, 18, 16, 16);
									}
									else
									{
										value2 = new Rectangle(54, 18, 16, 16);
									}
								}
								else
								{
									if (wire4)
									{
										value2 = new Rectangle(36, 18, 16, 16);
									}
									else
									{
										value2 = new Rectangle(36, 36, 16, 16);
									}
								}
							}
						}
						else
						{
							if (wire2)
							{
								if (wire3)
								{
									if (wire4)
									{
										value2 = new Rectangle(72, 0, 16, 16);
									}
									else
									{
										value2 = new Rectangle(72, 18, 16, 16);
									}
								}
								else
								{
									if (wire4)
									{
										value2 = new Rectangle(0, 36, 16, 16);
									}
									else
									{
										value2 = new Rectangle(18, 36, 16, 16);
									}
								}
							}
							else
							{
								if (wire3)
								{
									if (wire4)
									{
										value2 = new Rectangle(18, 0, 16, 16);
									}
									else
									{
										value2 = new Rectangle(54, 36, 16, 16);
									}
								}
								else
								{
									if (wire4)
									{
										value2 = new Rectangle(72, 36, 16, 16);
									}
									else
									{
										value2 = new Rectangle(0, 54, 16, 16);
									}
								}
							}
						}
						Color color = Lighting.GetColor(j, i);
						if (Lighting.lightMode < 2 && ((int)color.R > num || (double)color.G > (double)num * 1.1 || (double)color.B > (double)num * 1.2))
						{
							for (int k = 0; k < 4; k++)
							{
								int num6 = 0;
								int num7 = 0;
								Color color2 = color;
								Color color3 = color;
								if (k == 0)
								{
									if (Lighting.Brighter(j, i - 1, j - 1, i))
									{
										color3 = Lighting.GetColor(j - 1, i);
									}
									else
									{
										color3 = Lighting.GetColor(j, i - 1);
									}
								}
								if (k == 1)
								{
									if (Lighting.Brighter(j, i - 1, j + 1, i))
									{
										color3 = Lighting.GetColor(j + 1, i);
									}
									else
									{
										color3 = Lighting.GetColor(j, i - 1);
									}
									num6 = 8;
								}
								if (k == 2)
								{
									if (Lighting.Brighter(j, i + 1, j - 1, i))
									{
										color3 = Lighting.GetColor(j - 1, i);
									}
									else
									{
										color3 = Lighting.GetColor(j, i + 1);
									}
									num7 = 8;
								}
								if (k == 3)
								{
									if (Lighting.Brighter(j, i + 1, j + 1, i))
									{
										color3 = Lighting.GetColor(j + 1, i);
									}
									else
									{
										color3 = Lighting.GetColor(j, i + 1);
									}
									num6 = 8;
									num7 = 8;
								}
								color2.R = (byte)((color.R + color3.R) / 2);
								color2.G = (byte)((color.G + color3.G) / 2);
								color2.B = (byte)((color.B + color3.B) / 2);
								this.spriteBatch.Draw(Main.wireTexture, new Vector2((float)(j * 16 - (int)Main.screenPosition.X + num6), (float)(i * 16 - (int)Main.screenPosition.Y + num7)) + value, new Rectangle?(new Rectangle(value2.X + num6, value2.Y + num7, 8, 8)), color2, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
							}
						}
						else
						{
							this.spriteBatch.Draw(Main.wireTexture, new Vector2((float)(j * 16 - (int)Main.screenPosition.X), (float)(i * 16 - (int)Main.screenPosition.Y)) + value, new Rectangle?(value2), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
						}
					}
				}
			}
		}
		protected override void Draw(GameTime gameTime)
		{
			if (Lighting.lightMode >= 2)
			{
				Main.drawToScreen = true;
			}
			else
			{
				Main.drawToScreen = false;
			}
			if (Main.drawToScreen)
			{
				bool arg_22_0 = Main.targetSet;
			}
			if (!Main.drawToScreen && !Main.targetSet)
			{
				this.InitTargets();
			}
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Main.fpsCount++;
			if (!base.IsActive)
			{
				Main.maxQ = true;
			}
			if (!Main.dedServ)
			{
				bool flag = false;
				int arg_82_0 = Main.screenWidth;
				Viewport viewport = base.GraphicsDevice.Viewport;
				if (arg_82_0 == viewport.Width)
				{
					int arg_9D_0 = Main.screenHeight;
					viewport = base.GraphicsDevice.Viewport;
					if (arg_9D_0 == viewport.Height)
					{
						goto IL_AE;
					}
				}
				flag = true;
				if (Main.gamePaused)
				{
					Main.renderNow = true;
				}
				IL_AE:
				viewport = base.GraphicsDevice.Viewport;
				Main.screenWidth = viewport.Width;
				viewport = base.GraphicsDevice.Viewport;
				Main.screenHeight = viewport.Height;
				if (Main.screenWidth > Main.maxScreenW)
				{
					Main.screenWidth = Main.maxScreenW;
					flag = true;
				}
				if (Main.screenHeight > Main.maxScreenH)
				{
					Main.screenHeight = Main.maxScreenH;
					flag = true;
				}
				if (Main.screenWidth < Main.minScreenW)
				{
					Main.screenWidth = Main.minScreenW;
					flag = true;
				}
				if (Main.screenHeight < Main.minScreenH)
				{
					Main.screenHeight = Main.minScreenH;
					flag = true;
				}
				if (flag)
				{
					this.graphics.PreferredBackBufferWidth = Main.screenWidth;
					this.graphics.PreferredBackBufferHeight = Main.screenHeight;
					this.graphics.ApplyChanges();
					if (!Main.drawToScreen)
					{
						this.InitTargets();
					}
				}
			}
			Main.CursorColor();
			Main.drawTime++;
			Main.screenLastPosition = Main.screenPosition;
			if (Main.stackSplit == 0)
			{
				Main.stackCounter = 0;
				Main.stackDelay = 7;
			}
			else
			{
				Main.stackCounter++;
				if (Main.stackCounter >= 30)
				{
					Main.stackDelay--;
					if (Main.stackDelay < 2)
					{
						Main.stackDelay = 2;
					}
					Main.stackCounter = 0;
				}
			}
			Main.mouseTextColor += (byte)Main.mouseTextColorChange;
			if (Main.mouseTextColor >= 250)
			{
				Main.mouseTextColorChange = -4;
			}
			if (Main.mouseTextColor <= 175)
			{
				Main.mouseTextColorChange = 4;
			}
			if (Main.myPlayer >= 0)
			{
				Main.player[Main.myPlayer].mouseInterface = false;
			}
			Main.toolTip = new Item();
			if (!Main.gameMenu && Main.netMode != 2)
			{
				Main.screenPosition.X = Main.player[Main.myPlayer].position.X + (float)Main.player[Main.myPlayer].width * 0.5f - (float)Main.screenWidth * 0.5f;
				Main.screenPosition.Y = Main.player[Main.myPlayer].position.Y + (float)Main.player[Main.myPlayer].height * 0.5f - (float)Main.screenHeight * 0.5f;
				Main.screenPosition.X = (float)((int)Main.screenPosition.X);
				Main.screenPosition.Y = (float)((int)Main.screenPosition.Y);
			}
			if (!Main.gameMenu && Main.netMode != 2)
			{
				if (Main.screenPosition.X < Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
				{
					Main.screenPosition.X = Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
				}
				else
				{
					if (Main.screenPosition.X + (float)Main.screenWidth > Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f)
					{
						Main.screenPosition.X = Main.rightWorld - (float)Main.screenWidth - (float)(Lighting.offScreenTiles * 16) - 32f;
					}
				}
				if (Main.screenPosition.Y < Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
				{
					Main.screenPosition.Y = Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
				}
				else
				{
					if (Main.screenPosition.Y + (float)Main.screenHeight > Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f)
					{
						Main.screenPosition.Y = Main.bottomWorld - (float)Main.screenHeight - (float)(Lighting.offScreenTiles * 16) - 32f;
					}
				}
			}
			if (Main.showSplash)
			{
				this.DrawSplash(gameTime);
				return;
			}
			if (!Main.gameMenu)
			{
				if (Main.renderNow)
				{
					Main.screenLastPosition = Main.screenPosition;
					Main.renderNow = false;
					Main.renderCount = 99;
					int tempLightCount = Lighting.tempLightCount;
					this.Draw(gameTime);
					Lighting.tempLightCount = tempLightCount;
					Lighting.LightTiles(this.firstTileX, this.lastTileX, this.firstTileY, this.lastTileY);
					Lighting.LightTiles(this.firstTileX, this.lastTileX, this.firstTileY, this.lastTileY);
					this.RenderTiles();
					Main.sceneTilePos.X = Main.screenPosition.X - (float)Main.offScreenRange;
					Main.sceneTilePos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					this.RenderBackground();
					Main.sceneBackgroundPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
					Main.sceneBackgroundPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					this.RenderWalls();
					Main.sceneWallPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
					Main.sceneWallPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					this.RenderTiles2();
					Main.sceneTile2Pos.X = Main.screenPosition.X - (float)Main.offScreenRange;
					Main.sceneTile2Pos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					this.RenderWater();
					Main.sceneWaterPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
					Main.sceneWaterPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					Main.renderCount = 99;
				}
				else
				{
					if (Main.renderCount == 3)
					{
						this.RenderTiles();
						Main.sceneTilePos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneTilePos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					}
					if (Main.renderCount == 2)
					{
						this.RenderBackground();
						Main.sceneBackgroundPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneBackgroundPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					}
					if (Main.renderCount == 2)
					{
						this.RenderWalls();
						Main.sceneWallPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneWallPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					}
					if (Main.renderCount == 3)
					{
						this.RenderTiles2();
						Main.sceneTile2Pos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneTile2Pos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					}
					if (Main.renderCount == 1)
					{
						this.RenderWater();
						Main.sceneWaterPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneWaterPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					}
				}
				if (Main.render && !Main.gameMenu)
				{
					if (Math.Abs(Main.sceneTilePos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneTilePos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
					{
						this.RenderTiles();
						Main.sceneTilePos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneTilePos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					}
					if (Math.Abs(Main.sceneTile2Pos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneTile2Pos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
					{
						this.RenderTiles2();
						Main.sceneTile2Pos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneTile2Pos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					}
					if (Math.Abs(Main.sceneBackgroundPos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneBackgroundPos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
					{
						this.RenderBackground();
						Main.sceneBackgroundPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneBackgroundPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					}
					if (Math.Abs(Main.sceneWallPos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneWallPos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
					{
						this.RenderWalls();
						Main.sceneWallPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneWallPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					}
					if (Math.Abs(Main.sceneWaterPos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneWaterPos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
					{
						this.RenderWater();
						Main.sceneWaterPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
						Main.sceneWaterPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
					}
				}
			}
			this.bgParrallax = 0.1;
			this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.backgroundWidth[Main.background]) - (double)(Main.backgroundWidth[Main.background] / 2));
			this.bgLoops = Main.screenWidth / Main.backgroundWidth[Main.background] + 2;
			this.bgStartY = 0;
			this.bgLoopsY = 0;
			this.bgTop = (int)((double)(-(double)Main.screenPosition.Y) / (Main.worldSurface * 16.0 - 600.0) * 200.0);
			Main.bgColor = Color.White;
			if (Main.gameMenu || Main.netMode == 2)
			{
				this.bgTop = -200;
			}
			int num = (int)(Main.time / 54000.0 * (double)(Main.screenWidth + Main.sunTexture.Width * 2)) - Main.sunTexture.Width;
			int num2 = 0;
			Color white = Color.White;
			float num3 = 1f;
			float rotation = (float)(Main.time / 54000.0) * 2f - 7.3f;
			int num4 = (int)(Main.time / 32400.0 * (double)(Main.screenWidth + Main.moonTexture.Width * 2)) - Main.moonTexture.Width;
			int num5 = 0;
			Color white2 = Color.White;
			float num6 = 1f;
			float rotation2 = (float)(Main.time / 32400.0) * 2f - 7.3f;
			if (Main.dayTime)
			{
				double num7;
				if (Main.time < 27000.0)
				{
					num7 = Math.Pow(1.0 - Main.time / 54000.0 * 2.0, 2.0);
					num2 = (int)((double)this.bgTop + num7 * 250.0 + 180.0);
				}
				else
				{
					num7 = Math.Pow((Main.time / 54000.0 - 0.5) * 2.0, 2.0);
					num2 = (int)((double)this.bgTop + num7 * 250.0 + 180.0);
				}
				num3 = (float)(1.2 - num7 * 0.4);
			}
			else
			{
				double num8;
				if (Main.time < 16200.0)
				{
					num8 = Math.Pow(1.0 - Main.time / 32400.0 * 2.0, 2.0);
					num5 = (int)((double)this.bgTop + num8 * 250.0 + 180.0);
				}
				else
				{
					num8 = Math.Pow((Main.time / 32400.0 - 0.5) * 2.0, 2.0);
					num5 = (int)((double)this.bgTop + num8 * 250.0 + 180.0);
				}
				num6 = (float)(1.2 - num8 * 0.4);
			}
			if (Main.dayTime)
			{
				if (Main.time < 13500.0)
				{
					float num9 = (float)(Main.time / 13500.0);
					white.R = (byte)(num9 * 200f + 55f);
					white.G = (byte)(num9 * 180f + 75f);
					white.B = (byte)(num9 * 250f + 5f);
					Main.bgColor.R = (byte)(num9 * 230f + 25f);
					Main.bgColor.G = (byte)(num9 * 220f + 35f);
					Main.bgColor.B = (byte)(num9 * 220f + 35f);
				}
				if (Main.time > 45900.0)
				{
					float num9 = (float)(1.0 - (Main.time / 54000.0 - 0.85) * 6.666666666666667);
					white.R = (byte)(num9 * 120f + 55f);
					white.G = (byte)(num9 * 100f + 25f);
					white.B = (byte)(num9 * 120f + 55f);
					Main.bgColor.R = (byte)(num9 * 200f + 35f);
					Main.bgColor.G = (byte)(num9 * 85f + 35f);
					Main.bgColor.B = (byte)(num9 * 135f + 35f);
				}
				else
				{
					if (Main.time > 37800.0)
					{
						float num9 = (float)(1.0 - (Main.time / 54000.0 - 0.7) * 6.666666666666667);
						white.R = (byte)(num9 * 80f + 175f);
						white.G = (byte)(num9 * 130f + 125f);
						white.B = (byte)(num9 * 100f + 155f);
						Main.bgColor.R = (byte)(num9 * 20f + 235f);
						Main.bgColor.G = (byte)(num9 * 135f + 120f);
						Main.bgColor.B = (byte)(num9 * 85f + 170f);
					}
				}
			}
			if (!Main.dayTime)
			{
				if (Main.bloodMoon)
				{
					if (Main.time < 16200.0)
					{
						float num9 = (float)(1.0 - Main.time / 16200.0);
						white2.R = (byte)(num9 * 10f + 205f);
						white2.G = (byte)(num9 * 170f + 55f);
						white2.B = (byte)(num9 * 200f + 55f);
						Main.bgColor.R = (byte)(40f - num9 * 40f + 35f);
						Main.bgColor.G = (byte)(num9 * 20f + 15f);
						Main.bgColor.B = (byte)(num9 * 20f + 15f);
					}
					else
					{
						if (Main.time >= 16200.0)
						{
							float num9 = (float)((Main.time / 32400.0 - 0.5) * 2.0);
							white2.R = (byte)(num9 * 50f + 205f);
							white2.G = (byte)(num9 * 100f + 155f);
							white2.B = (byte)(num9 * 100f + 155f);
							white2.R = (byte)(num9 * 10f + 205f);
							white2.G = (byte)(num9 * 170f + 55f);
							white2.B = (byte)(num9 * 200f + 55f);
							Main.bgColor.R = (byte)(40f - num9 * 40f + 35f);
							Main.bgColor.G = (byte)(num9 * 20f + 15f);
							Main.bgColor.B = (byte)(num9 * 20f + 15f);
						}
					}
				}
				else
				{
					if (Main.time < 16200.0)
					{
						float num9 = (float)(1.0 - Main.time / 16200.0);
						white2.R = (byte)(num9 * 10f + 205f);
						white2.G = (byte)(num9 * 70f + 155f);
						white2.B = (byte)(num9 * 100f + 155f);
						Main.bgColor.R = (byte)(num9 * 20f + 15f);
						Main.bgColor.G = (byte)(num9 * 20f + 15f);
						Main.bgColor.B = (byte)(num9 * 20f + 15f);
					}
					else
					{
						if (Main.time >= 16200.0)
						{
							float num9 = (float)((Main.time / 32400.0 - 0.5) * 2.0);
							white2.R = (byte)(num9 * 50f + 205f);
							white2.G = (byte)(num9 * 100f + 155f);
							white2.B = (byte)(num9 * 100f + 155f);
							Main.bgColor.R = (byte)(num9 * 10f + 15f);
							Main.bgColor.G = (byte)(num9 * 20f + 15f);
							Main.bgColor.B = (byte)(num9 * 20f + 15f);
						}
					}
				}
			}
			if (Main.gameMenu || Main.netMode == 2)
			{
				this.bgTop = 0;
				if (!Main.dayTime)
				{
					Main.bgColor.R = 35;
					Main.bgColor.G = 35;
					Main.bgColor.B = 35;
				}
			}
			if (Main.gameMenu)
			{
				Main.bgDelay = 1000;
				Main.evilTiles = (int)(Main.bgAlpha[1] * 500f);
			}
			if (Main.evilTiles > 0)
			{
				float num10 = (float)Main.evilTiles / 500f;
				if (num10 > 1f)
				{
					num10 = 1f;
				}
				int num11 = (int)Main.bgColor.R;
				int num12 = (int)Main.bgColor.G;
				int num13 = (int)Main.bgColor.B;
				num11 -= (int)(100f * num10 * ((float)Main.bgColor.R / 255f));
				num12 -= (int)(140f * num10 * ((float)Main.bgColor.G / 255f));
				num13 -= (int)(80f * num10 * ((float)Main.bgColor.B / 255f));
				if (num11 < 15)
				{
					num11 = 15;
				}
				if (num12 < 15)
				{
					num12 = 15;
				}
				if (num13 < 15)
				{
					num13 = 15;
				}
				Main.bgColor.R = (byte)num11;
				Main.bgColor.G = (byte)num12;
				Main.bgColor.B = (byte)num13;
				num11 = (int)white.R;
				num12 = (int)white.G;
				num13 = (int)white.B;
				num11 -= (int)(100f * num10 * ((float)white.R / 255f));
				num12 -= (int)(100f * num10 * ((float)white.G / 255f));
				num13 -= (int)(0f * num10 * ((float)white.B / 255f));
				if (num11 < 15)
				{
					num11 = 15;
				}
				if (num12 < 15)
				{
					num12 = 15;
				}
				if (num13 < 15)
				{
					num13 = 15;
				}
				white.R = (byte)num11;
				white.G = (byte)num12;
				white.B = (byte)num13;
				num11 = (int)white2.R;
				num12 = (int)white2.G;
				num13 = (int)white2.B;
				num11 -= (int)(140f * num10 * ((float)white2.R / 255f));
				num12 -= (int)(190f * num10 * ((float)white2.G / 255f));
				num13 -= (int)(170f * num10 * ((float)white2.B / 255f));
				if (num11 < 15)
				{
					num11 = 15;
				}
				if (num12 < 15)
				{
					num12 = 15;
				}
				if (num13 < 15)
				{
					num13 = 15;
				}
				white2.R = (byte)num11;
				white2.G = (byte)num12;
				white2.B = (byte)num13;
			}
			if (Main.jungleTiles > 0)
			{
				float num14 = (float)Main.jungleTiles / 200f;
				if (num14 > 1f)
				{
					num14 = 1f;
				}
				int num15 = (int)Main.bgColor.R;
				int num16 = (int)Main.bgColor.G;
				int num17 = (int)Main.bgColor.B;
				num15 -= (int)(20f * num14 * ((float)Main.bgColor.R / 255f));
				num17 -= (int)(90f * num14 * ((float)Main.bgColor.B / 255f));
				if (num16 > 255)
				{
					num16 = 255;
				}
				if (num16 < 15)
				{
					num16 = 15;
				}
				if (num15 > 255)
				{
					num15 = 255;
				}
				if (num15 < 15)
				{
					num15 = 15;
				}
				if (num17 < 15)
				{
					num17 = 15;
				}
				Main.bgColor.R = (byte)num15;
				Main.bgColor.G = (byte)num16;
				Main.bgColor.B = (byte)num17;
				num15 = (int)white.R;
				num16 = (int)white.G;
				num17 = (int)white.B;
				num15 -= (int)(30f * num14 * ((float)white.R / 255f));
				num17 -= (int)(10f * num14 * ((float)white.B / 255f));
				if (num15 < 15)
				{
					num15 = 15;
				}
				if (num16 < 15)
				{
					num16 = 15;
				}
				if (num17 < 15)
				{
					num17 = 15;
				}
				white.R = (byte)num15;
				white.G = (byte)num16;
				white.B = (byte)num17;
				num15 = (int)white2.R;
				num16 = (int)white2.G;
				num17 = (int)white2.B;
				num16 -= (int)(140f * num14 * ((float)white2.R / 255f));
				num15 -= (int)(170f * num14 * ((float)white2.G / 255f));
				num17 -= (int)(190f * num14 * ((float)white2.B / 255f));
				if (num15 < 15)
				{
					num15 = 15;
				}
				if (num16 < 15)
				{
					num16 = 15;
				}
				if (num17 < 15)
				{
					num17 = 15;
				}
				white2.R = (byte)num15;
				white2.G = (byte)num16;
				white2.B = (byte)num17;
			}
			if (Main.bgColor.R < 15)
			{
				Main.bgColor.R = 15;
			}
			if (Main.bgColor.G < 15)
			{
				Main.bgColor.G = 15;
			}
			if (Main.bgColor.B < 15)
			{
				Main.bgColor.B = 15;
			}
			if (Main.bloodMoon)
			{
				if (Main.bgColor.R < 25)
				{
					Main.bgColor.R = 25;
				}
				if (Main.bgColor.G < 25)
				{
					Main.bgColor.G = 25;
				}
				if (Main.bgColor.B < 25)
				{
					Main.bgColor.B = 25;
				}
			}
			Main.tileColor.A = 255;
			Main.tileColor.R = (byte)((Main.bgColor.R + Main.bgColor.B + Main.bgColor.G) / 3);
			Main.tileColor.G = (byte)((Main.bgColor.R + Main.bgColor.B + Main.bgColor.G) / 3);
			Main.tileColor.B = (byte)((Main.bgColor.R + Main.bgColor.B + Main.bgColor.G) / 3);
			Main.tileColor.R = (byte)((Main.bgColor.R + Main.bgColor.G + Main.bgColor.B + Main.bgColor.R * 7) / 10);
			Main.tileColor.G = (byte)((Main.bgColor.R + Main.bgColor.G + Main.bgColor.B + Main.bgColor.G * 7) / 10);
			Main.tileColor.B = (byte)((Main.bgColor.R + Main.bgColor.G + Main.bgColor.B + Main.bgColor.B * 7) / 10);
			if (Main.tileColor.R >= 255 && Main.tileColor.G >= 255)
			{
				byte arg_1A41_0 = Main.tileColor.B;
			}
			float num18 = (float)(Main.maxTilesX / 4200);
			num18 *= num18;
			float num19 = (float)((double)((Main.screenPosition.Y + (float)(Main.screenHeight / 2)) / 16f - (65f + 10f * num18)) / (Main.worldSurface / 5.0));
			if (num19 < 0f)
			{
				num19 = 0f;
			}
			if (num19 > 1f)
			{
				num19 = 1f;
			}
			if (Main.gameMenu)
			{
				num19 = 1f;
			}
			Main.bgColor.R = (byte)((float)Main.bgColor.R * num19);
			Main.bgColor.G = (byte)((float)Main.bgColor.G * num19);
			Main.bgColor.B = (byte)((float)Main.bgColor.B * num19);
			base.GraphicsDevice.Clear(Color.Black);
			base.Draw(gameTime);
			this.spriteBatch.Begin();
			if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
			{
				for (int i = 0; i < this.bgLoops; i++)
				{
					this.spriteBatch.Draw(Main.backgroundTexture[Main.background], new Rectangle(this.bgStart + Main.backgroundWidth[Main.background] * i, this.bgTop, Main.backgroundWidth[Main.background], Main.backgroundHeight[Main.background]), Main.bgColor);
				}
			}
			if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0 && 255 - Main.bgColor.R - 100 > 0 && Main.netMode != 2)
			{
				for (int j = 0; j < Main.numStars; j++)
				{
					Color color = default(Color);
					float num20 = (float)Main.evilTiles / 500f;
					if (num20 > 1f)
					{
						num20 = 1f;
					}
					num20 = 1f - num20 * 0.5f;
					if (Main.evilTiles <= 0)
					{
						num20 = 1f;
					}
					int num21 = (int)((float)(255 - Main.bgColor.R - 100) * Main.star[j].twinkle * num20);
					int num22 = (int)((float)(255 - Main.bgColor.G - 100) * Main.star[j].twinkle * num20);
					int num23 = (int)((float)(255 - Main.bgColor.B - 100) * Main.star[j].twinkle * num20);
					if (num21 < 0)
					{
						num21 = 0;
					}
					if (num22 < 0)
					{
						num22 = 0;
					}
					if (num23 < 0)
					{
						num23 = 0;
					}
					color.R = (byte)num21;
					color.G = (byte)((float)num22 * num20);
					color.B = (byte)((float)num23 * num20);
					float num24 = Main.star[j].position.X * ((float)Main.screenWidth / 800f);
					float num25 = Main.star[j].position.Y * ((float)Main.screenHeight / 600f);
					this.spriteBatch.Draw(Main.starTexture[Main.star[j].type], new Vector2(num24 + (float)Main.starTexture[Main.star[j].type].Width * 0.5f, num25 + (float)Main.starTexture[Main.star[j].type].Height * 0.5f + (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.starTexture[Main.star[j].type].Width, Main.starTexture[Main.star[j].type].Height)), color, Main.star[j].rotation, new Vector2((float)Main.starTexture[Main.star[j].type].Width * 0.5f, (float)Main.starTexture[Main.star[j].type].Height * 0.5f), Main.star[j].scale * Main.star[j].twinkle, SpriteEffects.None, 0f);
				}
			}
			if ((double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 2.0)
			{
				if (Main.dayTime)
				{
					num3 *= 1.1f;
					if (!Main.gameMenu && Main.player[Main.myPlayer].head == 12)
					{
						this.spriteBatch.Draw(Main.sun2Texture, new Vector2((float)num, (float)(num2 + (int)Main.sunModY)), new Rectangle?(new Rectangle(0, 0, Main.sunTexture.Width, Main.sunTexture.Height)), white, rotation, new Vector2((float)(Main.sunTexture.Width / 2), (float)(Main.sunTexture.Height / 2)), num3, SpriteEffects.None, 0f);
					}
					else
					{
						this.spriteBatch.Draw(Main.sunTexture, new Vector2((float)num, (float)(num2 + (int)Main.sunModY)), new Rectangle?(new Rectangle(0, 0, Main.sunTexture.Width, Main.sunTexture.Height)), white, rotation, new Vector2((float)(Main.sunTexture.Width / 2), (float)(Main.sunTexture.Height / 2)), num3, SpriteEffects.None, 0f);
					}
				}
				if (!Main.dayTime)
				{
					this.spriteBatch.Draw(Main.moonTexture, new Vector2((float)num4, (float)(num5 + (int)Main.moonModY)), new Rectangle?(new Rectangle(0, Main.moonTexture.Width * Main.moonPhase, Main.moonTexture.Width, Main.moonTexture.Width)), white2, rotation2, new Vector2((float)(Main.moonTexture.Width / 2), (float)(Main.moonTexture.Width / 2)), num6, SpriteEffects.None, 0f);
				}
			}
			Rectangle value;
			if (Main.dayTime)
			{
				value = new Rectangle((int)((double)num - (double)Main.sunTexture.Width * 0.5 * (double)num3), (int)((double)num2 - (double)Main.sunTexture.Height * 0.5 * (double)num3 + (double)Main.sunModY), (int)((float)Main.sunTexture.Width * num3), (int)((float)Main.sunTexture.Width * num3));
			}
			else
			{
				value = new Rectangle((int)((double)num4 - (double)Main.moonTexture.Width * 0.5 * (double)num6), (int)((double)num5 - (double)Main.moonTexture.Width * 0.5 * (double)num6 + (double)Main.moonModY), (int)((float)Main.moonTexture.Width * num6), (int)((float)Main.moonTexture.Width * num6));
			}
			Rectangle rectangle = new Rectangle(Main.mouseX, Main.mouseY, 1, 1);
			Main.sunModY = (short)((double)Main.sunModY * 0.999);
			Main.moonModY = (short)((double)Main.moonModY * 0.999);
			if (Main.gameMenu && Main.netMode != 1)
			{
				if (Main.mouseLeft && Main.hasFocus)
				{
					if (rectangle.Intersects(value) || Main.grabSky)
					{
						if (Main.dayTime)
						{
							Main.time = 54000.0 * (double)((float)(Main.mouseX + Main.sunTexture.Width) / ((float)Main.screenWidth + (float)(Main.sunTexture.Width * 2)));
							Main.sunModY = (short)(Main.mouseY - num2);
							if (Main.time > 53990.0)
							{
								Main.time = 53990.0;
							}
						}
						else
						{
							Main.time = 32400.0 * (double)((float)(Main.mouseX + Main.moonTexture.Width) / ((float)Main.screenWidth + (float)(Main.moonTexture.Width * 2)));
							Main.moonModY = (short)(Main.mouseY - num5);
							if (Main.time > 32390.0)
							{
								Main.time = 32390.0;
							}
						}
						if (Main.time < 10.0)
						{
							Main.time = 10.0;
						}
						if (Main.netMode != 0)
						{
							NetMessage.SendData(18, -1, -1, "", 0, 0f, 0f, 0f, 0);
						}
						Main.grabSky = true;
					}
				}
				else
				{
					Main.grabSky = false;
				}
			}
			float num26 = (float)(Main.screenHeight - 600);
			this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1200.0 + 1190.0);
			float num27 = (float)(this.bgTop - 50);
			if (Main.resetClouds)
			{
				Cloud.resetClouds();
				Main.resetClouds = false;
			}
			if (base.IsActive || Main.netMode != 0)
			{
				Main.windSpeedSpeed += (float)Main.rand.Next(-10, 11) * 0.0001f;
				if (!Main.dayTime)
				{
					Main.windSpeedSpeed += (float)Main.rand.Next(-10, 11) * 0.0002f;
				}
				if ((double)Main.windSpeedSpeed < -0.002)
				{
					Main.windSpeedSpeed = -0.002f;
				}
				if ((double)Main.windSpeedSpeed > 0.002)
				{
					Main.windSpeedSpeed = 0.002f;
				}
				Main.windSpeed += Main.windSpeedSpeed;
				if ((double)Main.windSpeed < -0.3)
				{
					Main.windSpeed = -0.3f;
				}
				if ((double)Main.windSpeed > 0.3)
				{
					Main.windSpeed = 0.3f;
				}
				Main.numClouds += Main.rand.Next(-1, 2);
				if (Main.numClouds < 0)
				{
					Main.numClouds = 0;
				}
				if (Main.numClouds > Main.cloudLimit)
				{
					Main.numClouds = Main.cloudLimit;
				}
			}
			if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
			{
				for (int k = 0; k < 100; k++)
				{
					if (Main.cloud[k].active && Main.cloud[k].scale < 1f)
					{
						Color color2 = Main.cloud[k].cloudColor(Main.bgColor);
						if (num19 < 1f)
						{
							color2.R = (byte)((float)color2.R * num19);
							color2.G = (byte)((float)color2.G * num19);
							color2.B = (byte)((float)color2.B * num19);
							color2.A = (byte)((float)color2.A * num19);
						}
						float num28 = Main.cloud[k].position.Y * ((float)Main.screenHeight / 600f);
						float num29 = (float)((double)(Main.screenPosition.Y / 16f - 24f) / Main.worldSurface);
						if (num29 < 0f)
						{
							num29 = 0f;
						}
						if (num29 > 1f)
						{
							num29 = 1f;
						}
						if (Main.gameMenu)
						{
							num29 = 1f;
						}
						this.spriteBatch.Draw(Main.cloudTexture[Main.cloud[k].type], new Vector2(Main.cloud[k].position.X + (float)Main.cloudTexture[Main.cloud[k].type].Width * 0.5f, num28 + (float)Main.cloudTexture[Main.cloud[k].type].Height * 0.5f + num27), new Rectangle?(new Rectangle(0, 0, Main.cloudTexture[Main.cloud[k].type].Width, Main.cloudTexture[Main.cloud[k].type].Height)), color2, Main.cloud[k].rotation, new Vector2((float)Main.cloudTexture[Main.cloud[k].type].Width * 0.5f, (float)Main.cloudTexture[Main.cloud[k].type].Height * 0.5f), Main.cloud[k].scale, SpriteEffects.None, 0f);
					}
				}
			}
			num19 = 1f;
			float num30 = 1f;
			this.bgParrallax = 0.15;
			int num31 = (int)((float)Main.backgroundWidth[7] * num30);
			Color color3 = Main.bgColor;
			Color color4 = color3;
			if (num19 < 1f)
			{
				color3.R = (byte)((float)color3.R * num19);
				color3.G = (byte)((float)color3.G * num19);
				color3.B = (byte)((float)color3.B * num19);
				color3.A = (byte)((float)color3.A * num19);
			}
			this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
			this.bgLoops = Main.screenWidth / num31 + 2;
			this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1300.0 + 1090.0);
			if (Main.gameMenu)
			{
				this.bgTop = 100;
			}
			if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
			{
				color3 = color4;
				color3.R = (byte)((float)color3.R * Main.bgAlpha2[0]);
				color3.G = (byte)((float)color3.G * Main.bgAlpha2[0]);
				color3.B = (byte)((float)color3.B * Main.bgAlpha2[0]);
				color3.A = (byte)((float)color3.A * Main.bgAlpha2[0]);
				if (Main.bgAlpha2[0] > 0f)
				{
					for (int l = 0; l < this.bgLoops; l++)
					{
						SpriteBatch arg_2884_0 = this.spriteBatch;
						Texture2D arg_2884_1 = Main.backgroundTexture[7];
						Vector2 arg_2884_2 = new Vector2((float)(this.bgStart + num31 * l), (float)this.bgTop);
						Rectangle? arg_2884_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
						Color arg_2884_4 = color3;
						float arg_2884_5 = 0f;
						Vector2 origin = default(Vector2);
						arg_2884_0.Draw(arg_2884_1, arg_2884_2, arg_2884_3, arg_2884_4, arg_2884_5, origin, num30, SpriteEffects.None, 0f);
					}
				}
				color3 = color4;
				color3.R = (byte)((float)color3.R * Main.bgAlpha2[1]);
				color3.G = (byte)((float)color3.G * Main.bgAlpha2[1]);
				color3.B = (byte)((float)color3.B * Main.bgAlpha2[1]);
				color3.A = (byte)((float)color3.A * Main.bgAlpha2[1]);
				if (Main.bgAlpha2[1] > 0f)
				{
					for (int m = 0; m < this.bgLoops; m++)
					{
						SpriteBatch arg_296A_0 = this.spriteBatch;
						Texture2D arg_296A_1 = Main.backgroundTexture[23];
						Vector2 arg_296A_2 = new Vector2((float)(this.bgStart + num31 * m), (float)this.bgTop);
						Rectangle? arg_296A_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
						Color arg_296A_4 = color3;
						float arg_296A_5 = 0f;
						Vector2 origin = default(Vector2);
						arg_296A_0.Draw(arg_296A_1, arg_296A_2, arg_296A_3, arg_296A_4, arg_296A_5, origin, num30, SpriteEffects.None, 0f);
					}
				}
				color3 = color4;
				color3.R = (byte)((float)color3.R * Main.bgAlpha2[2]);
				color3.G = (byte)((float)color3.G * Main.bgAlpha2[2]);
				color3.B = (byte)((float)color3.B * Main.bgAlpha2[2]);
				color3.A = (byte)((float)color3.A * Main.bgAlpha2[2]);
				if (Main.bgAlpha2[2] > 0f)
				{
					for (int n = 0; n < this.bgLoops; n++)
					{
						SpriteBatch arg_2A50_0 = this.spriteBatch;
						Texture2D arg_2A50_1 = Main.backgroundTexture[24];
						Vector2 arg_2A50_2 = new Vector2((float)(this.bgStart + num31 * n), (float)this.bgTop);
						Rectangle? arg_2A50_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
						Color arg_2A50_4 = color3;
						float arg_2A50_5 = 0f;
						Vector2 origin = default(Vector2);
						arg_2A50_0.Draw(arg_2A50_1, arg_2A50_2, arg_2A50_3, arg_2A50_4, arg_2A50_5, origin, num30, SpriteEffects.None, 0f);
					}
				}
			}
			num27 = (float)(this.bgTop - 50);
			if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
			{
				for (int num32 = 0; num32 < 100; num32++)
				{
					if (Main.cloud[num32].active && (double)Main.cloud[num32].scale < 1.15 && Main.cloud[num32].scale >= 1f)
					{
						Color color5 = Main.cloud[num32].cloudColor(Main.bgColor);
						if (num19 < 1f)
						{
							color5.R = (byte)((float)color5.R * num19);
							color5.G = (byte)((float)color5.G * num19);
							color5.B = (byte)((float)color5.B * num19);
							color5.A = (byte)((float)color5.A * num19);
						}
						float num33 = Main.cloud[num32].position.Y * ((float)Main.screenHeight / 600f);
						float num34 = (float)((double)(Main.screenPosition.Y / 16f - 24f) / Main.worldSurface);
						if (num34 < 0f)
						{
							num34 = 0f;
						}
						if (num34 > 1f)
						{
							num34 = 1f;
						}
						if (Main.gameMenu)
						{
							num34 = 1f;
						}
						this.spriteBatch.Draw(Main.cloudTexture[Main.cloud[num32].type], new Vector2(Main.cloud[num32].position.X + (float)Main.cloudTexture[Main.cloud[num32].type].Width * 0.5f, num33 + (float)Main.cloudTexture[Main.cloud[num32].type].Height * 0.5f + num27), new Rectangle?(new Rectangle(0, 0, Main.cloudTexture[Main.cloud[num32].type].Width, Main.cloudTexture[Main.cloud[num32].type].Height)), color5, Main.cloud[num32].rotation, new Vector2((float)Main.cloudTexture[Main.cloud[num32].type].Width * 0.5f, (float)Main.cloudTexture[Main.cloud[num32].type].Height * 0.5f), Main.cloud[num32].scale, SpriteEffects.None, 0f);
					}
				}
			}
			if (Main.holyTiles > 0)
			{
				this.bgParrallax = 0.17;
				num30 = 1.1f;
				num31 = (int)((double)(3500f * num30) * 1.05);
				this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
				this.bgLoops = Main.screenWidth / num31 + 2;
				this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1400.0 + 900.0);
				if (Main.gameMenu)
				{
					this.bgTop = 230;
					this.bgStart -= 500;
				}
				Color color6 = color4;
				float num35 = (float)Main.holyTiles / 400f;
				if (num35 > 0.5f)
				{
					num35 = 0.5f;
				}
				color6.R = (byte)((float)color6.R * num35);
				color6.G = (byte)((float)color6.G * num35);
				color6.B = (byte)((float)color6.B * num35);
				color6.A = (byte)((float)color6.A * num35 * 0.8f);
				if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
				{
					for (int num36 = 0; num36 < this.bgLoops; num36++)
					{
						SpriteBatch arg_2EBD_0 = this.spriteBatch;
						Texture2D arg_2EBD_1 = Main.backgroundTexture[18];
						Vector2 arg_2EBD_2 = new Vector2((float)(this.bgStart + num31 * num36), (float)this.bgTop);
						Rectangle? arg_2EBD_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[18], Main.backgroundHeight[18]));
						Color arg_2EBD_4 = color6;
						float arg_2EBD_5 = 0f;
						Vector2 origin = default(Vector2);
						arg_2EBD_0.Draw(arg_2EBD_1, arg_2EBD_2, arg_2EBD_3, arg_2EBD_4, arg_2EBD_5, origin, num30, SpriteEffects.None, 0f);
						SpriteBatch arg_2F2D_0 = this.spriteBatch;
						Texture2D arg_2F2D_1 = Main.backgroundTexture[19];
						Vector2 arg_2F2D_2 = new Vector2((float)(this.bgStart + num31 * num36 + 1700), (float)(this.bgTop + 100));
						Rectangle? arg_2F2D_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[19], Main.backgroundHeight[19]));
						Color arg_2F2D_4 = color6;
						float arg_2F2D_5 = 0f;
						origin = default(Vector2);
						arg_2F2D_0.Draw(arg_2F2D_1, arg_2F2D_2, arg_2F2D_3, arg_2F2D_4, arg_2F2D_5, origin, num30 * 0.9f, SpriteEffects.None, 0f);
					}
				}
			}
			this.bgParrallax = 0.2;
			num30 = 1.15f;
			num31 = (int)((float)Main.backgroundWidth[7] * num30);
			this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
			this.bgLoops = Main.screenWidth / num31 + 2;
			this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1400.0 + 1260.0);
			if (Main.gameMenu)
			{
				this.bgTop = 230;
				this.bgStart -= 500;
			}
			if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
			{
				color3 = color4;
				color3.R = (byte)((float)color3.R * Main.bgAlpha2[0]);
				color3.G = (byte)((float)color3.G * Main.bgAlpha2[0]);
				color3.B = (byte)((float)color3.B * Main.bgAlpha2[0]);
				color3.A = (byte)((float)color3.A * Main.bgAlpha2[0]);
				if (Main.bgAlpha2[0] > 0f)
				{
					for (int num37 = 0; num37 < this.bgLoops; num37++)
					{
						SpriteBatch arg_30FE_0 = this.spriteBatch;
						Texture2D arg_30FE_1 = Main.backgroundTexture[8];
						Vector2 arg_30FE_2 = new Vector2((float)(this.bgStart + num31 * num37), (float)this.bgTop);
						Rectangle? arg_30FE_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
						Color arg_30FE_4 = color3;
						float arg_30FE_5 = 0f;
						Vector2 origin = default(Vector2);
						arg_30FE_0.Draw(arg_30FE_1, arg_30FE_2, arg_30FE_3, arg_30FE_4, arg_30FE_5, origin, num30, SpriteEffects.None, 0f);
					}
				}
				color3 = color4;
				color3.R = (byte)((float)color3.R * Main.bgAlpha2[1]);
				color3.G = (byte)((float)color3.G * Main.bgAlpha2[1]);
				color3.B = (byte)((float)color3.B * Main.bgAlpha2[1]);
				color3.A = (byte)((float)color3.A * Main.bgAlpha2[1]);
				if (Main.bgAlpha2[1] > 0f)
				{
					for (int num38 = 0; num38 < this.bgLoops; num38++)
					{
						SpriteBatch arg_31E4_0 = this.spriteBatch;
						Texture2D arg_31E4_1 = Main.backgroundTexture[22];
						Vector2 arg_31E4_2 = new Vector2((float)(this.bgStart + num31 * num38), (float)this.bgTop);
						Rectangle? arg_31E4_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
						Color arg_31E4_4 = color3;
						float arg_31E4_5 = 0f;
						Vector2 origin = default(Vector2);
						arg_31E4_0.Draw(arg_31E4_1, arg_31E4_2, arg_31E4_3, arg_31E4_4, arg_31E4_5, origin, num30, SpriteEffects.None, 0f);
					}
				}
				color3 = color4;
				color3.R = (byte)((float)color3.R * Main.bgAlpha2[2]);
				color3.G = (byte)((float)color3.G * Main.bgAlpha2[2]);
				color3.B = (byte)((float)color3.B * Main.bgAlpha2[2]);
				color3.A = (byte)((float)color3.A * Main.bgAlpha2[2]);
				if (Main.bgAlpha2[2] > 0f)
				{
					for (int num39 = 0; num39 < this.bgLoops; num39++)
					{
						SpriteBatch arg_32CA_0 = this.spriteBatch;
						Texture2D arg_32CA_1 = Main.backgroundTexture[25];
						Vector2 arg_32CA_2 = new Vector2((float)(this.bgStart + num31 * num39), (float)this.bgTop);
						Rectangle? arg_32CA_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
						Color arg_32CA_4 = color3;
						float arg_32CA_5 = 0f;
						Vector2 origin = default(Vector2);
						arg_32CA_0.Draw(arg_32CA_1, arg_32CA_2, arg_32CA_3, arg_32CA_4, arg_32CA_5, origin, num30, SpriteEffects.None, 0f);
					}
				}
				color3 = color4;
				color3.R = (byte)((float)color3.R * Main.bgAlpha2[3]);
				color3.G = (byte)((float)color3.G * Main.bgAlpha2[3]);
				color3.B = (byte)((float)color3.B * Main.bgAlpha2[3]);
				color3.A = (byte)((float)color3.A * Main.bgAlpha2[3]);
				if (Main.bgAlpha2[3] > 0f)
				{
					for (int num40 = 0; num40 < this.bgLoops; num40++)
					{
						SpriteBatch arg_33B0_0 = this.spriteBatch;
						Texture2D arg_33B0_1 = Main.backgroundTexture[28];
						Vector2 arg_33B0_2 = new Vector2((float)(this.bgStart + num31 * num40), (float)this.bgTop);
						Rectangle? arg_33B0_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[7], Main.backgroundHeight[7]));
						Color arg_33B0_4 = color3;
						float arg_33B0_5 = 0f;
						Vector2 origin = default(Vector2);
						arg_33B0_0.Draw(arg_33B0_1, arg_33B0_2, arg_33B0_3, arg_33B0_4, arg_33B0_5, origin, num30, SpriteEffects.None, 0f);
					}
				}
			}
			num27 = (float)this.bgTop * 1.01f - 150f;
			if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
			{
				for (int num41 = 0; num41 < 100; num41++)
				{
					if (Main.cloud[num41].active && Main.cloud[num41].scale > num30)
					{
						Color color7 = Main.cloud[num41].cloudColor(Main.bgColor);
						if (num19 < 1f)
						{
							color7.R = (byte)((float)color7.R * num19);
							color7.G = (byte)((float)color7.G * num19);
							color7.B = (byte)((float)color7.B * num19);
							color7.A = (byte)((float)color7.A * num19);
						}
						float num42 = Main.cloud[num41].position.Y * ((float)Main.screenHeight / 600f);
						float num43 = (float)((double)(Main.screenPosition.Y / 16f - 24f) / Main.worldSurface);
						if (num43 < 0f)
						{
							num43 = 0f;
						}
						if (num43 > 1f)
						{
							num43 = 1f;
						}
						if (Main.gameMenu)
						{
							num43 = 1f;
						}
						this.spriteBatch.Draw(Main.cloudTexture[Main.cloud[num41].type], new Vector2(Main.cloud[num41].position.X + (float)Main.cloudTexture[Main.cloud[num41].type].Width * 0.5f, num42 + (float)Main.cloudTexture[Main.cloud[num41].type].Height * 0.5f + num27), new Rectangle?(new Rectangle(0, 0, Main.cloudTexture[Main.cloud[num41].type].Width, Main.cloudTexture[Main.cloud[num41].type].Height)), color7, Main.cloud[num41].rotation, new Vector2((float)Main.cloudTexture[Main.cloud[num41].type].Width * 0.5f, (float)Main.cloudTexture[Main.cloud[num41].type].Height * 0.5f), Main.cloud[num41].scale, SpriteEffects.None, 0f);
					}
				}
			}
			int num44 = Main.bgStyle;
			int num45 = (int)((Main.screenPosition.X + (float)(Main.screenWidth / 2)) / 16f);
			if (num45 < 380 || num45 > Main.maxTilesX - 380)
			{
				num44 = 4;
			}
			else
			{
				if (Main.sandTiles > 1000)
				{
					if (Main.player[Main.myPlayer].zoneEvil)
					{
						num44 = 5;
					}
					else
					{
						if (Main.player[Main.myPlayer].zoneHoly)
						{
							num44 = 5;
						}
						else
						{
							num44 = 2;
						}
					}
				}
				else
				{
					if (Main.player[Main.myPlayer].zoneHoly)
					{
						num44 = 6;
					}
					else
					{
						if (Main.player[Main.myPlayer].zoneEvil)
						{
							num44 = 1;
						}
						else
						{
							if (Main.player[Main.myPlayer].zoneJungle)
							{
								num44 = 3;
							}
							else
							{
								num44 = 0;
							}
						}
					}
				}
			}
			float num46 = 0.05f;
			int num47 = 30;
			if (num44 == 0)
			{
				num47 = 120;
			}
			if (Main.bgDelay < 0)
			{
				Main.bgDelay++;
			}
			else
			{
				if (num44 != Main.bgStyle)
				{
					Main.bgDelay++;
					if (Main.bgDelay > num47)
					{
						Main.bgDelay = -60;
						Main.bgStyle = num44;
						if (num44 == 0)
						{
							Main.bgDelay = 0;
						}
					}
				}
				else
				{
					if (Main.bgDelay > 0)
					{
						Main.bgDelay--;
					}
				}
			}
			if (Main.gameMenu)
			{
				num46 = 0.02f;
				if (!Main.dayTime)
				{
					Main.bgStyle = 1;
				}
				else
				{
					Main.bgStyle = 0;
				}
				num44 = Main.bgStyle;
			}
			if (Main.quickBG > 0)
			{
				Main.quickBG--;
				Main.bgStyle = num44;
				num46 = 1f;
			}
			if (Main.bgStyle == 2)
			{
				Main.bgAlpha2[0] -= num46;
				if (Main.bgAlpha2[0] < 0f)
				{
					Main.bgAlpha2[0] = 0f;
				}
				Main.bgAlpha2[1] += num46;
				if (Main.bgAlpha2[1] > 1f)
				{
					Main.bgAlpha2[1] = 1f;
				}
				Main.bgAlpha2[2] -= num46;
				if (Main.bgAlpha2[2] < 0f)
				{
					Main.bgAlpha2[2] = 0f;
				}
				Main.bgAlpha2[3] -= num46;
				if (Main.bgAlpha2[3] < 0f)
				{
					Main.bgAlpha2[3] = 0f;
				}
			}
			else
			{
				if (Main.bgStyle == 5 || Main.bgStyle == 1 || Main.bgStyle == 6)
				{
					Main.bgAlpha2[0] -= num46;
					if (Main.bgAlpha2[0] < 0f)
					{
						Main.bgAlpha2[0] = 0f;
					}
					Main.bgAlpha2[1] -= num46;
					if (Main.bgAlpha2[1] < 0f)
					{
						Main.bgAlpha2[1] = 0f;
					}
					Main.bgAlpha2[2] += num46;
					if (Main.bgAlpha2[2] > 1f)
					{
						Main.bgAlpha2[2] = 1f;
					}
					Main.bgAlpha2[3] -= num46;
					if (Main.bgAlpha2[3] < 0f)
					{
						Main.bgAlpha2[3] = 0f;
					}
				}
				else
				{
					if (Main.bgStyle == 4)
					{
						Main.bgAlpha2[0] -= num46;
						if (Main.bgAlpha2[0] < 0f)
						{
							Main.bgAlpha2[0] = 0f;
						}
						Main.bgAlpha2[1] -= num46;
						if (Main.bgAlpha2[1] < 0f)
						{
							Main.bgAlpha2[1] = 0f;
						}
						Main.bgAlpha2[2] -= num46;
						if (Main.bgAlpha2[2] < 0f)
						{
							Main.bgAlpha2[2] = 0f;
						}
						Main.bgAlpha2[3] += num46;
						if (Main.bgAlpha2[3] > 1f)
						{
							Main.bgAlpha2[3] = 1f;
						}
					}
					else
					{
						Main.bgAlpha2[0] += num46;
						if (Main.bgAlpha2[0] > 1f)
						{
							Main.bgAlpha2[0] = 1f;
						}
						Main.bgAlpha2[1] -= num46;
						if (Main.bgAlpha2[1] < 0f)
						{
							Main.bgAlpha2[1] = 0f;
						}
						Main.bgAlpha2[2] -= num46;
						if (Main.bgAlpha2[2] < 0f)
						{
							Main.bgAlpha2[2] = 0f;
						}
						Main.bgAlpha2[3] -= num46;
						if (Main.bgAlpha2[3] < 0f)
						{
							Main.bgAlpha2[3] = 0f;
						}
					}
				}
			}
			for (int num48 = 0; num48 < 7; num48++)
			{
				if (Main.bgStyle == num48)
				{
					Main.bgAlpha[num48] += num46;
					if (Main.bgAlpha[num48] > 1f)
					{
						Main.bgAlpha[num48] = 1f;
					}
				}
				else
				{
					Main.bgAlpha[num48] -= num46;
					if (Main.bgAlpha[num48] < 0f)
					{
						Main.bgAlpha[num48] = 0f;
					}
				}
				color3 = color4;
				color3.R = (byte)((float)color3.R * Main.bgAlpha[num48]);
				color3.G = (byte)((float)color3.G * Main.bgAlpha[num48]);
				color3.B = (byte)((float)color3.B * Main.bgAlpha[num48]);
				color3.A = (byte)((float)color3.A * Main.bgAlpha[num48]);
				if (Main.bgAlpha[num48] > 0f && num48 == 3)
				{
					num30 = 1.25f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.4;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1660.0);
					if (Main.gameMenu)
					{
						this.bgTop = 320;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num49 = 0; num49 < this.bgLoops; num49++)
						{
							SpriteBatch arg_3D6B_0 = this.spriteBatch;
							Texture2D arg_3D6B_1 = Main.backgroundTexture[15];
							Vector2 arg_3D6B_2 = new Vector2((float)(this.bgStart + num31 * num49), (float)this.bgTop);
							Rectangle? arg_3D6B_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
							Color arg_3D6B_4 = color3;
							float arg_3D6B_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_3D6B_0.Draw(arg_3D6B_1, arg_3D6B_2, arg_3D6B_3, arg_3D6B_4, arg_3D6B_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
					num30 = 1.31f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.43;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1840.0);
					if (Main.gameMenu)
					{
						this.bgTop = 400;
						this.bgStart -= 80;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num50 = 0; num50 < this.bgLoops; num50++)
						{
							SpriteBatch arg_3EC2_0 = this.spriteBatch;
							Texture2D arg_3EC2_1 = Main.backgroundTexture[16];
							Vector2 arg_3EC2_2 = new Vector2((float)(this.bgStart + num31 * num50), (float)this.bgTop);
							Rectangle? arg_3EC2_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
							Color arg_3EC2_4 = color3;
							float arg_3EC2_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_3EC2_0.Draw(arg_3EC2_1, arg_3EC2_2, arg_3EC2_3, arg_3EC2_4, arg_3EC2_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
					num30 = 1.34f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.49;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2060.0);
					if (Main.gameMenu)
					{
						this.bgTop = 480;
						this.bgStart -= 120;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num51 = 0; num51 < this.bgLoops; num51++)
						{
							SpriteBatch arg_4019_0 = this.spriteBatch;
							Texture2D arg_4019_1 = Main.backgroundTexture[17];
							Vector2 arg_4019_2 = new Vector2((float)(this.bgStart + num31 * num51), (float)this.bgTop);
							Rectangle? arg_4019_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
							Color arg_4019_4 = color3;
							float arg_4019_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_4019_0.Draw(arg_4019_1, arg_4019_2, arg_4019_3, arg_4019_4, arg_4019_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
				}
				if (Main.bgAlpha[num48] > 0f && num48 == 2)
				{
					num30 = 1.25f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.37;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1750.0);
					if (Main.gameMenu)
					{
						this.bgTop = 320;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num52 = 0; num52 < this.bgLoops; num52++)
						{
							SpriteBatch arg_417C_0 = this.spriteBatch;
							Texture2D arg_417C_1 = Main.backgroundTexture[21];
							Vector2 arg_417C_2 = new Vector2((float)(this.bgStart + num31 * num52), (float)this.bgTop);
							Rectangle? arg_417C_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[20]));
							Color arg_417C_4 = color3;
							float arg_417C_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_417C_0.Draw(arg_417C_1, arg_417C_2, arg_417C_3, arg_417C_4, arg_417C_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
					num30 = 1.34f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.49;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2150.0);
					if (Main.gameMenu)
					{
						this.bgTop = 480;
						this.bgStart -= 120;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num53 = 0; num53 < this.bgLoops; num53++)
						{
							SpriteBatch arg_42D4_0 = this.spriteBatch;
							Texture2D arg_42D4_1 = Main.backgroundTexture[20];
							Vector2 arg_42D4_2 = new Vector2((float)(this.bgStart + num31 * num53), (float)this.bgTop);
							Rectangle? arg_42D4_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[20]));
							Color arg_42D4_4 = color3;
							float arg_42D4_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_42D4_0.Draw(arg_42D4_1, arg_42D4_2, arg_42D4_3, arg_42D4_4, arg_42D4_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
				}
				if (Main.bgAlpha[num48] > 0f && num48 == 5)
				{
					num30 = 1.25f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.37;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1750.0);
					if (Main.gameMenu)
					{
						this.bgTop = 320;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num54 = 0; num54 < this.bgLoops; num54++)
						{
							SpriteBatch arg_4437_0 = this.spriteBatch;
							Texture2D arg_4437_1 = Main.backgroundTexture[26];
							Vector2 arg_4437_2 = new Vector2((float)(this.bgStart + num31 * num54), (float)this.bgTop);
							Rectangle? arg_4437_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[20]));
							Color arg_4437_4 = color3;
							float arg_4437_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_4437_0.Draw(arg_4437_1, arg_4437_2, arg_4437_3, arg_4437_4, arg_4437_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
					num30 = 1.34f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.49;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2150.0);
					if (Main.gameMenu)
					{
						this.bgTop = 480;
						this.bgStart -= 120;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num55 = 0; num55 < this.bgLoops; num55++)
						{
							SpriteBatch arg_458F_0 = this.spriteBatch;
							Texture2D arg_458F_1 = Main.backgroundTexture[27];
							Vector2 arg_458F_2 = new Vector2((float)(this.bgStart + num31 * num55), (float)this.bgTop);
							Rectangle? arg_458F_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[20]));
							Color arg_458F_4 = color3;
							float arg_458F_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_458F_0.Draw(arg_458F_1, arg_458F_2, arg_458F_3, arg_458F_4, arg_458F_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
				}
				if (Main.bgAlpha[num48] > 0f && num48 == 1)
				{
					num30 = 1.25f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.4;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0);
					if (Main.gameMenu)
					{
						this.bgTop = 320;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num56 = 0; num56 < this.bgLoops; num56++)
						{
							SpriteBatch arg_46F1_0 = this.spriteBatch;
							Texture2D arg_46F1_1 = Main.backgroundTexture[12];
							Vector2 arg_46F1_2 = new Vector2((float)(this.bgStart + num31 * num56), (float)this.bgTop);
							Rectangle? arg_46F1_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
							Color arg_46F1_4 = color3;
							float arg_46F1_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_46F1_0.Draw(arg_46F1_1, arg_46F1_2, arg_46F1_3, arg_46F1_4, arg_46F1_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
					num30 = 1.31f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.43;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0);
					if (Main.gameMenu)
					{
						this.bgTop = 400;
						this.bgStart -= 80;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num57 = 0; num57 < this.bgLoops; num57++)
						{
							SpriteBatch arg_4848_0 = this.spriteBatch;
							Texture2D arg_4848_1 = Main.backgroundTexture[13];
							Vector2 arg_4848_2 = new Vector2((float)(this.bgStart + num31 * num57), (float)this.bgTop);
							Rectangle? arg_4848_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
							Color arg_4848_4 = color3;
							float arg_4848_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_4848_0.Draw(arg_4848_1, arg_4848_2, arg_4848_3, arg_4848_4, arg_4848_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
					num30 = 1.34f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.49;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0);
					if (Main.gameMenu)
					{
						this.bgTop = 480;
						this.bgStart -= 120;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num58 = 0; num58 < this.bgLoops; num58++)
						{
							SpriteBatch arg_499F_0 = this.spriteBatch;
							Texture2D arg_499F_1 = Main.backgroundTexture[14];
							Vector2 arg_499F_2 = new Vector2((float)(this.bgStart + num31 * num58), (float)this.bgTop);
							Rectangle? arg_499F_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
							Color arg_499F_4 = color3;
							float arg_499F_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_499F_0.Draw(arg_499F_1, arg_499F_2, arg_499F_3, arg_499F_4, arg_499F_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
				}
				if (Main.bgAlpha[num48] > 0f && num48 == 6)
				{
					num30 = 1.25f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.4;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0);
					if (Main.gameMenu)
					{
						this.bgTop = 320;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num59 = 0; num59 < this.bgLoops; num59++)
						{
							SpriteBatch arg_4B01_0 = this.spriteBatch;
							Texture2D arg_4B01_1 = Main.backgroundTexture[29];
							Vector2 arg_4B01_2 = new Vector2((float)(this.bgStart + num31 * num59), (float)this.bgTop);
							Rectangle? arg_4B01_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
							Color arg_4B01_4 = color3;
							float arg_4B01_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_4B01_0.Draw(arg_4B01_1, arg_4B01_2, arg_4B01_3, arg_4B01_4, arg_4B01_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
					num30 = 1.31f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.43;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0);
					if (Main.gameMenu)
					{
						this.bgTop = 400;
						this.bgStart -= 80;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num60 = 0; num60 < this.bgLoops; num60++)
						{
							SpriteBatch arg_4C58_0 = this.spriteBatch;
							Texture2D arg_4C58_1 = Main.backgroundTexture[30];
							Vector2 arg_4C58_2 = new Vector2((float)(this.bgStart + num31 * num60), (float)this.bgTop);
							Rectangle? arg_4C58_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
							Color arg_4C58_4 = color3;
							float arg_4C58_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_4C58_0.Draw(arg_4C58_1, arg_4C58_2, arg_4C58_3, arg_4C58_4, arg_4C58_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
					num30 = 1.34f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.49;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0);
					if (Main.gameMenu)
					{
						this.bgTop = 480;
						this.bgStart -= 120;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num61 = 0; num61 < this.bgLoops; num61++)
						{
							SpriteBatch arg_4DAF_0 = this.spriteBatch;
							Texture2D arg_4DAF_1 = Main.backgroundTexture[31];
							Vector2 arg_4DAF_2 = new Vector2((float)(this.bgStart + num31 * num61), (float)this.bgTop);
							Rectangle? arg_4DAF_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
							Color arg_4DAF_4 = color3;
							float arg_4DAF_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_4DAF_0.Draw(arg_4DAF_1, arg_4DAF_2, arg_4DAF_3, arg_4DAF_4, arg_4DAF_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
				}
				if (Main.bgAlpha[num48] > 0f && num48 == 0)
				{
					num30 = 1.25f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.4;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0);
					if (Main.gameMenu)
					{
						this.bgTop = 320;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num62 = 0; num62 < this.bgLoops; num62++)
						{
							SpriteBatch arg_4F10_0 = this.spriteBatch;
							Texture2D arg_4F10_1 = Main.backgroundTexture[9];
							Vector2 arg_4F10_2 = new Vector2((float)(this.bgStart + num31 * num62), (float)this.bgTop);
							Rectangle? arg_4F10_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
							Color arg_4F10_4 = color3;
							float arg_4F10_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_4F10_0.Draw(arg_4F10_1, arg_4F10_2, arg_4F10_3, arg_4F10_4, arg_4F10_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
					num30 = 1.31f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.43;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0);
					if (Main.gameMenu)
					{
						this.bgTop = 400;
						this.bgStart -= 80;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num63 = 0; num63 < this.bgLoops; num63++)
						{
							SpriteBatch arg_5067_0 = this.spriteBatch;
							Texture2D arg_5067_1 = Main.backgroundTexture[10];
							Vector2 arg_5067_2 = new Vector2((float)(this.bgStart + num31 * num63), (float)this.bgTop);
							Rectangle? arg_5067_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
							Color arg_5067_4 = color3;
							float arg_5067_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_5067_0.Draw(arg_5067_1, arg_5067_2, arg_5067_3, arg_5067_4, arg_5067_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
					num30 = 1.34f;
					num31 = (int)((float)Main.backgroundWidth[8] * num30);
					this.bgParrallax = 0.49;
					this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)num31) - (double)(num31 / 2));
					this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + num26 / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0);
					if (Main.gameMenu)
					{
						this.bgTop = 480;
						this.bgStart -= 120;
					}
					this.bgLoops = Main.screenWidth / num31 + 2;
					if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
					{
						for (int num64 = 0; num64 < this.bgLoops; num64++)
						{
							SpriteBatch arg_51BE_0 = this.spriteBatch;
							Texture2D arg_51BE_1 = Main.backgroundTexture[11];
							Vector2 arg_51BE_2 = new Vector2((float)(this.bgStart + num31 * num64), (float)this.bgTop);
							Rectangle? arg_51BE_3 = new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[8], Main.backgroundHeight[8]));
							Color arg_51BE_4 = color3;
							float arg_51BE_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_51BE_0.Draw(arg_51BE_1, arg_51BE_2, arg_51BE_3, arg_51BE_4, arg_51BE_5, origin, num30, SpriteEffects.None, 0f);
						}
					}
				}
			}
			if (Main.gameMenu || Main.netMode == 2)
			{
				this.DrawMenu();
				return;
			}
			this.firstTileX = (int)(Main.screenPosition.X / 16f - 1f);
			this.lastTileX = (int)((Main.screenPosition.X + (float)Main.screenWidth) / 16f) + 2;
			this.firstTileY = (int)(Main.screenPosition.Y / 16f - 1f);
			this.lastTileY = (int)((Main.screenPosition.Y + (float)Main.screenHeight) / 16f) + 2;
			if (this.firstTileX < 0)
			{
				this.firstTileX = 0;
			}
			if (this.lastTileX > Main.maxTilesX)
			{
				this.lastTileX = Main.maxTilesX;
			}
			if (this.firstTileY < 0)
			{
				this.firstTileY = 0;
			}
			if (this.lastTileY > Main.maxTilesY)
			{
				this.lastTileY = Main.maxTilesY;
			}
			if (!Main.drawSkip)
			{
				Lighting.LightTiles(this.firstTileX, this.lastTileX, this.firstTileY, this.lastTileY);
			}
			Color arg_52EA_0 = Color.White;
			if (Main.drawToScreen)
			{
				this.DrawWater(true);
			}
			else
			{
				this.spriteBatch.Draw(this.backWaterTarget, Main.sceneBackgroundPos - Main.screenPosition, Color.White);
			}
			float x = (Main.sceneBackgroundPos.X - Main.screenPosition.X + (float)Main.offScreenRange) * Main.caveParrallax - (float)Main.offScreenRange;
			if (Main.drawToScreen)
			{
				this.DrawBackground();
			}
			else
			{
				this.spriteBatch.Draw(this.backgroundTarget, new Vector2(x, Main.sceneBackgroundPos.Y - Main.screenPosition.Y), Color.White);
			}
			Main.magmaBGFrameCounter++;
			if (Main.magmaBGFrameCounter >= 8)
			{
				Main.magmaBGFrameCounter = 0;
				Main.magmaBGFrame++;
				if (Main.magmaBGFrame >= 3)
				{
					Main.magmaBGFrame = 0;
				}
			}
			try
			{
				if (Main.drawToScreen)
				{
					this.DrawBlack();
					this.DrawWalls();
				}
				else
				{
					this.spriteBatch.Draw(this.blackTarget, Main.sceneTilePos - Main.screenPosition, Color.White);
					this.spriteBatch.Draw(this.wallTarget, Main.sceneWallPos - Main.screenPosition, Color.White);
				}
				this.DrawWoF();
				if (Main.player[Main.myPlayer].detectCreature)
				{
					if (Main.drawToScreen)
					{
						this.DrawTiles(false);
						this.DrawTiles(true);
					}
					else
					{
						this.spriteBatch.Draw(this.tile2Target, Main.sceneTile2Pos - Main.screenPosition, Color.White);
						this.spriteBatch.Draw(this.tileTarget, Main.sceneTilePos - Main.screenPosition, Color.White);
					}
					this.DrawGore();
					this.DrawNPCs(true);
					this.DrawNPCs(false);
				}
				else
				{
					if (Main.drawToScreen)
					{
						this.DrawTiles(false);
						this.DrawNPCs(true);
						this.DrawTiles(true);
					}
					else
					{
						this.spriteBatch.Draw(this.tile2Target, Main.sceneTile2Pos - Main.screenPosition, Color.White);
						this.DrawNPCs(true);
						this.spriteBatch.Draw(this.tileTarget, Main.sceneTilePos - Main.screenPosition, Color.White);
					}
					this.DrawGore();
					this.DrawNPCs(false);
				}
			}
			catch
			{
			}
			for (int num65 = 0; num65 < 1000; num65++)
			{
				if (Main.projectile[num65].active && Main.projectile[num65].type > 0 && !Main.projectile[num65].hide)
				{
					this.DrawProj(num65);
				}
			}
			for (int num66 = 0; num66 < 255; num66++)
			{
				if (Main.player[num66].active)
				{
					if (Main.player[num66].ghost)
					{
						Vector2 position = Main.player[num66].position;
						Main.player[num66].position = Main.player[num66].shadowPos[0];
						Main.player[num66].shadow = 0.5f;
						this.DrawGhost(Main.player[num66]);
						Main.player[num66].position = Main.player[num66].shadowPos[1];
						Main.player[num66].shadow = 0.7f;
						this.DrawGhost(Main.player[num66]);
						Main.player[num66].position = Main.player[num66].shadowPos[2];
						Main.player[num66].shadow = 0.9f;
						this.DrawGhost(Main.player[num66]);
						Main.player[num66].position = position;
						Main.player[num66].shadow = 0f;
						this.DrawGhost(Main.player[num66]);
					}
					else
					{
						bool flag2 = false;
						bool flag3 = false;
						if (Main.player[num66].head == 5 && Main.player[num66].body == 5 && Main.player[num66].legs == 5)
						{
							flag2 = true;
						}
						if (Main.player[num66].head == 7 && Main.player[num66].body == 7 && Main.player[num66].legs == 7)
						{
							flag2 = true;
						}
						if (Main.player[num66].head == 22 && Main.player[num66].body == 14 && Main.player[num66].legs == 14)
						{
							flag2 = true;
						}
						if (Main.player[num66].body == 17 && Main.player[num66].legs == 16 && (Main.player[num66].head == 29 || Main.player[num66].head == 30 || Main.player[num66].head == 31))
						{
							flag2 = true;
						}
						if (Main.player[num66].body == 19 && Main.player[num66].legs == 18 && (Main.player[num66].head == 35 || Main.player[num66].head == 36 || Main.player[num66].head == 37))
						{
							flag3 = true;
						}
						if (Main.player[num66].body == 24 && Main.player[num66].legs == 23)
						{
							flag3 = true;
							flag2 = true;
						}
						if (flag3)
						{
							Vector2 position2 = Main.player[num66].position;
							if (!Main.gamePaused)
							{
								Main.player[num66].ghostFade += Main.player[num66].ghostDir * 0.075f;
							}
							if ((double)Main.player[num66].ghostFade < 0.1)
							{
								Main.player[num66].ghostDir = 1f;
								Main.player[num66].ghostFade = 0.1f;
							}
							if ((double)Main.player[num66].ghostFade > 0.9)
							{
								Main.player[num66].ghostDir = -1f;
								Main.player[num66].ghostFade = 0.9f;
							}
							Main.player[num66].position.X = position2.X - Main.player[num66].ghostFade * 5f;
							Main.player[num66].shadow = Main.player[num66].ghostFade;
							this.DrawPlayer(Main.player[num66]);
							Main.player[num66].position.X = position2.X + Main.player[num66].ghostFade * 5f;
							Main.player[num66].shadow = Main.player[num66].ghostFade;
							this.DrawPlayer(Main.player[num66]);
							Main.player[num66].position = position2;
							Main.player[num66].position.Y = position2.Y - Main.player[num66].ghostFade * 5f;
							Main.player[num66].shadow = Main.player[num66].ghostFade;
							this.DrawPlayer(Main.player[num66]);
							Main.player[num66].position.Y = position2.Y + Main.player[num66].ghostFade * 5f;
							Main.player[num66].shadow = Main.player[num66].ghostFade;
							this.DrawPlayer(Main.player[num66]);
							Main.player[num66].position = position2;
							Main.player[num66].shadow = 0f;
						}
						if (flag2)
						{
							Vector2 position3 = Main.player[num66].position;
							Main.player[num66].position = Main.player[num66].shadowPos[0];
							Main.player[num66].shadow = 0.5f;
							this.DrawPlayer(Main.player[num66]);
							Main.player[num66].position = Main.player[num66].shadowPos[1];
							Main.player[num66].shadow = 0.7f;
							this.DrawPlayer(Main.player[num66]);
							Main.player[num66].position = Main.player[num66].shadowPos[2];
							Main.player[num66].shadow = 0.9f;
							this.DrawPlayer(Main.player[num66]);
							Main.player[num66].position = position3;
							Main.player[num66].shadow = 0f;
						}
						this.DrawPlayer(Main.player[num66]);
					}
				}
			}
			if (!Main.gamePaused)
			{
				Main.essScale += (float)Main.essDir * 0.01f;
				if (Main.essScale > 1f)
				{
					Main.essDir = -1;
					Main.essScale = 1f;
				}
				if ((double)Main.essScale < 0.7)
				{
					Main.essDir = 1;
					Main.essScale = 0.7f;
				}
			}
			for (int num67 = 0; num67 < 200; num67++)
			{
				if (Main.item[num67].active && Main.item[num67].type > 0)
				{
					int arg_5C51_0 = (int)((double)Main.item[num67].position.X + (double)Main.item[num67].width * 0.5) / 16;
					int arg_5C57_0 = Lighting.offScreenTiles;
					int arg_5C88_0 = (int)((double)Main.item[num67].position.Y + (double)Main.item[num67].height * 0.5) / 16;
					int arg_5C8E_0 = Lighting.offScreenTiles;
					Color color8 = Lighting.GetColor((int)((double)Main.item[num67].position.X + (double)Main.item[num67].width * 0.5) / 16, (int)((double)Main.item[num67].position.Y + (double)Main.item[num67].height * 0.5) / 16);
					Color color9;
					if (!Main.gamePaused && base.IsActive && ((Main.item[num67].type >= 71 && Main.item[num67].type <= 74) || Main.item[num67].type == 58 || Main.item[num67].type == 109) && color8.R > 60)
					{
						float num68 = (float)Main.rand.Next(500) - (Math.Abs(Main.item[num67].velocity.X) + Math.Abs(Main.item[num67].velocity.Y)) * 10f;
						if (num68 < (float)(color8.R / 50))
						{
							Vector2 arg_5DFE_0 = Main.item[num67].position;
							int arg_5DFE_1 = Main.item[num67].width;
							int arg_5DFE_2 = Main.item[num67].height;
							int arg_5DFE_3 = 43;
							float arg_5DFE_4 = 0f;
							float arg_5DFE_5 = 0f;
							int arg_5DFE_6 = 254;
							color9 = default(Color);
							int num69 = Dust.NewDust(arg_5DFE_0, arg_5DFE_1, arg_5DFE_2, arg_5DFE_3, arg_5DFE_4, arg_5DFE_5, arg_5DFE_6, color9, 0.5f);
							Dust expr_5E0D = Main.dust[num69];
							expr_5E0D.velocity *= 0f;
						}
					}
					float rotation3 = Main.item[num67].velocity.X * 0.2f;
					float num70 = 1f;
					Color alpha = Main.item[num67].GetAlpha(color8);
					if (Main.item[num67].type == 520 || Main.item[num67].type == 521 || Main.item[num67].type == 547 || Main.item[num67].type == 548 || Main.item[num67].type == 549)
					{
						num70 = Main.essScale;
						alpha.R = (byte)((float)alpha.R * num70);
						alpha.G = (byte)((float)alpha.G * num70);
						alpha.B = (byte)((float)alpha.B * num70);
						alpha.A = (byte)((float)alpha.A * num70);
					}
					else
					{
						if (Main.item[num67].type == 58 || Main.item[num67].type == 184)
						{
							num70 = Main.essScale * 0.25f + 0.75f;
							alpha.R = (byte)((float)alpha.R * num70);
							alpha.G = (byte)((float)alpha.G * num70);
							alpha.B = (byte)((float)alpha.B * num70);
							alpha.A = (byte)((float)alpha.A * num70);
						}
					}
					float num71 = (float)(Main.item[num67].height - Main.itemTexture[Main.item[num67].type].Height);
					float num72 = (float)(Main.item[num67].width / 2 - Main.itemTexture[Main.item[num67].type].Width / 2);
					this.spriteBatch.Draw(Main.itemTexture[Main.item[num67].type], new Vector2(Main.item[num67].position.X - Main.screenPosition.X + (float)(Main.itemTexture[Main.item[num67].type].Width / 2) + num72, Main.item[num67].position.Y - Main.screenPosition.Y + (float)(Main.itemTexture[Main.item[num67].type].Height / 2) + num71 + 2f), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.item[num67].type].Width, Main.itemTexture[Main.item[num67].type].Height)), alpha, rotation3, new Vector2((float)(Main.itemTexture[Main.item[num67].type].Width / 2), (float)(Main.itemTexture[Main.item[num67].type].Height / 2)), num70, SpriteEffects.None, 0f);
					Color arg_6125_0 = Main.item[num67].color;
					color9 = default(Color);
					if (arg_6125_0 != color9)
					{
						this.spriteBatch.Draw(Main.itemTexture[Main.item[num67].type], new Vector2(Main.item[num67].position.X - Main.screenPosition.X + (float)(Main.itemTexture[Main.item[num67].type].Width / 2) + num72, Main.item[num67].position.Y - Main.screenPosition.Y + (float)(Main.itemTexture[Main.item[num67].type].Height / 2) + num71 + 2f), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.item[num67].type].Width, Main.itemTexture[Main.item[num67].type].Height)), Main.item[num67].GetColor(color8), rotation3, new Vector2((float)(Main.itemTexture[Main.item[num67].type].Width / 2), (float)(Main.itemTexture[Main.item[num67].type].Height / 2)), num70, SpriteEffects.None, 0f);
					}
				}
			}
			Rectangle value2 = new Rectangle((int)Main.screenPosition.X - 50, (int)Main.screenPosition.Y - 50, Main.screenWidth + 100, Main.screenHeight + 100);
			for (int num73 = 0; num73 < Main.numDust; num73++)
			{
				if (Main.dust[num73].active)
				{
					if (new Rectangle((int)Main.dust[num73].position.X, (int)Main.dust[num73].position.Y, 4, 4).Intersects(value2))
					{
						Color color10 = Lighting.GetColor((int)((double)Main.dust[num73].position.X + 4.0) / 16, (int)((double)Main.dust[num73].position.Y + 4.0) / 16);
						if (Main.dust[num73].type == 6 || Main.dust[num73].type == 15 || Main.dust[num73].noLight || (Main.dust[num73].type >= 59 && Main.dust[num73].type <= 64))
						{
							color10 = Color.White;
						}
						color10 = Main.dust[num73].GetAlpha(color10);
						this.spriteBatch.Draw(Main.dustTexture, Main.dust[num73].position - Main.screenPosition, new Rectangle?(Main.dust[num73].frame), color10, Main.dust[num73].rotation, new Vector2(4f, 4f), Main.dust[num73].scale, SpriteEffects.None, 0f);
						Color arg_6430_0 = Main.dust[num73].color;
						Color color9 = default(Color);
						if (arg_6430_0 != color9)
						{
							this.spriteBatch.Draw(Main.dustTexture, Main.dust[num73].position - Main.screenPosition, new Rectangle?(Main.dust[num73].frame), Main.dust[num73].GetColor(color10), Main.dust[num73].rotation, new Vector2(4f, 4f), Main.dust[num73].scale, SpriteEffects.None, 0f);
						}
						if (color10 == Color.Black)
						{
							Main.dust[num73].active = false;
						}
					}
					else
					{
						Main.dust[num73].active = false;
					}
				}
			}
			if (Main.drawToScreen)
			{
				this.DrawWater(false);
				if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].mech)
				{
					this.DrawWires();
				}
			}
			else
			{
				this.spriteBatch.Draw(this.waterTarget, Main.sceneWaterPos - Main.screenPosition, Color.White);
			}
			if (!Main.hideUI)
			{
				for (int num74 = 0; num74 < 255; num74++)
				{
					if (Main.player[num74].active && Main.player[num74].chatShowTime > 0 && num74 != Main.myPlayer && !Main.player[num74].dead)
					{
						Vector2 vector = Main.fontMouseText.MeasureString(Main.player[num74].chatText);
						Vector2 vector2;
						vector2.X = Main.player[num74].position.X + (float)(Main.player[num74].width / 2) - vector.X / 2f;
						vector2.Y = Main.player[num74].position.Y - vector.Y - 2f;
						for (int num75 = 0; num75 < 5; num75++)
						{
							int num76 = 0;
							int num77 = 0;
							Color black = Color.Black;
							if (num75 == 0)
							{
								num76 = -2;
							}
							if (num75 == 1)
							{
								num76 = 2;
							}
							if (num75 == 2)
							{
								num77 = -2;
							}
							if (num75 == 3)
							{
								num77 = 2;
							}
							if (num75 == 4)
							{
								black = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
							}
							SpriteBatch arg_66D7_0 = this.spriteBatch;
							SpriteFont arg_66D7_1 = Main.fontMouseText;
							string arg_66D7_2 = Main.player[num74].chatText;
							Vector2 arg_66D7_3 = new Vector2(vector2.X + (float)num76 - Main.screenPosition.X, vector2.Y + (float)num77 - Main.screenPosition.Y);
							Color arg_66D7_4 = black;
							float arg_66D7_5 = 0f;
							Vector2 origin = default(Vector2);
							arg_66D7_0.DrawString(arg_66D7_1, arg_66D7_2, arg_66D7_3, arg_66D7_4, arg_66D7_5, origin, 1f, SpriteEffects.None, 0f);
						}
					}
				}
				for (int num78 = 0; num78 < 100; num78++)
				{
					if (Main.combatText[num78].active)
					{
						int num79 = 0;
						if (Main.combatText[num78].crit)
						{
							num79 = 1;
						}
						Vector2 vector3 = Main.fontCombatText[num79].MeasureString(Main.combatText[num78].text);
						Vector2 origin2 = new Vector2(vector3.X * 0.5f, vector3.Y * 0.5f);
						float arg_6775_0 = Main.combatText[num78].scale;
						float num80 = (float)Main.combatText[num78].color.R;
						float num81 = (float)Main.combatText[num78].color.G;
						float num82 = (float)Main.combatText[num78].color.B;
						float num83 = (float)Main.combatText[num78].color.A;
						num80 *= Main.combatText[num78].scale * Main.combatText[num78].alpha * 0.3f;
						num82 *= Main.combatText[num78].scale * Main.combatText[num78].alpha * 0.3f;
						num81 *= Main.combatText[num78].scale * Main.combatText[num78].alpha * 0.3f;
						num83 *= Main.combatText[num78].scale * Main.combatText[num78].alpha;
						Color color11 = new Color((int)num80, (int)num81, (int)num82, (int)num83);
						for (int num84 = 0; num84 < 5; num84++)
						{
							int num85 = 0;
							int num86 = 0;
							if (num84 == 0)
							{
								num85--;
							}
							else
							{
								if (num84 == 1)
								{
									num85++;
								}
								else
								{
									if (num84 == 2)
									{
										num86--;
									}
									else
									{
										if (num84 == 3)
										{
											num86++;
										}
										else
										{
											num80 = (float)Main.combatText[num78].color.R * Main.combatText[num78].scale * Main.combatText[num78].alpha;
											num82 = (float)Main.combatText[num78].color.B * Main.combatText[num78].scale * Main.combatText[num78].alpha;
											num81 = (float)Main.combatText[num78].color.G * Main.combatText[num78].scale * Main.combatText[num78].alpha;
											num83 = (float)Main.combatText[num78].color.A * Main.combatText[num78].scale * Main.combatText[num78].alpha;
											color11 = new Color((int)num80, (int)num81, (int)num82, (int)num83);
										}
									}
								}
							}
							this.spriteBatch.DrawString(Main.fontCombatText[num79], Main.combatText[num78].text, new Vector2(Main.combatText[num78].position.X - Main.screenPosition.X + (float)num85 + origin2.X, Main.combatText[num78].position.Y - Main.screenPosition.Y + (float)num86 + origin2.Y), color11, Main.combatText[num78].rotation, origin2, Main.combatText[num78].scale, SpriteEffects.None, 0f);
						}
					}
				}
				for (int num87 = 0; num87 < 20; num87++)
				{
					if (Main.itemText[num87].active)
					{
						string text = Main.itemText[num87].name;
						if (Main.itemText[num87].stack > 1)
						{
							text = string.Concat(new object[]
							{
								text, 
								" (", 
								Main.itemText[num87].stack, 
								")"
							});
						}
						Vector2 vector4 = Main.fontMouseText.MeasureString(text);
						Vector2 origin3 = new Vector2(vector4.X * 0.5f, vector4.Y * 0.5f);
						float arg_6AFF_0 = Main.itemText[num87].scale;
						float num88 = (float)Main.itemText[num87].color.R;
						float num89 = (float)Main.itemText[num87].color.G;
						float num90 = (float)Main.itemText[num87].color.B;
						float num91 = (float)Main.itemText[num87].color.A;
						num88 *= Main.itemText[num87].scale * Main.itemText[num87].alpha * 0.3f;
						num90 *= Main.itemText[num87].scale * Main.itemText[num87].alpha * 0.3f;
						num89 *= Main.itemText[num87].scale * Main.itemText[num87].alpha * 0.3f;
						num91 *= Main.itemText[num87].scale * Main.itemText[num87].alpha;
						Color color12 = new Color((int)num88, (int)num89, (int)num90, (int)num91);
						for (int num92 = 0; num92 < 5; num92++)
						{
							int num93 = 0;
							int num94 = 0;
							if (num92 == 0)
							{
								num93 -= 2;
							}
							else
							{
								if (num92 == 1)
								{
									num93 += 2;
								}
								else
								{
									if (num92 == 2)
									{
										num94 -= 2;
									}
									else
									{
										if (num92 == 3)
										{
											num94 += 2;
										}
										else
										{
											num88 = (float)Main.itemText[num87].color.R * Main.itemText[num87].scale * Main.itemText[num87].alpha;
											num90 = (float)Main.itemText[num87].color.B * Main.itemText[num87].scale * Main.itemText[num87].alpha;
											num89 = (float)Main.itemText[num87].color.G * Main.itemText[num87].scale * Main.itemText[num87].alpha;
											num91 = (float)Main.itemText[num87].color.A * Main.itemText[num87].scale * Main.itemText[num87].alpha;
											color12 = new Color((int)num88, (int)num89, (int)num90, (int)num91);
										}
									}
								}
							}
							if (num92 < 4)
							{
								num91 = (float)Main.itemText[num87].color.A * Main.itemText[num87].scale * Main.itemText[num87].alpha;
								color12 = new Color(0, 0, 0, (int)num91);
							}
							this.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2(Main.itemText[num87].position.X - Main.screenPosition.X + (float)num93 + origin3.X, Main.itemText[num87].position.Y - Main.screenPosition.Y + (float)num94 + origin3.Y), color12, Main.itemText[num87].rotation, origin3, Main.itemText[num87].scale, SpriteEffects.None, 0f);
						}
					}
				}
				if (Main.netMode == 1 && Netplay.clientSock.statusText != "" && Netplay.clientSock.statusText != null)
				{
					string text2 = string.Concat(new object[]
					{
						Netplay.clientSock.statusText, 
						": ", 
						(int)((float)Netplay.clientSock.statusCount / (float)Netplay.clientSock.statusMax * 100f), 
						"%"
					});
					SpriteBatch arg_6F09_0 = this.spriteBatch;
					SpriteFont arg_6F09_1 = Main.fontMouseText;
					string arg_6F09_2 = text2;
					Vector2 arg_6F09_3 = new Vector2(628f - Main.fontMouseText.MeasureString(text2).X * 0.5f + (float)(Main.screenWidth - 800), 84f);
					Color arg_6F09_4 = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
					float arg_6F09_5 = 0f;
					Vector2 origin = default(Vector2);
					arg_6F09_0.DrawString(arg_6F09_1, arg_6F09_2, arg_6F09_3, arg_6F09_4, arg_6F09_5, origin, 1f, SpriteEffects.None, 0f);
				}
				this.DrawFPS();
				this.DrawInterface();
			}
			else
			{
				Main.maxQ = true;
			}
			this.spriteBatch.End();
			if (Main.mouseLeft)
			{
				Main.mouseLeftRelease = false;
			}
			else
			{
				Main.mouseLeftRelease = true;
			}
			if (Main.mouseRight)
			{
				Main.mouseRightRelease = false;
			}
			else
			{
				Main.mouseRightRelease = true;
			}
			if (Main.mouseState.RightButton != ButtonState.Pressed)
			{
				Main.stackSplit = 0;
			}
			if (Main.stackSplit > 0)
			{
				Main.stackSplit--;
			}
			if (Main.renderCount < 10)
			{
				Main.drawTimer[Main.renderCount] = (float)stopwatch.ElapsedMilliseconds;
				if (Main.drawTimerMaxDelay[Main.renderCount] > 0f)
				{
					Main.drawTimerMaxDelay[Main.renderCount] -= 1f;
				}
				else
				{
					Main.drawTimerMax[Main.renderCount] = 0f;
				}
				if (Main.drawTimer[Main.renderCount] > Main.drawTimerMax[Main.renderCount])
				{
					Main.drawTimerMax[Main.renderCount] = Main.drawTimer[Main.renderCount];
					Main.drawTimerMaxDelay[Main.renderCount] = 100f;
				}
			}
		}
		private static void UpdateInvasion()
		{
			if (Main.invasionDefeat)
			{
				Main.invasionDefeat = false;
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i].active && ((Main.npc[i].type >= 26 && Main.npc[i].type <= 29) || Main.npc[i].type == 111))
					{
						Main.invasionDefeat = true;
					}
				}
				if (!Main.invasionDefeat)
				{
					Main.InvasionWarning();
					NPC.downedGoblins = true;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
				}
			}
			if (Main.invasionType > 0)
			{
				if (Main.invasionSize <= 0)
				{
					Main.invasionType = 0;
					Main.invasionDelay = 7;
					Main.invasionDefeat = true;
				}
				else
				{
					Main.invasionDefeat = false;
				}
				if (Main.invasionX == (double)Main.spawnTileX)
				{
					return;
				}
				float num = 0.4f;
				if (Main.invasionX > (double)Main.spawnTileX)
				{
					Main.invasionX -= (double)num;
					if (Main.invasionX <= (double)Main.spawnTileX)
					{
						Main.invasionX = (double)Main.spawnTileX;
						Main.InvasionWarning();
					}
					else
					{
						Main.invasionWarn--;
					}
				}
				else
				{
					if (Main.invasionX < (double)Main.spawnTileX)
					{
						Main.invasionX += (double)num;
						if (Main.invasionX >= (double)Main.spawnTileX)
						{
							Main.invasionX = (double)Main.spawnTileX;
							Main.InvasionWarning();
						}
						else
						{
							Main.invasionWarn--;
						}
					}
				}
				if (Main.invasionWarn <= 0)
				{
					Main.invasionWarn = 3600;
					Main.InvasionWarning();
				}
			}
		}
		private static void InvasionWarning()
		{
			string text = "";
			if (Main.invasionSize <= 0)
			{
				text = "The goblin army has been defeated!";
			}
			else
			{
				if (Main.invasionX < (double)Main.spawnTileX)
				{
					text = "A goblin army is approaching from the west!";
				}
				else
				{
					if (Main.invasionX > (double)Main.spawnTileX)
					{
						text = "A goblin army is approaching from the east!";
					}
					else
					{
						text = "The goblin army has arrived!";
					}
				}
			}
			if (Main.netMode == 0)
			{
				Main.NewText(text, 175, 75, 255);
				return;
			}
			if (Main.netMode == 2)
			{
				NetMessage.SendData(25, -1, -1, text, 255, 175f, 75f, 255f, 0);
			}
		}
		public static void StartInvasion()
		{
			if (Main.invasionType == 0 && Main.invasionDelay == 0)
			{
				int num = 0;
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active && Main.player[i].statLifeMax >= 200)
					{
						num++;
					}
				}
				if (num > 0)
				{
					Main.invasionType = 1;
					Main.invasionSize = 80 + 40 * num;
					Main.invasionWarn = 0;
					if (Main.rand.Next(2) == 0)
					{
						Main.invasionX = 0.0;
						return;
					}
					Main.invasionX = (double)Main.maxTilesX;
				}
			}
		}
		private static void UpdateClient()
		{
			if (Main.myPlayer == 255)
			{
				Netplay.disconnect = true;
			}
			Main.netPlayCounter++;
			if (Main.netPlayCounter > 3600)
			{
				Main.netPlayCounter = 0;
			}
			if (Math.IEEERemainder((double)Main.netPlayCounter, 300.0) == 0.0)
			{
				NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
			}
			if (Math.IEEERemainder((double)Main.netPlayCounter, 600.0) == 0.0)
			{
				NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
				NetMessage.SendData(40, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
			}
			if (Netplay.clientSock.active)
			{
				Netplay.clientSock.timeOut++;
				if (!Main.stopTimeOuts && Netplay.clientSock.timeOut > 60 * Main.timeOut)
				{
					Main.statusText = "Connection timed out";
					Netplay.disconnect = true;
				}
			}
			for (int i = 0; i < 200; i++)
			{
				if (Main.item[i].active && Main.item[i].owner == Main.myPlayer)
				{
					Main.item[i].FindOwner(i);
				}
			}
		}
		private static void UpdateServer()
		{
			Main.netPlayCounter++;
			if (Main.netPlayCounter > 3600)
			{
				NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
				NetMessage.syncPlayers();
				Main.netPlayCounter = 0;
			}
			for (int i = 0; i < Main.maxNetPlayers; i++)
			{
				if (Main.player[i].active && Netplay.serverSock[i].active)
				{
					Netplay.serverSock[i].SpamUpdate();
				}
			}
			if (Math.IEEERemainder((double)Main.netPlayCounter, 900.0) == 0.0)
			{
				bool flag = true;
				int num = Main.lastItemUpdate;
				int num2 = 0;
				while (flag)
				{
					num++;
					if (num >= 200)
					{
						num = 0;
					}
					num2++;
					if (!Main.item[num].active || Main.item[num].owner == 255)
					{
						NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
					}
					if (num2 >= Main.maxItemUpdates || num == Main.lastItemUpdate)
					{
						flag = false;
					}
				}
				Main.lastItemUpdate = num;
			}
			for (int j = 0; j < 200; j++)
			{
				if (Main.item[j].active && (Main.item[j].owner == 255 || !Main.player[Main.item[j].owner].active))
				{
					Main.item[j].FindOwner(j);
				}
			}
			for (int k = 0; k < 255; k++)
			{
				if (Netplay.serverSock[k].active)
				{
					Netplay.serverSock[k].timeOut++;
					if (!Main.stopTimeOuts && Netplay.serverSock[k].timeOut > 60 * Main.timeOut)
					{
						Netplay.serverSock[k].kill = true;
					}
				}
				if (Main.player[k].active)
				{
					int sectionX = Netplay.GetSectionX((int)(Main.player[k].position.X / 16f));
					int sectionY = Netplay.GetSectionY((int)(Main.player[k].position.Y / 16f));
					int num3 = 0;
					for (int l = sectionX - 1; l < sectionX + 2; l++)
					{
						for (int m = sectionY - 1; m < sectionY + 2; m++)
						{
							if (l >= 0 && l < Main.maxSectionsX && m >= 0 && m < Main.maxSectionsY && !Netplay.serverSock[k].tileSection[l, m])
							{
								num3++;
							}
						}
					}
					if (num3 > 0)
					{
						int num4 = num3 * 150;
						NetMessage.SendData(9, k, -1, "Receiving tile data", num4, 0f, 0f, 0f, 0);
						Netplay.serverSock[k].statusText2 = "is receiving tile data";
						Netplay.serverSock[k].statusMax += num4;
						for (int n = sectionX - 1; n < sectionX + 2; n++)
						{
							for (int num5 = sectionY - 1; num5 < sectionY + 2; num5++)
							{
								if (n >= 0 && n < Main.maxSectionsX && num5 >= 0 && num5 < Main.maxSectionsY && !Netplay.serverSock[k].tileSection[n, num5])
								{
									NetMessage.SendSection(k, n, num5);
									NetMessage.SendData(11, k, -1, "", n, (float)num5, (float)n, (float)num5, 0);
								}
							}
						}
					}
				}
			}
		}
		public static void NewText(string newText, byte R = 255, byte G = 255, byte B = 255)
		{
			for (int i = Main.numChatLines - 1; i > 0; i--)
			{
				Main.chatLine[i].text = Main.chatLine[i - 1].text;
				Main.chatLine[i].showTime = Main.chatLine[i - 1].showTime;
				Main.chatLine[i].color = Main.chatLine[i - 1].color;
			}
			if (R == 0 && G == 0 && B == 0)
			{
				Main.chatLine[0].color = Color.White;
			}
			else
			{
				Main.chatLine[0].color = new Color((int)R, (int)G, (int)B);
			}
			Main.chatLine[0].text = newText;
			Main.chatLine[0].showTime = Main.chatLength;
			Main.PlaySound(12, -1, -1, 1);
		}
		private static void UpdateTime()
		{
			Main.time += (double)Main.dayRate;
			if (!Main.dayTime)
			{
				if (WorldGen.spawnEye && Main.netMode != 1 && Main.time > 4860.0)
				{
					for (int i = 0; i < 255; i++)
					{
						if (Main.player[i].active && !Main.player[i].dead && (double)Main.player[i].position.Y < Main.worldSurface * 16.0)
						{
							NPC.SpawnOnPlayer(i, 4);
							WorldGen.spawnEye = false;
							break;
						}
					}
				}
				if (Main.time > 32400.0)
				{
					if (Main.invasionDelay > 0)
					{
						Main.invasionDelay--;
					}
					WorldGen.spawnNPC = 0;
					Main.checkForSpawns = 0;
					Main.time = 0.0;
					Main.bloodMoon = false;
					Main.dayTime = true;
					Main.moonPhase++;
					if (Main.moonPhase >= 8)
					{
						Main.moonPhase = 0;
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
						WorldGen.saveAndPlay();
					}
					if (Main.netMode != 1 && WorldGen.shadowOrbSmashed)
					{
						if (!NPC.downedGoblins)
						{
							if (Main.rand.Next(3) == 0)
							{
								Main.StartInvasion();
							}
						}
						else
						{
							if (Main.rand.Next(15) == 0)
							{
								Main.StartInvasion();
							}
						}
					}
				}
				if (Main.time > 16200.0 && WorldGen.spawnMeteor)
				{
					WorldGen.spawnMeteor = false;
					WorldGen.dropMeteor();
					return;
				}
			}
			else
			{
				Main.bloodMoon = false;
				if (Main.time > 54000.0)
				{
					WorldGen.spawnNPC = 0;
					Main.checkForSpawns = 0;
					if (Main.rand.Next(50) == 0 && Main.netMode != 1 && WorldGen.shadowOrbSmashed)
					{
						WorldGen.spawnMeteor = true;
					}
					if (!NPC.downedBoss1 && Main.netMode != 1)
					{
						bool flag = false;
						for (int j = 0; j < 255; j++)
						{
							if (Main.player[j].active && Main.player[j].statLifeMax >= 200 && Main.player[j].statDefense > 10)
							{
								flag = true;
								break;
							}
						}
						if (flag && Main.rand.Next(3) == 0)
						{
							int num = 0;
							for (int k = 0; k < 200; k++)
							{
								if (Main.npc[k].active && Main.npc[k].townNPC)
								{
									num++;
								}
							}
							if (num >= 4)
							{
								WorldGen.spawnEye = true;
								if (Main.netMode == 0)
								{
									Main.NewText("You feel an evil presence watching you...", 50, 255, 130);
								}
								else
								{
									if (Main.netMode == 2)
									{
										NetMessage.SendData(25, -1, -1, "You feel an evil presence watching you...", 255, 50f, 255f, 130f, 0);
									}
								}
							}
						}
					}
					if (!WorldGen.spawnEye && Main.moonPhase != 4 && Main.rand.Next(9) == 0 && Main.netMode != 1)
					{
						for (int l = 0; l < 255; l++)
						{
							if (Main.player[l].active && Main.player[l].statLifeMax > 120)
							{
								Main.bloodMoon = true;
								break;
							}
						}
						if (Main.bloodMoon)
						{
							if (Main.netMode == 0)
							{
								Main.NewText("The Blood Moon is rising...", 50, 255, 130);
							}
							else
							{
								if (Main.netMode == 2)
								{
									NetMessage.SendData(25, -1, -1, "The Blood Moon is rising...", 255, 50f, 255f, 130f, 0);
								}
							}
						}
					}
					Main.time = 0.0;
					Main.dayTime = false;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
					}
				}
				if (Main.netMode != 1)
				{
					Main.checkForSpawns++;
					if (Main.checkForSpawns >= 7200)
					{
						int num2 = 0;
						for (int m = 0; m < 255; m++)
						{
							if (Main.player[m].active)
							{
								num2++;
							}
						}
						Main.checkForSpawns = 0;
						WorldGen.spawnNPC = 0;
						int num3 = 0;
						int num4 = 0;
						int num5 = 0;
						int num6 = 0;
						int num7 = 0;
						int num8 = 0;
						int num9 = 0;
						int num10 = 0;
						int num11 = 0;
						int num12 = 0;
						int num13 = 0;
						int num14 = 0;
						for (int n = 0; n < 200; n++)
						{
							if (Main.npc[n].active && Main.npc[n].townNPC)
							{
								if (Main.npc[n].type != 37 && !Main.npc[n].homeless)
								{
									WorldGen.QuickFindHome(n);
								}
								if (Main.npc[n].type == 37)
								{
									num8++;
								}
								if (Main.npc[n].type == 17)
								{
									num3++;
								}
								if (Main.npc[n].type == 18)
								{
									num4++;
								}
								if (Main.npc[n].type == 19)
								{
									num6++;
								}
								if (Main.npc[n].type == 20)
								{
									num5++;
								}
								if (Main.npc[n].type == 22)
								{
									num7++;
								}
								if (Main.npc[n].type == 38)
								{
									num9++;
								}
								if (Main.npc[n].type == 54)
								{
									num10++;
								}
								if (Main.npc[n].type == 107)
								{
									num12++;
								}
								if (Main.npc[n].type == 108)
								{
									num11++;
								}
								if (Main.npc[n].type == 124)
								{
									num13++;
								}
								num14++;
							}
						}
						if (WorldGen.spawnNPC == 0)
						{
							int num15 = 0;
							bool flag2 = false;
							int num16 = 0;
							bool flag3 = false;
							bool flag4 = false;
							for (int num17 = 0; num17 < 255; num17++)
							{
								if (Main.player[num17].active)
								{
									for (int num18 = 0; num18 < 48; num18++)
									{
										if (Main.player[num17].inventory[num18] != null & Main.player[num17].inventory[num18].stack > 0)
										{
											if (Main.player[num17].inventory[num18].type == 71)
											{
												num15 += Main.player[num17].inventory[num18].stack;
											}
											if (Main.player[num17].inventory[num18].type == 72)
											{
												num15 += Main.player[num17].inventory[num18].stack * 100;
											}
											if (Main.player[num17].inventory[num18].type == 73)
											{
												num15 += Main.player[num17].inventory[num18].stack * 10000;
											}
											if (Main.player[num17].inventory[num18].type == 74)
											{
												num15 += Main.player[num17].inventory[num18].stack * 1000000;
											}
											if (Main.player[num17].inventory[num18].ammo == 14 || Main.player[num17].inventory[num18].useAmmo == 14)
											{
												flag3 = true;
											}
											if (Main.player[num17].inventory[num18].type == 166 || Main.player[num17].inventory[num18].type == 167 || Main.player[num17].inventory[num18].type == 168 || Main.player[num17].inventory[num18].type == 235)
											{
												flag4 = true;
											}
										}
									}
									int num19 = Main.player[num17].statLifeMax / 20;
									if (num19 > 5)
									{
										flag2 = true;
									}
									num16 += num19;
								}
							}
							if (!NPC.downedBoss3 && num8 == 0)
							{
								int num20 = NPC.NewNPC(Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37, 0);
								Main.npc[num20].homeless = false;
								Main.npc[num20].homeTileX = Main.dungeonX;
								Main.npc[num20].homeTileY = Main.dungeonY;
							}
							if (WorldGen.spawnNPC == 0 && num7 < 1)
							{
								WorldGen.spawnNPC = 22;
							}
							if (WorldGen.spawnNPC == 0 && (double)num15 > 5000.0 && num3 < 1)
							{
								WorldGen.spawnNPC = 17;
							}
							if (WorldGen.spawnNPC == 0 && flag2 && num4 < 1)
							{
								WorldGen.spawnNPC = 18;
							}
							if (WorldGen.spawnNPC == 0 && flag3 && num6 < 1)
							{
								WorldGen.spawnNPC = 19;
							}
							if (WorldGen.spawnNPC == 0 && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num5 < 1)
							{
								WorldGen.spawnNPC = 20;
							}
							if (WorldGen.spawnNPC == 0 && flag4 && num3 > 0 && num9 < 1)
							{
								WorldGen.spawnNPC = 38;
							}
							if (WorldGen.spawnNPC == 0 && NPC.downedBoss3 && num10 < 1)
							{
								WorldGen.spawnNPC = 54;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedGoblin && num12 < 1)
							{
								WorldGen.spawnNPC = 107;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedWizard && num11 < 1)
							{
								WorldGen.spawnNPC = 108;
							}
							if (WorldGen.spawnNPC == 0 && NPC.savedMech && num13 < 1)
							{
								WorldGen.spawnNPC = 124;
							}
						}
					}
				}
			}
		}
		public static int DamageVar(float dmg)
		{
			float num = dmg * (1f + (float)Main.rand.Next(-15, 16) * 0.01f);
			return (int)Math.Round((double)num);
		}
		public static double CalculateDamage(int Damage, int Defense)
		{
			double num = (double)Damage - (double)Defense * 0.5;
			if (num < 1.0)
			{
				num = 1.0;
			}
			return num;
		}
		public static void PlaySound(int type, int x = -1, int y = -1, int Style = 1)
		{
			int num = Style;
			try
			{
				if (!Main.dedServ)
				{
					if (Main.soundVolume != 0f)
					{
						bool flag = false;
						float num2 = 1f;
						float num3 = 0f;
						if (x == -1 || y == -1)
						{
							flag = true;
						}
						else
						{
							if (WorldGen.gen)
							{
								return;
							}
							if (Main.netMode == 2)
							{
								return;
							}
							Rectangle value = new Rectangle((int)(Main.screenPosition.X - (float)(Main.screenWidth * 2)), (int)(Main.screenPosition.Y - (float)(Main.screenHeight * 2)), Main.screenWidth * 5, Main.screenHeight * 5);
							Rectangle rectangle = new Rectangle(x, y, 1, 1);
							Vector2 vector = new Vector2(Main.screenPosition.X + (float)Main.screenWidth * 0.5f, Main.screenPosition.Y + (float)Main.screenHeight * 0.5f);
							if (rectangle.Intersects(value))
							{
								flag = true;
							}
							if (flag)
							{
								num3 = ((float)x - vector.X) / ((float)Main.screenWidth * 0.5f);
								float num4 = Math.Abs((float)x - vector.X);
								float num5 = Math.Abs((float)y - vector.Y);
								float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
								num2 = 1f - num6 / ((float)Main.screenWidth * 1.5f);
							}
						}
						if (num3 < -1f)
						{
							num3 = -1f;
						}
						if (num3 > 1f)
						{
							num3 = 1f;
						}
						if (num2 > 1f)
						{
							num2 = 1f;
						}
						if (num2 > 0f)
						{
							if (flag)
							{
								num2 *= Main.soundVolume;
								if (type == 0)
								{
									int num7 = Main.rand.Next(3);
									Main.soundInstanceDig[num7].Stop();
									Main.soundInstanceDig[num7] = Main.soundDig[num7].CreateInstance();
									Main.soundInstanceDig[num7].Volume = num2;
									Main.soundInstanceDig[num7].Pan = num3;
									Main.soundInstanceDig[num7].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
									Main.soundInstanceDig[num7].Play();
								}
								else
								{
									if (type == 1)
									{
										int num8 = Main.rand.Next(3);
										Main.soundInstancePlayerHit[num8].Stop();
										Main.soundInstancePlayerHit[num8] = Main.soundPlayerHit[num8].CreateInstance();
										Main.soundInstancePlayerHit[num8].Volume = num2;
										Main.soundInstancePlayerHit[num8].Pan = num3;
										Main.soundInstancePlayerHit[num8].Play();
									}
									else
									{
										if (type == 2)
										{
											if (num == 1)
											{
												int num9 = Main.rand.Next(3);
												if (num9 == 1)
												{
													num = 18;
												}
												if (num9 == 2)
												{
													num = 19;
												}
											}
											if (num != 9 && num != 10 && num != 24 && num != 26 && num != 34)
											{
												Main.soundInstanceItem[num].Stop();
											}
											Main.soundInstanceItem[num] = Main.soundItem[num].CreateInstance();
											Main.soundInstanceItem[num].Volume = num2;
											Main.soundInstanceItem[num].Pan = num3;
											Main.soundInstanceItem[num].Pitch = (float)Main.rand.Next(-6, 7) * 0.01f;
											if (num == 26 || num == 35)
											{
												Main.soundInstanceItem[num].Volume = num2 * 0.75f;
												Main.soundInstanceItem[num].Pitch = Main.harpNote;
											}
											Main.soundInstanceItem[num].Play();
										}
										else
										{
											if (type == 3)
											{
												Main.soundInstanceNPCHit[num].Stop();
												Main.soundInstanceNPCHit[num] = Main.soundNPCHit[num].CreateInstance();
												Main.soundInstanceNPCHit[num].Volume = num2;
												Main.soundInstanceNPCHit[num].Pan = num3;
												Main.soundInstanceNPCHit[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
												Main.soundInstanceNPCHit[num].Play();
											}
											else
											{
												if (type == 4)
												{
													if (num != 10 || Main.soundInstanceNPCKilled[num].State != SoundState.Playing)
													{
														Main.soundInstanceNPCKilled[num] = Main.soundNPCKilled[num].CreateInstance();
														Main.soundInstanceNPCKilled[num].Volume = num2;
														Main.soundInstanceNPCKilled[num].Pan = num3;
														Main.soundInstanceNPCKilled[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
														Main.soundInstanceNPCKilled[num].Play();
													}
												}
												else
												{
													if (type == 5)
													{
														Main.soundInstancePlayerKilled.Stop();
														Main.soundInstancePlayerKilled = Main.soundPlayerKilled.CreateInstance();
														Main.soundInstancePlayerKilled.Volume = num2;
														Main.soundInstancePlayerKilled.Pan = num3;
														Main.soundInstancePlayerKilled.Play();
													}
													else
													{
														if (type == 6)
														{
															Main.soundInstanceGrass.Stop();
															Main.soundInstanceGrass = Main.soundGrass.CreateInstance();
															Main.soundInstanceGrass.Volume = num2;
															Main.soundInstanceGrass.Pan = num3;
															Main.soundInstanceGrass.Pitch = (float)Main.rand.Next(-30, 31) * 0.01f;
															Main.soundInstanceGrass.Play();
														}
														else
														{
															if (type == 7)
															{
																Main.soundInstanceGrab.Stop();
																Main.soundInstanceGrab = Main.soundGrab.CreateInstance();
																Main.soundInstanceGrab.Volume = num2;
																Main.soundInstanceGrab.Pan = num3;
																Main.soundInstanceGrab.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																Main.soundInstanceGrab.Play();
															}
															else
															{
																if (type == 8)
																{
																	Main.soundInstanceDoorOpen.Stop();
																	Main.soundInstanceDoorOpen = Main.soundDoorOpen.CreateInstance();
																	Main.soundInstanceDoorOpen.Volume = num2;
																	Main.soundInstanceDoorOpen.Pan = num3;
																	Main.soundInstanceDoorOpen.Pitch = (float)Main.rand.Next(-20, 21) * 0.01f;
																	Main.soundInstanceDoorOpen.Play();
																}
																else
																{
																	if (type == 9)
																	{
																		Main.soundInstanceDoorClosed.Stop();
																		Main.soundInstanceDoorClosed = Main.soundDoorClosed.CreateInstance();
																		Main.soundInstanceDoorClosed.Volume = num2;
																		Main.soundInstanceDoorClosed.Pan = num3;
																		Main.soundInstanceDoorOpen.Pitch = (float)Main.rand.Next(-20, 21) * 0.01f;
																		Main.soundInstanceDoorClosed.Play();
																	}
																	else
																	{
																		if (type == 10)
																		{
																			Main.soundInstanceMenuOpen.Stop();
																			Main.soundInstanceMenuOpen = Main.soundMenuOpen.CreateInstance();
																			Main.soundInstanceMenuOpen.Volume = num2;
																			Main.soundInstanceMenuOpen.Pan = num3;
																			Main.soundInstanceMenuOpen.Play();
																		}
																		else
																		{
																			if (type == 11)
																			{
																				Main.soundInstanceMenuClose.Stop();
																				Main.soundInstanceMenuClose = Main.soundMenuClose.CreateInstance();
																				Main.soundInstanceMenuClose.Volume = num2;
																				Main.soundInstanceMenuClose.Pan = num3;
																				Main.soundInstanceMenuClose.Play();
																			}
																			else
																			{
																				if (type == 12)
																				{
																					Main.soundInstanceMenuTick.Stop();
																					Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
																					Main.soundInstanceMenuTick.Volume = num2;
																					Main.soundInstanceMenuTick.Pan = num3;
																					Main.soundInstanceMenuTick.Play();
																				}
																				else
																				{
																					if (type == 13)
																					{
																						Main.soundInstanceShatter.Stop();
																						Main.soundInstanceShatter = Main.soundShatter.CreateInstance();
																						Main.soundInstanceShatter.Volume = num2;
																						Main.soundInstanceShatter.Pan = num3;
																						Main.soundInstanceShatter.Play();
																					}
																					else
																					{
																						if (type == 14)
																						{
																							int num10 = Main.rand.Next(3);
																							Main.soundInstanceZombie[num10] = Main.soundZombie[num10].CreateInstance();
																							Main.soundInstanceZombie[num10].Volume = num2 * 0.4f;
																							Main.soundInstanceZombie[num10].Pan = num3;
																							Main.soundInstanceZombie[num10].Play();
																						}
																						else
																						{
																							if (type == 15)
																							{
																								if (Main.soundInstanceRoar[num].State == SoundState.Stopped)
																								{
																									Main.soundInstanceRoar[num] = Main.soundRoar[num].CreateInstance();
																									Main.soundInstanceRoar[num].Volume = num2;
																									Main.soundInstanceRoar[num].Pan = num3;
																									Main.soundInstanceRoar[num].Play();
																								}
																							}
																							else
																							{
																								if (type == 16)
																								{
																									Main.soundInstanceDoubleJump.Stop();
																									Main.soundInstanceDoubleJump = Main.soundDoubleJump.CreateInstance();
																									Main.soundInstanceDoubleJump.Volume = num2;
																									Main.soundInstanceDoubleJump.Pan = num3;
																									Main.soundInstanceDoubleJump.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																									Main.soundInstanceDoubleJump.Play();
																								}
																								else
																								{
																									if (type == 17)
																									{
																										Main.soundInstanceRun.Stop();
																										Main.soundInstanceRun = Main.soundRun.CreateInstance();
																										Main.soundInstanceRun.Volume = num2;
																										Main.soundInstanceRun.Pan = num3;
																										Main.soundInstanceRun.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																										Main.soundInstanceRun.Play();
																									}
																									else
																									{
																										if (type == 18)
																										{
																											Main.soundInstanceCoins = Main.soundCoins.CreateInstance();
																											Main.soundInstanceCoins.Volume = num2;
																											Main.soundInstanceCoins.Pan = num3;
																											Main.soundInstanceCoins.Play();
																										}
																										else
																										{
																											if (type == 19)
																											{
																												if (Main.soundInstanceSplash[num].State == SoundState.Stopped)
																												{
																													Main.soundInstanceSplash[num] = Main.soundSplash[num].CreateInstance();
																													Main.soundInstanceSplash[num].Volume = num2;
																													Main.soundInstanceSplash[num].Pan = num3;
																													Main.soundInstanceSplash[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																													Main.soundInstanceSplash[num].Play();
																												}
																											}
																											else
																											{
																												if (type == 20)
																												{
																													int num11 = Main.rand.Next(3);
																													Main.soundInstanceFemaleHit[num11].Stop();
																													Main.soundInstanceFemaleHit[num11] = Main.soundFemaleHit[num11].CreateInstance();
																													Main.soundInstanceFemaleHit[num11].Volume = num2;
																													Main.soundInstanceFemaleHit[num11].Pan = num3;
																													Main.soundInstanceFemaleHit[num11].Play();
																												}
																												else
																												{
																													if (type == 21)
																													{
																														int num12 = Main.rand.Next(3);
																														Main.soundInstanceTink[num12].Stop();
																														Main.soundInstanceTink[num12] = Main.soundTink[num12].CreateInstance();
																														Main.soundInstanceTink[num12].Volume = num2;
																														Main.soundInstanceTink[num12].Pan = num3;
																														Main.soundInstanceTink[num12].Play();
																													}
																													else
																													{
																														if (type == 22)
																														{
																															Main.soundInstanceUnlock.Stop();
																															Main.soundInstanceUnlock = Main.soundUnlock.CreateInstance();
																															Main.soundInstanceUnlock.Volume = num2;
																															Main.soundInstanceUnlock.Pan = num3;
																															Main.soundInstanceUnlock.Play();
																														}
																														else
																														{
																															if (type == 23)
																															{
																																Main.soundInstanceDrown.Stop();
																																Main.soundInstanceDrown = Main.soundDrown.CreateInstance();
																																Main.soundInstanceDrown.Volume = num2;
																																Main.soundInstanceDrown.Pan = num3;
																																Main.soundInstanceDrown.Play();
																															}
																															else
																															{
																																if (type == 24)
																																{
																																	Main.soundInstanceChat = Main.soundChat.CreateInstance();
																																	Main.soundInstanceChat.Volume = num2;
																																	Main.soundInstanceChat.Pan = num3;
																																	Main.soundInstanceChat.Play();
																																}
																																else
																																{
																																	if (type == 25)
																																	{
																																		Main.soundInstanceMaxMana = Main.soundMaxMana.CreateInstance();
																																		Main.soundInstanceMaxMana.Volume = num2;
																																		Main.soundInstanceMaxMana.Pan = num3;
																																		Main.soundInstanceMaxMana.Play();
																																	}
																																	else
																																	{
																																		if (type == 26)
																																		{
																																			int num13 = Main.rand.Next(3, 5);
																																			Main.soundInstanceZombie[num13] = Main.soundZombie[num13].CreateInstance();
																																			Main.soundInstanceZombie[num13].Volume = num2 * 0.9f;
																																			Main.soundInstanceZombie[num13].Pan = num3;
																																			Main.soundInstanceSplash[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																																			Main.soundInstanceZombie[num13].Play();
																																		}
																																		else
																																		{
																																			if (type == 27)
																																			{
																																				if (Main.soundInstancePixie.State == SoundState.Playing)
																																				{
																																					Main.soundInstancePixie.Volume = num2;
																																					Main.soundInstancePixie.Pan = num3;
																																					Main.soundInstancePixie.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																																				}
																																				else
																																				{
																																					Main.soundInstancePixie.Stop();
																																					Main.soundInstancePixie = Main.soundPixie.CreateInstance();
																																					Main.soundInstancePixie.Volume = num2;
																																					Main.soundInstancePixie.Pan = num3;
																																					Main.soundInstancePixie.Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																																					Main.soundInstancePixie.Play();
																																				}
																																			}
																																			else
																																			{
																																				if (type == 28)
																																				{
																																					if (Main.soundInstanceMech[num].State != SoundState.Playing)
																																					{
																																						Main.soundInstanceMech[num] = Main.soundMech[num].CreateInstance();
																																						Main.soundInstanceMech[num].Volume = num2;
																																						Main.soundInstanceMech[num].Pan = num3;
																																						Main.soundInstanceMech[num].Pitch = (float)Main.rand.Next(-10, 11) * 0.01f;
																																						Main.soundInstanceMech[num].Play();
																																					}
																																				}
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			catch
			{
			}
		}
	}
}
