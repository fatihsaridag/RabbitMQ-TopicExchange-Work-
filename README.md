## Topic Exchange Kullanımı (Detaylı routelama yapısına sahip bir Exchange )## 

Biz producer olarak bir mesaj gönderdiğimizde mesajımızın route keyinde normal bir string olarak mesaj yazmak yerine "." lar ile beraber ifadeler belirliyoruz.<br/>
Örnek olarak  Routing Key => Critical.Error.Warning  <br/>
Yani noktalar ile berafer ifadelerimizi belirliyoruz. 


![3](https://user-images.githubusercontent.com/68101192/208653526-e5abe557-23c3-4834-b217-1a232c072741.PNG)



## Biraz daha açıklayalım ##
Routuing Key =>  Critical.Error.Warning 
1)  Critical.Error.Warning mesajımız var ve biz bunu dinlemek istiyorsak Cunsomer olarak direk  "Critical.Error.Warning" isteği atıyoruz.
2)  Bu sefe kuyruk oluşturma işlemini cunsomer'a bırakacağız çünkü varyasyon çok fazla. Peki ya varyasyon fazla derken ? 
3)  Mesela cunsomer olarak şunu isteyebiliriz. Critical olsun ancak ortadaki herhangi bir şey olsun , sonu da warning bitsin diyorsak eğer * ifadesini kullanıyoruz. 
4)  *.Error.* Dersek eğer böyle bir route'a bağlı kuyruk oluşturursak Producer mesaj ürettiğinde bunun route'u Info.Error.Warning olabilir vs vs Yani daha fazla customize edebiliyoruz.
5)  #.Error da ise sonu yalnızca sonu Error olanlar gelir. 
6)  *.*.Error ise En son karakter Error olsun diğer karakterler önemli değil.
7)  Info.# da ise başı Info olsun  sonu ne olursa olsun  olanlar gelir. 


## İlgili Resimler ##
![1](https://user-images.githubusercontent.com/68101192/208654341-20ce147d-500a-4744-9d94-47171b8b724a.png)
![2](https://user-images.githubusercontent.com/68101192/208654333-ba63a39f-d032-4a65-a467-2ede7ee72762.png)
