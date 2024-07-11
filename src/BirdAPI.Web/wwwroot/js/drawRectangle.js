let canvas, ctx;
let isDrawing = false;
let startX, startY;
function initializeCanvas(canvasRef) {
    console.log('initializeCanvas');
    canvas = canvasRef;
    ctx = canvas.getContext('2d');
    console.log('initializeCanvas2');
    canvas.addEventListener('mousedown', startDrawing);
    canvas.addEventListener('mousemove', draw);
    canvas.addEventListener('mouseup', stopDrawing);
}
function startDrawing(e) {
    console.log('initializeCanvas3');
    isDrawing = true;
    startX = e.offsetX;
    startY = e.offsetY;
}
function draw(e) {
    console.log('initializeCanvas4');
    if (!isDrawing) return;
    const rectWidth = e.offsetX - startX;
    const rectHeight = e.offsetY - startY;
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.strokeRect(startX, startY, rectWidth, rectHeight);
}
function stopDrawing() {
    console.log('initializeCanvas5');
    isDrawing = false;
}