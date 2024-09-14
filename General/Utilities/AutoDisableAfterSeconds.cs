// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
 
// public class AutoDisableAfterSeconds : MonoBehaviour
// {
//     public float disableAfterSeconds = 5;
//     // Start is called before the first frame update
//     void OnEnable()
//     {
//         StopAllCoroutines();
//         StartCoroutine(LiveAndDie());
//     }
//     IEnumerator LiveAndDie()
//     {
//         yield return new WaitForSeconds(disableAfterSeconds);
//         gameObject.SetActive(false);
//     }
//     private void OnDisable()
//     {
//         StopAllCoroutines();
//     }
//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
