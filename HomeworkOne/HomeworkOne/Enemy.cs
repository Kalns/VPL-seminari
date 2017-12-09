using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace HomeworkOne
{
    class Enemy
    {

        public double positionX { get; set; }
        public double positionY { get; set; }
        public Texture texture { get; set; }
        public double speed { get; set; }
        public int enemyType { get; set; }

        public Enemy(double positionX, double positionY, double speed, int enemyType)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.speed = speed;
            this.enemyType = enemyType;
            texture = new Texture();
        }

        public void drawEnemy(SharpGL.OpenGL gl)
        {
            switch(enemyType)
            {
                case 1:
                    texture.Create(gl, "..\\..\\gem1.png");
                    break;
                case 2:
                    texture.Create(gl, "..\\..\\gem2.png");
                    break;
                case 3:
                    texture.Create(gl, "..\\..\\gem3.png");
                    break;
                case 4:
                    texture.Create(gl, "..\\..\\gem4.png");
                    break;
            }
            gl.PushMatrix();
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -19.0f);
            gl.Begin(OpenGL.GL_QUADS);

            gl.TexCoord(0, 0); gl.Vertex(positionX - 1, positionY);
            gl.TexCoord(1, 0); gl.Vertex(positionX, positionY);
            gl.TexCoord(1, 1); gl.Vertex(positionX, positionY - 1);
            gl.TexCoord(0, 1); gl.Vertex(positionX - 1, positionY - 1);
            gl.End();
            gl.PopMatrix();
        }

        public void moveEnemy()
        {
            if (positionX  + speed < 0)
            {
                positionX = positionX + speed;
            }
            else if (positionX - speed > 0)
            {
                positionX = positionX - speed;
            }

            if (positionY + speed < 0)
            {
                positionY = positionY + speed;
            }
            else if (positionY - speed > 0)
            {
                positionY = positionY - speed;
            }
        }
    }
}
