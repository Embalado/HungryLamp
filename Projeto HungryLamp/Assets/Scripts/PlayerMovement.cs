using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 0f;
    float m_MySliderValue;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    public GameObject CapTrigger, StunTrigger, tornado, bullet, shield,Lantern;
    private GameObject FireBall;
    public Transform shoot;
    public int lives = 5;
    public int maxLives = 5;
    float timer, timer1, InvincibleCounter, shieldTimer;
    public float invincibleLength, flashLenght = 0.1f;
    public static bool Fire = false, Shield = false, damage = false, heal = false, heal1 = false, CanLoad = false, isDead = false;
    public GameObject playerRenderer;
    bool flasrender;
    public AudioSource m_AudioSource, m_AudioSource1, m_AudioSource2, m_AudioSource3, m_AudioSource4, m_AudioSource5;
    public static RaycastHit hitFireball = new RaycastHit();

    //bool audio
    bool isWalking, isPulling, isStun, isFire, isShield, isDamage;
    RaycastHit _hit;

    private float flashCounter;

    Transform Cam;
    Vector3 camForward;
    Vector3 move;
    Vector3 moveinput;
    float ForwardAumont;
    float turnAmount;

    [SerializeField] LifeSystem ls;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
       // SetupAnimator();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
        Cam = Camera.main.transform;
       

        if (CanLoad == true)
        {
            LoadPlayer();
            StartCoroutine(Loadtimer());
        }
        else
        {
            SavePlayer();
        }
        ls.DrawLife(lives, maxLives);
        damage = false;

    }

    void FixedUpdate()
    {



        if (isDead == false)
        {

          

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            if (Cam != null)
            {
                camForward = Vector3.Scale(Cam.up, new Vector3(1, 0, 1)).normalized;
                move = vertical * camForward + horizontal * Cam.right;
            }
            else
            {
                move = vertical * Vector3.forward + horizontal * Vector3.right;
            }
            if (move.magnitude > 1)
            {
                move.Normalize();
            }
            Move(move);
            Vector3 movement = new Vector3(horizontal, 0, vertical);
            //m_Rigidbody.AddForce(movement * 1 * Time.deltaTime,Space.World);
            



            bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
            isWalking = hasHorizontalInput || hasVerticalInput;
            //m_Animator.SetBool("IsWalking", isWalking);
            //Vector3 movement = new Vector3(horizontal, 0, vertical);
           if(isPulling==false)
            {
                transform.Translate(movement * 1.4f * Time.deltaTime, Space.World);
            }
           
            Plane Groundplane = new Plane(Vector3.up, Vector3.zero);
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayground;
            if (Groundplane.Raycast(_ray, out rayground))
            {
                Vector3 pointTolook = _ray.GetPoint(rayground);
                transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
            }



            /////
            //Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
            //m_Rotation = Quaternion.LookRotation(desiredForward);
        }
        if (InvincibleCounter > 0)
        {
            isDamage = false;
            InvincibleCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
            if (flashCounter < 0)
            {
                flasrender = !flasrender;
                playerRenderer.SetActive(flasrender);

                flashCounter = flashLenght;
            }
            if (InvincibleCounter <= 0)
            {

                playerRenderer.SetActive(true);
            }
        }

        if (shieldTimer > 0)
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0)
            {
                damage = false;
                isShield = false;
                shield.SetActive(false);
            }

        }



        if (damage == true && shieldTimer <= 0)
        {
            DamagePlayer(1);
            damage = false;

        }
        if (heal == true)
        {

            HealPlayer(1);
            heal = false;
        }
        if (heal1)
        {
            HealPlayer(5);
            heal1 = false;
        }
        if (Fire)
        {
            ShootRaycast();
            if (Input.GetKey(KeyCode.E))
            {
                
                isFire = true;
                Instantiate(bullet, shoot.position, shoot.rotation);
                Fire = false;

            }
            //else
            //{
            //    if(isFire)
            //    {
            //        Instantiate(bullet, shoot.position, shoot.rotation);
            //        Fire = false;
            //    }
            //}



        }
        else
        {
            isFire = false;
        }


        if (Shield)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                isShield = true;
                shieldTimer = 10;
                shield.SetActive(true);
                Shield = false;


            }
        }

        if (Input.GetMouseButton(0))
        {
            m_Animator.SetBool("IsPulling", true);
            isPulling = true;
            m_Animator.SetBool("IsWalking", false);
            timer += Time.deltaTime;
            if (timer > 0.5)
            {
                CapTrigger.SetActive(true);
                tornado.SetActive(true);
            }


        }
        else
        {
            isPulling = false;
            m_Animator.SetBool("IsPulling", false);
            timer = 0;
            CapTrigger.SetActive(false);
            tornado.SetActive(false);
        }
        if (Input.GetMouseButton(1))
        {
            isStun = true;
            StunTrigger.SetActive(true);
            timer1 += Time.deltaTime;
            if (timer1 > 0.5)
            {
                isStun = false;
                StunTrigger.SetActive(false);

            }

        }
        else
        {
            isStun = false;
            StunTrigger.SetActive(false);
            timer1 = 0;
        }
        ////Audio
        Audio();
        if (LapideSave.CanSave == true)
        {


            if (Input.GetKeyDown(KeyCode.F))
            {
                SavePlayer();

                Debug.Log("salvou");
            }
            //LapideSave.CanSave = false;
        }


    }
    public void DamagePlayer(int dmg)
    {
        if (InvincibleCounter <= 0)
        {

            isDamage = true;


            if (lives > 0)
            {
                lives -= dmg;
                ls.DrawLife(lives, maxLives);
            }
            if (lives == 0)
            {
                isDead = true;
                Lantern.SetActive(false);
                m_Animator.SetBool("IsDead", true);
            }
            InvincibleCounter = invincibleLength;
            playerRenderer.SetActive(false);
            flashCounter = flashLenght;
        }

    }
    public void HealPlayer(int dmg)
    {
        if (lives < maxLives)
        {
            lives += dmg;
            ls.DrawLife(lives, maxLives);
        }
        if (lives > maxLives)
        {
            lives = maxLives;
            ls.DrawLife(lives, maxLives);
        }
    }
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        lives = data.health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
    void Audio()
    {
        if (isWalking && isPulling == false)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }
        if (isPulling)
        {
            if (!m_AudioSource1.isPlaying)
            {
                m_AudioSource1.Play();
            }
        }
        else
        {
            m_AudioSource1.Stop();
        }
        if (isStun)
        {

            m_AudioSource2.Play();

        }

        if (isFire)
        {

            m_AudioSource3.Play();



        }

        if (isShield)
        {
            if (!m_AudioSource4.isPlaying)
            {
                m_AudioSource4.Play();
            }
        }
        else
        {
            m_AudioSource4.Stop();
        }
        if (isDamage)
        {

            m_AudioSource5.Play();

        }

    }


    IEnumerator Loadtimer()
    {

        yield return new WaitForSecondsRealtime(1);
        CanLoad = false;

    }
    void SetupAnimator()
    {

        foreach (Animator childAnimator in GetComponentsInChildren<Animator>())
        {
            if (childAnimator != m_Animator)
            {
                m_Animator.avatar = childAnimator.avatar;
                Destroy(childAnimator);
                break;
            }
        }
    }
    void Move(Vector3 move)
    {
        if (move.magnitude > 1)
        {
            move.Normalize();
        }
        this.moveinput = move;
        ConvertMoveInput();
        UpdateAnimator();
    }
    void ConvertMoveInput()
    {
        Vector3 localmMove = transform.InverseTransformDirection(moveinput);
        turnAmount = localmMove.x;
        ForwardAumont = localmMove.z;
    }
    void UpdateAnimator()
    {
        m_Animator.SetFloat("Forward", ForwardAumont, 0.1f, Time.deltaTime);
        m_Animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
    }
    void ShootRaycast()
    {

        if (Physics.Raycast(shoot.transform.position,transform.TransformDirection(Vector3.forward),out hitFireball,20f,LayerMask.GetMask("NoCol1")))
        {
            Debug.DrawRay(shoot.transform.position, transform.TransformDirection(Vector3.forward) * hitFireball.distance,Color.red);

        }
       else
        {
            Debug.DrawRay(shoot.transform.position, transform.TransformDirection(Vector3.forward) * 20F, Color.green);

        }
    }
}
