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

            if($num == 0){
                echo 0;
            }else if($num == 1){
                echo  1;
            }else{
                $factorial = 1;
                for($i = 1; $i <= $num; $i++){
                    $factorial *= $i;
                }
                echo $factorial;
            }

        }
    ?>
</body>
</html>