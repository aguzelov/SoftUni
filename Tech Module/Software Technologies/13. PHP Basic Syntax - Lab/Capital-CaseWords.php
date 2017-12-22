<?php
$words = "";
if (isset($_GET['text'])) {
    $capitalCaseArray = [];
    $delimiters = [" ", ",", "."];
    $array = preg_split("/[, .]/", $_GET["text"], null, PREG_SPLIT_NO_EMPTY);
    for ($i = 0; $i < count($array); $i++) {
        if(count($array[$i]) == ''){
            continue;
        }else if($array[$i] == mb_strtoupper($array[$i])){
            array_push($capitalCaseArray, $array[$i]);
        }
    }
    $words = implode(", ", $capitalCaseArray);
}
?>

<form>
    <textarea rows="10" name="text"><?= $words ?></textarea><br>
    <input type="submit" value="Extract"/>
</form>
