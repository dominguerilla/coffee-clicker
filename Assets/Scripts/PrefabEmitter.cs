using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Emits the specified prefab from the spawnPoint.
/// </summary>
public class PrefabEmitter : MonoBehaviour {

    public GameObject prefab;
    public Transform spawnPoint;
    public int startingPoolSize = 30;
    public int currentPoolSize;
    public int prefabsPerEmit = 1;

    public Vector3 spawnForceMax = new Vector3(1, 1, 1);

    Stack<GameObject> prefabPool;
    

    private void Awake() {
        prefabPool = new Stack<GameObject>();
        AddToPool(startingPoolSize);
        currentPoolSize = prefabPool.Count;
    }

    private void Update() {
        currentPoolSize = prefabPool.Count;
    }

    void AddToPool(int number) {
        for (int i = 0; i < number; i++) {
            GameObject bean = GameObject.Instantiate<GameObject>(prefab);
            CoffeeBeanParticle beanParticle = bean.GetComponent<CoffeeBeanParticle>();
            beanParticle.SetEmitter(this);
            bean.SetActive(false);
            prefabPool.Push(bean);
        }
    }

    private void OnMouseDown() {
        EmitBeanClick();   
    }

    public void EmitBeanClick() {
        for(int i = 0; i < prefabsPerEmit; i++) {
            if(prefabPool.Count > prefabsPerEmit) {
                GameObject poppedPrefab = prefabPool.Pop();
                poppedPrefab.transform.position = spawnPoint.position;
                CoffeeBeanParticle particle = poppedPrefab.GetComponent<CoffeeBeanParticle>();
                
                Rigidbody beanBody = poppedPrefab.GetComponent<Rigidbody>();
                float x = Random.Range(-spawnForceMax.x, spawnForceMax.x);
                float y = Random.Range(spawnForceMax.y/20, spawnForceMax.y);
                float z = Random.Range(-spawnForceMax.z, spawnForceMax.z);
                
                Vector3 spawnForce = new Vector3(x, y, z);
                poppedPrefab.SetActive(true);
                beanBody.AddRelativeForce(spawnForce, ForceMode.Impulse);
                beanBody.AddTorque(spawnForce);
                StartCoroutine(particle.Disappear());
            }else {
                //expand by 10% if there isn't enough objects
                AddToPool(startingPoolSize / 10);
            }
        }
    }

    public void ReturnToPool(GameObject obj) {
        obj.SetActive(false);
        prefabPool.Push(obj);
    }
}
