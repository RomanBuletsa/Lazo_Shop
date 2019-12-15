using System;
using Application;
using SceneManagement;
using UnityEngine;

namespace Exhibition
{
    public class ExhibitionManager : MonoBehaviour
    {
        [SerializeField] private Transform modelPointTransform;
        private GameObject productModel;
        private Vector3 eulerLookRotation;
        private float rotationSpeed = 2f;
        private bool clickButton;

        private void Awake() => ApplicationManager.Instance.ExhibitionManager = this;

        private void Start()
        {
            eulerLookRotation = new Vector3();
            productModel = Instantiate(ApplicationManager.Instance.AdminPageManager.ProductModel);
            productModel.transform.position = modelPointTransform.position;
            ScenesLoader.UnloadScene(ApplicationScenes.AdminPage.ToString());
        }

        private void Update()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                ScenesLoader.UnloadScene(ApplicationScenes.Exhibition.ToString());
                ScenesLoader.LoadScene(ApplicationScenes.AdminPage.ToString(), true, false);
            }

            if (Input.GetMouseButtonDown(0))
                clickButton = true;
            if (Input.GetMouseButtonUp(0))
                clickButton = false;

            if (clickButton)
            {
                eulerLookRotation.y += Input.GetAxisRaw("Mouse X") * rotationSpeed;
                eulerLookRotation.x += Input.GetAxisRaw("Mouse Y") * rotationSpeed;
                productModel.transform.rotation = Quaternion.Euler(eulerLookRotation);
            }
        }
    }
}
