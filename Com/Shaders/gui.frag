#version 330 core

out vec4 FragColor;
in vec2 TexCoord;

uniform sampler2D texture0;
uniform vec2 texStart;
uniform vec2 texEnd;

void main()
{
    vec2 uv = mix(texStart, texEnd, TexCoord);
    FragColor = texture(texture0, uv);
}
