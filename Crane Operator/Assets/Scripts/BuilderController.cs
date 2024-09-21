using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderController : MonoBehaviour
{
    [SerializeField]
    //������� ������� ����
    //�.�. �� 1 ������ ��� cargoInStepCount
    private List<GameObject> objectSteps = new();

    [SerializeField]
    //���-�� ������ �� ������ ����
    private List<int> cargoInStepCount = new();

    [SerializeField]
    private float fadeDuration = 30;


    //������� ���-�� ������ � ������� 
    private int currentCargoCount;
    //�������� �� ���
    private bool stepReady;
    //��������� �� �������
    private bool buildReady;
    //������ ��� ������������ ����
    private Cargo currentCargo;

    //���������� �����
    [SerializeField]
    private FadeScreen fade;
    [SerializeField]
    private FadeScreen fadeCamera;

    [SerializeField] private bool isCargo;
    [SerializeField] private bool isHook;

    [SerializeField]
    private GameObject Firework;
    //������������ �����
    public List<GameObject> cargoInArea = new();

    private int currentStep;


    private void Update()
    {  
        if(currentCargo != null && isCargo && !currentCargo.isGrabbing && !isHook)
        {
            UnloadCargo();
        }
    }
    
    //����� ��������� �����
    private void UnloadCargo()
    {
        //������� ����������� �������� �����
        currentCargo.canGrab = false;
        //��������� ���� � ������ ������
        cargoInArea.Add(currentCargo.gameObject);
        //������� ��� �� ������
        currentCargo = null;
        //��������� ������� �����
        currentCargoCount++;
        //��������� �������� �� ���������� ����
        StartCoroutine(StepReady());
    }

    //������ ���������� ����
    private void NextStep()
    {
        //�������� ������� ���-�� ����� � �������
        currentCargoCount = 0;

        //��������� ��������� �� ������� ���
        currentStep++;
    }

    //����� ��������� ����
    private IEnumerator StepReady()
    {
        //���� ��� �����
        if (currentCargoCount == cargoInStepCount[currentStep])
        {
            //������� ���� ���������
            ClearUnloadArea();

            StartCoroutine(Timer());

            yield return new WaitForSeconds(2f);
            //���������� ���������� ����� �������������
            UpdateVisual();
            //���� ��� ��������� ���
            if (objectSteps.Count - 2 != currentStep)
            {
                NextStep();
            }
            else
                EndGame();
        }
        //����� ������� �� ������
        else
        {
            yield return null;
        }
    }

    //����� ������� ���� ���������
    private void ClearUnloadArea()
    {
        foreach (var cargo in cargoInArea)
        {
            Destroy(cargo);
        }
        cargoInArea = new();
    }

    //���������� ���������� ����� ����
    private void UpdateVisual()
    {
        //������ ������
        objectSteps[currentStep].gameObject.SetActive(false);
        objectSteps[currentStep + 1].gameObject.SetActive(true);
    }

    private IEnumerator Timer()
    {
        fade.Fade(0, 2);
        fadeCamera.Fade(0, 2);
        yield return new WaitForSeconds(fadeDuration);
        fade.Fade(2, 0);
        fadeCamera.Fade(2, 0);
    }

    private void EndGame()
    {
        Debug.Log("������������� ��������!");
        Firework.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Cargo>(out var cargo))
        {
            isCargo = true;
            currentCargo = cargo;
        }

        if (other.TryGetComponent<HookController>(out var hook))
        {
            isHook = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Cargo>(out var cargo))
        {
            isCargo = false;
            currentCargo = null;
        }

        if (other.TryGetComponent<HookController>(out var hook))
        {
            isHook = false;
        }
    }
}
