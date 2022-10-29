<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:param name="output-filename" select="'output.txt'" />

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="/*"> 
        <FileSet>
            <FileSetFiles>
                <xsl:for-each select="//Years/Year">
                    <xsl:variable name="year" select="." />
                    <xsl:for-each select="Days/Day">
                        <xsl:variable name="day" select="." />
                        <FileSetFile>
                            <RelativePath>
                                <xsl:value-of select="$year/Name" />
                                <xsl:text>/</xsl:text>
                                <xsl:value-of select="$day/Name" />
                                <xsl:text>/Data.xml</xsl:text>
                            </RelativePath>
                            <FileContents>
                                &lt;<xsl:value-of select="$day/Name" />>
                                    <xsl:copy-of select="$day"/>
                                &lt;/<xsl:value-of select="$day/Name" />>                                
                            </FileContents>
                        </FileSetFile>
                            <FileSetFile>
                    <RelativePath>
                        <xsl:value-of select="$year/Name" />
                        <xsl:text>/</xsl:text>
                        <xsl:value-of select="$day/Name" />
                        <xsl:text>/README.md</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="default"># <xsl:value-of select="$day/Name" />
<xsl:choose>
                        <xsl:when test="normalize-space(Assignment)!=''" xml:space="preserve">
## PART 1:
<xsl:value-of select="Assignment"/>
<xsl:if test="normalize-space(Part2)!=''">## PART 2:
<xsl:value-of select="Part2"/></xsl:if></xsl:when>
                        <xsl:otherwise>
Puzzle not Codeefied yet.</xsl:otherwise>
                    </xsl:choose>
</xsl:element>
                </FileSetFile>
                </xsl:for-each>
                </xsl:for-each>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>
