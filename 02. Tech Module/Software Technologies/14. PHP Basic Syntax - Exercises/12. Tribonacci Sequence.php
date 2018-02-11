<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num"/>
    <input type="submit"/>
</form>
<?php
if (isset($_GET['num'])) {
    $num = intval($_GET['num']);

    $a = 0;
    $b = 1;
    $c = 1;
    $result = 0;
    if ($num == 0) $result = $a;
    if ($num == 1) $result = $b;
    if ($num == 2) $result = $c;

    echo "1 1 ";
    while($num > 2)
    {
        $result = $a + $b + $c;
        $a = $b;
        $b = $c;
        $c = $result;
        $num--;
        echo $result . " ";
    }
}
?>
</body>
</html>