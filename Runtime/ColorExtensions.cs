using System;
using UnityEngine;
using UnityEngine.UI;

public static class ColorExtensions
{
    public static Color OverrideAlpha(this Color color, float a)
    {
        return new Color(color.r, color.g, color.b, a); //
    }

    //Changes the normal color's alpha of a color block
    public static ColorBlock OverrideAlpha(this ColorBlock colorBlock, float a)
    {
        colorBlock.normalColor = colorBlock.normalColor.OverrideAlpha(a);
        colorBlock.highlightedColor = colorBlock.highlightedColor.OverrideAlpha(a);
        colorBlock.selectedColor = colorBlock.selectedColor.OverrideAlpha(a);
        return colorBlock;
    }

    public static Color Rainbow(float delta, float saturation = 0.5f)
    {
        for (float i = 0; i < 1; i += 0.01f)
        {
            Color c = HSL2RGB(i, saturation, saturation);
        }
        return HSL2RGB(delta, 0.5f, 0.5f);
    }

    // Given H,S,L in range of 0-1

    // Returns a Color (RGB struct) in range of 0-255

    private static Color HSL2RGB(float h, float sl, float l)
    {
        float v;
        float r, g, b;

        r = l;   // default to gray
        g = l;
        b = l;
        v = (l <= 0.5f) ? (l * (1.0f + sl)) : (l + sl - l * sl);

        if (v > 0)
        {
            float m;
            float sv;
            int sextant;
            float fract, vsf, mid1, mid2;

            m = l + l - v;

            sv = (v - m) / v;

            h *= 6.0f;

            sextant = (int)h;

            fract = h - sextant;

            vsf = v * sv * fract;

            mid1 = m + vsf;

            mid2 = v - vsf;

            switch (sextant)
            {
                case 0:
                    r = v;
                    g = mid1;
                    b = m;
                    break;
                case 1:
                    r = mid2;
                    g = v;
                    b = m;
                    break;
                case 2:
                    r = m;
                    g = v;
                    b = mid1;
                    break;
                case 3:
                    r = m;
                    g = mid2;
                    b = v;
                    break;
                case 4:
                    r = mid1;
                    g = m;
                    b = v;
                    break;
                case 5:
                    r = v;
                    g = m;
                    b = mid2;
                    break;
            }
        }

        Color rgb = new Color();
        rgb.r = r;
        rgb.g = g;
        rgb.b = b;
        return rgb;

    }
}
