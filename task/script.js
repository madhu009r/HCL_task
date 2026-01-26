let country=[];
async function loadcountries(){
   await fetch("https://restcountries.com/v3.1/all?fields=name,capital,region,cca2,flags")
    .then(Response=>Response.json())
    .then(data=>{
        country=data;
        console.log(data);

        serachbycode();
    })

}



function serachbycode(){

    let code =document.getElementById("CountryCode").value;

    let result= country.filter((c)=>{
        console.log(c.region);
        return  c.region == code
    })
   console.log(result);

   let country1= result.filter(r=>r.name.common == 'India');
//    console.log(country)

    const display=document.getElementById("countrylist");
    const list=document.createElement("li");
    list.textContent=country1[0].name.common;
    display.appendChild(list);
}
