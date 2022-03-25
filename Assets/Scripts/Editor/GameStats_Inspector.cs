using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UIElements;

[CustomEditor(typeof(GameStats))]
public class GameStats_Inspector : Editor
{
    public enum DisplayCategoryEnemy
    {
        LEVEL_1, LEVEL_2, LEVEL_3
    }

    public DisplayCategoryEnemy categoryToDisplayEnemy;

    GameStats gameStats;
    public override VisualElement CreateInspectorGUI()
    {
        gameStats = (GameStats)target;


        // Create a new VisualElement to be the root of our inspector UI
        VisualElement myInspector = new VisualElement();

        // Add a simple label
        myInspector.Add(new Label("This is a custom inspector"));

        // Return the finished inspector UI
        //return myInspector;
        return base.CreateInspectorGUI();
    }

    public override void OnInspectorGUI()
    {

        //Bat spawn section
        {
            GUILayout.BeginVertical();
            GUILayout.Label("Bat Spawn Section");
            EditorGUILayout.Space();
            GUILayout.BeginVertical();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("spawnPointBat"));
            GUILayout.EndVertical();
            gameStats.bat = (GameObject)EditorGUILayout.ObjectField("Bat:", gameStats.bat, typeof(GameObject), true);
            if (GUILayout.Button("Spawn Bat"))
            {
               
                if (GUILayout.Button("SpawnBat"))
                {
                    Instantiate(gameStats.e1, gameStats.spawnPointBat, Quaternion.identity);
                }
            }
            
            
            GUILayout.EndVertical();
        }

        //Enemy spawn section
        {

            GUILayout.BeginVertical();
            GUILayout.Label("Enemy Spawn Section");
            EditorGUILayout.Space();
            GUILayout.BeginVertical();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("spawnPointEnemy"));
            GUILayout.EndVertical();
            categoryToDisplayEnemy = (DisplayCategoryEnemy)EditorGUILayout.EnumPopup("Select Level", categoryToDisplayEnemy);
            switch (categoryToDisplayEnemy)
            {
                case DisplayCategoryEnemy.LEVEL_1:
                    {
                        GUILayout.BeginHorizontal();
                        gameStats.e1 = (GameObject)EditorGUILayout.ObjectField("EnemyType1:", gameStats.e1, typeof(GameObject), true);
                        if (GUILayout.Button("SpawnLeft1"))
                        {
                            Instantiate(gameStats.e1, gameStats.spawnPointEnemy, Quaternion.identity);
                        }
                        if (GUILayout.Button("SpawnRight1"))
                        {
                            GameObject enemy = Instantiate(gameStats.e1, gameStats.spawnPointEnemy, Quaternion.identity);
                            enemy.GetComponent<EnemyCharacter>().direction = -1;
                        }
                        GUILayout.EndHorizontal();

                        GUILayout.BeginHorizontal();

                        gameStats.e2 = (GameObject)EditorGUILayout.ObjectField("EnemyType2:", gameStats.e2, typeof(GameObject), true);
                        if (GUILayout.Button("SpawnLeft2"))
                        {
                            Instantiate(gameStats.e2, gameStats.spawnPointEnemy, Quaternion.identity);
                        }
                        if (GUILayout.Button("SpawnRight2"))
                        {
                            GameObject enemy = Instantiate(gameStats.e2, gameStats.spawnPointEnemy, Quaternion.identity);
                            enemy.GetComponent<EnemyCharacter>().direction = -1;
                        }
                        GUILayout.EndHorizontal();

                        GUILayout.BeginHorizontal();
                        gameStats.e3 = (GameObject)EditorGUILayout.ObjectField("EnemyType3:", gameStats.e3, typeof(GameObject), true);
                        if (GUILayout.Button("SpawnLeft3"))
                        {
                            Instantiate(gameStats.e3, gameStats.spawnPointEnemy, Quaternion.identity);
                        }
                        if (GUILayout.Button("SpawnRight3"))
                        {
                            GameObject enemy = Instantiate(gameStats.e3, gameStats.spawnPointEnemy, Quaternion.identity);
                            enemy.GetComponent<EnemyCharacter>().direction = -1;
                        }
                        GUILayout.EndHorizontal();
                        break;
                    }
                case DisplayCategoryEnemy.LEVEL_2:
                    {
                        GUILayout.BeginHorizontal();
                        gameStats.e4 = (GameObject)EditorGUILayout.ObjectField("EnemyType1:", gameStats.e4, typeof(GameObject), true);
                        if (GUILayout.Button("SpawnLeft1"))
                        {
                            Instantiate(gameStats.e4, gameStats.spawnPointEnemy, Quaternion.identity);
                        }
                        if (GUILayout.Button("SpawnRight1"))
                        {
                            GameObject enemy = Instantiate(gameStats.e4, gameStats.spawnPointEnemy, Quaternion.identity);
                            enemy.GetComponent<EnemyCharacter>().direction = -1;
                        }
                        GUILayout.EndHorizontal();

                        GUILayout.BeginHorizontal();
                        gameStats.e5 = (GameObject)EditorGUILayout.ObjectField("EnemyType1:", gameStats.e5, typeof(GameObject), true);
                        if (GUILayout.Button("SpawnLeft1"))
                        {
                            Instantiate(gameStats.e5, gameStats.spawnPointEnemy, Quaternion.identity);
                        }
                        if (GUILayout.Button("SpawnRight1"))
                        {
                            GameObject enemy = Instantiate(gameStats.e5, gameStats.spawnPointEnemy, Quaternion.identity);
                            enemy.GetComponent<EnemyCharacter>().direction = -1;
                        }
                        GUILayout.EndHorizontal();

                        GUILayout.BeginHorizontal();
                        gameStats.e6 = (GameObject)EditorGUILayout.ObjectField("EnemyType1:", gameStats.e6, typeof(GameObject), true);
                        if (GUILayout.Button("SpawnLeft1"))
                        {
                            Instantiate(gameStats.e6, gameStats.spawnPointEnemy, Quaternion.identity);
                        }
                        if (GUILayout.Button("SpawnRight1"))
                        {
                            GameObject enemy = Instantiate(gameStats.e6, gameStats.spawnPointEnemy, Quaternion.identity);
                            enemy.GetComponent<EnemyCharacter>().direction = -1;
                        }
                        GUILayout.EndHorizontal();
                        break;
                    }
                case DisplayCategoryEnemy.LEVEL_3:
                    {
                        GUILayout.BeginHorizontal();
                        gameStats.e7 = (GameObject)EditorGUILayout.ObjectField("EnemyType1:", gameStats.e7, typeof(GameObject), true);
                        if (GUILayout.Button("SpawnLeft1"))
                        {
                            Instantiate(gameStats.e7, gameStats.spawnPointEnemy, Quaternion.identity);
                        }
                        if (GUILayout.Button("SpawnRight1"))
                        {
                            GameObject enemy = Instantiate(gameStats.e7, gameStats.spawnPointEnemy, Quaternion.identity);
                            enemy.GetComponent<EnemyCharacter>().direction = -1;
                        }
                        GUILayout.EndHorizontal();

                        GUILayout.BeginHorizontal();
                        gameStats.e8 = (GameObject)EditorGUILayout.ObjectField("EnemyType1:", gameStats.e8, typeof(GameObject), true);
                        if (GUILayout.Button("SpawnLeft1"))
                        {
                            Instantiate(gameStats.e8, gameStats.spawnPointEnemy, Quaternion.identity);
                        }
                        if (GUILayout.Button("SpawnRight1"))
                        {
                            GameObject enemy = Instantiate(gameStats.e8, gameStats.spawnPointEnemy, Quaternion.identity);
                            enemy.GetComponent<EnemyCharacter>().direction = -1;
                        }
                        GUILayout.EndHorizontal();

                        GUILayout.BeginHorizontal();
                        gameStats.e9 = (GameObject)EditorGUILayout.ObjectField("EnemyType1:", gameStats.e9, typeof(GameObject), true);
                        if (GUILayout.Button("SpawnLeft1"))
                        {
                            Instantiate(gameStats.e9, gameStats.spawnPointEnemy, Quaternion.identity);
                        }
                        if (GUILayout.Button("SpawnRight1"))
                        {
                            GameObject enemy = Instantiate(gameStats.e9, gameStats.spawnPointEnemy, Quaternion.identity);
                            enemy.GetComponent<EnemyCharacter>().direction = -1;
                        }
                        GUILayout.EndHorizontal();
                        break;
                    }
            }
            GUILayout.EndVertical();
        }

        serializedObject.ApplyModifiedProperties();
        if (GUI.changed)
        {
            EditorUtility.SetDirty(gameStats);
            EditorSceneManager.MarkSceneDirty(gameStats.gameObject.scene);
        }
    }
}
