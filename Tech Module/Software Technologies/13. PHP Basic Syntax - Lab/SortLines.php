<?php
//$towns = ['Sofia', 'Plovdiv', 'Varna', 'Burgas', 'Pleven', 'Ruse', 'Stara Zagora', 'Veliko Tarnovo', 'Sliven', 'Dobrich'];

if (isset($_GET['lines'])) {
    $towns = $_GET['lines'];
    $towns = explode("\n", $towns);
    asort($towns);
    $sortedLines = implode("\n", $towns);
} else {
    $sortedLines = "";
}
?>
<form>
    <textarea rows="10" name="lines"><?= $sortedLines ?></textarea> <br>
    <input type="submit" value="Sort"/>
</form>
