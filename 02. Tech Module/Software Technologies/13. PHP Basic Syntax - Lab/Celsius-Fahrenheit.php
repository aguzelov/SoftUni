<?php
function calcCel(float $t):float {
    return $t*9/5+32;
}
function calcFah(float $t):float {
    return ($t - 32) * 5/9;
}
$msgAfterCelsius = "";
if(isset($_GET['cel'])){
    $celTemp = floatval($_GET['cel']);
    $fahTemp = calcCel($celTemp);
    $msgAfterCelsius = "$celTemp &deg;C = $fahTemp &deg;F";
}else if(isset($_GET['fah'])){
    $fahTemp = floatval($_GET['fah']);
    $celTemp = calcFah($fahTemp);
    $msgAfterCelsius = "$fahTemp &deg;F = $celTemp &deg;C";
}
?>
<form>
    Celsius: <input type="text" name="cel" />
    <input type="submit" value="Convert" />
    <?= $msgAfterCelsius ?>
</form>
<form>
    Fahrenheit: <input type="text" name="fah" />
    <input type="submit" value="Convert" />
</form>
