<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:param name="output-filename" select="'output.txt'" />
    <xsl:variable name="root" select="/" />

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="/*">
        <FileSet>
            <FileSetFiles>
                <FileSetFile>
                    <RelativePath>
                        <xsl:text>AoCSSoT.xml</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve"><AdventOfCode>
    <Years>
        <xsl:for-each select="//Years/Year">
            <xsl:apply-templates select="." />
        </xsl:for-each>
        <ROOT>
            <xsl:copy-of select="$root"/>
        </ROOT>
    </Years>
</AdventOfCode>
</xsl:element>
                </FileSetFile>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
    <xsl:template match="Year">        
        <xsl:copy>
            <xsl:apply-templates select="*"/>
            <Days>
                <xsl:for-each select="$root//Days/Day[Year=current()/YearId]">
                    <xsl:apply-templates select="."/>
                </xsl:for-each>
            </Days>
        </xsl:copy>
    </xsl:template>
    <xsl:template match="Day">
        <xsl:copy>
            <xsl:apply-templates select="*"/>
        </xsl:copy>
    </xsl:template>
</xsl:stylesheet>
