<?php
if (isset($_GET['num1']) && isset($_GET['num2'])) {
    $firstNumber = intval($_GET['num1']);
    $secondNumber = intval($_GET['num2']);
    $sum = $firstNumber + $secondNumber;
    echo "$firstNumber + $secondNumber = $sum";
}
?>
<form>
    <div>First Number:</div>
    <input type="number" name="num1"/>
    <div>Second Number</div>
    <input type="number" name="num2"/>
    <div><input type="submit"/></div>
</form>
