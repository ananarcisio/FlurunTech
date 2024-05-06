<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Atualizar de alunos</title>
</head>
<body>
<section id="cardcontainer">
  <div class="card">
      <?php
        // Armazenar os dados da URL em variáveis PHP
        $id = $_GET['id'];
        $razaosocial = $_GET['razaosocial'];
        $nomefantasia = $_GET['nomefantasia'];
        $email = $_GET['email'];
        $telefone = $_GET['telefone'];
        $cnpj = $_GET['cnpj'];
        $endereco = $_GET['endereco'];
        $numero = $_GET['numero'];
        $complemento = $_GET['complemento'];
        $bairro = $_GET['bairro'];
        $cidade = $_GET['cidade'];
        $uf = $_GET['uf'];
        $setor = $_GET['setor'];

        // Função para verificar se o sexo é feminino, masculino ou outro
        function isChecked($value, $radioValue) {
            return $value === $radioValue ? 'checked' : '';
        }
      ?>
      <form method="POST" action="update2.php">
        <h1 id="title">ATUALIZAÇÃO DE ALUNOS</h1>
        
        <div class="input">
          <input name="razaosocial" type="text" required="" autocomplete="off" value="<?= $razaosocial ?>">
          <label for="razaosocial">Razão social</label>
        </div>

        <div class="input">
          <input name="nomefantasia" type="text" required="" autocomplete="off" value="<?= $nomefantasia?>">
          <label for="nomefantasia">Nome fantasia</label>
        </div>

        <div class="input">
          <input name="email" type="email" required="" autocomplete="off" value="<?= $email ?>">
          <label for="email">E-mail</label>
        </div>

        <div class="input">
          <input name="telefone" type="text" required="" autocomplete="off" value="<?= $telefone ?>">
          <label for="telefone">Telefone</label>
        </div>

        <div class="input" id="s2">
          <input name="cnpj" type="text" required="" autocomplete="off" value="<?= $cnpj ?>">
          <label for="cnpj">Cnpj</label>
        </div>


        <div class="input" id="s2">
          <input name="endereco" type="text" required="" autocomplete="off" value="<?= $endereco ?>">
          <label for="endereco">Endereço</label>
        </div>

        <div class="input">
          <input name="numero" type="text" required="" autocomplete="off" value="<?= $numero ?>">
          <label for="numero">Numero</label>
        </div>

        <div class="input">
          <input name="complemento" type="text" required="" autocomplete="off" value="<?= $complemento ?>">
          <label for="complemento">Complemento</label>
        </div>

        <div class="input">
          <input name="bairro" type="text" required="" autocomplete="off" value="<?= $bairro ?>">
          <label for="bairro">Bairro</label>
        </div>

        <div class="input">
          <input name="cidade" type="text" required="" autocomplete="off" value="<?= $cidade ?>">
          <label for="cidade">Cidade</label>
        </div>

        <select class="form-select" aria-label="Default select example" name="UF">
          <option selected disabled>UF</option>
          <option value="Rondônia" <?= $uf === 'Rondônia' ? 'selected' : '' ?>>RO</option>
          <option value="Acre" <?= $uf === 'Acre' ? 'selected' : '' ?>>AC</option>
          <option value="Amazonas" <?= $uf === 'Amazonas' ? 'selected' : '' ?>>AM</option>
          <option value="Roraima" <?= $uf === 'Roraima' ? 'selected' : '' ?>>RR</option>
          <option value="Pará" <?= $uf === 'Pará' ? 'selected' : '' ?>>PA</option>
          <option value="Amapá" <?= $uf === 'Amapá' ? 'selected' : '' ?>>AP</option>
          <option value="Tocantins" <?= $uf === 'Tocantins' ? 'selected' : '' ?>>TO</option>
          <option value="Maranhão" <?= $uf === 'Maranhão' ? 'selected' : '' ?>>MA</option>
          <option value="Piauí" <?= $uf === 'Piauí' ? 'selected' : '' ?>>PI</option>
          <option value="Ceará" <?= $uf === 'Ceará' ? 'selected' : '' ?>>CE</option>
          <option value="Rio Grande do Norte" <?= $uf === 'Rio Grande do Norte' ? 'selected' : '' ?>>RN</option>
          <option value="Paraíba" <?= $uf === 'Paraíba' ? 'selected' : '' ?>>PB</option>
          <option value="Pernambuco" <?= $uf === 'Pernambuco' ? 'selected' : '' ?>>PE</option>
          <option value="Alagoas" <?= $uf === 'Alagoas' ? 'selected' : '' ?>>AL</option>
          <option value="Sergipe" <?= $uf === 'Sergipe' ? 'selected' : '' ?>>SE</option>
          <option value="Bahia" <?= $uf === 'Bahia' ? 'selected' : '' ?>>BA</option>
          <option value="Minas Gerais" <?= $uf === 'Minas Gerais' ? 'selected' : '' ?>>MG</option>
          <option value="Espírito Santo" <?= $uf === 'Espírito Santo' ? 'selected' : '' ?>>ES</option>
          <option value="Rio de Janeiro" <?= $uf === 'Rio de Janeiro' ? 'selected' : '' ?>>RJ</option>
          <option value="São Paulo" <?= $uf === 'São Paulo' ? 'selected' : '' ?>>SP</option>
          <option value="Paraná" <?= $uf === 'Paraná' ? 'selected' : '' ?>>PR</option>
          <option value="Santa Catarina" <?= $uf === 'Santa Catarina' ? 'selected' : '' ?>>SC</option>
          <option value="Rio Grande do Sul" <?= $uf === 'Rio Grande do Sul' ? 'selected' : '' ?>>RS</option>
          <option value="Mato Grosso do Sul" <?= $uf === 'Mato Grosso do Sul' ? 'selected' : '' ?>>MS</option>
          <option value="Mato Grosso" <?= $uf === 'Mato Grosso' ? 'selected' : '' ?>>MT</option>
          <option value="Goiás" <?= $uf === 'Goiás' ? 'selected' : '' ?>>GO</option>
          <option value="Distrito Federal" <?= $uf === 'Distrito Federal' ? 'selected' : '' ?>>DF</option>
        </select>

        <select class="form-select" aria-label="Default select example" name="setor">
          <option selected disabled>Setor</option>
          <option value="Alimentação" <?= $setor === 'Alimentação' ? 'selected' : '' ?> >Alimentação</option>
          <option value="Mobiliário" <?= $setor === 'Mobiliário' ? 'selected' : '' ?> >Mobiliário</option>
          <option value="Equipamentos" <?= $setor === 'Equipamentos' ? 'selected' : '' ?> >Equipamentos</option>
          <option value="Recursos humanos" <?= $setor === 'Recursos humanos' ? 'selected' : '' ?> >Recursos humanos</option>
          <option value="Recreação" <?= $setor === 'Recreação' ? 'selected' : '' ?> >Recreação</option>
          <option value="Artístico" <?= $setor === 'Artístico' ? 'selected' : '' ?> >Artístico</option>
          <option value="Mídia social" <?= $setor === 'Mídia social' ? 'selected' : '' ?> >Mídia social</option>
          <option value="Estrutura" <?= $setor === 'Estrutura' ? 'selected' : '' ?> >Estrutura</option>
          <option value="Brindes" <?= $setor === 'Brindes' ? 'selected' : '' ?> >Brindes</option>
          <option value="Decoração" <?= $setor === 'Decoração' ? 'selected' : '' ?> >Decoração</option>
        </select>

        <button type="submit" name="submit"> Atualizar </button>
        <a href="dados.php"> <button  type="button"> Ver dados</button></a>

        <input name="id" type="text" required="" autocomplete="off" value="<?= $id ?>" style="display: none;">
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