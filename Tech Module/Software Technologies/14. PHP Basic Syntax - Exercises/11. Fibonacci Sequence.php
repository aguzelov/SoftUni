<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
<?php
if (isset($_GET['num'])) {
    $num = intval($_GET['num']);

    $first = 1;
    $second = 1;
    $last = 0;
    echo $first . " ";
    echo $second . " ";

    for($i = 1; $i <= $num-2; $i++){
        $last = $first + $second;
        $first = $second;
        $second = $last;
        echo $last . " ";
    }
}
?>
    </body>
</html>