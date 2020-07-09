using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ikiYonluHizVer : MonoBehaviour
{
    
    public Rigidbody rb;// Topumuzun rigitbady bilgisini tuttuğumuz değişken
    public float h = 65;//belirlenen h yüksekliği siz tanımlayabilirsiniz
    public float gravity = 9.8f;// gravity
    public GameObject silindir;//Scriptin yazılı olmadığı objenin pozisyon bilgisinin tutulacağı değişken
    public float xmesafesi;
     public float ymesafesi;
     public float xHizi=0;//başlangıç hızları
     public float yHizi=0;
     public float t;// t süresi
     public Vector3 mesafe;//objeler arasındaki mesafeyi tutacak vector tipindeki değişken
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Scripti küreye yazdığımız için ilk kısımda "transform.position" ile kürenin pozisyonuna ulaşıyoruz
        //Silindir için rigidbody referansını sürükleyerek GameObject değişkenine atadıktan sonra artık silindir pozisyonuna ulaşmak için 
        //"silindir.transform.position" komutuyla ulaştık. Bu elde ettiğimiz iki vectörün farkını alınca mesafe vektörünü elde etmiş olduk.
        mesafe = transform.position - silindir.transform.position;
        //Mesafe vectörünün x düzeyindeki elementine ulaştık
         xmesafesi = mesafe.x;
        //Pozisyondan dolayı mesafe negatif çıkabilir, bu yüzden bunun kontrolünü yapıp işaretini dğiştirdik.
         if (xmesafesi<0) {
             xmesafesi = xmesafesi* -1;
         }
         // tanımlanan h yükseskliğine göre t 'nin hesaplanması
        t =  Mathf.Sqrt(gravity * h*2);

        xHizi = xmesafesi /2* t; //Yatayda ivme değişmediği için mesafeyi (t-uçuş+t-iniş) 2t süresine bölünce x te ki hızı hesapladık

        yHizi = gravity*h;// y de ki hız ivme ile yükseklik çarpımına eşit olur.(ivme--> gravity)

        //eğik atış hareketinin gerçekleşmesi için hesaplanan Vx ve Vy hızları objeye verildi.
        rb.AddForce(xHizi, yHizi, 0);
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    


}
