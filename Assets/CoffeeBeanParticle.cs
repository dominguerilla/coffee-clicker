using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBeanParticle : MonoBehaviour {

    public float lifetime = 5f;
    
    CoffeeBeanEmitter emitter;
    Material[] mats;

    private void Awake() {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        mats = new Material[renderers.Length];
        for(int i = 0; i < renderers.Length; i++) {
            mats[i] = renderers[i].material;
        }
    }

    public void SetEmitter(CoffeeBeanEmitter emitter) {
        this.emitter = emitter;
    }

    public IEnumerator Disappear() {
        Material firstMat = mats[0];
        float step = 0;
        while(firstMat.color.a > 0) {
            foreach(Material mat in mats) {
                Color col = mat.color;
                float alpha = 1 - Mathf.Lerp(0, 1, step/lifetime);
                Color newColor = new Color(col.r, col.g, col.b, alpha);
                mat.color = newColor;
            }
            step += Time.deltaTime;
            yield return null;
        }
        emitter.ReturnToPool(this.gameObject);
        foreach(Material mat in mats) {
            Color original = new Color(mat.color.r, mat.color.g, mat.color.b, 1);
            mat.color = original;
        }
    }
}
