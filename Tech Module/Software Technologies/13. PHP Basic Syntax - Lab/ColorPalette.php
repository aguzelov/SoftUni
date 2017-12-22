<!DOCTYPE html>
<html>
<head>
    <title>Color Palette</title>
    <style>
        div {
            display: inline-block;
            width: 150px;
            padding: 2px;
            margin: 5px;
        }
    </style>
</head>
<body>
<?php
for ($i = 0; $i <= 255; $i += 51) {
    for ($j = 0; $j <= 255; $j += 51) {
        for ($l = 0; $l <= 255; $l += 51) {
            ?>
            <div style='background: rgb(<?= $i ?>,<?= $j ?>,<?= $l ?>)'>rgb(<?= $i ?>, <?= $j ?>, <?= $l ?>)</div>
            <?php
        }
    }
}
?>
</body>
</html>

