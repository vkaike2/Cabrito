using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaController : MonoBehaviour {

    private PlataformaService plataformaService; 

    void Start(){
        plataformaService = new PlataformaService(gameObject);
    }
    
    void Update(){
        plataformaService.descer();
    }
}