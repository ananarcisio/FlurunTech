<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Cadastro de fornecedores</title>
</head>
<body>
<section id="cardcontainer">
  <div class="card">
      <form method="POST" action="insert.php">
        <h1 id="title">CADASTRO</h1>
        
        <div class="input">
          <input name="empresa" type="text" required="" autocomplete="off">
          <label for="empresa">Empresa</label>
        </div>

        <div class="input">
          <input name="email" type="email" required="" autocomplete="off">
          <label for="email">E-mail</label>
        </div>

        <div class="input">
          <input name="telefone" type="text" required="" autocomplete="off">
          <label for="telefone">Telefone</label>
        </div>

        <div class="input" id="s2">
          <input name="cargo" type="text" required="" autocomplete="off">
          <label for="cargo">Cargo</label>
        </div>


        <div class="input" id="s2">
          <input name="nome" type="text" required="" autocomplete="off">
          <label for="nome">nome</label>
        </div>

        <button type="submit" name="submit"> Cadastrar </button>
        <a href="dados.php"> <button  type="button"> Ver contratantes cadastrados </button></a>
      </form>
  </div>

    
</section>
</body>
</html>

<style>
  body{
    background-color: #000;
    padding: 5vh;
    font-family: 'Segoe UI', sans-serif;
    color: white;
  }
  #title{
    grid-column: span 2;
    background: linear-gradient(-45deg, #fc00ff 0%, #00dbde 100%);
    -webkit-background-clip: text; 
    background-clip: text;
    color: transparent; 
    font-size: 2rem;
    justify-self: center;
  }
  form{
    display: grid;
    grid-template-columns: 1fr 1fr;
    column-gap: 3vw
  }
  #cardcontainer{
   display: flex;
   width: 100%;
   height: 100%;
   align-items: center;
   justify-content: center;
  }
  .card {
    position: relative;
    width: 50%;
    height: 70%;
    background-color: #000;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    padding: 12px;
    gap: 12px;
    border-radius: 8px;
    cursor: pointer;
    color: white;
  }

  .card::before {
    content: '';
    position: absolute;
    inset: 0;
    left: -10px;
    margin: auto;
    width: 103%;
    height: 103%;
    border-radius: 10px;
    background: linear-gradient(-45deg, #e81cff 0%, #40c9ff 100% );
    z-index: -10;
    pointer-events: none;
    transition: all 0.6s cubic-bezier(0.175, 0.885, 0.32, 1.275);
  }

  .card::after {
    content: "";
    z-index: -1;
    position: absolute;
    inset: 0;
    background: linear-gradient(-45deg, #fc00ff 0%, #00dbde 100% );
    transform: translate3d(0, 0, 0) scale(0.95);
    filter: blur(20px);
  }

  .card p:not(.heading) {
    font-size: 14px;
  }

  .card p:last-child {
    color: #e81cff;
    font-weight: 600;
  }

  .card:hover::after {
    filter: blur(30px);
  }

  .card:hover::before {
    transform: rotate(-90deg) scaleX(1.34) scaleY(0.77);
  }

  .input {
  font-family: 'Segoe UI', sans-serif;
  margin: 1em 1em 1em 0;
  max-width: 40vw;
  position: relative;
  color: white;
  }

.input input {
  font-size: 100%;
  padding: 0.8em;
  outline: none;
  border: 2px solid rgb(141, 109, 255);
  background-color: transparent;
  border-radius: 20px;
  width: 100%;
  color: white;
}

select {
  -webkit-appearance: none;
  -moz-appearance:    none;
  appearance:         none;
}


.input label {
  font-size: 100%;
  position: absolute;
  left: 0;
  top: -1px;
  padding: 0.8em;
  margin-left: 0.5em;
  pointer-events: none;
  transition: all 0.3s ease;
  color: rgb(255, 255, 255);
}

.input :is(input:focus, input:valid)~label {
  transform: translateY(-50%) scale(.9);
  margin: 0em;
  margin-left: 1.3em;
  padding: 0.4em;
  background-color: #000;
}

.inputGroup :is(input:focus, input:valid) {
  border-color: rgb(37, 37, 211);
}

.form-select{
  background-color: #000;
  color: white;
  font-size: 100%;
  padding: 0.8em;
  outline: none;
  border: 2px solid rgb(141, 109, 255);
  border-radius: 20px;
  max-width: 100%;
margin: 3px;
}

.radio-buttons-container {
  display: flex;
  align-items: center;
  gap: 24px;
  grid-column: span 2;
  justify-self: center;
  margin: 2vh;

}

.radio-button {
  display: inline-block;
  position: relative;
  cursor: pointer;
}

.radio-button__input {
  position: absolute;
  opacity: 0;
  width: 0;
  height: 0;
}

.radio-button__label {
  display: inline-block;
  padding-left: 30px;
  margin-bottom: 10px;
  position: relative;
  font-size: 16px;
  color: #fff;
  cursor: pointer;
  transition: all 0.3s cubic-bezier(0.23, 1, 0.320, 1);
}

.radio-button__custom {
  position: absolute;
  top: 50%;
  left: 0;
  transform: translateY(-50%);
  width: 20px;
  height: 20px;
  border-radius: 50%;
  border: 2px solid #555;
  transition: all 0.3s cubic-bezier(0.23, 1, 0.320, 1);
}

.radio-button__input:checked + .radio-button__label .radio-button__custom {
  transform: translateY(-50%) scale(0.9);
  border: 5px solid rgb(141, 109, 255);
  color: rgb(141, 109, 255);
}

.radio-button__input:checked + .radio-button__label {
  color: rgb(141, 109, 255);
}

.radio-button__label:hover .radio-button__custom {
  transform: translateY(-50%) scale(1.2);
  border-color: #4c8bf5;
  box-shadow: 0 0 10px #4c8bf580;
}

#s2{
  grid-column: span 2;
}

button {
 --color: #560bad;
 font-family: inherit;
 display: inline-block;
 width: 8em;
 height: 2.6em;
 line-height: 2.3em;
 margin: 20px;
 position: relative;
 overflow: hidden;
 border: 2px solid var(--color);
 transition: color .5s;
 z-index: 1;
 font-size: 17px;
 border-radius: 20px;
 font-weight: 500;
 color: var(--color);
 justify-self: center;
 background-color: rgba(86, 11, 173, 20%);
}

button:before {
 content: "";
 position: absolute;
 z-index: -1;
 background: var(--color);
 height: 150px;
 width: 200px;
 border-radius: 50%;
}

button:hover {
 color: #fff;
}

button:before {
 top: 100%;
 left: 100%;
 transition: all .7s;
}

button:hover:before {
 top: -30px;
 left: -30px;
}

button:active:before {
 background: #3a0ca3;
 transition: 0s;
}
a{
  justify-self: center;
}
</style>