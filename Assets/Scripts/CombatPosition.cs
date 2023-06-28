using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CombatPosition : MonoBehaviour
{
    //public EnemyAldeano enemyAldean;

    public Enemy enemyy;
    public Combat combatscript;
    public List<GameObject> enemyGObj;
    public Transform enemytransf;
    public GameObject areaWhereTheEnemySpawns;

    public List<GameObject> AreasWhereTheEnemiesSpawns;
    public int CounterforPlacesWhereEnemiesSpawns;

    public bool battlePosition = false;
    public bool CombatON = false;
    public bool enemyInvoke = false;
    public Rigidbody playerRB;
    public Camera mainCamera;
    public Player player;
    public List<CinemachineVirtualCamera> cameras;
    public CinemachineVirtualCamera ActiveCamera;
    GameManager myGM;
    public MyCamera camerascript;
    public int enemiesreminder;
    public Deck deckscript;
    public VigorDeck vigordeckscript;
    public VigorCardsDisplay ScriptVigorCardDisplaySlot4;
    public VigorCardsDisplay ScriptVigorCardDisplaySlot5;
    public VigorCardsDisplay ScriptVigorCardDisplaySlot6;
    public CardDisplay cardDisplayScriptSlot1;
    public CardDisplay cardDisplayScriptSlot2;
    public CardDisplay cardDisplayScriptSlot3;


    public StadisticPlayer stadisticPlayerScript;
    public EnemyHeathPointsUI EnemyHealthPointsScript;

    AudioSource MyAudioSource;
    public AudioClip CardSwipe;
    public AudioClip EnemyDiesAudio;

    public float ContadorTransicion;

    Charview view;
    public CharacterController playercontroler;


    public void Update()
    {
        if (CombatON == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (CombatON == false)
        {
            combatscript.NormalCardsAnimation.StopPlayback();
            combatscript.NormalCardsAnimation.Rebind();
            combatscript.VigorCardsAnimation.StopPlayback();
            combatscript.VigorCardsAnimation.Rebind();
        }
    }

    private void Awake()
    {
        view = GetComponent<Charview>();
        MyAudioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        playercontroler = GetComponent<CharacterController>();
        myGM = GameManager.instance;
    }
    public void PlayAudio(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }
    public void salircombate()
    {

        enemiesreminder--;
        if (enemiesreminder <= 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            SwitchCamera(cameras[0]);
            PlayAudio(EnemyDiesAudio);
            myGM.activeUI();
            battlePosition = false;
            player.enabled = true;
            playerRB.constraints = RigidbodyConstraints.None;
            playerRB.constraints = RigidbodyConstraints.FreezeRotation;
            CombatON = false;
            enemyInvoke = false;
            combatscript.DrawAgain();

            Debug.Log("You came out of combat");
        }
    }

    public void combatON()
    {

        // SwitchCamera(cameras[1]);
        battlePosition = true;
        PlayAudio(CardSwipe);
        view.Isrunning(false);
        camerascript.enabled = false;
        myGM.activeUI();
        player.enabled = false;
        vigordeckscript.CreateListOfMyVigorCardsBuildForCombat();
        deckscript.CreateListOfMyrCardsBuildForCombat();
        mainCamera.transform.LookAt(enemytransf);
        playerRB.constraints = RigidbodyConstraints.FreezeAll;
        Debug.Log("You entered combat");
        deckscript.DrawCards();
        vigordeckscript.DrawCards();
        CombatON = true;
        combatscript.NormalCardsAnimation.CrossFade("CardsNormalAnimation", 0f);
        combatscript.VigorCardsAnimation.CrossFade("CardsAnimations", 0f);
        if (combatscript.drawButtonBool == false)
        {
            combatscript.DrawButtonActiveOrNot();
            combatscript.counterForDrawButton = 0;
        }
    }
    public void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        ActiveCamera = camera;

        foreach (CinemachineVirtualCamera c in cameras)
        {
            if (c != camera && c.Priority != 0)
            {
                c.Priority = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            camerascript.canMoveCamera = false;
            enemiesreminder = 1;
            Vector3 direccion = new Vector3(15, 1, 15);
            transform.LookAt(direccion);

            if (enemyInvoke == false)
            {
                EnemyInvoke();
            }

            Destroy(areaWhereTheEnemySpawns.gameObject);

            if (CombatON == false)
            {
                SwitchCamera(cameras[1]);
                combatON();
            }
        }
        if (other.gameObject.layer == 13)
        {
            Destroy(other.gameObject);
            camerascript.canMoveCamera = false;
            enemiesreminder = 1;
            Vector3 direccion = new Vector3(0, 1, 5);
            transform.LookAt(direccion);

            if (enemyInvoke == false)
            {
                EnemyInvoke();
            }

            Destroy(areaWhereTheEnemySpawns.gameObject);

            if (CombatON == false)
            {
                SwitchCamera(cameras[2]);
                combatON();
            }
        }
        if (other.gameObject.layer == 14)
        {
            Destroy(other.gameObject);
            camerascript.canMoveCamera = false;
            enemiesreminder = 1;
            Vector3 direccion = new Vector3(-120, 1, 80);
            transform.LookAt(direccion);

            if (enemyInvoke == false)
            {
                EnemyInvoke();
            }

            Destroy(areaWhereTheEnemySpawns.gameObject);

            if (CombatON == false)
            {
                SwitchCamera(cameras[3]);
                combatON();
            }
        }
        if (other.gameObject.layer == 17)
        {
            Destroy(other.gameObject);
            camerascript.canMoveCamera = false;
            enemiesreminder = 1;
            Vector3 direccion = new Vector3(-147, 1, 67);
            transform.LookAt(direccion);

            if (enemyInvoke == false)
            {
                EnemyInvoke();
            }

            Destroy(areaWhereTheEnemySpawns.gameObject);

            if (CombatON == false)
            {
                SwitchCamera(cameras[4]);
                combatON();
            }
        }
    }
    void EnemyInvoke()
    {
        Enemy actualenemy = Instantiate(enemyGObj[CounterforPlacesWhereEnemiesSpawns], AreasWhereTheEnemiesSpawns[CounterforPlacesWhereEnemiesSpawns].transform.position, AreasWhereTheEnemiesSpawns[CounterforPlacesWhereEnemiesSpawns].transform.rotation).GetComponent<Enemy>();  //PRUEBA

        //enemyGObj.Remove(actualenemy); NO FUNCIONA
        actualenemy.Setcombat(this);
        actualenemy.SetPlayer(stadisticPlayerScript);
        combatscript.setenemy(actualenemy);
        EnemyHealthPointsScript.SetEnemyInEnemyHealthPoints(actualenemy);
        ScriptVigorCardDisplaySlot4.setenemy(actualenemy);
        ScriptVigorCardDisplaySlot5.setenemy(actualenemy);
        ScriptVigorCardDisplaySlot6.setenemy(actualenemy);
        cardDisplayScriptSlot1.setenemy(actualenemy);
        cardDisplayScriptSlot2.setenemy(actualenemy);
        cardDisplayScriptSlot3.setenemy(actualenemy);

        enemyInvoke = true;
        CounterforPlacesWhereEnemiesSpawns += 1; // PRUEBA
    }
}

