using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManualRot
{

    struct Matrix3x3
    {
        public float m00, m01, m02,
                    m10, m11, m12,
                    m20, m21, m22;

        public static Matrix3x3 Euler(float x, float y, float z)
        {

            Matrix3x3 result = new Matrix3x3();
            Matrix3x3 xMatrix = Rotate(x, "x");
            Matrix3x3 yMatrix = Rotate(y, "y");
            Matrix3x3 zMatrix = Rotate(z, "z");
            result = multiplyAll(xMatrix, yMatrix, zMatrix);

            return result;
        }

        public static Matrix3x3 Euler(Vector3 eulerAngles)
        {
            Matrix3x3 result = Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
            return result;
        }

        public static Matrix3x3 multiplyAll(Matrix3x3 x, Matrix3x3 y, Matrix3x3 z)
        {
            var rezMat = new Matrix3x3();
            rezMat = multiplyTwo(z, y);
            rezMat = multiplyTwo(rezMat, x);
            return rezMat;
        }

        public static Vector3 MatrixVector(Matrix3x3 matrix, Vector3 vector)
        {
            Vector3 result;
            result.x = matrix.m00 * vector.x + matrix.m01 * vector.y + matrix.m02 * vector.z;
            result.y = matrix.m10 * vector.x + matrix.m11 * vector.y + matrix.m12 * vector.z;
            result.z = matrix.m20 * vector.x + matrix.m21 * vector.y + matrix.m22 * vector.z;
            return result;
        }

        public static Matrix3x3 Rotate(float angleInDeg, string axisId)
        {
            Matrix3x3 result = new Matrix3x3();
            if (axisId.Equals("x"))
                result.setXMatrix(angleInDeg);
            if (axisId.Equals("y"))
                result.setYMatrix(angleInDeg);
            if (axisId.Equals("z"))
                result.setZMatrix(angleInDeg);

            return result;
        }

        private void setXMatrix(float xAngle)
        {
            xAngle *= Mathf.Deg2Rad;

            this.m00 = 1;
            this.m01 = 0;
            this.m02 = 0;

            this.m10 = 0;
            this.m11 = Mathf.Cos(xAngle);
            this.m12 = -Mathf.Sin(xAngle);

            this.m20 = 0;
            this.m21 = Mathf.Sin(xAngle);
            this.m22 = Mathf.Cos(xAngle);
        }

        private void setYMatrix(float yAngle)
        {
            yAngle *= Mathf.Deg2Rad;

            this.m00 = Mathf.Cos(yAngle);
            this.m01 = 0;
            this.m02 = Mathf.Sin(yAngle);

            this.m10 = 0;
            this.m11 = 1;
            this.m12 = 0;

            this.m20 = -Mathf.Sin(yAngle);
            this.m21 = 0;
            this.m22 = Mathf.Cos(yAngle);
        }

        private void setZMatrix(float zAngle)
        {
            zAngle *= Mathf.Deg2Rad;

            this.m00 = Mathf.Cos(zAngle);
            this.m01 = -Mathf.Sin(zAngle);
            this.m02 = 0;

            this.m10 = Mathf.Sin(zAngle);
            this.m11 = Mathf.Cos(zAngle);
            this.m12 = 0;

            this.m20 = 0;
            this.m21 = 0;
            this.m22 = 1;
        }

        private static Matrix3x3 multiplyTwo(Matrix3x3 a, Matrix3x3 b)
        {
            var val = new Matrix3x3();

            //Rząd 1
            val.m00 = a.m00 * b.m00 + a.m01 * b.m10 + a.m02 * b.m20;
            val.m01 = a.m00 * b.m01 + a.m01 * b.m11 + a.m02 * b.m21;
            val.m02 = a.m00 * b.m02 + a.m01 * b.m12 + a.m02 * b.m22;

            //Rząd 2
            val.m10 = a.m10 * b.m00 + a.m11 * b.m10 + a.m12 * b.m20;
            val.m11 = a.m10 * b.m01 + a.m11 * b.m11 + a.m12 * b.m21;
            val.m12 = a.m10 * b.m02 + a.m11 * b.m12 + a.m12 * b.m22;

            //Rząd 3
            val.m20 = a.m20 * b.m00 + a.m21 * b.m10 + a.m22 * b.m20;
            val.m21 = a.m20 * b.m01 + a.m21 * b.m11 + a.m22 * b.m21;
            val.m22 = a.m20 * b.m02 + a.m21 * b.m12 + a.m22 * b.m22;

            return val;
        }

    }
}
