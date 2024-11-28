@{
    ViewData["Title"] = "Search";
}

<h1 > Buscar Empresa </ h1 >

<form method = "post" asp - action = "Search" >
    < div class= "form-group" >
        < label for= "id" > ID da Empresa </ label >
        < input type = "number" id = "id" name = "id" class= "form-control" required />
    </ div >
    < button type = "submit" class= "btn btn-primary" > Buscar </ button >
</ form >

< div >
    < a asp - action = "Index" > Voltar para a lista</a>
</div>
