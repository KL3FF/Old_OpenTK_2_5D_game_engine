#version 330 core

out vec4 FragColor;
in vec2 TexCoord;

uniform sampler2D ourTexture;
uniform vec2 texStart;  // Startpunkt des Ausschnitts
uniform vec2 texEnd;    // Endpunkt des Ausschnitts

void main()
{
    // Berechne die Texturkoordinaten für den Ausschnitt
    vec2 adjustedTexCoord = texStart + TexCoord * (texEnd - texStart);

    // Abfrage der Textur mit den angepassten Koordinaten
    FragColor = texture(ourTexture, adjustedTexCoord);
}
