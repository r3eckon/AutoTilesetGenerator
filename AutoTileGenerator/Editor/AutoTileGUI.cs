using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

namespace AutoTileGenerator.Scripts
{
    public class AutoTileGUI : EditorWindow
    {

        

        public int currentTileSize = 128;
        public string currentFile = "";
        public string currentSaveFolder = "";
        public Texture2D myImage;
        public byte[] temp;
        public Texture2D tile;
        public string currentPrefix = "AutoTile_";


        [MenuItem("Window/AutoTileset Generator")]
        public static void Init()
        {
            AutoTileGUI window = (AutoTileGUI)EditorWindow.GetWindow(typeof(AutoTileGUI));
            window.titleContent.text = "AutoTileset Generator";
            window.Show();
        }

        void OnGUI()
        {

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Step 1 : Set Tile Size");

            EditorGUILayout.Space();

            currentTileSize = EditorGUILayout.IntField("Tile Size : ", currentTileSize);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Step 2 : Open Atlas / AutoTile File");

            EditorGUILayout.Space();

            if (GUILayout.Button("Open Atlas Image ( PNG )"))
            {
                currentFile = EditorUtility.OpenFilePanel("Open Atlas Image...", Application.dataPath, "png");

                if (!string.IsNullOrEmpty(currentFile))
                {
                    temp = File.ReadAllBytes(currentFile);
                    
                    myImage = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                    myImage.filterMode = FilterMode.Point;
                    myImage.wrapMode = TextureWrapMode.Clamp;
                    myImage.LoadImage(temp,false);


                }
            }

            EditorGUILayout.TextField("Current File : ", currentFile);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Step 3 : Generate AutoTileset!");

            EditorGUILayout.Space();

            currentPrefix = EditorGUILayout.TextField("File Prefix ( Optional ) : ", currentPrefix);


            EditorGUI.BeginDisabledGroup(string.IsNullOrEmpty(currentFile));

            if(GUILayout.Button("Build Tileset to Folder..." ))
            {

                currentSaveFolder = EditorUtility.OpenFolderPanel("Select Folder...", Application.dataPath, "");

                AutoTileUtilities.latestAutoTilesetTexturePaths = new string[AutoTileUtilities.TypeCount];

                for(byte i = 0; i < AutoTileUtilities.TypeCount; i++)
                {
                    tile = AutoTileUtilities.GetAutoTile(AutoTileUtilities.BakePositions(AutoTileUtilities.AutoTileValueToFragments(AutoTileUtilities.TileTypeOffsetToAutoTileValue(i))), myImage, currentTileSize, currentTileSize);

                    AutoTileUtilities.latestAutoTilesetPrefix = currentPrefix;
                    AutoTileUtilities.latestAutoTilesetTexturePaths[i] = currentSaveFolder + "/" + currentPrefix + i + ".png";

                    File.WriteAllBytes(AutoTileUtilities.latestAutoTilesetTexturePaths[i], tile.EncodeToPNG());

                }

                AssetDatabase.Refresh();

            }

            EditorGUI.EndDisabledGroup();
            

        }
    }
}

