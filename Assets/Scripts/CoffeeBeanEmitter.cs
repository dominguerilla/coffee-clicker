using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Emits coffee bean prefabs from the coffee plant. Used by player clicks and farmers.
/// </summary>
public class CoffeeBeanEmitter : MonoBehaviour {

    public GameObject beanPrefab;
    public Transform spawnPoint;
    public int poolSize = 10;

    public Vector3 spawnForceMax = new Vector3(1, 1, 1);

    Stack<GameObject> beanPool;
    CoffeePlant plant;

    private void Awake() {
        beanPool = new Stack<GameObject>();
        plant = GetComponent<CoffeePlant>();
        for (int i = 0; i < poolSize; i++) {
            GameObject bean = GameObject.Instantiate<GameObject>(beanPrefab);
            CoffeeBeanParticle beanParticle = bean.GetComponent<CoffeeBeanParticle>();
            beanParticle.SetEmitter(this);
            bean.SetActive(false);
            beanPool.Push(bean);
        }
    }

    private void OnMouseDown() {
        EmitBeanClick();   
    }

    public void EmitBeanClick() {
        for(int i = 0; i < plant.beansPerClick; i++) {
            if(beanPool.Count > 0) {
                GameObject bean = beanPool.Pop();
                bean.transform.position = spawnPoint.position;
                CoffeeBeanParticle particle = bean.GetComponent<CoffeeBeanParticle>();
                
                Rigidbody beanBody = bean.GetComponent<Rigidbody>();
                float x = Random.Range(-spawnForceMax.x, spawnForceMax.x);
                float y = Random.Range(spawnForceMax.y/20, spawnForceMax.y);
                float z = Random.Range(-spawnForceMax.z, spawnForceMax.z);
                
                Vector3 spawnForce = new Vector3(x, y, z);
                bean.SetActive(true);
                beanBody.AddRelativeForce(spawnForce, ForceMode.Impulse);
                beanBody.AddTorque(spawnForce);
                StartCoroutine(particle.Disappear());
            }
        }
    }

    public void ReturnToPool(GameObject obj) {
        obj.SetActive(false);
        beanPool.Push(obj);
    }
}
