var gl;
var VSHADER_SOURCE =
    'attribute vec3 a_Position;\n' +
    'void main(void) {\n' +
    'gl_Position = vec4(a_Position, 1.0);\n' +
    '}\n';
var FSHADER_SOURCE =
    'void main(void) {\n' +
    'gl_FragColor = vec4(0.0, 0.0, 0.0, 1.0);\n' +
    '}\n';

window.onload = () => {
    var canvas = document.getElementById('chart');

    gl = initWebGL(canvas);

    if (!gl) return;

    gl.clearColor(1.0, 1.0, 1.0, 1.0);
    gl.enable(gl.DEPTH_TEST);
    gl.depthFunc(gl.LEQUAL);
    gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);

    initShaders();

    var a_Position = gl.getAttribLocation(shaderProgram, 'a_Position');

    gl.enableVertexAttribArray(a_Position);

    $.getJSON('http://localhost:5000/api/Test/GetCoords', function (data) {
        var coords = data;

        var points_buffer = gl.createBuffer();

        gl.bindBuffer(gl.ARRAY_BUFFER, points_buffer);
        gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(coords), gl.STATIC_DRAW);

        gl.vertexAttribPointer(a_Position, 3, gl.FLOAT, false, 0, 0);

        gl.drawArrays(gl.LINE_STRIP, 0, coords.length / 3);

        console.log(coords.length);

    });
}

function initWebGL(canvas) {
    gl = null;

    try {
        gl = canvas.getContext("webgl") || canvas.getContext("experimental-webgl");
    }
    catch (e) { }

    if (!gl) {
        alert("Unable to initialize WebGL. Your browser may not support it.");
        gl = null;
    }

    return gl;
}

function initShaders() {
    var fragmentShader = getShader(gl, 'fs', FSHADER_SOURCE);
    var vertexShader = getShader(gl, 'vs', VSHADER_SOURCE);

    shaderProgram = gl.createProgram();
    gl.attachShader(shaderProgram, vertexShader);
    gl.attachShader(shaderProgram, fragmentShader);
    gl.linkProgram(shaderProgram);

    gl.useProgram(shaderProgram);
}

function getShader(gl, id, str) {
    var shader;

    if (id == 'vs') {
        shader = gl.createShader(gl.VERTEX_SHADER);
    } else if (id == 'fs') {
        shader = gl.createShader(gl.FRAGMENT_SHADER);
    } else {
        return null;
    }

    gl.shaderSource(shader, str);
    gl.compileShader(shader);

    if (!gl.getShaderParameter(shader, gl.COMPILE_STATUS)) {
        alert('An error occurred compiling the shaders: ' + gl.getShaderInfoLog(shader));
        return null;
    }

    return shader;
}

function initBuffers() {
    var pointsBuffer = gl.createBuffer();
    var coords =
        [
            0.5, 0.1, 0.1,
            -0.5, 0.2, -0.1,
            0.2, -0.1, 0.5
        ];
    gl.bindBuffer(gl.ARRAY_BUFFER, pointsBuffer);
    gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(coords), gl.STATIC_DRAW);
    gl.bindBuffer(gl.ARRAY_BUFFER, null);
}

function drawScene() {
    var a_Position = gl.getAttribLocation(shaderProgram, 'a_Position');
    gl.enableVertexAttribArray(a_Position);

    gl.vertexAttribPointer(a_Position, 3, gl.FLOAT, false, 0, 0);
    gl.drawArrays(gl.LINE_STRIP, 0, 3);
}