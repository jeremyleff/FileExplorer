<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileExplorer.Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Bootstrap 101 Template</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/player.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <h1>Media Player</h1>

    <div>
        <select data-bind="options: services, optionsText: 'name', value: selectedService"></select>
        <select data-bind="options: years, optionsText: 'name', value: selectedYear"></select>
        <select data-bind="options: dates, optionsText: 'name', value: selectedDate"></select>
    </div><br /><br /><br />
    <div>
        <audio id="audio" preload="auto" tabindex="0" controls="" type="audio/mpeg"></audio>
        <ul id="playlist" data-bind="foreach: files">
            <li><a data-bind="text: name, attr: { href: path }"></a>
            </li>
        </ul>
    </div>

    <%--<pre data-bind="text: ko.toJSON($data, null, 2)"></pre>--%>


    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="js/jquery-3.1.1.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    <script src="js/knockout-3.4.0.js"></script>
    <script src="js/models/model.js"></script>
    <script src="js/models/audioPlayer.js"></script>
</body>
</html>
