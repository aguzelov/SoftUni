<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>
<?php

for ($i = 0; $i < 9 ; $i++){
    for($j = 0; $j < 5; $j++){
        if($i == 0 || $i == 4 || $i == 8){
            echo "<button style=' background-color: blue'>1</button>";
        }else{
            if($j ==0 && $i < 4){
                echo "<button style=' background-color: blue'>1</button>";

            }else if($j== 4 && $i >4){
                echo "<button style=' background-color: blue'>1</button>";
            }
            else{
                echo "<button>0</button>";
            }
        }
    }
    echo "<br>";
}
?>
</body>
</html>